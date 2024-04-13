program ApiTest;

uses
  Forms,
  ApiTestUnit in 'ApiTestUnit.pas' {APITestForm},
  FxComApiTrader_TLB in 'FxComApiTrader_TLB.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TAPITestForm, APITestForm);
  Application.Run;
end.
