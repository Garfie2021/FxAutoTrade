unit ApiTestUnit;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ComCtrls, ExtCtrls, Menus, OleServer,
  FxComApiTrader_TLB, ActiveX, StrUtils;

const
  Null_Number   = -MaxInt;

type

  TAPITestForm = class(TForm)
    DataGroupBox: TGroupBox;
    MessageGroupBox: TGroupBox;
    TopPanel: TPanel;
    ConnectButton: TButton;
    DisconnectButton: TButton;
    StatusGroup: TGroupBox;
    StatusPanel: TPanel;
    Splitter1: TSplitter;
    SchemaLabel: TLabel;
    SchemaEdit: TEdit;
    LoginLabel: TLabel;
    LoginEdit: TEdit;
    PasswordLabel: TLabel;
    PasswordEdit: TEdit;
    DataBox: TMemo;
    MsgBox: TMemo;
    IDLabel: TLabel;
    IDEdit: TEdit;
    procedure FormCreate(Sender: TObject);
    procedure ConnectButtonClick(Sender: TObject);
    procedure DisconnectButtonClick(Sender: TObject);
    procedure FxTraderApiStatusChange(ASender: TObject; Status: TOleEnum);
    procedure FxTraderApiPairMessage(ASender: TObject; const Pair: IFxPair;
      MessageType: TOleEnum);
    procedure FxTraderApiAccountMessage(ASender: TObject; const Account: IFxAccount;
      MessageType: TOleEnum);
    procedure FxTraderApiTradeMessage(ASender: TObject; const Trade: IFxTrade;
      MessageType: TOleEnum);
    procedure FxTraderApiOrderMessage(ASender: TObject; const Order: IFxOrder;
      MessageType: TOleEnum);
    procedure FxTraderApiTextMessage(ASender: TObject; const Text: IFxTextMessage);
    procedure FxTraderApiError(ASender: TObject; const Error: IFxError);
    procedure FxTraderApiMarginCallMessage(ASender: TObject;
      const MarginCall: IFxMarginCallMessage);
    procedure FxTraderApiGetClosedTrade(ASender: TObject; const Trade: IFxTrade);
    procedure FxTraderApiRulesChange(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    FxTraderApi: TFxTraderApi;
    FMessageLog: String;
    { Private declarations }
    procedure AddLog(Msg: String);
    procedure ShowTableData;
    procedure AddMessageLog(LogMsg: String);
    procedure ShowStatus(Status: Integer);
    function MsgTypeToStr(MessageType: Integer): String;
    function LogicTypeToStr(LogicType: Integer): String;
    procedure AddMessageLogSynch;
  public
    { Public declarations }
    procedure ClearTables;
  end;

var
  APITestForm: TAPITestForm;


implementation

{$R *.dfm}

function ProcessError(IE: IFxError): Boolean;
var
  ErrType: String;
  ErrMsg: String;
begin
  if IE <> nil then
  begin
    case IE.ErrorType of
      et_Unknown       : ErrType := 'Error: Unknown';
      et_Connection    : ErrType := 'Error: Connection';
      et_DataConvert   : ErrType := 'Error: Data convertion';
      et_DataNotFound  : ErrType := 'Error: Data not found';
      et_Restricted    : ErrType := 'Error: Restricted action';
      et_Parameter     : ErrType := 'Error: Parameter Error';
      et_CallbackFailed: ErrType := 'Error: Callback Failed';
      et_ServerError   : ErrType := 'Error: Server Error';
    end;
    ErrMsg := 'Message: ' + IE.Message;

    if IE.Code <> 0 then
      ErrMsg := ErrMsg + #13#10 + 'Code: ' + IntToStr(IE.Code);

    if IE.Details <> '' then
      ErrMsg := ErrMsg + #13#10 + 'Details: ' + IE.Details;
    MessageDlg(ErrType + #13#10 + ErrMsg, mtError, [mbOK], 0);
    Result := True;
  end
  else
    Result := False;
end;

{ TAPITestForm }

procedure TAPITestForm.FormCreate(Sender: TObject);
begin
  FxTraderApi := TFxTraderApi.Create(Self);
  with FxTraderApi do
  begin
    OnPairMessage := FxTraderApiPairMessage;
    OnAccountMessage := FxTraderApiAccountMessage;
    OnOrderMessage := FxTraderApiOrderMessage;
    OnTradeMessage := FxTraderApiTradeMessage;
    OnRulesChange := FxTraderApiRulesChange;
    OnError := FxTraderApiError;
    OnTextMessage := FxTraderApiTextMessage;
    OnMarginCallMessage := FxTraderApiMarginCallMessage;
    OnStatusChange := FxTraderApiStatusChange;
    OnGetClosedTrade := FxTraderApiGetClosedTrade;
  end;
  Caption := Caption + ' [API ver.' + FxTraderApi.Version + ']';
end;

procedure TAPITestForm.FormDestroy(Sender: TObject);
begin
  if FxTraderApi.Status <> cs_Offline then
    FxTraderApi.Logoff;
end;

procedure TAPITestForm.AddMessageLogSynch;
begin
  with MsgBox do
  begin
    Lines.BeginUpdate;
    try
      while Lines.Count > 100 do
        Lines.Delete(Lines.Count - 1);
      Lines.Insert(0, FMessageLog);
    finally
      Lines.EndUpdate;
    end;
  end;
end;

procedure TAPITestForm.AddMessageLog(LogMsg: String);
begin
  // CallBack could be called from another thread
  // To avoid GUI freezes Synchronize should be used.

  FMessageLog := FormatDateTime('hh:nn:ss ', Now) + LogMsg;
  TThread.Synchronize(nil, AddMessageLogSynch);
end;

procedure TAPITestForm.ShowStatus(Status: Integer);
var
  StatusStr: String;
begin
  case Status of
    cs_Offline: StatusStr := 'OFFLINE';
    cs_Online: StatusStr := 'ONLINE';
    cs_LoadingData: StatusStr := 'LOADING DATA';
    cs_WaitingForConnection: StatusStr := 'WAIT FOR CONNECTION';
  end;
  StatusPanel.Caption := StatusStr;
end;

procedure TAPITestForm.AddLog(Msg: String);
begin
  with DataBox do
  begin
    Lines.Add(Msg);
    Update;
  end;
end;

procedure TAPITestForm.ClearTables;
begin
  DataBox.Clear;
  DataBox.Update;
  MsgBox.Clear;
  MsgBox.Update;
end;

procedure TAPITestForm.ShowTableData;
var
  i: Integer;
  DT: TDateTime;
  IE: IFxError;
  IP: IFxPair;
  IA: IFxAccount;
  IT: IFxTrade;
  IO: IFxOrder;
  IR: IFxRules;
  PL: IFxPairList;
  AL: IFxAccountList;
  OL: IFxOrderList;
  TL: IFxTradeList;
  Interest: double;
begin

  // Rules
  IR := FxTraderApi.Rules;

  AddLog('System rules:');
  AddLog('Company Title: ' + IR.CompanyTitle);
  AddLog('DB Version: ' + IR.DBVersion);
  AddLog('Base Currency: ' + IR.BaseCurrency);
  AddLog('Use Usable Payback: ' + LogicTypeToStr(IR.UseUsablePayback));
  AddLog('...');
  AddLog('');

  // ServerTime
  IE := FxTraderApi.GetServerTime(DT);
  if ProcessError(IE) then Exit;

  AddLog('Server Time: ' + DateTimeToStr(DT));
  AddLog('');

  //Pairs
  AddLog('Pair data:');
  PL := FxTraderApi.Pairs;
  for i := 0 to PL.Count - 1 do
  begin
    IP := PL.Pair[i];
    if Assigned(IP) then
    begin
      AddLog('Pair: ' +
        IP.PairId + ' ' +
        IP.Name + ' ' +
        FloatToStr(IP.BuyRate) + ' ' +
        FloatToStr(IP.SellRate) + ' ...');
    end;
  end;
  AddLog('');

  //Accounts
  AddLog('Account data:');
  AL := FxTraderApi.Accounts;
  for i := 0 to AL.Count - 1 do
  begin
    IA := AL.Account[i];
    if Assigned(IA) then
    begin
      IA.GetInterestOnUsableMargin(Interest);
      AddLog('Account[ ' +
        IA.AccountId + ']: ' +
        //IA.MoneyOwnerId + ' ' +
        IfThen(Interest = Null_Number, 'N/A',
        FloatToStr(Interest)));//+' '+
        // FloatToStr(IA.Balance) + ' ...');
    end;
  end;
  AddLog('');

  //Orders
  AddLog('Order data:');
  OL := FxTraderApi.Orders;
  for i := 0 to OL.Count - 1 do
  begin
    IO := OL.Order[i];
    if Assigned(IO) then
    begin
      AddLog('Order: ' +
        IO.OrderId + ' ' +
        IO.AccountId + ' ' +
        FloatTostr(IO.Rate) + ' ...');
    end;
  end;
  AddLog('');

  //Trades
  AddLog('Trade data:');
  TL := FxTraderApi.Trades;
  for i := 0 to TL.Count - 1 do
  begin
    IT := TL.Trade[i];
    if Assigned(IT) then
    begin
      AddLog('Trade: ' +
        IT.TradeId + ' ' +
        IT.AccountId + ' ' +
        FloatTostr(IT.OpenRate) + ' ...');
    end;
  end;
  AddLog('');

  FxTraderApi.GetClosedTradesAsync('0', '10000', -1, -1, '', '');
end;

procedure TAPITestForm.ConnectButtonClick(Sender: TObject);
var
  IE: IFxError;
begin
  IE := FxTraderApi.Logon(SchemaEdit.Text, LoginEdit.Text, PasswordEdit.Text,'',IDEdit.Text);
  if ProcessError(IE) then Exit;
  ClearTables;
  ShowTableData;
end;


procedure TAPITestForm.DisconnectButtonClick(Sender: TObject);
var
  IE: IFxError;
begin
  IE := FxTraderApi.Logoff;
  ProcessError(IE);
  ClearTables;
end;

procedure TAPITestForm.FxTraderApiStatusChange(ASender: TObject; Status: TOleEnum);
begin
  ShowStatus(Status);
end;

function TAPITestForm.MsgTypeToStr(MessageType: Integer): String;
begin
  case MessageType of
    mt_Add: Result := '[Add]';
    mt_Update: Result := '[Upd]';
    mt_Delete: Result := '[Del]';
    mt_Subscribe: Result := '[+]';
    mt_Unsubscribe: Result := '[-]';
  end;
end;

function TAPITestForm.LogicTypeToStr(LogicType: Integer): String;
begin
  case LogicType of
    lg_True: Result := '[True]';
    lg_False: Result := '[False]';
    lg_Unknown: Result := '[Unknown]';
  end;
end;

procedure TAPITestForm.FxTraderApiPairMessage(ASender: TObject; const Pair: IFxPair;
  MessageType: TOleEnum);
begin
  AddMessageLog(MsgTypeToStr(MessageType) + ' Pair: ' + Pair.Name + ' ' +
    FloatToStr(Pair.BuyRate) + ' ' + FloatToStr(Pair.SellRate) + ' ...');
end;

procedure TAPITestForm.FxTraderApiAccountMessage(ASender: TObject;
  const Account: IFxAccount; MessageType: TOleEnum);
begin
  AddMessageLog(MsgTypeToStr(MessageType) + ' Account_Id:' + Account.AccountId + ' ' +
    'Balance: ' + FloatToStr(Account.Balance) + ' ...');
end;

procedure TAPITestForm.FxTraderApiTradeMessage(ASender: TObject; const Trade: IFxTrade;
  MessageType: TOleEnum);
begin
  AddMessageLog(MsgTypeToStr(MessageType) + ' Trade: ' +
    Trade.TradeId + ' ' + Trade.AccountId + ' ' +
    FloatToStr(Trade.OpenRate) + ' ...');
end;

procedure TAPITestForm.FxTraderApiOrderMessage(ASender: TObject; const Order: IFxOrder;
  MessageType: TOleEnum);
begin
  AddMessageLog(MsgTypeToStr(MessageType) + ' Order: ' +
    Order.OrderId + ' ' + Order.AccountId + ' ' +
    FloatToStr(Order.Rate) + ' ...');

end;

procedure TAPITestForm.FxTraderApiTextMessage(ASender: TObject; const Text: IFxTextMessage);
begin
  AddMessageLog('Text: ' + Text.Sender + ' ' + Text.Text);
end;

procedure TAPITestForm.FxTraderApiError(ASender: TObject; const Error: IFxError);
begin
  AddMessageLog('Error: ' + Error.Message + ' ' + Error.Details + ' ...');
end;

procedure TAPITestForm.FxTraderApiGetClosedTrade(ASender: TObject; const Trade: IFxTrade);
begin
  AddLog('Closed Trade: ' +
    Trade.TradeId + ' ' +
    Trade.AccountId + ' ' +
    FloatTostr(Trade.OpenRate) + ' ...');
end;

procedure TAPITestForm.FxTraderApiMarginCallMessage(ASender: TObject;
  const MarginCall: IFxMarginCallMessage);
begin
  AddMessageLog('Margin Call: ' + MarginCall.AccountId + ' ' +
    MarginCall.MarginLevel + ' ...');
end;

procedure TAPITestForm.FxTraderApiRulesChange(Sender: TObject);
begin
  AddMessageLog('Rules changed');
end;

end.

