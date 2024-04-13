#include <atlbase.h>
#include <atlwin.h>
#include <conio.h>
#include <iostream>
#include <atlcomtime.h>

#import "progid:FxComApiTrader.FxTraderApi" raw_dispinterfaces named_guids

BEGIN_OBJECT_MAP(ObjectMap)
END_OBJECT_MAP()

class COnTradeEventSink :
	public IDispEventImpl<1, COnTradeEventSink,
    &__uuidof(FxComApiTrader::IFxTraderApiEvents), &FxComApiTrader::LIBID_FxComApiTrader, 2, 0>
{
	public:
		BEGIN_SINK_MAP(COnTradeEventSink)
            SINK_ENTRY_EX(1, __uuidof(FxComApiTrader::IFxTraderApiEvents), 201, OnPairMessage)
            SINK_ENTRY_EX(1, __uuidof(FxComApiTrader::IFxTraderApiEvents), 206, OnError)
			SINK_ENTRY_EX(1, __uuidof(FxComApiTrader::IFxTraderApiEvents), 209, OnStatusChange)
		END_SINK_MAP()

	HRESULT __stdcall OnPairMessage ( struct FxComApiTrader::IFxPair * Pair, enum FxComApiTrader::FxMessageType MessageType );
	HRESULT __stdcall OnError ( struct IFxError * Error );
	HRESULT __stdcall OnStatusChange( enum FxConnectionStatus Status );
};

HRESULT __stdcall COnTradeEventSink::OnPairMessage( struct FxComApiTrader::IFxPair * pair, enum FxComApiTrader::FxMessageType MessageType )
{
	std::cout<<"+++++START PAIR MESSAGE++++"<<std::endl;
	std::cout<<"ID: "      <<pair->PairId  <<std::endl;
	std::cout<<"SellRate: "<<pair->SellRate<<std::endl;
	std::cout<<"BuyRate: " <<pair->BuyRate <<std::endl;
	std::cout<<"-----STOP  PAIR MESSAGE----"<<std::endl;
	return S_OK;
}

HRESULT __stdcall COnTradeEventSink::OnError( struct IFxError * Error )
{
    return S_OK;
}

HRESULT __stdcall COnTradeEventSink::OnStatusChange( enum FxConnectionStatus Status )
{
	return S_OK;
}

int main(int argc, char ** argv)
{
	CComModule _Module;
	_Module.Init(ObjectMap, NULL/*hInstance*/, &FxComApiTrader::LIBID_FxComApiTrader);
	CoInitialize(NULL);

	_com_ptr_t<_com_IIID<FxComApiTrader::IFxTraderApi, &__uuidof(FxComApiTrader::IFxTraderApi)>> api;
	api.CreateInstance(OLESTR("FxComApiTrader.FxTraderApi"));

    COnTradeEventSink * events = new COnTradeEventSink();
	events->DispEventAdvise(api);

	FxComApiTrader::IFxErrorPtr error = api->Logon("***", "***", "***", "", "");

    if(error != NULL)
	{
	    std::wcout<<L"Can not logon, because: "<<error->Message<<std::endl;
		error.Release();

		events->DispEventUnadvise(api);
		delete events;
		api.Release();
		CoUninitialize();
		_Module.Term();
		std::cout<<"Press any key to continue..."<<std::endl;
		while(!_kbhit());
		return -1;
	}

	std::cout<<"+++++START TRADES++++"<<std::endl;
	FxComApiTrader::IFxTradeListPtr trades = api->Trades;
	std::cout<<"Trades count: "<<trades->Count<<std::endl;
	for(int i = 0; i < trades->Count; ++i)
	{
		FxComApiTrader::IFxTradePtr trade = trades->Trade[i];
		std::cout<<"ID: "<<trade->TradeId<<std::endl;
		std::cout<<"Amount: "<<trade->Amount<<std::endl;
		std::cout<<"PairID: "<<trade->PairId<<std::endl;
		trade.Release();
	}
	trades.Release();
	std::cout<<"-----STOP  TRADES----"<<std::endl;

	DATE fromDate(COleDateTime(2009, 1, 25, 0, 0, 0).m_dt);
	DATE toDate  (COleDateTime(2009, 2, 1, 0, 0, 0).m_dt);
	FxComApiTrader::IFxOrderList * orders = NULL;
	error = api->GetOrdersHistory("", "", fromDate, toDate, "1", "", &orders);

        if(error != NULL)
	{
	    std::wcout<<L"Error: "<<error->Message<<std::endl;
        error.Release();

        events->DispEventUnadvise(api);
        delete events;
        api.Release();
        CoUninitialize();
        _Module.Term();
        std::cout<<"Press any key to continue..."<<std::endl;
        while(!_kbhit());
        return -1;
	}

	std::cout<<"+++++START ORDERS HISTORY++++"<<std::endl;
    std::cout<<"orders count: "<<orders->Count<<std::endl;
	for(int i = 0; i < orders->Count; ++i)
	{
            FxComApiTrader::IFxOrderPtr order = orders->Order[i];
            std::cout<<"ID: "<<order->OrderId<<std::endl;
            std::cout<<"Amount: "<<order->Amount<<std::endl;
            std::cout<<"PairID: "<<order->PairId<<std::endl;
            order.Release();
	}
	std::cout<<"+++++STOP  ORDERS HISTORY++++"<<std::endl;

	std::cout<<"Press any key to continue..."<<std::endl;
	while(!_kbhit());

	api->Logoff();

	events->DispEventUnadvise(api);
	delete events;

	api.Release();
	CoUninitialize();
	_Module.Term();
	return 0;
}