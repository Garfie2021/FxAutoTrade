using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FXCore;
using Common;
using DB;
/*
namespace FXCM
{
    public static class TradeRate
    {
		public static TradeDeskAut tradeDesk_Rate;
		public static TableAut offers_Rate;

		public static string[] QuoteIdList;

	
		public static void ログイン(string FXCM_URL, string connection, string strUsername, string strPassword)
		{
			FXCore.CoreAut fxCore;
			fxCore = new FXCore.CoreAut();

			tradeDesk_Rate = (FXCore.TradeDeskAut)fxCore.CreateTradeDesk("trader");
			tradeDesk_Rate.Login(strUsername, strPassword, FXCM_URL, connection);
			offers_Rate = (FXCore.TableAut)tradeDesk_Rate.FindMainTable("offers");

			//QuoteID登録();
		}

        public static void ログアウト()
        {
			if (tradeDesk_Rate != null)
			{
				tradeDesk_Rate.Logout();
				tradeDesk_Rate = null;
			}
		}

		private static uint GetRate_Cnt = 0;
		public static void GetRate(byte 通貨ペアNo, ref double 買いRate, ref double 売りRate)
		{
			for (GetRate_Cnt = 1; GetRate_Cnt <= offers_Rate.RowCount; GetRate_Cnt++)
			{
				if (FXCMConst.通貨ペアList[通貨ペアNo].Equals((string)offers_Rate.CellValue(GetRate_Cnt, "Instrument")) == false)
					continue;

				買いRate = (double)offers_Rate.CellValue(GetRate_Cnt, "Ask");
				売りRate = (double)offers_Rate.CellValue(GetRate_Cnt, "Bid");

				return;
			}
		}

		//public static uint QuoteID登録_iCnt;
		//public static byte QuoteID登録_通貨ペアNo;
		//private static void QuoteID登録()
		//{
		//	QuoteIdList = new string[FXCMConst.通貨ペア数];

		//	for (QuoteID登録_通貨ペアNo = 0; QuoteID登録_通貨ペアNo < FXCMConst.通貨ペアList.Length; QuoteID登録_通貨ペアNo++)
		//	{
		//		for (QuoteID登録_iCnt = 1; QuoteID登録_iCnt <= offers_Rate.RowCount; QuoteID登録_iCnt++)
		//		{
		//			if (FXCMConst.通貨ペアList[QuoteID登録_通貨ペアNo].Equals((string)offers_Rate.CellValue(QuoteID登録_iCnt, "Instrument")) == false)
		//				continue;

		//			QuoteIdList[QuoteID登録_通貨ペアNo] = (string)offers_Rate.CellValue(QuoteID登録_iCnt, "QuoteID");
		//		}
		//	}
		//}

	}
}

*/