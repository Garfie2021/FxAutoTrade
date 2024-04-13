unit FxComApiTrader_TLB;

// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// $Rev: 2392 $
// File generated on 19.03.2014 11:44:49 from Type Library described below.

// ************************************************************************  //
// Type Lib: D:\Delphi\Src\ACTForex\COMAPI\api_com_trader\trunk\Bin\FxComApiTrader.dll (1)
// LIBID: {B9B7019C-2600-4675-9A8B-148212D40400}
// LCID: 0
// Helpfile: 
// HelpString: FxComTraderApi library.
// DepndLst: 
//   (1) v2.0 stdole, (C:\Windows\system32\stdole2.tlb)
// ************************************************************************ //
// *************************************************************************//
// NOTE:                                                                      
// Items guarded by $IFDEF_LIVE_SERVER_AT_DESIGN_TIME are used by properties  
// which return objects that may need to be explicitly created via a function 
// call prior to any access via the property. These items have been disabled  
// in order to prevent accidental use from within the object inspector. You   
// may enable them by defining LIVE_SERVER_AT_DESIGN_TIME or by selectively   
// removing them from the $IFDEF blocks. However, such items must still be    
// programmatically created via a method of the appropriate CoClass before    
// they can be used.                                                          
{$TYPEDADDRESS OFF} // Unit must be compiled without type-checked pointers. 
{$WARN SYMBOL_PLATFORM OFF}
{$WRITEABLECONST ON}
{$VARPROPSETTER ON}
interface

uses Windows, ActiveX, Classes, Graphics, OleServer, StdVCL, Variants;
  

// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_1111                                      
//   CoClasses          : CLASS_1111                                      
//   DISPInterfaces     : DIID_1111                                       
//   Non-DISP interfaces: IID_1111                                        
// *********************************************************************//
const
  // TypeLibrary Major and minor versions
  FxComApiTraderMajorVersion = 2;
  FxComApiTraderMinorVersion = 0;

  LIBID_FxComApiTrader: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40400}';

  IID_IFxTraderApi: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40401}';
  DIID_IFxTraderApiEvents: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40402}';
  CLASS_FxTraderApi: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40403}';
  IID_IFxPair: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40405}';
  IID_IFxAccount: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40406}';
  IID_IFxTrade: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40407}';
  IID_IFxOrder: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40408}';
  IID_IFxRules: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40409}';
  IID_IFxError: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4040A}';
  IID_IFxTextMessage: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4040B}';
  IID_IFxMarginCallMessage: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4040C}';
  IID_IFxPairList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4040D}';
  IID_IFxAccountList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4040E}';
  IID_IFxOrderList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4040F}';
  IID_IFxTradeList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40410}';
  IID_IFxLot: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4041E}';
  IID_IFxLotList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4041F}';
  IID_IFxTick: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40422}';
  IID_IFxTickList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40423}';
  IID_IFxCandle: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40426}';
  IID_IFxCandleList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40427}';
  IID_IFxChartInterval: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4042A}';
  IID_IFxChartIntervalList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4042B}';
  IID_IFxDebugInfo: TGUID = '{5F1BF187-7477-4680-8A3A-88496D3952B7}';
  IID_IFxPairGroup: TGUID = '{63BAD035-8092-40E2-832B-9D0663AA4517}';
  IID_IFxPairGroupList: TGUID = '{870274E2-CE91-4182-9DE9-7AF087678452}';
  CLASS_FxPair: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40412}';
  CLASS_FxAccount: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40413}';
  CLASS_FxTrade: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40414}';
  CLASS_FxOrder: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40415}';
  CLASS_FxRules: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40416}';
  CLASS_FxError: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40417}';
  CLASS_FxTextMessage: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40418}';
  CLASS_FxMarginCallMessage: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40419}';
  CLASS_FxPairList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4041A}';
  CLASS_FxAccountList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4041B}';
  CLASS_FxOrderList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4041C}';
  CLASS_FxTradeList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4041D}';
  CLASS_FxLot: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40420}';
  CLASS_FxLotList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40421}';
  CLASS_FxTick: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40424}';
  CLASS_FxTickList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40425}';
  CLASS_FxCandle: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40428}';
  CLASS_FxCandleList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D40429}';
  CLASS_FxChartInterval: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4042C}';
  CLASS_FxChartIntervalList: TGUID = '{B9B7019C-2600-4675-9A8B-148212D4042D}';
  CLASS_FxDebugInfo: TGUID = '{035D478E-BCD1-4DF6-BEE8-A23DA71D4634}';
  CLASS_FxPairGroup: TGUID = '{F6D66122-3D65-4A5E-B52D-56AE0739CA83}';
  CLASS_FxPairGroupList: TGUID = '{85204830-9E9C-4933-BA11-B6EC87419FC7}';
  IID_IFxTraderApiInt: TGUID = '{FAC7E28D-1F0B-455F-A56A-4668AA86EA57}';
  CLASS_FxTraderApiInt: TGUID = '{4ED11038-E2AB-4290-B013-BFB8E69401EA}';
  IID_IFxTestData: TGUID = '{A0DC25CD-4314-4022-941C-EC6FC89529FD}';
  CLASS_FxTestData: TGUID = '{22CEAC8A-C4B6-46D2-88E6-A0FD4B60E102}';
  IID_IFxDefaultAmountInfo: TGUID = '{1736EBF6-AEFE-487D-88A5-7CD64B976806}';
  CLASS_FxDefaultAmountInfo: TGUID = '{ED652CB5-1654-4F25-B71C-9D5E884CA77F}';
  IID_IFxNonTradingInterval: TGUID = '{980EAC19-F591-49B9-AC98-B12B00EBE8DB}';
  IID_IFxNonTradingIntervalList: TGUID = '{95685731-A559-4AB2-9470-64FDB2E5BC66}';
  CLASS_FxNonTradingInterval: TGUID = '{880859F8-F63F-4767-86F0-387477B0CEDD}';
  CLASS_FxNonTradingIntervalList: TGUID = '{BB596139-EB18-46B3-8901-DC3E2703A862}';

// *********************************************************************//
// Declaration of Enumerations defined in Type Library                    
// *********************************************************************//
// Constants for enum FxBuySell
type
  FxBuySell = TOleEnum;
const
  bs_Buy = $00000000;
  bs_Sell = $00000001;

// Constants for enum FxLogic
type
  FxLogic = TOleEnum;
const
  lg_True = $00000000;
  lg_False = $00000001;
  lg_Unknown = $00000002;

// Constants for enum FxAccountType
type
  FxAccountType = TOleEnum;
const
  at_Dealer = $00000000;
  at_Clearing = $00000001;
  at_Bank = $00000002;
  at_Trade = $00000003;
  at_Test = $00000004;
  at_Group = $00000005;

// Constants for enum FxOrderType
type
  FxOrderType = TOleEnum;
const
  ot_Init = $00000000;
  ot_RejectInit = $00000001;
  ot_Close = $00000002;
  ot_RejectClose = $00000003;
  ot_EntryStop = $00000004;
  ot_EntryLimit = $00000005;
  ot_Stop = $00000006;
  ot_Limit = $00000007;
  ot_Margin = $00000008;
  ot_MinEquity = $00000009;
  ot_InitFailed = $0000000A;
  ot_EntryFailed = $0000000B;
  ot_StopFailed = $0000000C;
  ot_LimitFailed = $0000000D;
  ot_MarginFailed = $0000000E;
  ot_NotApplicable = $0000000F;
  ot_Entry = $00000010;
  ot_CloseFailed = $00000011;
  ot_CloseByMasterTrader = $00000012;

// Constants for enum FxUserType
type
  FxUserType = TOleEnum;
const
  ut_Trader = $00000000;
  ut_Dealer = $00000001;
  ut_System = $00000002;
  ut_Administrator = $00000003;
  ut_Feed = $00000004;
  ut_Performer = $00000005;
  ut_Customer = $00000006;
  ut_TRAdministrator = $00000007;
  ut_MasterTrader = $00000008;

// Constants for enum FxErrorType
type
  FxErrorType = TOleEnum;
const
  et_Unknown = $00000000;
  et_Connection = $00000001;
  et_DataConvert = $00000002;
  et_DataNotFound = $00000003;
  et_Restricted = $00000004;
  et_Parameter = $00000005;
  et_CallbackFailed = $00000006;
  et_ServerError = $00000007;
  et_ReconnectError = $00000008;

// Constants for enum FxConnectionStatus
type
  FxConnectionStatus = TOleEnum;
const
  cs_Offline = $00000000;
  cs_Online = $00000001;
  cs_Connecting = $00000002;
  cs_LoadingData = $00000003;
  cs_WaitingForConnection = $00000004;

// Constants for enum FxMessageType
type
  FxMessageType = TOleEnum;
const
  mt_Add = $00000000;
  mt_Update = $00000001;
  mt_Delete = $00000002;
  mt_Subscribe = $00000003;
  mt_Unsubscribe = $00000004;

// Constants for enum FxStopLimit
type
  FxStopLimit = TOleEnum;
const
  sl_Stop = $00000000;
  sl_Limit = $00000001;

// Constants for enum FxTransactionType
type
  FxTransactionType = TOleEnum;
const
  tt_Unknown = $00000000;
  tt_Adjustment = $00000001;
  tt_DepositWithdraw = $00000002;
  tt_OptionOpened = $00000003;
  tt_OptionClosed = $00000004;
  tt_OptionExpired = $00000005;
  tt_Compensation = $00000006;
  tt_ProfitLoss = $00000007;
  tt_Commission = $00000008;
  tt_Fee = $00000009;
  tt_Interest = $0000000A;
  tt_OvernightFee = $0000000B;
  tt_PairFee = $0000000C;
  tt_Future = $0000000D;
  tt_Dividend = $0000000E;
  tt_FixedCostOpen = $0000000F;
  tt_FixedCostClose = $00000010;
  tt_ZeroAdjust = $00000011;

// Constants for enum FxGroupMode
type
  FxGroupMode = TOleEnum;
const
  gm_Group = $00000000;
  gm_Individual = $00000001;
  gm_Both = $00000002;

// Constants for enum FxDebugInfoType
type
  FxDebugInfoType = TOleEnum;
const
  di_Request = $00000000;
  di_Responce = $00000001;
  di_Message = $00000002;
  di_Error = $00000003;
  di_Info = $00000004;
  di_CallBack = $00000005;
  di_Debug = $00000006;
  di_Feed = $00000007;
  di_CallBackFeed = $00000008;

// Constants for enum FxPairType
type
  FxPairType = TOleEnum;
const
  pt_Forex = $00000000;
  pt_ContractForDiffecence = $00000001;
  pt_Future = $00000002;
  pt_ExchangeTradedFund = $00000003;

// Constants for enum FxCommentsType
type
  FxCommentsType = TOleEnum;
const
  ct_Order = $00000000;
  ct_Trade = $00000001;
  ct_ClosedTrade = $00000002;

type

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
  IFxTraderApi = interface;
  IFxTraderApiDisp = dispinterface;
  IFxTraderApiEvents = dispinterface;
  IFxPair = interface;
  IFxPairDisp = dispinterface;
  IFxAccount = interface;
  IFxAccountDisp = dispinterface;
  IFxTrade = interface;
  IFxTradeDisp = dispinterface;
  IFxOrder = interface;
  IFxOrderDisp = dispinterface;
  IFxRules = interface;
  IFxRulesDisp = dispinterface;
  IFxError = interface;
  IFxErrorDisp = dispinterface;
  IFxTextMessage = interface;
  IFxTextMessageDisp = dispinterface;
  IFxMarginCallMessage = interface;
  IFxMarginCallMessageDisp = dispinterface;
  IFxPairList = interface;
  IFxPairListDisp = dispinterface;
  IFxAccountList = interface;
  IFxAccountListDisp = dispinterface;
  IFxOrderList = interface;
  IFxOrderListDisp = dispinterface;
  IFxTradeList = interface;
  IFxTradeListDisp = dispinterface;
  IFxLot = interface;
  IFxLotDisp = dispinterface;
  IFxLotList = interface;
  IFxLotListDisp = dispinterface;
  IFxTick = interface;
  IFxTickDisp = dispinterface;
  IFxTickList = interface;
  IFxTickListDisp = dispinterface;
  IFxCandle = interface;
  IFxCandleDisp = dispinterface;
  IFxCandleList = interface;
  IFxCandleListDisp = dispinterface;
  IFxChartInterval = interface;
  IFxChartIntervalDisp = dispinterface;
  IFxChartIntervalList = interface;
  IFxChartIntervalListDisp = dispinterface;
  IFxDebugInfo = interface;
  IFxDebugInfoDisp = dispinterface;
  IFxPairGroup = interface;
  IFxPairGroupDisp = dispinterface;
  IFxPairGroupList = interface;
  IFxPairGroupListDisp = dispinterface;
  IFxTraderApiInt = interface;
  IFxTraderApiIntDisp = dispinterface;
  IFxTestData = interface;
  IFxTestDataDisp = dispinterface;
  IFxDefaultAmountInfo = interface;
  IFxDefaultAmountInfoDisp = dispinterface;
  IFxNonTradingInterval = interface;
  IFxNonTradingIntervalDisp = dispinterface;
  IFxNonTradingIntervalList = interface;
  IFxNonTradingIntervalListDisp = dispinterface;

// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
// *********************************************************************//
  FxTraderApi = IFxTraderApi;
  FxPair = IFxPair;
  FxAccount = IFxAccount;
  FxTrade = IFxTrade;
  FxOrder = IFxOrder;
  FxRules = IFxRules;
  FxError = IFxError;
  FxTextMessage = IFxTextMessage;
  FxMarginCallMessage = IFxMarginCallMessage;
  FxPairList = IFxPairList;
  FxAccountList = IFxAccountList;
  FxOrderList = IFxOrderList;
  FxTradeList = IFxTradeList;
  FxLot = IFxLot;
  FxLotList = IFxLotList;
  FxTick = IFxTick;
  FxTickList = IFxTickList;
  FxCandle = IFxCandle;
  FxCandleList = IFxCandleList;
  FxChartInterval = IFxChartInterval;
  FxChartIntervalList = IFxChartIntervalList;
  FxDebugInfo = IFxDebugInfo;
  FxPairGroup = IFxPairGroup;
  FxPairGroupList = IFxPairGroupList;
  FxTraderApiInt = IFxTraderApiInt;
  FxTestData = IFxTestData;
  FxDefaultAmountInfo = IFxDefaultAmountInfo;
  FxNonTradingInterval = IFxNonTradingInterval;
  FxNonTradingIntervalList = IFxNonTradingIntervalList;


// *********************************************************************//
// Interface: IFxTraderApi
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40401}
// *********************************************************************//
  IFxTraderApi = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40401}']
    function Logon(const Schema: WideString; const Login: WideString; const Password: WideString; 
                   const Language: WideString; const ApiID: WideString): IFxError; safecall;
    function Logon2(const Protocol: WideString; const Host: WideString; Port: Integer; 
                    const DBAlias: WideString; const DASPath: WideString; const Login: WideString; 
                    const Password: WideString; const Language: WideString): IFxError; safecall;
    function Logoff: IFxError; safecall;
    function Get_Pairs: IFxPairList; safecall;
    function Get_Accounts: IFxAccountList; safecall;
    function Get_Orders: IFxOrderList; safecall;
    function Get_Trades: IFxTradeList; safecall;
    function Get_Rules: IFxRules; safecall;
    function Get_Status: FxConnectionStatus; safecall;
    function Get_ProxyServer: WideString; safecall;
    procedure Set_ProxyServer(const Value: WideString); safecall;
    function Get_ProxyPort: Integer; safecall;
    procedure Set_ProxyPort(Value: Integer); safecall;
    function Get_ProxyUserName: WideString; safecall;
    procedure Set_ProxyUserName(const Value: WideString); safecall;
    function Get_ProxyPassword: WideString; safecall;
    procedure Set_ProxyPassword(const Value: WideString); safecall;
    function ChangeUserPassword(const Password: WideString): IFxError; safecall;
    function CreateInitOrder(const AccountId: WideString; const GroupId: WideString; 
                             const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                             TraderRange: Double; out InitOrderId: WideString; 
                             const ClientTag: WideString; const Lots: IFxLotList): IFxError; safecall;
    function CreateEntryOrder(StopLimit: FxStopLimit; const AccountId: WideString; 
                              const GroupId: WideString; const PairId: WideString; 
                              LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                              TraderRange: Double; out EntryOrderId: WideString; 
                              const ClientTag: WideString; const Lots: IFxLotList): IFxError; safecall;
    function ChangeStopLimitOnTrade(StopLimit: FxStopLimit; const TradeId: WideString; 
                                    Rate: Double; out StopLimitOrderId: WideString; 
                                    const ClientTag: WideString): IFxError; safecall;
    function ChangeStopLimitOnEntryOrder(StopLimit: FxStopLimit; const OrderId: WideString; 
                                         Rate: Double; out StopLimitOrderId: WideString; 
                                         const ClientTag: WideString): IFxError; safecall;
    function DeleteOrder(const OrderId: WideString): IFxError; safecall;
    function CloseTrade(const TradeId: WideString; TraderRange: Double; LotCount: Double; 
                        out CloseOrderId: WideString; const ClientTag: WideString; 
                        CloseWithHedge: FxLogic; const Lots: IFxLotList): IFxError; safecall;
    function HedgeTrade(const TradeId: WideString; LotCount: Double; out HedgeOrderId: WideString; 
                        const ClientTag: WideString; const Lots: IFxLotList): IFxError; safecall;
    function GetGroupTrades(const GroupTradeId: WideString; out TradeList: IFxTradeList): IFxError; safecall;
    function GetClosedTrades(const FromTradeId: WideString; const ToTradeId: WideString; 
                             FromTime: TDateTime; ToTime: TDateTime; const AccountId: WideString; 
                             const PairId: WideString; out TradeList: IFxTradeList): IFxError; safecall;
    function Get_Version: WideString; safecall;
    function GetServerTime(out DateTime: TDateTime): IFxError; safecall;
    function ChangeEntryOrderRate(const OrderId: WideString; NewRate: Double): IFxError; safecall;
    function GetOrdersHistory(const FromOrderId: WideString; const ToOrderId: WideString; 
                              FromTime: TDateTime; ToTime: TDateTime; const AccountId: WideString; 
                              const PairId: WideString; out OrderList: IFxOrderList): IFxError; safecall;
    function GetAccountsHistory(const FromTransactionId: WideString; 
                                const ToTransactionId: WideString; FromTime: TDateTime; 
                                ToTime: TDateTime; const AccountId: WideString; 
                                const PairId: WideString; out AccountList: IFxAccountList): IFxError; safecall;
    function Get_NewLotList: IFxLotList; safecall;
    function GetMaxLots(const GroupId: WideString; const PairId: WideString; BuySell: FxBuySell; 
                        Rate: Double; const LotList: IFxLotList): IFxError; safecall;
    function AcceptRejectedOrder(const OrderId: WideString): IFxError; safecall;
    procedure SetEntryServer(const Host: WideString; const Port: WideString); safecall;
    function ChangeStopTrailOnTrade(const TradeId: WideString; TrailDistance: Double; 
                                    out StopOrderId: WideString; const ClientTag: WideString): IFxError; safecall;
    function ChangeStopTrailOnEntryOrder(const OrderId: WideString; TrailDistance: Double; 
                                         out StopOrderId: WideString; const ClientTag: WideString): IFxError; safecall;
    function Get_GroupMode: FxGroupMode; safecall;
    procedure Set_GroupMode(Value: FxGroupMode); safecall;
    function GetTickHistory(const PairId: WideString; Count: Integer; FromTime: TDateTime; 
                            ToTime: TDateTime; out TickList: IFxTickList): IFxError; safecall;
    function CreateInitOrder2(const AccountId: WideString; const GroupId: WideString; 
                              const PairId: WideString; Rate: Double; LotCount: Double; 
                              BuySell: FxBuySell; TraderRange: Double; out InitOrderId: WideString; 
                              const ClientTag: WideString; const Lots: IFxLotList): IFxError; safecall;
    function CloseTrade2(const TradeId: WideString; Rate: Double; TraderRange: Double; 
                         LotCount: Double; out CloseOrderId: WideString; 
                         const ClientTag: WideString; CloseWithHedge: FxLogic; 
                         const Lots: IFxLotList): IFxError; safecall;
    function HedgeTrade2(const TradeId: WideString; Rate: Double; LotCount: Double; 
                         out HedgeOrderId: WideString; const ClientTag: WideString; 
                         const Lots: IFxLotList): IFxError; safecall;
    function Get_ChartIntervals: IFxChartIntervalList; safecall;
    function GetCandleHistory(const PairId: WideString; const ChartIntervalId: WideString; 
                              Count: Integer; FromTime: TDateTime; ToTime: TDateTime; 
                              out CandleList: IFxCandleList): IFxError; safecall;
    function Get_UseCompactPair: FxLogic; safecall;
    procedure Set_UseCompactPair(Value: FxLogic); safecall;
    procedure SetDebugLog(const DebugIniFileName: WideString); safecall;
    function GetPairGroups(out Groups: IFxPairGroupList): IFxError; safecall;
    function UpdatePairSubscribtion(const Id: WideString; Subscribe: FxLogic; 
                                    out DependentPairs: IFxPairList): IFxError; safecall;
    function Get_LastError: IFxError; safecall;
    function ChangeOCOLink(const OrderId1: WideString; const OrderId2: WideString): IFxError; safecall;
    function CreateEntryOCOOrders(const AccountId: WideString; const GroupId: WideString; 
                                  const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                                  StopRate: Double; LimitRate: Double; const ClientTag: WideString; 
                                  out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError; safecall;
    function CreateEntryOrderSL(StopLimit: FxStopLimit; const AccountId: WideString; 
                                const GroupId: WideString; const PairId: WideString; 
                                LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                                TraderRange: Double; out EntryOrderId: WideString; 
                                const ClientTag: WideString; const Lots: IFxLotList; 
                                EntryDistance: Double; StopTrailDistance: Double; StopRate: Double; 
                                LimitRate: Double): IFxError; safecall;
    function CheckUser(const Schema: WideString; const Login: WideString; 
                       const Password: WideString; const ApiID: WideString): IFxError; safecall;
    function GetRemovedOrdersHistory(const FromOrderId: WideString; const ToOrderId: WideString; 
                                     FromTime: TDateTime; ToTime: TDateTime; 
                                     FromRemovedTime: TDateTime; ToRemovedTime: TDateTime; 
                                     const AccountId: WideString; const PairId: WideString; 
                                     out OrderList: IFxOrderList): IFxError; safecall;
    function CreateInitOrderSL(const AccountId: WideString; const GroupId: WideString; 
                               const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                               TraderRange: Double; const ClientTag: WideString; 
                               const Lots: IFxLotList; StopTrailDistance: Double; StopRate: Double; 
                               LimitRate: Double; out InitOrderId: WideString): IFxError; safecall;
    function Test: Integer; safecall;
    function GetTestData: IFxTestData; safecall;
    procedure SetTestData(ReconnectTimeOut: Integer); safecall;
    function Get_PairGroups: IFxPairGroupList; safecall;
    function Get_FeedStatus: FxConnectionStatus; safecall;
    function AcceptRejectedOrder2(const OrderId: WideString; Range: Double): IFxError; safecall;
    function ModifyTradingComments(const Id: WideString; const Comments: WideString; 
                                   CommentType: FxCommentsType): IFxError; safecall;
    function RemoveTradingComments(const Id: WideString; CommentType: FxCommentsType): IFxError; safecall;
    function CloseFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                  const Lots: IFxLotList; BuySell: FxBuySell; 
                                  const ClientTag: WideString; TraderRange: Double; 
                                  out OrderId: WideString): IFxError; safecall;
    function CloseFifoTrades(const AccountId: WideString; const PairId: WideString; Lots: Double; 
                             BuySell: FxBuySell; const ClientTag: WideString; TraderRange: Double; 
                             out OrderId: WideString): IFxError; safecall;
    function StopOnFifoTrades(const AccountId: WideString; const PairId: WideString; Rate: Double; 
                              Lots: Double; BuySell: FxBuySell; const ClientTag: WideString; 
                              out OrderId: WideString): IFxError; safecall;
    function LimitOnFifoTrades(const AccountId: WideString; const PairId: WideString; Rate: Double; 
                               Lots: Double; BuySell: FxBuySell; const ClientTag: WideString; 
                               out OrderId: WideString): IFxError; safecall;
    function TrailOnFifoTrades(const AccountId: WideString; const PairId: WideString; 
                               Trail: Double; Lots: Double; BuySell: FxBuySell; 
                               const ClientTag: WideString; out OrderId: WideString): IFxError; safecall;
    function StopOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                   Rate: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                   const ClientTag: WideString; out OrderId: WideString): IFxError; safecall;
    function LimitOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                    Rate: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                    const ClientTag: WideString; out OrderId: WideString): IFxError; safecall;
    function TrailOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                    Trail: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                    const ClientTag: WideString; out OrderId: WideString): IFxError; safecall;
    function ChangeOrderAmount(const OrderId: WideString; LotCount: Double; const Lots: IFxLotList): IFxError; safecall;
    function CreateOCOOrders(const AccountId: WideString; const PairId: WideString; 
                             LotCount: Double; BuySell: FxBuySell; StopRate: Double; 
                             LimitRate: Double; const ClientTag: WideString; 
                             out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError; safecall;
    function CreateGroupOCOOrders(const GroupId: WideString; const PairId: WideString; 
                                  const Lots: IFxLotList; BuySell: FxBuySell; StopRate: Double; 
                                  LimitRate: Double; const ClientTag: WideString; 
                                  out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError; safecall;
    function GetClosedTradesAsync(const FromTradeId: WideString; const ToTradeId: WideString; 
                                  FromTime: TDateTime; ToTime: TDateTime; 
                                  const AccountId: WideString; const PairId: WideString): IFxError; safecall;
    property Pairs: IFxPairList read Get_Pairs;
    property Accounts: IFxAccountList read Get_Accounts;
    property Orders: IFxOrderList read Get_Orders;
    property Trades: IFxTradeList read Get_Trades;
    property Rules: IFxRules read Get_Rules;
    property Status: FxConnectionStatus read Get_Status;
    property ProxyServer: WideString read Get_ProxyServer write Set_ProxyServer;
    property ProxyPort: Integer read Get_ProxyPort write Set_ProxyPort;
    property ProxyUserName: WideString read Get_ProxyUserName write Set_ProxyUserName;
    property ProxyPassword: WideString read Get_ProxyPassword write Set_ProxyPassword;
    property Version: WideString read Get_Version;
    property NewLotList: IFxLotList read Get_NewLotList;
    property GroupMode: FxGroupMode read Get_GroupMode write Set_GroupMode;
    property ChartIntervals: IFxChartIntervalList read Get_ChartIntervals;
    property UseCompactPair: FxLogic read Get_UseCompactPair write Set_UseCompactPair;
    property LastError: IFxError read Get_LastError;
    property PairGroups: IFxPairGroupList read Get_PairGroups;
    property FeedStatus: FxConnectionStatus read Get_FeedStatus;
  end;

// *********************************************************************//
// DispIntf:  IFxTraderApiDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40401}
// *********************************************************************//
  IFxTraderApiDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40401}']
    function Logon(const Schema: WideString; const Login: WideString; const Password: WideString; 
                   const Language: WideString; const ApiID: WideString): IFxError; dispid 201;
    function Logon2(const Protocol: WideString; const Host: WideString; Port: Integer; 
                    const DBAlias: WideString; const DASPath: WideString; const Login: WideString; 
                    const Password: WideString; const Language: WideString): IFxError; dispid 202;
    function Logoff: IFxError; dispid 203;
    property Pairs: IFxPairList readonly dispid 204;
    property Accounts: IFxAccountList readonly dispid 205;
    property Orders: IFxOrderList readonly dispid 206;
    property Trades: IFxTradeList readonly dispid 207;
    property Rules: IFxRules readonly dispid 208;
    property Status: FxConnectionStatus readonly dispid 209;
    property ProxyServer: WideString dispid 210;
    property ProxyPort: Integer dispid 211;
    property ProxyUserName: WideString dispid 212;
    property ProxyPassword: WideString dispid 213;
    function ChangeUserPassword(const Password: WideString): IFxError; dispid 214;
    function CreateInitOrder(const AccountId: WideString; const GroupId: WideString; 
                             const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                             TraderRange: Double; out InitOrderId: WideString; 
                             const ClientTag: WideString; const Lots: IFxLotList): IFxError; dispid 215;
    function CreateEntryOrder(StopLimit: FxStopLimit; const AccountId: WideString; 
                              const GroupId: WideString; const PairId: WideString; 
                              LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                              TraderRange: Double; out EntryOrderId: WideString; 
                              const ClientTag: WideString; const Lots: IFxLotList): IFxError; dispid 216;
    function ChangeStopLimitOnTrade(StopLimit: FxStopLimit; const TradeId: WideString; 
                                    Rate: Double; out StopLimitOrderId: WideString; 
                                    const ClientTag: WideString): IFxError; dispid 217;
    function ChangeStopLimitOnEntryOrder(StopLimit: FxStopLimit; const OrderId: WideString; 
                                         Rate: Double; out StopLimitOrderId: WideString; 
                                         const ClientTag: WideString): IFxError; dispid 218;
    function DeleteOrder(const OrderId: WideString): IFxError; dispid 219;
    function CloseTrade(const TradeId: WideString; TraderRange: Double; LotCount: Double; 
                        out CloseOrderId: WideString; const ClientTag: WideString; 
                        CloseWithHedge: FxLogic; const Lots: IFxLotList): IFxError; dispid 220;
    function HedgeTrade(const TradeId: WideString; LotCount: Double; out HedgeOrderId: WideString; 
                        const ClientTag: WideString; const Lots: IFxLotList): IFxError; dispid 221;
    function GetGroupTrades(const GroupTradeId: WideString; out TradeList: IFxTradeList): IFxError; dispid 222;
    function GetClosedTrades(const FromTradeId: WideString; const ToTradeId: WideString; 
                             FromTime: TDateTime; ToTime: TDateTime; const AccountId: WideString; 
                             const PairId: WideString; out TradeList: IFxTradeList): IFxError; dispid 223;
    property Version: WideString readonly dispid 224;
    function GetServerTime(out DateTime: TDateTime): IFxError; dispid 225;
    function ChangeEntryOrderRate(const OrderId: WideString; NewRate: Double): IFxError; dispid 226;
    function GetOrdersHistory(const FromOrderId: WideString; const ToOrderId: WideString; 
                              FromTime: TDateTime; ToTime: TDateTime; const AccountId: WideString; 
                              const PairId: WideString; out OrderList: IFxOrderList): IFxError; dispid 227;
    function GetAccountsHistory(const FromTransactionId: WideString; 
                                const ToTransactionId: WideString; FromTime: TDateTime; 
                                ToTime: TDateTime; const AccountId: WideString; 
                                const PairId: WideString; out AccountList: IFxAccountList): IFxError; dispid 228;
    property NewLotList: IFxLotList readonly dispid 229;
    function GetMaxLots(const GroupId: WideString; const PairId: WideString; BuySell: FxBuySell; 
                        Rate: Double; const LotList: IFxLotList): IFxError; dispid 230;
    function AcceptRejectedOrder(const OrderId: WideString): IFxError; dispid 231;
    procedure SetEntryServer(const Host: WideString; const Port: WideString); dispid 232;
    function ChangeStopTrailOnTrade(const TradeId: WideString; TrailDistance: Double; 
                                    out StopOrderId: WideString; const ClientTag: WideString): IFxError; dispid 233;
    function ChangeStopTrailOnEntryOrder(const OrderId: WideString; TrailDistance: Double; 
                                         out StopOrderId: WideString; const ClientTag: WideString): IFxError; dispid 234;
    property GroupMode: FxGroupMode dispid 235;
    function GetTickHistory(const PairId: WideString; Count: Integer; FromTime: TDateTime; 
                            ToTime: TDateTime; out TickList: IFxTickList): IFxError; dispid 236;
    function CreateInitOrder2(const AccountId: WideString; const GroupId: WideString; 
                              const PairId: WideString; Rate: Double; LotCount: Double; 
                              BuySell: FxBuySell; TraderRange: Double; out InitOrderId: WideString; 
                              const ClientTag: WideString; const Lots: IFxLotList): IFxError; dispid 237;
    function CloseTrade2(const TradeId: WideString; Rate: Double; TraderRange: Double; 
                         LotCount: Double; out CloseOrderId: WideString; 
                         const ClientTag: WideString; CloseWithHedge: FxLogic; 
                         const Lots: IFxLotList): IFxError; dispid 238;
    function HedgeTrade2(const TradeId: WideString; Rate: Double; LotCount: Double; 
                         out HedgeOrderId: WideString; const ClientTag: WideString; 
                         const Lots: IFxLotList): IFxError; dispid 239;
    property ChartIntervals: IFxChartIntervalList readonly dispid 240;
    function GetCandleHistory(const PairId: WideString; const ChartIntervalId: WideString; 
                              Count: Integer; FromTime: TDateTime; ToTime: TDateTime; 
                              out CandleList: IFxCandleList): IFxError; dispid 241;
    property UseCompactPair: FxLogic dispid 242;
    procedure SetDebugLog(const DebugIniFileName: WideString); dispid 243;
    function GetPairGroups(out Groups: IFxPairGroupList): IFxError; dispid 244;
    function UpdatePairSubscribtion(const Id: WideString; Subscribe: FxLogic; 
                                    out DependentPairs: IFxPairList): IFxError; dispid 245;
    property LastError: IFxError readonly dispid 246;
    function ChangeOCOLink(const OrderId1: WideString; const OrderId2: WideString): IFxError; dispid 247;
    function CreateEntryOCOOrders(const AccountId: WideString; const GroupId: WideString; 
                                  const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                                  StopRate: Double; LimitRate: Double; const ClientTag: WideString; 
                                  out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError; dispid 248;
    function CreateEntryOrderSL(StopLimit: FxStopLimit; const AccountId: WideString; 
                                const GroupId: WideString; const PairId: WideString; 
                                LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                                TraderRange: Double; out EntryOrderId: WideString; 
                                const ClientTag: WideString; const Lots: IFxLotList; 
                                EntryDistance: Double; StopTrailDistance: Double; StopRate: Double; 
                                LimitRate: Double): IFxError; dispid 249;
    function CheckUser(const Schema: WideString; const Login: WideString; 
                       const Password: WideString; const ApiID: WideString): IFxError; dispid 250;
    function GetRemovedOrdersHistory(const FromOrderId: WideString; const ToOrderId: WideString; 
                                     FromTime: TDateTime; ToTime: TDateTime; 
                                     FromRemovedTime: TDateTime; ToRemovedTime: TDateTime; 
                                     const AccountId: WideString; const PairId: WideString; 
                                     out OrderList: IFxOrderList): IFxError; dispid 251;
    function CreateInitOrderSL(const AccountId: WideString; const GroupId: WideString; 
                               const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                               TraderRange: Double; const ClientTag: WideString; 
                               const Lots: IFxLotList; StopTrailDistance: Double; StopRate: Double; 
                               LimitRate: Double; out InitOrderId: WideString): IFxError; dispid 252;
    function Test: Integer; dispid 253;
    function GetTestData: IFxTestData; dispid 255;
    procedure SetTestData(ReconnectTimeOut: Integer); dispid 254;
    property PairGroups: IFxPairGroupList readonly dispid 256;
    property FeedStatus: FxConnectionStatus readonly dispid 257;
    function AcceptRejectedOrder2(const OrderId: WideString; Range: Double): IFxError; dispid 258;
    function ModifyTradingComments(const Id: WideString; const Comments: WideString; 
                                   CommentType: FxCommentsType): IFxError; dispid 259;
    function RemoveTradingComments(const Id: WideString; CommentType: FxCommentsType): IFxError; dispid 260;
    function CloseFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                  const Lots: IFxLotList; BuySell: FxBuySell; 
                                  const ClientTag: WideString; TraderRange: Double; 
                                  out OrderId: WideString): IFxError; dispid 261;
    function CloseFifoTrades(const AccountId: WideString; const PairId: WideString; Lots: Double; 
                             BuySell: FxBuySell; const ClientTag: WideString; TraderRange: Double; 
                             out OrderId: WideString): IFxError; dispid 262;
    function StopOnFifoTrades(const AccountId: WideString; const PairId: WideString; Rate: Double; 
                              Lots: Double; BuySell: FxBuySell; const ClientTag: WideString; 
                              out OrderId: WideString): IFxError; dispid 263;
    function LimitOnFifoTrades(const AccountId: WideString; const PairId: WideString; Rate: Double; 
                               Lots: Double; BuySell: FxBuySell; const ClientTag: WideString; 
                               out OrderId: WideString): IFxError; dispid 264;
    function TrailOnFifoTrades(const AccountId: WideString; const PairId: WideString; 
                               Trail: Double; Lots: Double; BuySell: FxBuySell; 
                               const ClientTag: WideString; out OrderId: WideString): IFxError; dispid 265;
    function StopOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                   Rate: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                   const ClientTag: WideString; out OrderId: WideString): IFxError; dispid 266;
    function LimitOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                    Rate: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                    const ClientTag: WideString; out OrderId: WideString): IFxError; dispid 267;
    function TrailOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                    Trail: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                    const ClientTag: WideString; out OrderId: WideString): IFxError; dispid 268;
    function ChangeOrderAmount(const OrderId: WideString; LotCount: Double; const Lots: IFxLotList): IFxError; dispid 269;
    function CreateOCOOrders(const AccountId: WideString; const PairId: WideString; 
                             LotCount: Double; BuySell: FxBuySell; StopRate: Double; 
                             LimitRate: Double; const ClientTag: WideString; 
                             out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError; dispid 270;
    function CreateGroupOCOOrders(const GroupId: WideString; const PairId: WideString; 
                                  const Lots: IFxLotList; BuySell: FxBuySell; StopRate: Double; 
                                  LimitRate: Double; const ClientTag: WideString; 
                                  out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError; dispid 271;
    function GetClosedTradesAsync(const FromTradeId: WideString; const ToTradeId: WideString; 
                                  FromTime: TDateTime; ToTime: TDateTime; 
                                  const AccountId: WideString; const PairId: WideString): IFxError; dispid 272;
  end;

// *********************************************************************//
// DispIntf:  IFxTraderApiEvents
// Flags:     (4096) Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40402}
// *********************************************************************//
  IFxTraderApiEvents = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40402}']
    procedure OnPairMessage(const Pair: IFxPair; MessageType: FxMessageType); dispid 201;
    procedure OnAccountMessage(const Account: IFxAccount; MessageType: FxMessageType); dispid 202;
    procedure OnOrderMessage(const Order: IFxOrder; MessageType: FxMessageType); dispid 203;
    procedure OnTradeMessage(const Trade: IFxTrade; MessageType: FxMessageType); dispid 204;
    procedure OnRulesChange; dispid 205;
    procedure OnError(const Error: IFxError); dispid 206;
    procedure OnTextMessage(const Text: IFxTextMessage); dispid 207;
    procedure OnMarginCallMessage(const MarginCall: IFxMarginCallMessage); dispid 208;
    procedure OnStatusChange(Status: FxConnectionStatus); dispid 209;
    procedure OnFeedStatusChange(FeedStatus: FxConnectionStatus); dispid 210;
    procedure OnLogoff(const Code: WideString); dispid 211;
    procedure OnGetClosedTrade(const Trade: IFxTrade); dispid 212;
  end;

// *********************************************************************//
// Interface: IFxPair
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40405}
// *********************************************************************//
  IFxPair = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40405}']
    function Get_BuyRate: Double; safecall;
    function Get_SellRate: Double; safecall;
    function Get_LastBuyRate: Double; safecall;
    function Get_LastSellRate: Double; safecall;
    function Get_ExtBid: Double; safecall;
    function Get_ExtAsk: Double; safecall;
    function Get_High: Double; safecall;
    function Get_Low: Double; safecall;
    function Get_Time: TDateTime; safecall;
    function Get_LotSize: Double; safecall;
    function Get_CurContract: WideString; safecall;
    function Get_Multiplier: Double; safecall;
    function Get_MultiplierStep: Integer; safecall;
    function Get_Active: FxLogic; safecall;
    function Get_PipCost: Double; safecall;
    function Get_Name: WideString; safecall;
    function Get_PairId: WideString; safecall;
    function Get_CloseDaySellRate: Double; safecall;
    function Get_NetChange: Double; safecall;
    function Get_PairType: FxPairType; safecall;
    function Get_MaxLotCount: Int64; safecall;
    function Get_ConditionalDistance: Double; safecall;
    function Get_PremiumBuy: Double; safecall;
    function Get_PremiumSell: Double; safecall;
    function Get_Precision: Double; safecall;
    function Get_TradeStep: Double; safecall;
    function Get_MinIncrement: Double; safecall;
    function Get_UsePercentPremium: FxLogic; safecall;
    function Get_Currency1: WideString; safecall;
    function Get_Currency2: WideString; safecall;
    function Get_NonTradingIntervals: IFxNonTradingIntervalList; safecall;
    property BuyRate: Double read Get_BuyRate;
    property SellRate: Double read Get_SellRate;
    property LastBuyRate: Double read Get_LastBuyRate;
    property LastSellRate: Double read Get_LastSellRate;
    property ExtBid: Double read Get_ExtBid;
    property ExtAsk: Double read Get_ExtAsk;
    property High: Double read Get_High;
    property Low: Double read Get_Low;
    property Time: TDateTime read Get_Time;
    property LotSize: Double read Get_LotSize;
    property CurContract: WideString read Get_CurContract;
    property Multiplier: Double read Get_Multiplier;
    property MultiplierStep: Integer read Get_MultiplierStep;
    property Active: FxLogic read Get_Active;
    property PipCost: Double read Get_PipCost;
    property Name: WideString read Get_Name;
    property PairId: WideString read Get_PairId;
    property CloseDaySellRate: Double read Get_CloseDaySellRate;
    property NetChange: Double read Get_NetChange;
    property PairType: FxPairType read Get_PairType;
    property MaxLotCount: Int64 read Get_MaxLotCount;
    property ConditionalDistance: Double read Get_ConditionalDistance;
    property PremiumBuy: Double read Get_PremiumBuy;
    property PremiumSell: Double read Get_PremiumSell;
    property Precision: Double read Get_Precision;
    property TradeStep: Double read Get_TradeStep;
    property MinIncrement: Double read Get_MinIncrement;
    property UsePercentPremium: FxLogic read Get_UsePercentPremium;
    property Currency1: WideString read Get_Currency1;
    property Currency2: WideString read Get_Currency2;
    property NonTradingIntervals: IFxNonTradingIntervalList read Get_NonTradingIntervals;
  end;

// *********************************************************************//
// DispIntf:  IFxPairDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40405}
// *********************************************************************//
  IFxPairDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40405}']
    property BuyRate: Double readonly dispid 201;
    property SellRate: Double readonly dispid 202;
    property LastBuyRate: Double readonly dispid 203;
    property LastSellRate: Double readonly dispid 204;
    property ExtBid: Double readonly dispid 205;
    property ExtAsk: Double readonly dispid 206;
    property High: Double readonly dispid 207;
    property Low: Double readonly dispid 208;
    property Time: TDateTime readonly dispid 209;
    property LotSize: Double readonly dispid 210;
    property CurContract: WideString readonly dispid 211;
    property Multiplier: Double readonly dispid 212;
    property MultiplierStep: Integer readonly dispid 213;
    property Active: FxLogic readonly dispid 214;
    property PipCost: Double readonly dispid 215;
    property Name: WideString readonly dispid 216;
    property PairId: WideString readonly dispid 217;
    property CloseDaySellRate: Double readonly dispid 218;
    property NetChange: Double readonly dispid 219;
    property PairType: FxPairType readonly dispid 220;
    property MaxLotCount: {??Int64}OleVariant readonly dispid 221;
    property ConditionalDistance: Double readonly dispid 222;
    property PremiumBuy: Double readonly dispid 223;
    property PremiumSell: Double readonly dispid 224;
    property Precision: Double readonly dispid 225;
    property TradeStep: Double readonly dispid 226;
    property MinIncrement: Double readonly dispid 227;
    property UsePercentPremium: FxLogic readonly dispid 228;
    property Currency1: WideString readonly dispid 229;
    property Currency2: WideString readonly dispid 230;
    property NonTradingIntervals: IFxNonTradingIntervalList readonly dispid 231;
  end;

// *********************************************************************//
// Interface: IFxAccount
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40406}
// *********************************************************************//
  IFxAccount = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40406}']
    function Get_AccountType: FxAccountType; safecall;
    function Get_Balance: Double; safecall;
    function Get_MoneyOwner: WideString; safecall;
    function Get_UsedMargin: Double; safecall;
    function Get_MarginCall: WideString; safecall;
    function Get_TraderRange: Double; safecall;
    function Get_CustId: WideString; safecall;
    function Get_GroupId: WideString; safecall;
    function Get_Active: FxLogic; safecall;
    function Get_OpenPositions: Double; safecall;
    function Get_Commission: Double; safecall;
    function Get_Fee: Double; safecall;
    function Get_Premium: Double; safecall;
    function Get_NetPL: Double; safecall;
    function Get_Equity: Double; safecall;
    function Get_UsableMargin: Double; safecall;
    function Get_AccountId: WideString; safecall;
    function Get_TransactionId: WideString; safecall;
    function Get_TransactionTime: TDateTime; safecall;
    function Get_TransactionType: FxTransactionType; safecall;
    function Get_MoneyOwnerId: WideString; safecall;
    function Get_GroupAccountId: WideString; safecall;
    function Get_OpenCharge: Double; safecall;
    function Get_CloseCharge: Double; safecall;
    function Get_DefaultAmount: Double; safecall;
    function Get_Income: Double; safecall;
    function Get_Comment: WideString; safecall;
    function Get_DefaultAmountInfo: IFxDefaultAmountInfo; safecall;
    function GetNetPL(out Value: Double): IFxError; safecall;
    function GetUsedMargin(out Value: Double): IFxError; safecall;
    function GetCloseCharge(out Value: Double): IFxError; safecall;
    function GetCommissions(out Value: Double): IFxError; safecall;
    function GetPremium(out Value: Double): IFxError; safecall;
    function GetFee(out Value: Double): IFxError; safecall;
    function GetUsableMargin(out Value: Double): IFxError; safecall;
    function GetEquity(out Value: Double): IFxError; safecall;
    function GetOpenPositionsCount(out Value: Double): IFxError; safecall;
    function GetOpenCharge(out Value: Double): IFxError; safecall;
    function GetInterestOnUsableMargin(out Value: Double): IFxError; safecall;
    property AccountType: FxAccountType read Get_AccountType;
    property Balance: Double read Get_Balance;
    property MoneyOwner: WideString read Get_MoneyOwner;
    property UsedMargin: Double read Get_UsedMargin;
    property MarginCall: WideString read Get_MarginCall;
    property TraderRange: Double read Get_TraderRange;
    property CustId: WideString read Get_CustId;
    property GroupId: WideString read Get_GroupId;
    property Active: FxLogic read Get_Active;
    property OpenPositions: Double read Get_OpenPositions;
    property Commission: Double read Get_Commission;
    property Fee: Double read Get_Fee;
    property Premium: Double read Get_Premium;
    property NetPL: Double read Get_NetPL;
    property Equity: Double read Get_Equity;
    property UsableMargin: Double read Get_UsableMargin;
    property AccountId: WideString read Get_AccountId;
    property TransactionId: WideString read Get_TransactionId;
    property TransactionTime: TDateTime read Get_TransactionTime;
    property TransactionType: FxTransactionType read Get_TransactionType;
    property MoneyOwnerId: WideString read Get_MoneyOwnerId;
    property GroupAccountId: WideString read Get_GroupAccountId;
    property OpenCharge: Double read Get_OpenCharge;
    property CloseCharge: Double read Get_CloseCharge;
    property DefaultAmount: Double read Get_DefaultAmount;
    property Income: Double read Get_Income;
    property Comment: WideString read Get_Comment;
    property DefaultAmountInfo: IFxDefaultAmountInfo read Get_DefaultAmountInfo;
  end;

// *********************************************************************//
// DispIntf:  IFxAccountDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40406}
// *********************************************************************//
  IFxAccountDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40406}']
    property AccountType: FxAccountType readonly dispid 201;
    property Balance: Double readonly dispid 202;
    property MoneyOwner: WideString readonly dispid 203;
    property UsedMargin: Double readonly dispid 204;
    property MarginCall: WideString readonly dispid 205;
    property TraderRange: Double readonly dispid 206;
    property CustId: WideString readonly dispid 208;
    property GroupId: WideString readonly dispid 209;
    property Active: FxLogic readonly dispid 210;
    property OpenPositions: Double readonly dispid 211;
    property Commission: Double readonly dispid 212;
    property Fee: Double readonly dispid 213;
    property Premium: Double readonly dispid 214;
    property NetPL: Double readonly dispid 215;
    property Equity: Double readonly dispid 216;
    property UsableMargin: Double readonly dispid 217;
    property AccountId: WideString readonly dispid 218;
    property TransactionId: WideString readonly dispid 219;
    property TransactionTime: TDateTime readonly dispid 220;
    property TransactionType: FxTransactionType readonly dispid 221;
    property MoneyOwnerId: WideString readonly dispid 222;
    property GroupAccountId: WideString readonly dispid 223;
    property OpenCharge: Double readonly dispid 224;
    property CloseCharge: Double readonly dispid 225;
    property DefaultAmount: Double readonly dispid 226;
    property Income: Double readonly dispid 227;
    property Comment: WideString readonly dispid 228;
    property DefaultAmountInfo: IFxDefaultAmountInfo readonly dispid 229;
    function GetNetPL(out Value: Double): IFxError; dispid 231;
    function GetUsedMargin(out Value: Double): IFxError; dispid 232;
    function GetCloseCharge(out Value: Double): IFxError; dispid 233;
    function GetCommissions(out Value: Double): IFxError; dispid 234;
    function GetPremium(out Value: Double): IFxError; dispid 235;
    function GetFee(out Value: Double): IFxError; dispid 236;
    function GetUsableMargin(out Value: Double): IFxError; dispid 237;
    function GetEquity(out Value: Double): IFxError; dispid 238;
    function GetOpenPositionsCount(out Value: Double): IFxError; dispid 239;
    function GetOpenCharge(out Value: Double): IFxError; dispid 240;
    function GetInterestOnUsableMargin(out Value: Double): IFxError; dispid 230;
  end;

// *********************************************************************//
// Interface: IFxTrade
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40407}
// *********************************************************************//
  IFxTrade = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40407}']
    function Get_AccountId: WideString; safecall;
    function Get_AccountType: FxAccountType; safecall;
    function Get_PairId: WideString; safecall;
    function Get_Amount: Double; safecall;
    function Get_BuySell: FxBuySell; safecall;
    function Get_OpenRate: Double; safecall;
    function Get_OpenTime: TDateTime; safecall;
    function Get_Commission: Double; safecall;
    function Get_Fee: Double; safecall;
    function Get_Premium: Double; safecall;
    function Get_MoneyOwner: WideString; safecall;
    function Get_ParentOrderId: WideString; safecall;
    function Get_GroupId: WideString; safecall;
    function Get_StopRate: Double; safecall;
    function Get_LimitRate: Double; safecall;
    function Get_NetPL: Double; safecall;
    function Get_BEP: Double; safecall;
    function Get_CloseRate: Double; safecall;
    function Get_CloseTime: TDateTime; safecall;
    function Get_CloseOrderId: WideString; safecall;
    function Get_ParentTradeId: WideString; safecall;
    function Get_TradeId: WideString; safecall;
    function Get_GroupTradeId: WideString; safecall;
    function Get_TrailDistance: Double; safecall;
    function Get_PairName: WideString; safecall;
    function Get_ClientTag: WideString; safecall;
    function GetBtid(out Value: WideString): FxLogic; safecall;
    function Get_OpenCharge: Double; safecall;
    function Get_CloseCharge: Double; safecall;
    function Get_StopOrder: IFxOrder; safecall;
    function Get_LimitOrder: IFxOrder; safecall;
    function Get_NfaFee: Double; safecall;
    function Get_Reason: FxOrderType; safecall;
    function Get_NotionalCloseCrossRate: Double; safecall;
    function Get_NotionalOpenCrossRate: Double; safecall;
    function GetOriginalTradeID(out Value: WideString): FxLogic; safecall;
    function GetComments(out Value: WideString): FxLogic; safecall;
    function GetNetPL(out Value: Double): IFxError; safecall;
    function GetTradeCloseCharge(out Value: Double): IFxError; safecall;
    property AccountId: WideString read Get_AccountId;
    property AccountType: FxAccountType read Get_AccountType;
    property PairId: WideString read Get_PairId;
    property Amount: Double read Get_Amount;
    property BuySell: FxBuySell read Get_BuySell;
    property OpenRate: Double read Get_OpenRate;
    property OpenTime: TDateTime read Get_OpenTime;
    property Commission: Double read Get_Commission;
    property Fee: Double read Get_Fee;
    property Premium: Double read Get_Premium;
    property MoneyOwner: WideString read Get_MoneyOwner;
    property ParentOrderId: WideString read Get_ParentOrderId;
    property GroupId: WideString read Get_GroupId;
    property StopRate: Double read Get_StopRate;
    property LimitRate: Double read Get_LimitRate;
    property NetPL: Double read Get_NetPL;
    property BEP: Double read Get_BEP;
    property CloseRate: Double read Get_CloseRate;
    property CloseTime: TDateTime read Get_CloseTime;
    property CloseOrderId: WideString read Get_CloseOrderId;
    property ParentTradeId: WideString read Get_ParentTradeId;
    property TradeId: WideString read Get_TradeId;
    property GroupTradeId: WideString read Get_GroupTradeId;
    property TrailDistance: Double read Get_TrailDistance;
    property PairName: WideString read Get_PairName;
    property ClientTag: WideString read Get_ClientTag;
    property OpenCharge: Double read Get_OpenCharge;
    property CloseCharge: Double read Get_CloseCharge;
    property StopOrder: IFxOrder read Get_StopOrder;
    property LimitOrder: IFxOrder read Get_LimitOrder;
    property NfaFee: Double read Get_NfaFee;
    property Reason: FxOrderType read Get_Reason;
    property NotionalCloseCrossRate: Double read Get_NotionalCloseCrossRate;
    property NotionalOpenCrossRate: Double read Get_NotionalOpenCrossRate;
  end;

// *********************************************************************//
// DispIntf:  IFxTradeDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40407}
// *********************************************************************//
  IFxTradeDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40407}']
    property AccountId: WideString readonly dispid 201;
    property AccountType: FxAccountType readonly dispid 202;
    property PairId: WideString readonly dispid 203;
    property Amount: Double readonly dispid 204;
    property BuySell: FxBuySell readonly dispid 205;
    property OpenRate: Double readonly dispid 206;
    property OpenTime: TDateTime readonly dispid 207;
    property Commission: Double readonly dispid 208;
    property Fee: Double readonly dispid 209;
    property Premium: Double readonly dispid 210;
    property MoneyOwner: WideString readonly dispid 211;
    property ParentOrderId: WideString readonly dispid 212;
    property GroupId: WideString readonly dispid 213;
    property StopRate: Double readonly dispid 214;
    property LimitRate: Double readonly dispid 215;
    property NetPL: Double readonly dispid 216;
    property BEP: Double readonly dispid 217;
    property CloseRate: Double readonly dispid 218;
    property CloseTime: TDateTime readonly dispid 219;
    property CloseOrderId: WideString readonly dispid 220;
    property ParentTradeId: WideString readonly dispid 221;
    property TradeId: WideString readonly dispid 222;
    property GroupTradeId: WideString readonly dispid 223;
    property TrailDistance: Double readonly dispid 224;
    property PairName: WideString readonly dispid 225;
    property ClientTag: WideString readonly dispid 226;
    function GetBtid(out Value: WideString): FxLogic; dispid 227;
    property OpenCharge: Double readonly dispid 228;
    property CloseCharge: Double readonly dispid 229;
    property StopOrder: IFxOrder readonly dispid 230;
    property LimitOrder: IFxOrder readonly dispid 231;
    property NfaFee: Double readonly dispid 232;
    property Reason: FxOrderType readonly dispid 233;
    property NotionalCloseCrossRate: Double readonly dispid 234;
    property NotionalOpenCrossRate: Double readonly dispid 235;
    function GetOriginalTradeID(out Value: WideString): FxLogic; dispid 236;
    function GetComments(out Value: WideString): FxLogic; dispid 237;
    function GetNetPL(out Value: Double): IFxError; dispid 238;
    function GetTradeCloseCharge(out Value: Double): IFxError; dispid 239;
  end;

// *********************************************************************//
// Interface: IFxOrder
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40408}
// *********************************************************************//
  IFxOrder = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40408}']
    function Get_AccountId: WideString; safecall;
    function Get_PairId: WideString; safecall;
    function Get_Amount: Double; safecall;
    function Get_BuySell: FxBuySell; safecall;
    function Get_Time: TDateTime; safecall;
    function Get_OrderType: FxOrderType; safecall;
    function Get_TradeId: WideString; safecall;
    function Get_Condition: FxLogic; safecall;
    function Get_MoneyOwner: WideString; safecall;
    function Get_Initiator: FxUserType; safecall;
    function Get_StopRate: Double; safecall;
    function Get_LimitRate: Double; safecall;
    function Get_CloseRate: Double; safecall;
    function Get_Rate: Double; safecall;
    function Get_OrderId: WideString; safecall;
    function Get_ClientTag: WideString; safecall;
    function Get_TrailDistance: Double; safecall;
    function Get_OCO_Id: WideString; safecall;
    function GetReason(out Value: WideString): FxLogic; safecall;
    function GetBtid(out Value: WideString): FxLogic; safecall;
    function Get_BuyRate: Double; safecall;
    function Get_SellRate: Double; safecall;
    function GetComments(out Value: WideString): FxLogic; safecall;
    property AccountId: WideString read Get_AccountId;
    property PairId: WideString read Get_PairId;
    property Amount: Double read Get_Amount;
    property BuySell: FxBuySell read Get_BuySell;
    property Time: TDateTime read Get_Time;
    property OrderType: FxOrderType read Get_OrderType;
    property TradeId: WideString read Get_TradeId;
    property Condition: FxLogic read Get_Condition;
    property MoneyOwner: WideString read Get_MoneyOwner;
    property Initiator: FxUserType read Get_Initiator;
    property StopRate: Double read Get_StopRate;
    property LimitRate: Double read Get_LimitRate;
    property CloseRate: Double read Get_CloseRate;
    property Rate: Double read Get_Rate;
    property OrderId: WideString read Get_OrderId;
    property ClientTag: WideString read Get_ClientTag;
    property TrailDistance: Double read Get_TrailDistance;
    property OCO_Id: WideString read Get_OCO_Id;
    property BuyRate: Double read Get_BuyRate;
    property SellRate: Double read Get_SellRate;
  end;

// *********************************************************************//
// DispIntf:  IFxOrderDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40408}
// *********************************************************************//
  IFxOrderDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40408}']
    property AccountId: WideString readonly dispid 201;
    property PairId: WideString readonly dispid 202;
    property Amount: Double readonly dispid 203;
    property BuySell: FxBuySell readonly dispid 204;
    property Time: TDateTime readonly dispid 206;
    property OrderType: FxOrderType readonly dispid 207;
    property TradeId: WideString readonly dispid 208;
    property Condition: FxLogic readonly dispid 209;
    property MoneyOwner: WideString readonly dispid 210;
    property Initiator: FxUserType readonly dispid 211;
    property StopRate: Double readonly dispid 212;
    property LimitRate: Double readonly dispid 213;
    property CloseRate: Double readonly dispid 214;
    property Rate: Double readonly dispid 205;
    property OrderId: WideString readonly dispid 215;
    property ClientTag: WideString readonly dispid 216;
    property TrailDistance: Double readonly dispid 217;
    property OCO_Id: WideString readonly dispid 218;
    function GetReason(out Value: WideString): FxLogic; dispid 219;
    function GetBtid(out Value: WideString): FxLogic; dispid 220;
    property BuyRate: Double readonly dispid 221;
    property SellRate: Double readonly dispid 222;
    function GetComments(out Value: WideString): FxLogic; dispid 223;
  end;

// *********************************************************************//
// Interface: IFxRules
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40409}
// *********************************************************************//
  IFxRules = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40409}']
    function Get_DBVersion: WideString; safecall;
    function Get_CompanyTitle: WideString; safecall;
    function Get_BaseCurrency: WideString; safecall;
    function Get_CurrencyDecimalDigits: Integer; safecall;
    function Get_MarketIsOpen: FxLogic; safecall;
    function Get_AllowHedging: Integer; safecall;
    function Get_Count: Integer; safecall;
    function GetName(Index: Integer; out Value: WideString): FxLogic; safecall;
    function GetValue(Index: Integer; out Value: WideString): FxLogic; safecall;
    function GetValueByName(const Index: WideString; out Value: WideString): FxLogic; safecall;
    function Get_ChartServerURL: WideString; safecall;
    function Get_UseUsablePayback: FxLogic; safecall;
    property DBVersion: WideString read Get_DBVersion;
    property CompanyTitle: WideString read Get_CompanyTitle;
    property BaseCurrency: WideString read Get_BaseCurrency;
    property CurrencyDecimalDigits: Integer read Get_CurrencyDecimalDigits;
    property MarketIsOpen: FxLogic read Get_MarketIsOpen;
    property AllowHedging: Integer read Get_AllowHedging;
    property Count: Integer read Get_Count;
    property ChartServerURL: WideString read Get_ChartServerURL;
    property UseUsablePayback: FxLogic read Get_UseUsablePayback;
  end;

// *********************************************************************//
// DispIntf:  IFxRulesDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40409}
// *********************************************************************//
  IFxRulesDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40409}']
    property DBVersion: WideString readonly dispid 301;
    property CompanyTitle: WideString readonly dispid 302;
    property BaseCurrency: WideString readonly dispid 303;
    property CurrencyDecimalDigits: Integer readonly dispid 304;
    property MarketIsOpen: FxLogic readonly dispid 305;
    property AllowHedging: Integer readonly dispid 306;
    property Count: Integer readonly dispid 201;
    function GetName(Index: Integer; out Value: WideString): FxLogic; dispid 205;
    function GetValue(Index: Integer; out Value: WideString): FxLogic; dispid 206;
    function GetValueByName(const Index: WideString; out Value: WideString): FxLogic; dispid 207;
    property ChartServerURL: WideString readonly dispid 202;
    property UseUsablePayback: FxLogic readonly dispid 203;
  end;

// *********************************************************************//
// Interface: IFxError
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040A}
// *********************************************************************//
  IFxError = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4040A}']
    function Get_Message: WideString; safecall;
    function Get_Details: WideString; safecall;
    function Get_ErrorType: FxErrorType; safecall;
    function Get_CallStack: WideString; safecall;
    function Get_Code: Integer; safecall;
    property Message: WideString read Get_Message;
    property Details: WideString read Get_Details;
    property ErrorType: FxErrorType read Get_ErrorType;
    property CallStack: WideString read Get_CallStack;
    property Code: Integer read Get_Code;
  end;

// *********************************************************************//
// DispIntf:  IFxErrorDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040A}
// *********************************************************************//
  IFxErrorDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4040A}']
    property Message: WideString readonly dispid 301;
    property Details: WideString readonly dispid 302;
    property ErrorType: FxErrorType readonly dispid 303;
    property CallStack: WideString readonly dispid 304;
    property Code: Integer readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxTextMessage
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040B}
// *********************************************************************//
  IFxTextMessage = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4040B}']
    function Get_Sender: WideString; safecall;
    function Get_Text: WideString; safecall;
    property Sender: WideString read Get_Sender;
    property Text: WideString read Get_Text;
  end;

// *********************************************************************//
// DispIntf:  IFxTextMessageDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040B}
// *********************************************************************//
  IFxTextMessageDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4040B}']
    property Sender: WideString readonly dispid 301;
    property Text: WideString readonly dispid 302;
  end;

// *********************************************************************//
// Interface: IFxMarginCallMessage
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040C}
// *********************************************************************//
  IFxMarginCallMessage = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4040C}']
    function Get_AccountId: WideString; safecall;
    function Get_MarginLevel: WideString; safecall;
    function Get_MarginTime: TDateTime; safecall;
    function Get_MagrinNumber: Integer; safecall;
    property AccountId: WideString read Get_AccountId;
    property MarginLevel: WideString read Get_MarginLevel;
    property MarginTime: TDateTime read Get_MarginTime;
    property MagrinNumber: Integer read Get_MagrinNumber;
  end;

// *********************************************************************//
// DispIntf:  IFxMarginCallMessageDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040C}
// *********************************************************************//
  IFxMarginCallMessageDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4040C}']
    property AccountId: WideString readonly dispid 301;
    property MarginLevel: WideString readonly dispid 302;
    property MarginTime: TDateTime readonly dispid 303;
    property MagrinNumber: Integer readonly dispid 304;
  end;

// *********************************************************************//
// Interface: IFxPairList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040D}
// *********************************************************************//
  IFxPairList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4040D}']
    function Get_Pair(Index: Integer): IFxPair; safecall;
    function Get_PairById(const Id: WideString): IFxPair; safecall;
    function Get_Count: Integer; safecall;
    property Pair[Index: Integer]: IFxPair read Get_Pair;
    property PairById[const Id: WideString]: IFxPair read Get_PairById;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxPairListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040D}
// *********************************************************************//
  IFxPairListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4040D}']
    property Pair[Index: Integer]: IFxPair readonly dispid 301;
    property PairById[const Id: WideString]: IFxPair readonly dispid 302;
    property Count: Integer readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxAccountList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040E}
// *********************************************************************//
  IFxAccountList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4040E}']
    function Get_Account(Index: Integer): IFxAccount; safecall;
    function Get_AccountById(const Id: WideString): IFxAccount; safecall;
    function Get_Count: Integer; safecall;
    property Account[Index: Integer]: IFxAccount read Get_Account;
    property AccountById[const Id: WideString]: IFxAccount read Get_AccountById;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxAccountListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040E}
// *********************************************************************//
  IFxAccountListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4040E}']
    property Account[Index: Integer]: IFxAccount readonly dispid 301;
    property AccountById[const Id: WideString]: IFxAccount readonly dispid 302;
    property Count: Integer readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxOrderList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040F}
// *********************************************************************//
  IFxOrderList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4040F}']
    function Get_Order(Index: Integer): IFxOrder; safecall;
    function Get_OrderById(const Id: WideString): IFxOrder; safecall;
    function Get_Count: Integer; safecall;
    property Order[Index: Integer]: IFxOrder read Get_Order;
    property OrderById[const Id: WideString]: IFxOrder read Get_OrderById;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxOrderListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4040F}
// *********************************************************************//
  IFxOrderListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4040F}']
    property Order[Index: Integer]: IFxOrder readonly dispid 301;
    property OrderById[const Id: WideString]: IFxOrder readonly dispid 302;
    property Count: Integer readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxTradeList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40410}
// *********************************************************************//
  IFxTradeList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40410}']
    function Get_Trade(Index: Integer): IFxTrade; safecall;
    function Get_TradeById(const Id: WideString): IFxTrade; safecall;
    function Get_Count: Integer; safecall;
    property Trade[Index: Integer]: IFxTrade read Get_Trade;
    property TradeById[const Id: WideString]: IFxTrade read Get_TradeById;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxTradeListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40410}
// *********************************************************************//
  IFxTradeListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40410}']
    property Trade[Index: Integer]: IFxTrade readonly dispid 301;
    property TradeById[const Id: WideString]: IFxTrade readonly dispid 302;
    property Count: Integer readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxLot
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4041E}
// *********************************************************************//
  IFxLot = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4041E}']
    function Get_MaxLotCount: Double; safecall;
    procedure Set_MaxLotCount(Value: Double); safecall;
    function Get_LotCount: Double; safecall;
    procedure Set_LotCount(Value: Double); safecall;
    function Get_AccountId: WideString; safecall;
    procedure Set_AccountId(const Value: WideString); safecall;
    property MaxLotCount: Double read Get_MaxLotCount write Set_MaxLotCount;
    property LotCount: Double read Get_LotCount write Set_LotCount;
    property AccountId: WideString read Get_AccountId write Set_AccountId;
  end;

// *********************************************************************//
// DispIntf:  IFxLotDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4041E}
// *********************************************************************//
  IFxLotDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4041E}']
    property MaxLotCount: Double dispid 201;
    property LotCount: Double dispid 202;
    property AccountId: WideString dispid 203;
  end;

// *********************************************************************//
// Interface: IFxLotList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4041F}
// *********************************************************************//
  IFxLotList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4041F}']
    function Get_Lot(Index: Integer): IFxLot; safecall;
    function Get_Count: Integer; safecall;
    procedure Update(const AccountId: WideString; LotCount: Double; MaxLotCount: Double); safecall;
    procedure Delete(Index: Integer); safecall;
    property Lot[Index: Integer]: IFxLot read Get_Lot;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxLotListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4041F}
// *********************************************************************//
  IFxLotListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4041F}']
    property Lot[Index: Integer]: IFxLot readonly dispid 201;
    property Count: Integer readonly dispid 202;
    procedure Update(const AccountId: WideString; LotCount: Double; MaxLotCount: Double); dispid 203;
    procedure Delete(Index: Integer); dispid 204;
  end;

// *********************************************************************//
// Interface: IFxTick
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40422}
// *********************************************************************//
  IFxTick = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40422}']
    function Get_Rate: Double; safecall;
    function Get_Time: TDateTime; safecall;
    property Rate: Double read Get_Rate;
    property Time: TDateTime read Get_Time;
  end;

// *********************************************************************//
// DispIntf:  IFxTickDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40422}
// *********************************************************************//
  IFxTickDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40422}']
    property Rate: Double readonly dispid 201;
    property Time: TDateTime readonly dispid 202;
  end;

// *********************************************************************//
// Interface: IFxTickList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40423}
// *********************************************************************//
  IFxTickList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40423}']
    function Get_Tick(Index: Integer): IFxTick; safecall;
    function Get_Count: Integer; safecall;
    property Tick[Index: Integer]: IFxTick read Get_Tick;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxTickListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40423}
// *********************************************************************//
  IFxTickListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40423}']
    property Tick[Index: Integer]: IFxTick readonly dispid 201;
    property Count: Integer readonly dispid 202;
  end;

// *********************************************************************//
// Interface: IFxCandle
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40426}
// *********************************************************************//
  IFxCandle = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40426}']
    function Get_Time: TDateTime; safecall;
    function Get_Open: Double; safecall;
    function Get_Close: Double; safecall;
    function Get_High: Double; safecall;
    function Get_Low: Double; safecall;
    property Time: TDateTime read Get_Time;
    property Open: Double read Get_Open;
    property Close: Double read Get_Close;
    property High: Double read Get_High;
    property Low: Double read Get_Low;
  end;

// *********************************************************************//
// DispIntf:  IFxCandleDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40426}
// *********************************************************************//
  IFxCandleDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40426}']
    property Time: TDateTime readonly dispid 201;
    property Open: Double readonly dispid 202;
    property Close: Double readonly dispid 203;
    property High: Double readonly dispid 204;
    property Low: Double readonly dispid 205;
  end;

// *********************************************************************//
// Interface: IFxCandleList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40427}
// *********************************************************************//
  IFxCandleList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D40427}']
    function Get_Candle(Index: Integer): IFxCandle; safecall;
    function Get_Count: Integer; safecall;
    property Candle[Index: Integer]: IFxCandle read Get_Candle;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxCandleListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D40427}
// *********************************************************************//
  IFxCandleListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D40427}']
    property Candle[Index: Integer]: IFxCandle readonly dispid 201;
    property Count: Integer readonly dispid 202;
  end;

// *********************************************************************//
// Interface: IFxChartInterval
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4042A}
// *********************************************************************//
  IFxChartInterval = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4042A}']
    function Get_Id: WideString; safecall;
    function Get_Duration: Integer; safecall;
    property Id: WideString read Get_Id;
    property Duration: Integer read Get_Duration;
  end;

// *********************************************************************//
// DispIntf:  IFxChartIntervalDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4042A}
// *********************************************************************//
  IFxChartIntervalDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4042A}']
    property Id: WideString readonly dispid 201;
    property Duration: Integer readonly dispid 202;
  end;

// *********************************************************************//
// Interface: IFxChartIntervalList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4042B}
// *********************************************************************//
  IFxChartIntervalList = interface(IDispatch)
    ['{B9B7019C-2600-4675-9A8B-148212D4042B}']
    function Get_Interval(Index: Integer): IFxChartInterval; safecall;
    function Get_Count: Integer; safecall;
    property Interval[Index: Integer]: IFxChartInterval read Get_Interval;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxChartIntervalListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {B9B7019C-2600-4675-9A8B-148212D4042B}
// *********************************************************************//
  IFxChartIntervalListDisp = dispinterface
    ['{B9B7019C-2600-4675-9A8B-148212D4042B}']
    property Interval[Index: Integer]: IFxChartInterval readonly dispid 201;
    property Count: Integer readonly dispid 202;
  end;

// *********************************************************************//
// Interface: IFxDebugInfo
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {5F1BF187-7477-4680-8A3A-88496D3952B7}
// *********************************************************************//
  IFxDebugInfo = interface(IDispatch)
    ['{5F1BF187-7477-4680-8A3A-88496D3952B7}']
    function Get_Time: TDateTime; safecall;
    function Get_DebugType: FxDebugInfoType; safecall;
    function Get_Details: WideString; safecall;
    property Time: TDateTime read Get_Time;
    property DebugType: FxDebugInfoType read Get_DebugType;
    property Details: WideString read Get_Details;
  end;

// *********************************************************************//
// DispIntf:  IFxDebugInfoDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {5F1BF187-7477-4680-8A3A-88496D3952B7}
// *********************************************************************//
  IFxDebugInfoDisp = dispinterface
    ['{5F1BF187-7477-4680-8A3A-88496D3952B7}']
    property Time: TDateTime readonly dispid 201;
    property DebugType: FxDebugInfoType readonly dispid 202;
    property Details: WideString readonly dispid 203;
  end;

// *********************************************************************//
// Interface: IFxPairGroup
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {63BAD035-8092-40E2-832B-9D0663AA4517}
// *********************************************************************//
  IFxPairGroup = interface(IFxPairList)
    ['{63BAD035-8092-40E2-832B-9D0663AA4517}']
    function Get_GroupId: WideString; safecall;
    function Get_GroupName: WideString; safecall;
    function Get_GroupParent: IFxPairGroup; safecall;
    property GroupId: WideString read Get_GroupId;
    property GroupName: WideString read Get_GroupName;
    property GroupParent: IFxPairGroup read Get_GroupParent;
  end;

// *********************************************************************//
// DispIntf:  IFxPairGroupDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {63BAD035-8092-40E2-832B-9D0663AA4517}
// *********************************************************************//
  IFxPairGroupDisp = dispinterface
    ['{63BAD035-8092-40E2-832B-9D0663AA4517}']
    property GroupId: WideString readonly dispid 401;
    property GroupName: WideString readonly dispid 402;
    property GroupParent: IFxPairGroup readonly dispid 303;
    property Pair[Index: Integer]: IFxPair readonly dispid 301;
    property PairById[const Id: WideString]: IFxPair readonly dispid 302;
    property Count: Integer readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxPairGroupList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {870274E2-CE91-4182-9DE9-7AF087678452}
// *********************************************************************//
  IFxPairGroupList = interface(IDispatch)
    ['{870274E2-CE91-4182-9DE9-7AF087678452}']
    function Get_Group(Index: Integer): IFxPairGroup; safecall;
    function Get_GroupById(const Id: WideString): IFxPairGroup; safecall;
    function Get_Count: Integer; safecall;
    property Group[Index: Integer]: IFxPairGroup read Get_Group;
    property GroupById[const Id: WideString]: IFxPairGroup read Get_GroupById;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxPairGroupListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {870274E2-CE91-4182-9DE9-7AF087678452}
// *********************************************************************//
  IFxPairGroupListDisp = dispinterface
    ['{870274E2-CE91-4182-9DE9-7AF087678452}']
    property Group[Index: Integer]: IFxPairGroup readonly dispid 301;
    property GroupById[const Id: WideString]: IFxPairGroup readonly dispid 302;
    property Count: Integer readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxTraderApiInt
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {FAC7E28D-1F0B-455F-A56A-4668AA86EA57}
// *********************************************************************//
  IFxTraderApiInt = interface(IDispatch)
    ['{FAC7E28D-1F0B-455F-A56A-4668AA86EA57}']
  end;

// *********************************************************************//
// DispIntf:  IFxTraderApiIntDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {FAC7E28D-1F0B-455F-A56A-4668AA86EA57}
// *********************************************************************//
  IFxTraderApiIntDisp = dispinterface
    ['{FAC7E28D-1F0B-455F-A56A-4668AA86EA57}']
  end;

// *********************************************************************//
// Interface: IFxTestData
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {A0DC25CD-4314-4022-941C-EC6FC89529FD}
// *********************************************************************//
  IFxTestData = interface(IDispatch)
    ['{A0DC25CD-4314-4022-941C-EC6FC89529FD}']
    function Get_Session: WideString; safecall;
    property Session: WideString read Get_Session;
  end;

// *********************************************************************//
// DispIntf:  IFxTestDataDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {A0DC25CD-4314-4022-941C-EC6FC89529FD}
// *********************************************************************//
  IFxTestDataDisp = dispinterface
    ['{A0DC25CD-4314-4022-941C-EC6FC89529FD}']
    property Session: WideString readonly dispid 201;
  end;

// *********************************************************************//
// Interface: IFxDefaultAmountInfo
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {1736EBF6-AEFE-487D-88A5-7CD64B976806}
// *********************************************************************//
  IFxDefaultAmountInfo = interface(IDispatch)
    ['{1736EBF6-AEFE-487D-88A5-7CD64B976806}']
    function GetDefaultAmount: Double; safecall;
    function UsePercentDA: FxLogic; safecall;
  end;

// *********************************************************************//
// DispIntf:  IFxDefaultAmountInfoDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {1736EBF6-AEFE-487D-88A5-7CD64B976806}
// *********************************************************************//
  IFxDefaultAmountInfoDisp = dispinterface
    ['{1736EBF6-AEFE-487D-88A5-7CD64B976806}']
    function GetDefaultAmount: Double; dispid 201;
    function UsePercentDA: FxLogic; dispid 202;
  end;

// *********************************************************************//
// Interface: IFxNonTradingInterval
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {980EAC19-F591-49B9-AC98-B12B00EBE8DB}
// *********************************************************************//
  IFxNonTradingInterval = interface(IDispatch)
    ['{980EAC19-F591-49B9-AC98-B12B00EBE8DB}']
    function Get_Id: WideString; safecall;
    function Get_TimeStart: TDateTime; safecall;
    function Get_TimeStop: TDateTime; safecall;
    property Id: WideString read Get_Id;
    property TimeStart: TDateTime read Get_TimeStart;
    property TimeStop: TDateTime read Get_TimeStop;
  end;

// *********************************************************************//
// DispIntf:  IFxNonTradingIntervalDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {980EAC19-F591-49B9-AC98-B12B00EBE8DB}
// *********************************************************************//
  IFxNonTradingIntervalDisp = dispinterface
    ['{980EAC19-F591-49B9-AC98-B12B00EBE8DB}']
    property Id: WideString readonly dispid 201;
    property TimeStart: TDateTime readonly dispid 202;
    property TimeStop: TDateTime readonly dispid 203;
  end;

// *********************************************************************//
// Interface: IFxNonTradingIntervalList
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {95685731-A559-4AB2-9470-64FDB2E5BC66}
// *********************************************************************//
  IFxNonTradingIntervalList = interface(IDispatch)
    ['{95685731-A559-4AB2-9470-64FDB2E5BC66}']
    function Get_NonTradingInterval(Index: Integer): IFxNonTradingInterval; safecall;
    function Get_NonTradingIntervalById(const Id: WideString): IFxNonTradingInterval; safecall;
    function Get_Count: Integer; safecall;
    property NonTradingInterval[Index: Integer]: IFxNonTradingInterval read Get_NonTradingInterval;
    property NonTradingIntervalById[const Id: WideString]: IFxNonTradingInterval read Get_NonTradingIntervalById;
    property Count: Integer read Get_Count;
  end;

// *********************************************************************//
// DispIntf:  IFxNonTradingIntervalListDisp
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {95685731-A559-4AB2-9470-64FDB2E5BC66}
// *********************************************************************//
  IFxNonTradingIntervalListDisp = dispinterface
    ['{95685731-A559-4AB2-9470-64FDB2E5BC66}']
    property NonTradingInterval[Index: Integer]: IFxNonTradingInterval readonly dispid 201;
    property NonTradingIntervalById[const Id: WideString]: IFxNonTradingInterval readonly dispid 202;
    property Count: Integer readonly dispid 203;
  end;

// *********************************************************************//
// The Class CoFxTraderApi provides a Create and CreateRemote method to          
// create instances of the default interface IFxTraderApi exposed by              
// the CoClass FxTraderApi. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTraderApi = class
    class function Create: IFxTraderApi;
    class function CreateRemote(const MachineName: string): IFxTraderApi;
  end;

  TFxTraderApiOnPairMessage = procedure(ASender: TObject; const Pair: IFxPair; 
                                                          MessageType: FxMessageType) of object;
  TFxTraderApiOnAccountMessage = procedure(ASender: TObject; const Account: IFxAccount; 
                                                             MessageType: FxMessageType) of object;
  TFxTraderApiOnOrderMessage = procedure(ASender: TObject; const Order: IFxOrder; 
                                                           MessageType: FxMessageType) of object;
  TFxTraderApiOnTradeMessage = procedure(ASender: TObject; const Trade: IFxTrade; 
                                                           MessageType: FxMessageType) of object;
  TFxTraderApiOnError = procedure(ASender: TObject; const Error: IFxError) of object;
  TFxTraderApiOnTextMessage = procedure(ASender: TObject; const Text: IFxTextMessage) of object;
  TFxTraderApiOnMarginCallMessage = procedure(ASender: TObject; const MarginCall: IFxMarginCallMessage) of object;
  TFxTraderApiOnStatusChange = procedure(ASender: TObject; Status: FxConnectionStatus) of object;
  TFxTraderApiOnFeedStatusChange = procedure(ASender: TObject; FeedStatus: FxConnectionStatus) of object;
  TFxTraderApiOnLogoff = procedure(ASender: TObject; const Code: WideString) of object;
  TFxTraderApiOnGetClosedTrade = procedure(ASender: TObject; const Trade: IFxTrade) of object;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TFxTraderApi
// Help String      : FxTraderApi object.
// Default Interface: IFxTraderApi
// Def. Intf. DISP? : No
// Event   Interface: IFxTraderApiEvents
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TFxTraderApiProperties= class;
{$ENDIF}
  TFxTraderApi = class(TOleServer)
  private
    FOnPairMessage: TFxTraderApiOnPairMessage;
    FOnAccountMessage: TFxTraderApiOnAccountMessage;
    FOnOrderMessage: TFxTraderApiOnOrderMessage;
    FOnTradeMessage: TFxTraderApiOnTradeMessage;
    FOnRulesChange: TNotifyEvent;
    FOnError: TFxTraderApiOnError;
    FOnTextMessage: TFxTraderApiOnTextMessage;
    FOnMarginCallMessage: TFxTraderApiOnMarginCallMessage;
    FOnStatusChange: TFxTraderApiOnStatusChange;
    FOnFeedStatusChange: TFxTraderApiOnFeedStatusChange;
    FOnLogoff: TFxTraderApiOnLogoff;
    FOnGetClosedTrade: TFxTraderApiOnGetClosedTrade;
    FIntf: IFxTraderApi;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps: TFxTraderApiProperties;
    function GetServerProperties: TFxTraderApiProperties;
{$ENDIF}
    function GetDefaultInterface: IFxTraderApi;
  protected
    procedure InitServerData; override;
    procedure InvokeEvent(DispID: TDispID; var Params: TVariantArray); override;
    function Get_Pairs: IFxPairList;
    function Get_Accounts: IFxAccountList;
    function Get_Orders: IFxOrderList;
    function Get_Trades: IFxTradeList;
    function Get_Rules: IFxRules;
    function Get_Status: FxConnectionStatus;
    function Get_ProxyServer: WideString;
    procedure Set_ProxyServer(const Value: WideString);
    function Get_ProxyPort: Integer;
    procedure Set_ProxyPort(Value: Integer);
    function Get_ProxyUserName: WideString;
    procedure Set_ProxyUserName(const Value: WideString);
    function Get_ProxyPassword: WideString;
    procedure Set_ProxyPassword(const Value: WideString);
    function Get_Version: WideString;
    function Get_NewLotList: IFxLotList;
    function Get_GroupMode: FxGroupMode;
    procedure Set_GroupMode(Value: FxGroupMode);
    function Get_ChartIntervals: IFxChartIntervalList;
    function Get_UseCompactPair: FxLogic;
    procedure Set_UseCompactPair(Value: FxLogic);
    function Get_LastError: IFxError;
    function Get_PairGroups: IFxPairGroupList;
    function Get_FeedStatus: FxConnectionStatus;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IFxTraderApi);
    procedure Disconnect; override;
    function Logon(const Schema: WideString; const Login: WideString; const Password: WideString; 
                   const Language: WideString; const ApiID: WideString): IFxError;
    function Logon2(const Protocol: WideString; const Host: WideString; Port: Integer; 
                    const DBAlias: WideString; const DASPath: WideString; const Login: WideString; 
                    const Password: WideString; const Language: WideString): IFxError;
    function Logoff: IFxError;
    function ChangeUserPassword(const Password: WideString): IFxError;
    function CreateInitOrder(const AccountId: WideString; const GroupId: WideString; 
                             const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                             TraderRange: Double; out InitOrderId: WideString; 
                             const ClientTag: WideString; const Lots: IFxLotList): IFxError;
    function CreateEntryOrder(StopLimit: FxStopLimit; const AccountId: WideString; 
                              const GroupId: WideString; const PairId: WideString; 
                              LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                              TraderRange: Double; out EntryOrderId: WideString; 
                              const ClientTag: WideString; const Lots: IFxLotList): IFxError;
    function ChangeStopLimitOnTrade(StopLimit: FxStopLimit; const TradeId: WideString; 
                                    Rate: Double; out StopLimitOrderId: WideString; 
                                    const ClientTag: WideString): IFxError;
    function ChangeStopLimitOnEntryOrder(StopLimit: FxStopLimit; const OrderId: WideString; 
                                         Rate: Double; out StopLimitOrderId: WideString; 
                                         const ClientTag: WideString): IFxError;
    function DeleteOrder(const OrderId: WideString): IFxError;
    function CloseTrade(const TradeId: WideString; TraderRange: Double; LotCount: Double; 
                        out CloseOrderId: WideString; const ClientTag: WideString; 
                        CloseWithHedge: FxLogic; const Lots: IFxLotList): IFxError;
    function HedgeTrade(const TradeId: WideString; LotCount: Double; out HedgeOrderId: WideString; 
                        const ClientTag: WideString; const Lots: IFxLotList): IFxError;
    function GetGroupTrades(const GroupTradeId: WideString; out TradeList: IFxTradeList): IFxError;
    function GetClosedTrades(const FromTradeId: WideString; const ToTradeId: WideString; 
                             FromTime: TDateTime; ToTime: TDateTime; const AccountId: WideString; 
                             const PairId: WideString; out TradeList: IFxTradeList): IFxError;
    function GetServerTime(out DateTime: TDateTime): IFxError;
    function ChangeEntryOrderRate(const OrderId: WideString; NewRate: Double): IFxError;
    function GetOrdersHistory(const FromOrderId: WideString; const ToOrderId: WideString; 
                              FromTime: TDateTime; ToTime: TDateTime; const AccountId: WideString; 
                              const PairId: WideString; out OrderList: IFxOrderList): IFxError;
    function GetAccountsHistory(const FromTransactionId: WideString; 
                                const ToTransactionId: WideString; FromTime: TDateTime; 
                                ToTime: TDateTime; const AccountId: WideString; 
                                const PairId: WideString; out AccountList: IFxAccountList): IFxError;
    function GetMaxLots(const GroupId: WideString; const PairId: WideString; BuySell: FxBuySell; 
                        Rate: Double; const LotList: IFxLotList): IFxError;
    function AcceptRejectedOrder(const OrderId: WideString): IFxError;
    procedure SetEntryServer(const Host: WideString; const Port: WideString);
    function ChangeStopTrailOnTrade(const TradeId: WideString; TrailDistance: Double; 
                                    out StopOrderId: WideString; const ClientTag: WideString): IFxError;
    function ChangeStopTrailOnEntryOrder(const OrderId: WideString; TrailDistance: Double; 
                                         out StopOrderId: WideString; const ClientTag: WideString): IFxError;
    function GetTickHistory(const PairId: WideString; Count: Integer; FromTime: TDateTime; 
                            ToTime: TDateTime; out TickList: IFxTickList): IFxError;
    function CreateInitOrder2(const AccountId: WideString; const GroupId: WideString; 
                              const PairId: WideString; Rate: Double; LotCount: Double; 
                              BuySell: FxBuySell; TraderRange: Double; out InitOrderId: WideString; 
                              const ClientTag: WideString; const Lots: IFxLotList): IFxError;
    function CloseTrade2(const TradeId: WideString; Rate: Double; TraderRange: Double; 
                         LotCount: Double; out CloseOrderId: WideString; 
                         const ClientTag: WideString; CloseWithHedge: FxLogic; 
                         const Lots: IFxLotList): IFxError;
    function HedgeTrade2(const TradeId: WideString; Rate: Double; LotCount: Double; 
                         out HedgeOrderId: WideString; const ClientTag: WideString; 
                         const Lots: IFxLotList): IFxError;
    function GetCandleHistory(const PairId: WideString; const ChartIntervalId: WideString; 
                              Count: Integer; FromTime: TDateTime; ToTime: TDateTime; 
                              out CandleList: IFxCandleList): IFxError;
    procedure SetDebugLog(const DebugIniFileName: WideString);
    function GetPairGroups(out Groups: IFxPairGroupList): IFxError;
    function UpdatePairSubscribtion(const Id: WideString; Subscribe: FxLogic; 
                                    out DependentPairs: IFxPairList): IFxError;
    function ChangeOCOLink(const OrderId1: WideString; const OrderId2: WideString): IFxError;
    function CreateEntryOCOOrders(const AccountId: WideString; const GroupId: WideString; 
                                  const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                                  StopRate: Double; LimitRate: Double; const ClientTag: WideString; 
                                  out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError;
    function CreateEntryOrderSL(StopLimit: FxStopLimit; const AccountId: WideString; 
                                const GroupId: WideString; const PairId: WideString; 
                                LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                                TraderRange: Double; out EntryOrderId: WideString; 
                                const ClientTag: WideString; const Lots: IFxLotList; 
                                EntryDistance: Double; StopTrailDistance: Double; StopRate: Double; 
                                LimitRate: Double): IFxError;
    function CheckUser(const Schema: WideString; const Login: WideString; 
                       const Password: WideString; const ApiID: WideString): IFxError;
    function GetRemovedOrdersHistory(const FromOrderId: WideString; const ToOrderId: WideString; 
                                     FromTime: TDateTime; ToTime: TDateTime; 
                                     FromRemovedTime: TDateTime; ToRemovedTime: TDateTime; 
                                     const AccountId: WideString; const PairId: WideString; 
                                     out OrderList: IFxOrderList): IFxError;
    function CreateInitOrderSL(const AccountId: WideString; const GroupId: WideString; 
                               const PairId: WideString; LotCount: Double; BuySell: FxBuySell; 
                               TraderRange: Double; const ClientTag: WideString; 
                               const Lots: IFxLotList; StopTrailDistance: Double; StopRate: Double; 
                               LimitRate: Double; out InitOrderId: WideString): IFxError;
    function Test: Integer;
    function GetTestData: IFxTestData;
    procedure SetTestData(ReconnectTimeOut: Integer);
    function AcceptRejectedOrder2(const OrderId: WideString; Range: Double): IFxError;
    function ModifyTradingComments(const Id: WideString; const Comments: WideString; 
                                   CommentType: FxCommentsType): IFxError;
    function RemoveTradingComments(const Id: WideString; CommentType: FxCommentsType): IFxError;
    function CloseFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                  const Lots: IFxLotList; BuySell: FxBuySell; 
                                  const ClientTag: WideString; TraderRange: Double; 
                                  out OrderId: WideString): IFxError;
    function CloseFifoTrades(const AccountId: WideString; const PairId: WideString; Lots: Double; 
                             BuySell: FxBuySell; const ClientTag: WideString; TraderRange: Double; 
                             out OrderId: WideString): IFxError;
    function StopOnFifoTrades(const AccountId: WideString; const PairId: WideString; Rate: Double; 
                              Lots: Double; BuySell: FxBuySell; const ClientTag: WideString; 
                              out OrderId: WideString): IFxError;
    function LimitOnFifoTrades(const AccountId: WideString; const PairId: WideString; Rate: Double; 
                               Lots: Double; BuySell: FxBuySell; const ClientTag: WideString; 
                               out OrderId: WideString): IFxError;
    function TrailOnFifoTrades(const AccountId: WideString; const PairId: WideString; 
                               Trail: Double; Lots: Double; BuySell: FxBuySell; 
                               const ClientTag: WideString; out OrderId: WideString): IFxError;
    function StopOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                   Rate: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                   const ClientTag: WideString; out OrderId: WideString): IFxError;
    function LimitOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                    Rate: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                    const ClientTag: WideString; out OrderId: WideString): IFxError;
    function TrailOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                    Trail: Double; const Lots: IFxLotList; BuySell: FxBuySell; 
                                    const ClientTag: WideString; out OrderId: WideString): IFxError;
    function ChangeOrderAmount(const OrderId: WideString; LotCount: Double; const Lots: IFxLotList): IFxError;
    function CreateOCOOrders(const AccountId: WideString; const PairId: WideString; 
                             LotCount: Double; BuySell: FxBuySell; StopRate: Double; 
                             LimitRate: Double; const ClientTag: WideString; 
                             out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError;
    function CreateGroupOCOOrders(const GroupId: WideString; const PairId: WideString; 
                                  const Lots: IFxLotList; BuySell: FxBuySell; StopRate: Double; 
                                  LimitRate: Double; const ClientTag: WideString; 
                                  out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError;
    function GetClosedTradesAsync(const FromTradeId: WideString; const ToTradeId: WideString; 
                                  FromTime: TDateTime; ToTime: TDateTime; 
                                  const AccountId: WideString; const PairId: WideString): IFxError;
    property DefaultInterface: IFxTraderApi read GetDefaultInterface;
    property Pairs: IFxPairList read Get_Pairs;
    property Accounts: IFxAccountList read Get_Accounts;
    property Orders: IFxOrderList read Get_Orders;
    property Trades: IFxTradeList read Get_Trades;
    property Rules: IFxRules read Get_Rules;
    property Status: FxConnectionStatus read Get_Status;
    property Version: WideString read Get_Version;
    property NewLotList: IFxLotList read Get_NewLotList;
    property ChartIntervals: IFxChartIntervalList read Get_ChartIntervals;
    property LastError: IFxError read Get_LastError;
    property PairGroups: IFxPairGroupList read Get_PairGroups;
    property FeedStatus: FxConnectionStatus read Get_FeedStatus;
    property ProxyServer: WideString read Get_ProxyServer write Set_ProxyServer;
    property ProxyPort: Integer read Get_ProxyPort write Set_ProxyPort;
    property ProxyUserName: WideString read Get_ProxyUserName write Set_ProxyUserName;
    property ProxyPassword: WideString read Get_ProxyPassword write Set_ProxyPassword;
    property GroupMode: FxGroupMode read Get_GroupMode write Set_GroupMode;
    property UseCompactPair: FxLogic read Get_UseCompactPair write Set_UseCompactPair;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TFxTraderApiProperties read GetServerProperties;
{$ENDIF}
    property OnPairMessage: TFxTraderApiOnPairMessage read FOnPairMessage write FOnPairMessage;
    property OnAccountMessage: TFxTraderApiOnAccountMessage read FOnAccountMessage write FOnAccountMessage;
    property OnOrderMessage: TFxTraderApiOnOrderMessage read FOnOrderMessage write FOnOrderMessage;
    property OnTradeMessage: TFxTraderApiOnTradeMessage read FOnTradeMessage write FOnTradeMessage;
    property OnRulesChange: TNotifyEvent read FOnRulesChange write FOnRulesChange;
    property OnError: TFxTraderApiOnError read FOnError write FOnError;
    property OnTextMessage: TFxTraderApiOnTextMessage read FOnTextMessage write FOnTextMessage;
    property OnMarginCallMessage: TFxTraderApiOnMarginCallMessage read FOnMarginCallMessage write FOnMarginCallMessage;
    property OnStatusChange: TFxTraderApiOnStatusChange read FOnStatusChange write FOnStatusChange;
    property OnFeedStatusChange: TFxTraderApiOnFeedStatusChange read FOnFeedStatusChange write FOnFeedStatusChange;
    property OnLogoff: TFxTraderApiOnLogoff read FOnLogoff write FOnLogoff;
    property OnGetClosedTrade: TFxTraderApiOnGetClosedTrade read FOnGetClosedTrade write FOnGetClosedTrade;
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TFxTraderApi
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TFxTraderApiProperties = class(TPersistent)
  private
    FServer:    TFxTraderApi;
    function    GetDefaultInterface: IFxTraderApi;
    constructor Create(AServer: TFxTraderApi);
  protected
    function Get_Pairs: IFxPairList;
    function Get_Accounts: IFxAccountList;
    function Get_Orders: IFxOrderList;
    function Get_Trades: IFxTradeList;
    function Get_Rules: IFxRules;
    function Get_Status: FxConnectionStatus;
    function Get_ProxyServer: WideString;
    procedure Set_ProxyServer(const Value: WideString);
    function Get_ProxyPort: Integer;
    procedure Set_ProxyPort(Value: Integer);
    function Get_ProxyUserName: WideString;
    procedure Set_ProxyUserName(const Value: WideString);
    function Get_ProxyPassword: WideString;
    procedure Set_ProxyPassword(const Value: WideString);
    function Get_Version: WideString;
    function Get_NewLotList: IFxLotList;
    function Get_GroupMode: FxGroupMode;
    procedure Set_GroupMode(Value: FxGroupMode);
    function Get_ChartIntervals: IFxChartIntervalList;
    function Get_UseCompactPair: FxLogic;
    procedure Set_UseCompactPair(Value: FxLogic);
    function Get_LastError: IFxError;
    function Get_PairGroups: IFxPairGroupList;
    function Get_FeedStatus: FxConnectionStatus;
  public
    property DefaultInterface: IFxTraderApi read GetDefaultInterface;
  published
    property ProxyServer: WideString read Get_ProxyServer write Set_ProxyServer;
    property ProxyPort: Integer read Get_ProxyPort write Set_ProxyPort;
    property ProxyUserName: WideString read Get_ProxyUserName write Set_ProxyUserName;
    property ProxyPassword: WideString read Get_ProxyPassword write Set_ProxyPassword;
    property GroupMode: FxGroupMode read Get_GroupMode write Set_GroupMode;
    property UseCompactPair: FxLogic read Get_UseCompactPair write Set_UseCompactPair;
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoFxPair provides a Create and CreateRemote method to          
// create instances of the default interface IFxPair exposed by              
// the CoClass FxPair. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxPair = class
    class function Create: IFxPair;
    class function CreateRemote(const MachineName: string): IFxPair;
  end;

// *********************************************************************//
// The Class CoFxAccount provides a Create and CreateRemote method to          
// create instances of the default interface IFxAccount exposed by              
// the CoClass FxAccount. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxAccount = class
    class function Create: IFxAccount;
    class function CreateRemote(const MachineName: string): IFxAccount;
  end;

// *********************************************************************//
// The Class CoFxTrade provides a Create and CreateRemote method to          
// create instances of the default interface IFxTrade exposed by              
// the CoClass FxTrade. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTrade = class
    class function Create: IFxTrade;
    class function CreateRemote(const MachineName: string): IFxTrade;
  end;

// *********************************************************************//
// The Class CoFxOrder provides a Create and CreateRemote method to          
// create instances of the default interface IFxOrder exposed by              
// the CoClass FxOrder. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxOrder = class
    class function Create: IFxOrder;
    class function CreateRemote(const MachineName: string): IFxOrder;
  end;

// *********************************************************************//
// The Class CoFxRules provides a Create and CreateRemote method to          
// create instances of the default interface IFxRules exposed by              
// the CoClass FxRules. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxRules = class
    class function Create: IFxRules;
    class function CreateRemote(const MachineName: string): IFxRules;
  end;

// *********************************************************************//
// The Class CoFxError provides a Create and CreateRemote method to          
// create instances of the default interface IFxError exposed by              
// the CoClass FxError. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxError = class
    class function Create: IFxError;
    class function CreateRemote(const MachineName: string): IFxError;
  end;

// *********************************************************************//
// The Class CoFxTextMessage provides a Create and CreateRemote method to          
// create instances of the default interface IFxTextMessage exposed by              
// the CoClass FxTextMessage. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTextMessage = class
    class function Create: IFxTextMessage;
    class function CreateRemote(const MachineName: string): IFxTextMessage;
  end;

// *********************************************************************//
// The Class CoFxMarginCallMessage provides a Create and CreateRemote method to          
// create instances of the default interface IFxMarginCallMessage exposed by              
// the CoClass FxMarginCallMessage. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxMarginCallMessage = class
    class function Create: IFxMarginCallMessage;
    class function CreateRemote(const MachineName: string): IFxMarginCallMessage;
  end;

// *********************************************************************//
// The Class CoFxPairList provides a Create and CreateRemote method to          
// create instances of the default interface IFxPairList exposed by              
// the CoClass FxPairList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxPairList = class
    class function Create: IFxPairList;
    class function CreateRemote(const MachineName: string): IFxPairList;
  end;

// *********************************************************************//
// The Class CoFxAccountList provides a Create and CreateRemote method to          
// create instances of the default interface IFxAccountList exposed by              
// the CoClass FxAccountList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxAccountList = class
    class function Create: IFxAccountList;
    class function CreateRemote(const MachineName: string): IFxAccountList;
  end;

// *********************************************************************//
// The Class CoFxOrderList provides a Create and CreateRemote method to          
// create instances of the default interface IFxOrderList exposed by              
// the CoClass FxOrderList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxOrderList = class
    class function Create: IFxOrderList;
    class function CreateRemote(const MachineName: string): IFxOrderList;
  end;

// *********************************************************************//
// The Class CoFxTradeList provides a Create and CreateRemote method to          
// create instances of the default interface IFxTradeList exposed by              
// the CoClass FxTradeList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTradeList = class
    class function Create: IFxTradeList;
    class function CreateRemote(const MachineName: string): IFxTradeList;
  end;

// *********************************************************************//
// The Class CoFxLot provides a Create and CreateRemote method to          
// create instances of the default interface IFxLot exposed by              
// the CoClass FxLot. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxLot = class
    class function Create: IFxLot;
    class function CreateRemote(const MachineName: string): IFxLot;
  end;

// *********************************************************************//
// The Class CoFxLotList provides a Create and CreateRemote method to          
// create instances of the default interface IFxLotList exposed by              
// the CoClass FxLotList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxLotList = class
    class function Create: IFxLotList;
    class function CreateRemote(const MachineName: string): IFxLotList;
  end;

// *********************************************************************//
// The Class CoFxTick provides a Create and CreateRemote method to          
// create instances of the default interface IFxTick exposed by              
// the CoClass FxTick. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTick = class
    class function Create: IFxTick;
    class function CreateRemote(const MachineName: string): IFxTick;
  end;

// *********************************************************************//
// The Class CoFxTickList provides a Create and CreateRemote method to          
// create instances of the default interface IFxTickList exposed by              
// the CoClass FxTickList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTickList = class
    class function Create: IFxTickList;
    class function CreateRemote(const MachineName: string): IFxTickList;
  end;

// *********************************************************************//
// The Class CoFxCandle provides a Create and CreateRemote method to          
// create instances of the default interface IFxCandle exposed by              
// the CoClass FxCandle. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxCandle = class
    class function Create: IFxCandle;
    class function CreateRemote(const MachineName: string): IFxCandle;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TFxCandle
// Help String      : FxCandle object.
// Default Interface: IFxCandle
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TFxCandleProperties= class;
{$ENDIF}
  TFxCandle = class(TOleServer)
  private
    FIntf: IFxCandle;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps: TFxCandleProperties;
    function GetServerProperties: TFxCandleProperties;
{$ENDIF}
    function GetDefaultInterface: IFxCandle;
  protected
    procedure InitServerData; override;
    function Get_Time: TDateTime;
    function Get_Open: Double;
    function Get_Close: Double;
    function Get_High: Double;
    function Get_Low: Double;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IFxCandle);
    procedure Disconnect; override;
    property DefaultInterface: IFxCandle read GetDefaultInterface;
    property Time: TDateTime read Get_Time;
    property Open: Double read Get_Open;
    property Close: Double read Get_Close;
    property High: Double read Get_High;
    property Low: Double read Get_Low;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TFxCandleProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TFxCandle
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TFxCandleProperties = class(TPersistent)
  private
    FServer:    TFxCandle;
    function    GetDefaultInterface: IFxCandle;
    constructor Create(AServer: TFxCandle);
  protected
    function Get_Time: TDateTime;
    function Get_Open: Double;
    function Get_Close: Double;
    function Get_High: Double;
    function Get_Low: Double;
  public
    property DefaultInterface: IFxCandle read GetDefaultInterface;
  published
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoFxCandleList provides a Create and CreateRemote method to          
// create instances of the default interface IFxCandleList exposed by              
// the CoClass FxCandleList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxCandleList = class
    class function Create: IFxCandleList;
    class function CreateRemote(const MachineName: string): IFxCandleList;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TFxCandleList
// Help String      : FxCandleList object.
// Default Interface: IFxCandleList
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TFxCandleListProperties= class;
{$ENDIF}
  TFxCandleList = class(TOleServer)
  private
    FIntf: IFxCandleList;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps: TFxCandleListProperties;
    function GetServerProperties: TFxCandleListProperties;
{$ENDIF}
    function GetDefaultInterface: IFxCandleList;
  protected
    procedure InitServerData; override;
    function Get_Candle(Index: Integer): IFxCandle;
    function Get_Count: Integer;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IFxCandleList);
    procedure Disconnect; override;
    property DefaultInterface: IFxCandleList read GetDefaultInterface;
    property Candle[Index: Integer]: IFxCandle read Get_Candle;
    property Count: Integer read Get_Count;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TFxCandleListProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TFxCandleList
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TFxCandleListProperties = class(TPersistent)
  private
    FServer:    TFxCandleList;
    function    GetDefaultInterface: IFxCandleList;
    constructor Create(AServer: TFxCandleList);
  protected
    function Get_Candle(Index: Integer): IFxCandle;
    function Get_Count: Integer;
  public
    property DefaultInterface: IFxCandleList read GetDefaultInterface;
  published
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoFxChartInterval provides a Create and CreateRemote method to          
// create instances of the default interface IFxChartInterval exposed by              
// the CoClass FxChartInterval. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxChartInterval = class
    class function Create: IFxChartInterval;
    class function CreateRemote(const MachineName: string): IFxChartInterval;
  end;

// *********************************************************************//
// The Class CoFxChartIntervalList provides a Create and CreateRemote method to          
// create instances of the default interface IFxChartIntervalList exposed by              
// the CoClass FxChartIntervalList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxChartIntervalList = class
    class function Create: IFxChartIntervalList;
    class function CreateRemote(const MachineName: string): IFxChartIntervalList;
  end;

// *********************************************************************//
// The Class CoFxDebugInfo provides a Create and CreateRemote method to          
// create instances of the default interface IFxDebugInfo exposed by              
// the CoClass FxDebugInfo. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxDebugInfo = class
    class function Create: IFxDebugInfo;
    class function CreateRemote(const MachineName: string): IFxDebugInfo;
  end;

// *********************************************************************//
// The Class CoFxPairGroup provides a Create and CreateRemote method to          
// create instances of the default interface IFxPairGroup exposed by              
// the CoClass FxPairGroup. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxPairGroup = class
    class function Create: IFxPairGroup;
    class function CreateRemote(const MachineName: string): IFxPairGroup;
  end;

// *********************************************************************//
// The Class CoFxPairGroupList provides a Create and CreateRemote method to          
// create instances of the default interface IFxPairGroupList exposed by              
// the CoClass FxPairGroupList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxPairGroupList = class
    class function Create: IFxPairGroupList;
    class function CreateRemote(const MachineName: string): IFxPairGroupList;
  end;

// *********************************************************************//
// The Class CoFxTraderApiInt provides a Create and CreateRemote method to          
// create instances of the default interface IFxTraderApiInt exposed by              
// the CoClass FxTraderApiInt. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTraderApiInt = class
    class function Create: IFxTraderApiInt;
    class function CreateRemote(const MachineName: string): IFxTraderApiInt;
  end;

// *********************************************************************//
// The Class CoFxTestData provides a Create and CreateRemote method to          
// create instances of the default interface IFxTestData exposed by              
// the CoClass FxTestData. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxTestData = class
    class function Create: IFxTestData;
    class function CreateRemote(const MachineName: string): IFxTestData;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TFxTestData
// Help String      : 
// Default Interface: IFxTestData
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TFxTestDataProperties= class;
{$ENDIF}
  TFxTestData = class(TOleServer)
  private
    FIntf: IFxTestData;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps: TFxTestDataProperties;
    function GetServerProperties: TFxTestDataProperties;
{$ENDIF}
    function GetDefaultInterface: IFxTestData;
  protected
    procedure InitServerData; override;
    function Get_Session: WideString;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IFxTestData);
    procedure Disconnect; override;
    property DefaultInterface: IFxTestData read GetDefaultInterface;
    property Session: WideString read Get_Session;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TFxTestDataProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TFxTestData
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TFxTestDataProperties = class(TPersistent)
  private
    FServer:    TFxTestData;
    function    GetDefaultInterface: IFxTestData;
    constructor Create(AServer: TFxTestData);
  protected
    function Get_Session: WideString;
  public
    property DefaultInterface: IFxTestData read GetDefaultInterface;
  published
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoFxDefaultAmountInfo provides a Create and CreateRemote method to          
// create instances of the default interface IFxDefaultAmountInfo exposed by              
// the CoClass FxDefaultAmountInfo. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxDefaultAmountInfo = class
    class function Create: IFxDefaultAmountInfo;
    class function CreateRemote(const MachineName: string): IFxDefaultAmountInfo;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TFxDefaultAmountInfo
// Help String      : 
// Default Interface: IFxDefaultAmountInfo
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TFxDefaultAmountInfoProperties= class;
{$ENDIF}
  TFxDefaultAmountInfo = class(TOleServer)
  private
    FIntf: IFxDefaultAmountInfo;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps: TFxDefaultAmountInfoProperties;
    function GetServerProperties: TFxDefaultAmountInfoProperties;
{$ENDIF}
    function GetDefaultInterface: IFxDefaultAmountInfo;
  protected
    procedure InitServerData; override;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IFxDefaultAmountInfo);
    procedure Disconnect; override;
    function GetDefaultAmount: Double;
    function UsePercentDA: FxLogic;
    property DefaultInterface: IFxDefaultAmountInfo read GetDefaultInterface;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TFxDefaultAmountInfoProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TFxDefaultAmountInfo
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TFxDefaultAmountInfoProperties = class(TPersistent)
  private
    FServer:    TFxDefaultAmountInfo;
    function    GetDefaultInterface: IFxDefaultAmountInfo;
    constructor Create(AServer: TFxDefaultAmountInfo);
  protected
  public
    property DefaultInterface: IFxDefaultAmountInfo read GetDefaultInterface;
  published
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoFxNonTradingInterval provides a Create and CreateRemote method to          
// create instances of the default interface IFxNonTradingInterval exposed by              
// the CoClass FxNonTradingInterval. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxNonTradingInterval = class
    class function Create: IFxNonTradingInterval;
    class function CreateRemote(const MachineName: string): IFxNonTradingInterval;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TFxNonTradingInterval
// Help String      : 
// Default Interface: IFxNonTradingInterval
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TFxNonTradingIntervalProperties= class;
{$ENDIF}
  TFxNonTradingInterval = class(TOleServer)
  private
    FIntf: IFxNonTradingInterval;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps: TFxNonTradingIntervalProperties;
    function GetServerProperties: TFxNonTradingIntervalProperties;
{$ENDIF}
    function GetDefaultInterface: IFxNonTradingInterval;
  protected
    procedure InitServerData; override;
    function Get_Id: WideString;
    function Get_TimeStart: TDateTime;
    function Get_TimeStop: TDateTime;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IFxNonTradingInterval);
    procedure Disconnect; override;
    property DefaultInterface: IFxNonTradingInterval read GetDefaultInterface;
    property Id: WideString read Get_Id;
    property TimeStart: TDateTime read Get_TimeStart;
    property TimeStop: TDateTime read Get_TimeStop;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TFxNonTradingIntervalProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TFxNonTradingInterval
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TFxNonTradingIntervalProperties = class(TPersistent)
  private
    FServer:    TFxNonTradingInterval;
    function    GetDefaultInterface: IFxNonTradingInterval;
    constructor Create(AServer: TFxNonTradingInterval);
  protected
    function Get_Id: WideString;
    function Get_TimeStart: TDateTime;
    function Get_TimeStop: TDateTime;
  public
    property DefaultInterface: IFxNonTradingInterval read GetDefaultInterface;
  published
  end;
{$ENDIF}


// *********************************************************************//
// The Class CoFxNonTradingIntervalList provides a Create and CreateRemote method to          
// create instances of the default interface IFxNonTradingIntervalList exposed by              
// the CoClass FxNonTradingIntervalList. The functions are intended to be used by             
// clients wishing to automate the CoClass objects exposed by the         
// server of this typelibrary.                                            
// *********************************************************************//
  CoFxNonTradingIntervalList = class
    class function Create: IFxNonTradingIntervalList;
    class function CreateRemote(const MachineName: string): IFxNonTradingIntervalList;
  end;


// *********************************************************************//
// OLE Server Proxy class declaration
// Server Object    : TFxNonTradingIntervalList
// Help String      : 
// Default Interface: IFxNonTradingIntervalList
// Def. Intf. DISP? : No
// Event   Interface: 
// TypeFlags        : (2) CanCreate
// *********************************************************************//
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  TFxNonTradingIntervalListProperties= class;
{$ENDIF}
  TFxNonTradingIntervalList = class(TOleServer)
  private
    FIntf: IFxNonTradingIntervalList;
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    FProps: TFxNonTradingIntervalListProperties;
    function GetServerProperties: TFxNonTradingIntervalListProperties;
{$ENDIF}
    function GetDefaultInterface: IFxNonTradingIntervalList;
  protected
    procedure InitServerData; override;
    function Get_NonTradingInterval(Index: Integer): IFxNonTradingInterval;
    function Get_NonTradingIntervalById(const Id: WideString): IFxNonTradingInterval;
    function Get_Count: Integer;
  public
    constructor Create(AOwner: TComponent); override;
    destructor  Destroy; override;
    procedure Connect; override;
    procedure ConnectTo(svrIntf: IFxNonTradingIntervalList);
    procedure Disconnect; override;
    property DefaultInterface: IFxNonTradingIntervalList read GetDefaultInterface;
    property NonTradingInterval[Index: Integer]: IFxNonTradingInterval read Get_NonTradingInterval;
    property NonTradingIntervalById[const Id: WideString]: IFxNonTradingInterval read Get_NonTradingIntervalById;
    property Count: Integer read Get_Count;
  published
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
    property Server: TFxNonTradingIntervalListProperties read GetServerProperties;
{$ENDIF}
  end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
// *********************************************************************//
// OLE Server Properties Proxy Class
// Server Object    : TFxNonTradingIntervalList
// (This object is used by the IDE's Property Inspector to allow editing
//  of the properties of this server)
// *********************************************************************//
 TFxNonTradingIntervalListProperties = class(TPersistent)
  private
    FServer:    TFxNonTradingIntervalList;
    function    GetDefaultInterface: IFxNonTradingIntervalList;
    constructor Create(AServer: TFxNonTradingIntervalList);
  protected
    function Get_NonTradingInterval(Index: Integer): IFxNonTradingInterval;
    function Get_NonTradingIntervalById(const Id: WideString): IFxNonTradingInterval;
    function Get_Count: Integer;
  public
    property DefaultInterface: IFxNonTradingIntervalList read GetDefaultInterface;
  published
  end;
{$ENDIF}


procedure Register;

resourcestring
  dtlServerPage = 'ActiveX';

  dtlOcxPage = 'ActiveX';

implementation

uses ComObj;

class function CoFxTraderApi.Create: IFxTraderApi;
begin
  Result := CreateComObject(CLASS_FxTraderApi) as IFxTraderApi;
end;

class function CoFxTraderApi.CreateRemote(const MachineName: string): IFxTraderApi;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTraderApi) as IFxTraderApi;
end;

procedure TFxTraderApi.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{B9B7019C-2600-4675-9A8B-148212D40403}';
    IntfIID:   '{B9B7019C-2600-4675-9A8B-148212D40401}';
    EventIID:  '{B9B7019C-2600-4675-9A8B-148212D40402}';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TFxTraderApi.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    ConnectEvents(punk);
    Fintf:= punk as IFxTraderApi;
  end;
end;

procedure TFxTraderApi.ConnectTo(svrIntf: IFxTraderApi);
begin
  Disconnect;
  FIntf := svrIntf;
  ConnectEvents(FIntf);
end;

procedure TFxTraderApi.DisConnect;
begin
  if Fintf <> nil then
  begin
    DisconnectEvents(FIntf);
    FIntf := nil;
  end;
end;

function TFxTraderApi.GetDefaultInterface: IFxTraderApi;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call "Connect" or "ConnectTo" before this operation');
  Result := FIntf;
end;

constructor TFxTraderApi.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TFxTraderApiProperties.Create(Self);
{$ENDIF}
end;

destructor TFxTraderApi.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TFxTraderApi.GetServerProperties: TFxTraderApiProperties;
begin
  Result := FProps;
end;
{$ENDIF}

procedure TFxTraderApi.InvokeEvent(DispID: TDispID; var Params: TVariantArray);
begin
  case DispID of
    -1: Exit;  // DISPID_UNKNOWN
    201: if Assigned(FOnPairMessage) then
         FOnPairMessage(Self,
                        IUnknown(TVarData(Params[0]).VPointer) as IFxPair {const IFxPair},
                        Params[1] {FxMessageType});
    202: if Assigned(FOnAccountMessage) then
         FOnAccountMessage(Self,
                           IUnknown(TVarData(Params[0]).VPointer) as IFxAccount {const IFxAccount},
                           Params[1] {FxMessageType});
    203: if Assigned(FOnOrderMessage) then
         FOnOrderMessage(Self,
                         IUnknown(TVarData(Params[0]).VPointer) as IFxOrder {const IFxOrder},
                         Params[1] {FxMessageType});
    204: if Assigned(FOnTradeMessage) then
         FOnTradeMessage(Self,
                         IUnknown(TVarData(Params[0]).VPointer) as IFxTrade {const IFxTrade},
                         Params[1] {FxMessageType});
    205: if Assigned(FOnRulesChange) then
         FOnRulesChange(Self);
    206: if Assigned(FOnError) then
         FOnError(Self, IUnknown(TVarData(Params[0]).VPointer) as IFxError {const IFxError});
    207: if Assigned(FOnTextMessage) then
         FOnTextMessage(Self, IUnknown(TVarData(Params[0]).VPointer) as IFxTextMessage {const IFxTextMessage});
    208: if Assigned(FOnMarginCallMessage) then
         FOnMarginCallMessage(Self, IUnknown(TVarData(Params[0]).VPointer) as IFxMarginCallMessage {const IFxMarginCallMessage});
    209: if Assigned(FOnStatusChange) then
         FOnStatusChange(Self, Params[0] {FxConnectionStatus});
    210: if Assigned(FOnFeedStatusChange) then
         FOnFeedStatusChange(Self, Params[0] {FxConnectionStatus});
    211: if Assigned(FOnLogoff) then
         FOnLogoff(Self, Params[0] {const WideString});
    212: if Assigned(FOnGetClosedTrade) then
         FOnGetClosedTrade(Self, IUnknown(TVarData(Params[0]).VPointer) as IFxTrade {const IFxTrade});
  end; {case DispID}
end;

function TFxTraderApi.Get_Pairs: IFxPairList;
begin
    Result := DefaultInterface.Pairs;
end;

function TFxTraderApi.Get_Accounts: IFxAccountList;
begin
    Result := DefaultInterface.Accounts;
end;

function TFxTraderApi.Get_Orders: IFxOrderList;
begin
    Result := DefaultInterface.Orders;
end;

function TFxTraderApi.Get_Trades: IFxTradeList;
begin
    Result := DefaultInterface.Trades;
end;

function TFxTraderApi.Get_Rules: IFxRules;
begin
    Result := DefaultInterface.Rules;
end;

function TFxTraderApi.Get_Status: FxConnectionStatus;
begin
    Result := DefaultInterface.Status;
end;

function TFxTraderApi.Get_ProxyServer: WideString;
begin
    Result := DefaultInterface.ProxyServer;
end;

procedure TFxTraderApi.Set_ProxyServer(const Value: WideString);
  { Warning: The property ProxyServer has a setter and a getter whose
    types do not match. Delphi was unable to generate a property of
    this sort and so is using a Variant as a passthrough. }
var
  InterfaceVariant: OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  InterfaceVariant.ProxyServer := Value;
end;

function TFxTraderApi.Get_ProxyPort: Integer;
begin
    Result := DefaultInterface.ProxyPort;
end;

procedure TFxTraderApi.Set_ProxyPort(Value: Integer);
begin
  DefaultInterface.Set_ProxyPort(Value);
end;

function TFxTraderApi.Get_ProxyUserName: WideString;
begin
    Result := DefaultInterface.ProxyUserName;
end;

procedure TFxTraderApi.Set_ProxyUserName(const Value: WideString);
  { Warning: The property ProxyUserName has a setter and a getter whose
    types do not match. Delphi was unable to generate a property of
    this sort and so is using a Variant as a passthrough. }
var
  InterfaceVariant: OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  InterfaceVariant.ProxyUserName := Value;
end;

function TFxTraderApi.Get_ProxyPassword: WideString;
begin
    Result := DefaultInterface.ProxyPassword;
end;

procedure TFxTraderApi.Set_ProxyPassword(const Value: WideString);
  { Warning: The property ProxyPassword has a setter and a getter whose
    types do not match. Delphi was unable to generate a property of
    this sort and so is using a Variant as a passthrough. }
var
  InterfaceVariant: OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  InterfaceVariant.ProxyPassword := Value;
end;

function TFxTraderApi.Get_Version: WideString;
begin
    Result := DefaultInterface.Version;
end;

function TFxTraderApi.Get_NewLotList: IFxLotList;
begin
    Result := DefaultInterface.NewLotList;
end;

function TFxTraderApi.Get_GroupMode: FxGroupMode;
begin
    Result := DefaultInterface.GroupMode;
end;

procedure TFxTraderApi.Set_GroupMode(Value: FxGroupMode);
begin
  DefaultInterface.Set_GroupMode(Value);
end;

function TFxTraderApi.Get_ChartIntervals: IFxChartIntervalList;
begin
    Result := DefaultInterface.ChartIntervals;
end;

function TFxTraderApi.Get_UseCompactPair: FxLogic;
begin
    Result := DefaultInterface.UseCompactPair;
end;

procedure TFxTraderApi.Set_UseCompactPair(Value: FxLogic);
begin
  DefaultInterface.Set_UseCompactPair(Value);
end;

function TFxTraderApi.Get_LastError: IFxError;
begin
    Result := DefaultInterface.LastError;
end;

function TFxTraderApi.Get_PairGroups: IFxPairGroupList;
begin
    Result := DefaultInterface.PairGroups;
end;

function TFxTraderApi.Get_FeedStatus: FxConnectionStatus;
begin
    Result := DefaultInterface.FeedStatus;
end;

function TFxTraderApi.Logon(const Schema: WideString; const Login: WideString; 
                            const Password: WideString; const Language: WideString; 
                            const ApiID: WideString): IFxError;
begin
  Result := DefaultInterface.Logon(Schema, Login, Password, Language, ApiID);
end;

function TFxTraderApi.Logon2(const Protocol: WideString; const Host: WideString; Port: Integer; 
                             const DBAlias: WideString; const DASPath: WideString; 
                             const Login: WideString; const Password: WideString; 
                             const Language: WideString): IFxError;
begin
  Result := DefaultInterface.Logon2(Protocol, Host, Port, DBAlias, DASPath, Login, Password, 
                                    Language);
end;

function TFxTraderApi.Logoff: IFxError;
begin
  Result := DefaultInterface.Logoff;
end;

function TFxTraderApi.ChangeUserPassword(const Password: WideString): IFxError;
begin
  Result := DefaultInterface.ChangeUserPassword(Password);
end;

function TFxTraderApi.CreateInitOrder(const AccountId: WideString; const GroupId: WideString; 
                                      const PairId: WideString; LotCount: Double; 
                                      BuySell: FxBuySell; TraderRange: Double; 
                                      out InitOrderId: WideString; const ClientTag: WideString; 
                                      const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.CreateInitOrder(AccountId, GroupId, PairId, LotCount, BuySell, 
                                             TraderRange, InitOrderId, ClientTag, Lots);
end;

function TFxTraderApi.CreateEntryOrder(StopLimit: FxStopLimit; const AccountId: WideString; 
                                       const GroupId: WideString; const PairId: WideString; 
                                       LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                                       TraderRange: Double; out EntryOrderId: WideString; 
                                       const ClientTag: WideString; const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.CreateEntryOrder(StopLimit, AccountId, GroupId, PairId, LotCount, 
                                              BuySell, Rate, TraderRange, EntryOrderId, ClientTag, 
                                              Lots);
end;

function TFxTraderApi.ChangeStopLimitOnTrade(StopLimit: FxStopLimit; const TradeId: WideString; 
                                             Rate: Double; out StopLimitOrderId: WideString; 
                                             const ClientTag: WideString): IFxError;
begin
  Result := DefaultInterface.ChangeStopLimitOnTrade(StopLimit, TradeId, Rate, StopLimitOrderId, 
                                                    ClientTag);
end;

function TFxTraderApi.ChangeStopLimitOnEntryOrder(StopLimit: FxStopLimit; 
                                                  const OrderId: WideString; Rate: Double; 
                                                  out StopLimitOrderId: WideString; 
                                                  const ClientTag: WideString): IFxError;
begin
  Result := DefaultInterface.ChangeStopLimitOnEntryOrder(StopLimit, OrderId, Rate, 
                                                         StopLimitOrderId, ClientTag);
end;

function TFxTraderApi.DeleteOrder(const OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.DeleteOrder(OrderId);
end;

function TFxTraderApi.CloseTrade(const TradeId: WideString; TraderRange: Double; LotCount: Double; 
                                 out CloseOrderId: WideString; const ClientTag: WideString; 
                                 CloseWithHedge: FxLogic; const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.CloseTrade(TradeId, TraderRange, LotCount, CloseOrderId, ClientTag, 
                                        CloseWithHedge, Lots);
end;

function TFxTraderApi.HedgeTrade(const TradeId: WideString; LotCount: Double; 
                                 out HedgeOrderId: WideString; const ClientTag: WideString; 
                                 const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.HedgeTrade(TradeId, LotCount, HedgeOrderId, ClientTag, Lots);
end;

function TFxTraderApi.GetGroupTrades(const GroupTradeId: WideString; out TradeList: IFxTradeList): IFxError;
begin
  Result := DefaultInterface.GetGroupTrades(GroupTradeId, TradeList);
end;

function TFxTraderApi.GetClosedTrades(const FromTradeId: WideString; const ToTradeId: WideString; 
                                      FromTime: TDateTime; ToTime: TDateTime; 
                                      const AccountId: WideString; const PairId: WideString; 
                                      out TradeList: IFxTradeList): IFxError;
begin
  Result := DefaultInterface.GetClosedTrades(FromTradeId, ToTradeId, FromTime, ToTime, AccountId, 
                                             PairId, TradeList);
end;

function TFxTraderApi.GetServerTime(out DateTime: TDateTime): IFxError;
begin
  Result := DefaultInterface.GetServerTime(DateTime);
end;

function TFxTraderApi.ChangeEntryOrderRate(const OrderId: WideString; NewRate: Double): IFxError;
begin
  Result := DefaultInterface.ChangeEntryOrderRate(OrderId, NewRate);
end;

function TFxTraderApi.GetOrdersHistory(const FromOrderId: WideString; const ToOrderId: WideString; 
                                       FromTime: TDateTime; ToTime: TDateTime; 
                                       const AccountId: WideString; const PairId: WideString; 
                                       out OrderList: IFxOrderList): IFxError;
begin
  Result := DefaultInterface.GetOrdersHistory(FromOrderId, ToOrderId, FromTime, ToTime, AccountId, 
                                              PairId, OrderList);
end;

function TFxTraderApi.GetAccountsHistory(const FromTransactionId: WideString; 
                                         const ToTransactionId: WideString; FromTime: TDateTime; 
                                         ToTime: TDateTime; const AccountId: WideString; 
                                         const PairId: WideString; out AccountList: IFxAccountList): IFxError;
begin
  Result := DefaultInterface.GetAccountsHistory(FromTransactionId, ToTransactionId, FromTime, 
                                                ToTime, AccountId, PairId, AccountList);
end;

function TFxTraderApi.GetMaxLots(const GroupId: WideString; const PairId: WideString; 
                                 BuySell: FxBuySell; Rate: Double; const LotList: IFxLotList): IFxError;
begin
  Result := DefaultInterface.GetMaxLots(GroupId, PairId, BuySell, Rate, LotList);
end;

function TFxTraderApi.AcceptRejectedOrder(const OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.AcceptRejectedOrder(OrderId);
end;

procedure TFxTraderApi.SetEntryServer(const Host: WideString; const Port: WideString);
begin
  DefaultInterface.SetEntryServer(Host, Port);
end;

function TFxTraderApi.ChangeStopTrailOnTrade(const TradeId: WideString; TrailDistance: Double; 
                                             out StopOrderId: WideString; 
                                             const ClientTag: WideString): IFxError;
begin
  Result := DefaultInterface.ChangeStopTrailOnTrade(TradeId, TrailDistance, StopOrderId, ClientTag);
end;

function TFxTraderApi.ChangeStopTrailOnEntryOrder(const OrderId: WideString; TrailDistance: Double; 
                                                  out StopOrderId: WideString; 
                                                  const ClientTag: WideString): IFxError;
begin
  Result := DefaultInterface.ChangeStopTrailOnEntryOrder(OrderId, TrailDistance, StopOrderId, 
                                                         ClientTag);
end;

function TFxTraderApi.GetTickHistory(const PairId: WideString; Count: Integer; FromTime: TDateTime; 
                                     ToTime: TDateTime; out TickList: IFxTickList): IFxError;
begin
  Result := DefaultInterface.GetTickHistory(PairId, Count, FromTime, ToTime, TickList);
end;

function TFxTraderApi.CreateInitOrder2(const AccountId: WideString; const GroupId: WideString; 
                                       const PairId: WideString; Rate: Double; LotCount: Double; 
                                       BuySell: FxBuySell; TraderRange: Double; 
                                       out InitOrderId: WideString; const ClientTag: WideString; 
                                       const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.CreateInitOrder2(AccountId, GroupId, PairId, Rate, LotCount, BuySell, 
                                              TraderRange, InitOrderId, ClientTag, Lots);
end;

function TFxTraderApi.CloseTrade2(const TradeId: WideString; Rate: Double; TraderRange: Double; 
                                  LotCount: Double; out CloseOrderId: WideString; 
                                  const ClientTag: WideString; CloseWithHedge: FxLogic; 
                                  const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.CloseTrade2(TradeId, Rate, TraderRange, LotCount, CloseOrderId, 
                                         ClientTag, CloseWithHedge, Lots);
end;

function TFxTraderApi.HedgeTrade2(const TradeId: WideString; Rate: Double; LotCount: Double; 
                                  out HedgeOrderId: WideString; const ClientTag: WideString; 
                                  const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.HedgeTrade2(TradeId, Rate, LotCount, HedgeOrderId, ClientTag, Lots);
end;

function TFxTraderApi.GetCandleHistory(const PairId: WideString; const ChartIntervalId: WideString; 
                                       Count: Integer; FromTime: TDateTime; ToTime: TDateTime; 
                                       out CandleList: IFxCandleList): IFxError;
begin
  Result := DefaultInterface.GetCandleHistory(PairId, ChartIntervalId, Count, FromTime, ToTime, 
                                              CandleList);
end;

procedure TFxTraderApi.SetDebugLog(const DebugIniFileName: WideString);
begin
  DefaultInterface.SetDebugLog(DebugIniFileName);
end;

function TFxTraderApi.GetPairGroups(out Groups: IFxPairGroupList): IFxError;
begin
  Result := DefaultInterface.GetPairGroups(Groups);
end;

function TFxTraderApi.UpdatePairSubscribtion(const Id: WideString; Subscribe: FxLogic; 
                                             out DependentPairs: IFxPairList): IFxError;
begin
  Result := DefaultInterface.UpdatePairSubscribtion(Id, Subscribe, DependentPairs);
end;

function TFxTraderApi.ChangeOCOLink(const OrderId1: WideString; const OrderId2: WideString): IFxError;
begin
  Result := DefaultInterface.ChangeOCOLink(OrderId1, OrderId2);
end;

function TFxTraderApi.CreateEntryOCOOrders(const AccountId: WideString; const GroupId: WideString; 
                                           const PairId: WideString; LotCount: Double; 
                                           BuySell: FxBuySell; StopRate: Double; LimitRate: Double; 
                                           const ClientTag: WideString; 
                                           out EntryOrderId1: WideString; 
                                           out EntryOrderId2: WideString): IFxError;
begin
  Result := DefaultInterface.CreateEntryOCOOrders(AccountId, GroupId, PairId, LotCount, BuySell, 
                                                  StopRate, LimitRate, ClientTag, EntryOrderId1, 
                                                  EntryOrderId2);
end;

function TFxTraderApi.CreateEntryOrderSL(StopLimit: FxStopLimit; const AccountId: WideString; 
                                         const GroupId: WideString; const PairId: WideString; 
                                         LotCount: Double; BuySell: FxBuySell; Rate: Double; 
                                         TraderRange: Double; out EntryOrderId: WideString; 
                                         const ClientTag: WideString; const Lots: IFxLotList; 
                                         EntryDistance: Double; StopTrailDistance: Double; 
                                         StopRate: Double; LimitRate: Double): IFxError;
begin
  Result := DefaultInterface.CreateEntryOrderSL(StopLimit, AccountId, GroupId, PairId, LotCount, 
                                                BuySell, Rate, TraderRange, EntryOrderId, 
                                                ClientTag, Lots, EntryDistance, StopTrailDistance, 
                                                StopRate, LimitRate);
end;

function TFxTraderApi.CheckUser(const Schema: WideString; const Login: WideString; 
                                const Password: WideString; const ApiID: WideString): IFxError;
begin
  Result := DefaultInterface.CheckUser(Schema, Login, Password, ApiID);
end;

function TFxTraderApi.GetRemovedOrdersHistory(const FromOrderId: WideString; 
                                              const ToOrderId: WideString; FromTime: TDateTime; 
                                              ToTime: TDateTime; FromRemovedTime: TDateTime; 
                                              ToRemovedTime: TDateTime; 
                                              const AccountId: WideString; 
                                              const PairId: WideString; out OrderList: IFxOrderList): IFxError;
begin
  Result := DefaultInterface.GetRemovedOrdersHistory(FromOrderId, ToOrderId, FromTime, ToTime, 
                                                     FromRemovedTime, ToRemovedTime, AccountId, 
                                                     PairId, OrderList);
end;

function TFxTraderApi.CreateInitOrderSL(const AccountId: WideString; const GroupId: WideString; 
                                        const PairId: WideString; LotCount: Double; 
                                        BuySell: FxBuySell; TraderRange: Double; 
                                        const ClientTag: WideString; const Lots: IFxLotList; 
                                        StopTrailDistance: Double; StopRate: Double; 
                                        LimitRate: Double; out InitOrderId: WideString): IFxError;
begin
  Result := DefaultInterface.CreateInitOrderSL(AccountId, GroupId, PairId, LotCount, BuySell, 
                                               TraderRange, ClientTag, Lots, StopTrailDistance, 
                                               StopRate, LimitRate, InitOrderId);
end;

function TFxTraderApi.Test: Integer;
begin
  Result := DefaultInterface.Test;
end;

function TFxTraderApi.GetTestData: IFxTestData;
begin
  Result := DefaultInterface.GetTestData;
end;

procedure TFxTraderApi.SetTestData(ReconnectTimeOut: Integer);
begin
  DefaultInterface.SetTestData(ReconnectTimeOut);
end;

function TFxTraderApi.AcceptRejectedOrder2(const OrderId: WideString; Range: Double): IFxError;
begin
  Result := DefaultInterface.AcceptRejectedOrder2(OrderId, Range);
end;

function TFxTraderApi.ModifyTradingComments(const Id: WideString; const Comments: WideString; 
                                            CommentType: FxCommentsType): IFxError;
begin
  Result := DefaultInterface.ModifyTradingComments(Id, Comments, CommentType);
end;

function TFxTraderApi.RemoveTradingComments(const Id: WideString; CommentType: FxCommentsType): IFxError;
begin
  Result := DefaultInterface.RemoveTradingComments(Id, CommentType);
end;

function TFxTraderApi.CloseFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                           const Lots: IFxLotList; BuySell: FxBuySell; 
                                           const ClientTag: WideString; TraderRange: Double; 
                                           out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.CloseFifoGroupTrades(GroupId, PairId, Lots, BuySell, ClientTag, 
                                                  TraderRange, OrderId);
end;

function TFxTraderApi.CloseFifoTrades(const AccountId: WideString; const PairId: WideString; 
                                      Lots: Double; BuySell: FxBuySell; 
                                      const ClientTag: WideString; TraderRange: Double; 
                                      out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.CloseFifoTrades(AccountId, PairId, Lots, BuySell, ClientTag, 
                                             TraderRange, OrderId);
end;

function TFxTraderApi.StopOnFifoTrades(const AccountId: WideString; const PairId: WideString; 
                                       Rate: Double; Lots: Double; BuySell: FxBuySell; 
                                       const ClientTag: WideString; out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.StopOnFifoTrades(AccountId, PairId, Rate, Lots, BuySell, ClientTag, 
                                              OrderId);
end;

function TFxTraderApi.LimitOnFifoTrades(const AccountId: WideString; const PairId: WideString; 
                                        Rate: Double; Lots: Double; BuySell: FxBuySell; 
                                        const ClientTag: WideString; out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.LimitOnFifoTrades(AccountId, PairId, Rate, Lots, BuySell, ClientTag, 
                                               OrderId);
end;

function TFxTraderApi.TrailOnFifoTrades(const AccountId: WideString; const PairId: WideString; 
                                        Trail: Double; Lots: Double; BuySell: FxBuySell; 
                                        const ClientTag: WideString; out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.TrailOnFifoTrades(AccountId, PairId, Trail, Lots, BuySell, ClientTag, 
                                               OrderId);
end;

function TFxTraderApi.StopOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                            Rate: Double; const Lots: IFxLotList; 
                                            BuySell: FxBuySell; const ClientTag: WideString; 
                                            out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.StopOnFifoGroupTrades(GroupId, PairId, Rate, Lots, BuySell, ClientTag, 
                                                   OrderId);
end;

function TFxTraderApi.LimitOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                             Rate: Double; const Lots: IFxLotList; 
                                             BuySell: FxBuySell; const ClientTag: WideString; 
                                             out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.LimitOnFifoGroupTrades(GroupId, PairId, Rate, Lots, BuySell, 
                                                    ClientTag, OrderId);
end;

function TFxTraderApi.TrailOnFifoGroupTrades(const GroupId: WideString; const PairId: WideString; 
                                             Trail: Double; const Lots: IFxLotList; 
                                             BuySell: FxBuySell; const ClientTag: WideString; 
                                             out OrderId: WideString): IFxError;
begin
  Result := DefaultInterface.TrailOnFifoGroupTrades(GroupId, PairId, Trail, Lots, BuySell, 
                                                    ClientTag, OrderId);
end;

function TFxTraderApi.ChangeOrderAmount(const OrderId: WideString; LotCount: Double; 
                                        const Lots: IFxLotList): IFxError;
begin
  Result := DefaultInterface.ChangeOrderAmount(OrderId, LotCount, Lots);
end;

function TFxTraderApi.CreateOCOOrders(const AccountId: WideString; const PairId: WideString; 
                                      LotCount: Double; BuySell: FxBuySell; StopRate: Double; 
                                      LimitRate: Double; const ClientTag: WideString; 
                                      out EntryOrderId1: WideString; out EntryOrderId2: WideString): IFxError;
begin
  Result := DefaultInterface.CreateOCOOrders(AccountId, PairId, LotCount, BuySell, StopRate, 
                                             LimitRate, ClientTag, EntryOrderId1, EntryOrderId2);
end;

function TFxTraderApi.CreateGroupOCOOrders(const GroupId: WideString; const PairId: WideString; 
                                           const Lots: IFxLotList; BuySell: FxBuySell; 
                                           StopRate: Double; LimitRate: Double; 
                                           const ClientTag: WideString; 
                                           out EntryOrderId1: WideString; 
                                           out EntryOrderId2: WideString): IFxError;
begin
  Result := DefaultInterface.CreateGroupOCOOrders(GroupId, PairId, Lots, BuySell, StopRate, 
                                                  LimitRate, ClientTag, EntryOrderId1, EntryOrderId2);
end;

function TFxTraderApi.GetClosedTradesAsync(const FromTradeId: WideString; 
                                           const ToTradeId: WideString; FromTime: TDateTime; 
                                           ToTime: TDateTime; const AccountId: WideString; 
                                           const PairId: WideString): IFxError;
begin
  Result := DefaultInterface.GetClosedTradesAsync(FromTradeId, ToTradeId, FromTime, ToTime, 
                                                  AccountId, PairId);
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TFxTraderApiProperties.Create(AServer: TFxTraderApi);
begin
  inherited Create;
  FServer := AServer;
end;

function TFxTraderApiProperties.GetDefaultInterface: IFxTraderApi;
begin
  Result := FServer.DefaultInterface;
end;

function TFxTraderApiProperties.Get_Pairs: IFxPairList;
begin
    Result := DefaultInterface.Pairs;
end;

function TFxTraderApiProperties.Get_Accounts: IFxAccountList;
begin
    Result := DefaultInterface.Accounts;
end;

function TFxTraderApiProperties.Get_Orders: IFxOrderList;
begin
    Result := DefaultInterface.Orders;
end;

function TFxTraderApiProperties.Get_Trades: IFxTradeList;
begin
    Result := DefaultInterface.Trades;
end;

function TFxTraderApiProperties.Get_Rules: IFxRules;
begin
    Result := DefaultInterface.Rules;
end;

function TFxTraderApiProperties.Get_Status: FxConnectionStatus;
begin
    Result := DefaultInterface.Status;
end;

function TFxTraderApiProperties.Get_ProxyServer: WideString;
begin
    Result := DefaultInterface.ProxyServer;
end;

procedure TFxTraderApiProperties.Set_ProxyServer(const Value: WideString);
  { Warning: The property ProxyServer has a setter and a getter whose
    types do not match. Delphi was unable to generate a property of
    this sort and so is using a Variant as a passthrough. }
var
  InterfaceVariant: OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  InterfaceVariant.ProxyServer := Value;
end;

function TFxTraderApiProperties.Get_ProxyPort: Integer;
begin
    Result := DefaultInterface.ProxyPort;
end;

procedure TFxTraderApiProperties.Set_ProxyPort(Value: Integer);
begin
  DefaultInterface.Set_ProxyPort(Value);
end;

function TFxTraderApiProperties.Get_ProxyUserName: WideString;
begin
    Result := DefaultInterface.ProxyUserName;
end;

procedure TFxTraderApiProperties.Set_ProxyUserName(const Value: WideString);
  { Warning: The property ProxyUserName has a setter and a getter whose
    types do not match. Delphi was unable to generate a property of
    this sort and so is using a Variant as a passthrough. }
var
  InterfaceVariant: OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  InterfaceVariant.ProxyUserName := Value;
end;

function TFxTraderApiProperties.Get_ProxyPassword: WideString;
begin
    Result := DefaultInterface.ProxyPassword;
end;

procedure TFxTraderApiProperties.Set_ProxyPassword(const Value: WideString);
  { Warning: The property ProxyPassword has a setter and a getter whose
    types do not match. Delphi was unable to generate a property of
    this sort and so is using a Variant as a passthrough. }
var
  InterfaceVariant: OleVariant;
begin
  InterfaceVariant := DefaultInterface;
  InterfaceVariant.ProxyPassword := Value;
end;

function TFxTraderApiProperties.Get_Version: WideString;
begin
    Result := DefaultInterface.Version;
end;

function TFxTraderApiProperties.Get_NewLotList: IFxLotList;
begin
    Result := DefaultInterface.NewLotList;
end;

function TFxTraderApiProperties.Get_GroupMode: FxGroupMode;
begin
    Result := DefaultInterface.GroupMode;
end;

procedure TFxTraderApiProperties.Set_GroupMode(Value: FxGroupMode);
begin
  DefaultInterface.Set_GroupMode(Value);
end;

function TFxTraderApiProperties.Get_ChartIntervals: IFxChartIntervalList;
begin
    Result := DefaultInterface.ChartIntervals;
end;

function TFxTraderApiProperties.Get_UseCompactPair: FxLogic;
begin
    Result := DefaultInterface.UseCompactPair;
end;

procedure TFxTraderApiProperties.Set_UseCompactPair(Value: FxLogic);
begin
  DefaultInterface.Set_UseCompactPair(Value);
end;

function TFxTraderApiProperties.Get_LastError: IFxError;
begin
    Result := DefaultInterface.LastError;
end;

function TFxTraderApiProperties.Get_PairGroups: IFxPairGroupList;
begin
    Result := DefaultInterface.PairGroups;
end;

function TFxTraderApiProperties.Get_FeedStatus: FxConnectionStatus;
begin
    Result := DefaultInterface.FeedStatus;
end;

{$ENDIF}

class function CoFxPair.Create: IFxPair;
begin
  Result := CreateComObject(CLASS_FxPair) as IFxPair;
end;

class function CoFxPair.CreateRemote(const MachineName: string): IFxPair;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxPair) as IFxPair;
end;

class function CoFxAccount.Create: IFxAccount;
begin
  Result := CreateComObject(CLASS_FxAccount) as IFxAccount;
end;

class function CoFxAccount.CreateRemote(const MachineName: string): IFxAccount;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxAccount) as IFxAccount;
end;

class function CoFxTrade.Create: IFxTrade;
begin
  Result := CreateComObject(CLASS_FxTrade) as IFxTrade;
end;

class function CoFxTrade.CreateRemote(const MachineName: string): IFxTrade;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTrade) as IFxTrade;
end;

class function CoFxOrder.Create: IFxOrder;
begin
  Result := CreateComObject(CLASS_FxOrder) as IFxOrder;
end;

class function CoFxOrder.CreateRemote(const MachineName: string): IFxOrder;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxOrder) as IFxOrder;
end;

class function CoFxRules.Create: IFxRules;
begin
  Result := CreateComObject(CLASS_FxRules) as IFxRules;
end;

class function CoFxRules.CreateRemote(const MachineName: string): IFxRules;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxRules) as IFxRules;
end;

class function CoFxError.Create: IFxError;
begin
  Result := CreateComObject(CLASS_FxError) as IFxError;
end;

class function CoFxError.CreateRemote(const MachineName: string): IFxError;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxError) as IFxError;
end;

class function CoFxTextMessage.Create: IFxTextMessage;
begin
  Result := CreateComObject(CLASS_FxTextMessage) as IFxTextMessage;
end;

class function CoFxTextMessage.CreateRemote(const MachineName: string): IFxTextMessage;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTextMessage) as IFxTextMessage;
end;

class function CoFxMarginCallMessage.Create: IFxMarginCallMessage;
begin
  Result := CreateComObject(CLASS_FxMarginCallMessage) as IFxMarginCallMessage;
end;

class function CoFxMarginCallMessage.CreateRemote(const MachineName: string): IFxMarginCallMessage;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxMarginCallMessage) as IFxMarginCallMessage;
end;

class function CoFxPairList.Create: IFxPairList;
begin
  Result := CreateComObject(CLASS_FxPairList) as IFxPairList;
end;

class function CoFxPairList.CreateRemote(const MachineName: string): IFxPairList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxPairList) as IFxPairList;
end;

class function CoFxAccountList.Create: IFxAccountList;
begin
  Result := CreateComObject(CLASS_FxAccountList) as IFxAccountList;
end;

class function CoFxAccountList.CreateRemote(const MachineName: string): IFxAccountList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxAccountList) as IFxAccountList;
end;

class function CoFxOrderList.Create: IFxOrderList;
begin
  Result := CreateComObject(CLASS_FxOrderList) as IFxOrderList;
end;

class function CoFxOrderList.CreateRemote(const MachineName: string): IFxOrderList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxOrderList) as IFxOrderList;
end;

class function CoFxTradeList.Create: IFxTradeList;
begin
  Result := CreateComObject(CLASS_FxTradeList) as IFxTradeList;
end;

class function CoFxTradeList.CreateRemote(const MachineName: string): IFxTradeList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTradeList) as IFxTradeList;
end;

class function CoFxLot.Create: IFxLot;
begin
  Result := CreateComObject(CLASS_FxLot) as IFxLot;
end;

class function CoFxLot.CreateRemote(const MachineName: string): IFxLot;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxLot) as IFxLot;
end;

class function CoFxLotList.Create: IFxLotList;
begin
  Result := CreateComObject(CLASS_FxLotList) as IFxLotList;
end;

class function CoFxLotList.CreateRemote(const MachineName: string): IFxLotList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxLotList) as IFxLotList;
end;

class function CoFxTick.Create: IFxTick;
begin
  Result := CreateComObject(CLASS_FxTick) as IFxTick;
end;

class function CoFxTick.CreateRemote(const MachineName: string): IFxTick;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTick) as IFxTick;
end;

class function CoFxTickList.Create: IFxTickList;
begin
  Result := CreateComObject(CLASS_FxTickList) as IFxTickList;
end;

class function CoFxTickList.CreateRemote(const MachineName: string): IFxTickList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTickList) as IFxTickList;
end;

class function CoFxCandle.Create: IFxCandle;
begin
  Result := CreateComObject(CLASS_FxCandle) as IFxCandle;
end;

class function CoFxCandle.CreateRemote(const MachineName: string): IFxCandle;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxCandle) as IFxCandle;
end;

procedure TFxCandle.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{B9B7019C-2600-4675-9A8B-148212D40428}';
    IntfIID:   '{B9B7019C-2600-4675-9A8B-148212D40426}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TFxCandle.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IFxCandle;
  end;
end;

procedure TFxCandle.ConnectTo(svrIntf: IFxCandle);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TFxCandle.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TFxCandle.GetDefaultInterface: IFxCandle;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call "Connect" or "ConnectTo" before this operation');
  Result := FIntf;
end;

constructor TFxCandle.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TFxCandleProperties.Create(Self);
{$ENDIF}
end;

destructor TFxCandle.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TFxCandle.GetServerProperties: TFxCandleProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TFxCandle.Get_Time: TDateTime;
begin
    Result := DefaultInterface.Time;
end;

function TFxCandle.Get_Open: Double;
begin
    Result := DefaultInterface.Open;
end;

function TFxCandle.Get_Close: Double;
begin
    Result := DefaultInterface.Close;
end;

function TFxCandle.Get_High: Double;
begin
    Result := DefaultInterface.High;
end;

function TFxCandle.Get_Low: Double;
begin
    Result := DefaultInterface.Low;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TFxCandleProperties.Create(AServer: TFxCandle);
begin
  inherited Create;
  FServer := AServer;
end;

function TFxCandleProperties.GetDefaultInterface: IFxCandle;
begin
  Result := FServer.DefaultInterface;
end;

function TFxCandleProperties.Get_Time: TDateTime;
begin
    Result := DefaultInterface.Time;
end;

function TFxCandleProperties.Get_Open: Double;
begin
    Result := DefaultInterface.Open;
end;

function TFxCandleProperties.Get_Close: Double;
begin
    Result := DefaultInterface.Close;
end;

function TFxCandleProperties.Get_High: Double;
begin
    Result := DefaultInterface.High;
end;

function TFxCandleProperties.Get_Low: Double;
begin
    Result := DefaultInterface.Low;
end;

{$ENDIF}

class function CoFxCandleList.Create: IFxCandleList;
begin
  Result := CreateComObject(CLASS_FxCandleList) as IFxCandleList;
end;

class function CoFxCandleList.CreateRemote(const MachineName: string): IFxCandleList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxCandleList) as IFxCandleList;
end;

procedure TFxCandleList.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{B9B7019C-2600-4675-9A8B-148212D40429}';
    IntfIID:   '{B9B7019C-2600-4675-9A8B-148212D40427}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TFxCandleList.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IFxCandleList;
  end;
end;

procedure TFxCandleList.ConnectTo(svrIntf: IFxCandleList);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TFxCandleList.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TFxCandleList.GetDefaultInterface: IFxCandleList;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call "Connect" or "ConnectTo" before this operation');
  Result := FIntf;
end;

constructor TFxCandleList.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TFxCandleListProperties.Create(Self);
{$ENDIF}
end;

destructor TFxCandleList.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TFxCandleList.GetServerProperties: TFxCandleListProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TFxCandleList.Get_Candle(Index: Integer): IFxCandle;
begin
    Result := DefaultInterface.Candle[Index];
end;

function TFxCandleList.Get_Count: Integer;
begin
    Result := DefaultInterface.Count;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TFxCandleListProperties.Create(AServer: TFxCandleList);
begin
  inherited Create;
  FServer := AServer;
end;

function TFxCandleListProperties.GetDefaultInterface: IFxCandleList;
begin
  Result := FServer.DefaultInterface;
end;

function TFxCandleListProperties.Get_Candle(Index: Integer): IFxCandle;
begin
    Result := DefaultInterface.Candle[Index];
end;

function TFxCandleListProperties.Get_Count: Integer;
begin
    Result := DefaultInterface.Count;
end;

{$ENDIF}

class function CoFxChartInterval.Create: IFxChartInterval;
begin
  Result := CreateComObject(CLASS_FxChartInterval) as IFxChartInterval;
end;

class function CoFxChartInterval.CreateRemote(const MachineName: string): IFxChartInterval;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxChartInterval) as IFxChartInterval;
end;

class function CoFxChartIntervalList.Create: IFxChartIntervalList;
begin
  Result := CreateComObject(CLASS_FxChartIntervalList) as IFxChartIntervalList;
end;

class function CoFxChartIntervalList.CreateRemote(const MachineName: string): IFxChartIntervalList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxChartIntervalList) as IFxChartIntervalList;
end;

class function CoFxDebugInfo.Create: IFxDebugInfo;
begin
  Result := CreateComObject(CLASS_FxDebugInfo) as IFxDebugInfo;
end;

class function CoFxDebugInfo.CreateRemote(const MachineName: string): IFxDebugInfo;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxDebugInfo) as IFxDebugInfo;
end;

class function CoFxPairGroup.Create: IFxPairGroup;
begin
  Result := CreateComObject(CLASS_FxPairGroup) as IFxPairGroup;
end;

class function CoFxPairGroup.CreateRemote(const MachineName: string): IFxPairGroup;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxPairGroup) as IFxPairGroup;
end;

class function CoFxPairGroupList.Create: IFxPairGroupList;
begin
  Result := CreateComObject(CLASS_FxPairGroupList) as IFxPairGroupList;
end;

class function CoFxPairGroupList.CreateRemote(const MachineName: string): IFxPairGroupList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxPairGroupList) as IFxPairGroupList;
end;

class function CoFxTraderApiInt.Create: IFxTraderApiInt;
begin
  Result := CreateComObject(CLASS_FxTraderApiInt) as IFxTraderApiInt;
end;

class function CoFxTraderApiInt.CreateRemote(const MachineName: string): IFxTraderApiInt;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTraderApiInt) as IFxTraderApiInt;
end;

class function CoFxTestData.Create: IFxTestData;
begin
  Result := CreateComObject(CLASS_FxTestData) as IFxTestData;
end;

class function CoFxTestData.CreateRemote(const MachineName: string): IFxTestData;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxTestData) as IFxTestData;
end;

procedure TFxTestData.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{22CEAC8A-C4B6-46D2-88E6-A0FD4B60E102}';
    IntfIID:   '{A0DC25CD-4314-4022-941C-EC6FC89529FD}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TFxTestData.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IFxTestData;
  end;
end;

procedure TFxTestData.ConnectTo(svrIntf: IFxTestData);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TFxTestData.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TFxTestData.GetDefaultInterface: IFxTestData;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call "Connect" or "ConnectTo" before this operation');
  Result := FIntf;
end;

constructor TFxTestData.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TFxTestDataProperties.Create(Self);
{$ENDIF}
end;

destructor TFxTestData.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TFxTestData.GetServerProperties: TFxTestDataProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TFxTestData.Get_Session: WideString;
begin
    Result := DefaultInterface.Session;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TFxTestDataProperties.Create(AServer: TFxTestData);
begin
  inherited Create;
  FServer := AServer;
end;

function TFxTestDataProperties.GetDefaultInterface: IFxTestData;
begin
  Result := FServer.DefaultInterface;
end;

function TFxTestDataProperties.Get_Session: WideString;
begin
    Result := DefaultInterface.Session;
end;

{$ENDIF}

class function CoFxDefaultAmountInfo.Create: IFxDefaultAmountInfo;
begin
  Result := CreateComObject(CLASS_FxDefaultAmountInfo) as IFxDefaultAmountInfo;
end;

class function CoFxDefaultAmountInfo.CreateRemote(const MachineName: string): IFxDefaultAmountInfo;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxDefaultAmountInfo) as IFxDefaultAmountInfo;
end;

procedure TFxDefaultAmountInfo.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{ED652CB5-1654-4F25-B71C-9D5E884CA77F}';
    IntfIID:   '{1736EBF6-AEFE-487D-88A5-7CD64B976806}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TFxDefaultAmountInfo.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IFxDefaultAmountInfo;
  end;
end;

procedure TFxDefaultAmountInfo.ConnectTo(svrIntf: IFxDefaultAmountInfo);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TFxDefaultAmountInfo.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TFxDefaultAmountInfo.GetDefaultInterface: IFxDefaultAmountInfo;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call "Connect" or "ConnectTo" before this operation');
  Result := FIntf;
end;

constructor TFxDefaultAmountInfo.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TFxDefaultAmountInfoProperties.Create(Self);
{$ENDIF}
end;

destructor TFxDefaultAmountInfo.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TFxDefaultAmountInfo.GetServerProperties: TFxDefaultAmountInfoProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TFxDefaultAmountInfo.GetDefaultAmount: Double;
begin
  Result := DefaultInterface.GetDefaultAmount;
end;

function TFxDefaultAmountInfo.UsePercentDA: FxLogic;
begin
  Result := DefaultInterface.UsePercentDA;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TFxDefaultAmountInfoProperties.Create(AServer: TFxDefaultAmountInfo);
begin
  inherited Create;
  FServer := AServer;
end;

function TFxDefaultAmountInfoProperties.GetDefaultInterface: IFxDefaultAmountInfo;
begin
  Result := FServer.DefaultInterface;
end;

{$ENDIF}

class function CoFxNonTradingInterval.Create: IFxNonTradingInterval;
begin
  Result := CreateComObject(CLASS_FxNonTradingInterval) as IFxNonTradingInterval;
end;

class function CoFxNonTradingInterval.CreateRemote(const MachineName: string): IFxNonTradingInterval;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxNonTradingInterval) as IFxNonTradingInterval;
end;

procedure TFxNonTradingInterval.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{880859F8-F63F-4767-86F0-387477B0CEDD}';
    IntfIID:   '{980EAC19-F591-49B9-AC98-B12B00EBE8DB}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TFxNonTradingInterval.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IFxNonTradingInterval;
  end;
end;

procedure TFxNonTradingInterval.ConnectTo(svrIntf: IFxNonTradingInterval);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TFxNonTradingInterval.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TFxNonTradingInterval.GetDefaultInterface: IFxNonTradingInterval;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call "Connect" or "ConnectTo" before this operation');
  Result := FIntf;
end;

constructor TFxNonTradingInterval.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TFxNonTradingIntervalProperties.Create(Self);
{$ENDIF}
end;

destructor TFxNonTradingInterval.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TFxNonTradingInterval.GetServerProperties: TFxNonTradingIntervalProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TFxNonTradingInterval.Get_Id: WideString;
begin
    Result := DefaultInterface.Id;
end;

function TFxNonTradingInterval.Get_TimeStart: TDateTime;
begin
    Result := DefaultInterface.TimeStart;
end;

function TFxNonTradingInterval.Get_TimeStop: TDateTime;
begin
    Result := DefaultInterface.TimeStop;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TFxNonTradingIntervalProperties.Create(AServer: TFxNonTradingInterval);
begin
  inherited Create;
  FServer := AServer;
end;

function TFxNonTradingIntervalProperties.GetDefaultInterface: IFxNonTradingInterval;
begin
  Result := FServer.DefaultInterface;
end;

function TFxNonTradingIntervalProperties.Get_Id: WideString;
begin
    Result := DefaultInterface.Id;
end;

function TFxNonTradingIntervalProperties.Get_TimeStart: TDateTime;
begin
    Result := DefaultInterface.TimeStart;
end;

function TFxNonTradingIntervalProperties.Get_TimeStop: TDateTime;
begin
    Result := DefaultInterface.TimeStop;
end;

{$ENDIF}

class function CoFxNonTradingIntervalList.Create: IFxNonTradingIntervalList;
begin
  Result := CreateComObject(CLASS_FxNonTradingIntervalList) as IFxNonTradingIntervalList;
end;

class function CoFxNonTradingIntervalList.CreateRemote(const MachineName: string): IFxNonTradingIntervalList;
begin
  Result := CreateRemoteComObject(MachineName, CLASS_FxNonTradingIntervalList) as IFxNonTradingIntervalList;
end;

procedure TFxNonTradingIntervalList.InitServerData;
const
  CServerData: TServerData = (
    ClassID:   '{BB596139-EB18-46B3-8901-DC3E2703A862}';
    IntfIID:   '{95685731-A559-4AB2-9470-64FDB2E5BC66}';
    EventIID:  '';
    LicenseKey: nil;
    Version: 500);
begin
  ServerData := @CServerData;
end;

procedure TFxNonTradingIntervalList.Connect;
var
  punk: IUnknown;
begin
  if FIntf = nil then
  begin
    punk := GetServer;
    Fintf:= punk as IFxNonTradingIntervalList;
  end;
end;

procedure TFxNonTradingIntervalList.ConnectTo(svrIntf: IFxNonTradingIntervalList);
begin
  Disconnect;
  FIntf := svrIntf;
end;

procedure TFxNonTradingIntervalList.DisConnect;
begin
  if Fintf <> nil then
  begin
    FIntf := nil;
  end;
end;

function TFxNonTradingIntervalList.GetDefaultInterface: IFxNonTradingIntervalList;
begin
  if FIntf = nil then
    Connect;
  Assert(FIntf <> nil, 'DefaultInterface is NULL. Component is not connected to Server. You must call "Connect" or "ConnectTo" before this operation');
  Result := FIntf;
end;

constructor TFxNonTradingIntervalList.Create(AOwner: TComponent);
begin
  inherited Create(AOwner);
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps := TFxNonTradingIntervalListProperties.Create(Self);
{$ENDIF}
end;

destructor TFxNonTradingIntervalList.Destroy;
begin
{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
  FProps.Free;
{$ENDIF}
  inherited Destroy;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
function TFxNonTradingIntervalList.GetServerProperties: TFxNonTradingIntervalListProperties;
begin
  Result := FProps;
end;
{$ENDIF}

function TFxNonTradingIntervalList.Get_NonTradingInterval(Index: Integer): IFxNonTradingInterval;
begin
    Result := DefaultInterface.NonTradingInterval[Index];
end;

function TFxNonTradingIntervalList.Get_NonTradingIntervalById(const Id: WideString): IFxNonTradingInterval;
begin
    Result := DefaultInterface.NonTradingIntervalById[Id];
end;

function TFxNonTradingIntervalList.Get_Count: Integer;
begin
    Result := DefaultInterface.Count;
end;

{$IFDEF LIVE_SERVER_AT_DESIGN_TIME}
constructor TFxNonTradingIntervalListProperties.Create(AServer: TFxNonTradingIntervalList);
begin
  inherited Create;
  FServer := AServer;
end;

function TFxNonTradingIntervalListProperties.GetDefaultInterface: IFxNonTradingIntervalList;
begin
  Result := FServer.DefaultInterface;
end;

function TFxNonTradingIntervalListProperties.Get_NonTradingInterval(Index: Integer): IFxNonTradingInterval;
begin
    Result := DefaultInterface.NonTradingInterval[Index];
end;

function TFxNonTradingIntervalListProperties.Get_NonTradingIntervalById(const Id: WideString): IFxNonTradingInterval;
begin
    Result := DefaultInterface.NonTradingIntervalById[Id];
end;

function TFxNonTradingIntervalListProperties.Get_Count: Integer;
begin
    Result := DefaultInterface.Count;
end;

{$ENDIF}

procedure Register;
begin
  RegisterComponents(dtlServerPage, [TFxTraderApi, TFxCandle, TFxCandleList, TFxTestData, 
    TFxDefaultAmountInfo, TFxNonTradingInterval, TFxNonTradingIntervalList]);
end;

end.
