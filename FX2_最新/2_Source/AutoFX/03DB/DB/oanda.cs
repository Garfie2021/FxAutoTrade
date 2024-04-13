using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using 定数;
using 共通Data;

namespace DB
{
    public static class oanda
    {
        private static SqlCommand cmd_GetTransaction最終日時;
        private static SqlCommand cmd_SelectマイナスInstrument;
        private static SqlCommand cmd_GetBSポジションCnt;
        private static SqlCommand cmd_Cnt約定数;
        private static SqlCommand cmd_Cnt_Trades_TradeID;
        private static SqlCommand cmd_InsertOrderResponse;
        private static SqlCommand cmd_InsertOrder;
        private static SqlCommand cmd_InsertTrade_リミット変更;
        private static SqlCommand cmd_InsertTrade;
        private static SqlCommand cmd_InsertDeleteTradeResponse;
        private static SqlCommand cmd_InsertTransaction;
        private static SqlCommand cmd_InsertAccount;
        private static SqlCommand cmd_GetSUM差益;
        private static SqlCommand cmd_GetTransactionCnt;
        

        public static void SqlCommandInitialize(SqlConnection cn)
        {
            cmd_GetTransaction最終日時 = new SqlCommand("oanda.spGetTransaction最終日時", cn);
            cmd_GetTransaction最終日時.CommandType = CommandType.StoredProcedure;
            //cmd_GetTransaction最終日時.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetTransaction最終日時.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_GetTransaction最終日時.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_GetTransaction最終日時.Parameters.Add(new SqlParameter("OandaTransaction最終日時", SqlDbType.DateTime));
            cmd_GetTransaction最終日時.Parameters["OandaTransaction最終日時"].Direction = ParameterDirection.Output;
            cmd_GetTransaction最終日時.Parameters.Add(new SqlParameter("OandaTransactionLastId", SqlDbType.BigInt));
            cmd_GetTransaction最終日時.Parameters["OandaTransactionLastId"].Direction = ParameterDirection.Output;

            cmd_SelectマイナスInstrument = new SqlCommand("oanda.spSelectマイナスInstrument", cn);
            cmd_SelectマイナスInstrument.CommandType = CommandType.StoredProcedure;
            //cmd_SelectマイナスInstrument.CommandTimeout = DB定数.CommandTimeout;
            cmd_SelectマイナスInstrument.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_SelectマイナスInstrument.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_SelectマイナスInstrument.Parameters.Add(new SqlParameter("from", SqlDbType.DateTime));
            cmd_SelectマイナスInstrument.Parameters["from"].Direction = ParameterDirection.Input;
            cmd_SelectマイナスInstrument.Parameters.Add(new SqlParameter("to", SqlDbType.DateTime));
            cmd_SelectマイナスInstrument.Parameters["to"].Direction = ParameterDirection.Input;

            cmd_GetBSポジションCnt = new SqlCommand("oanda.spGetBSポジションCnt", cn);
            cmd_GetBSポジションCnt.CommandType = CommandType.StoredProcedure;
            //cmd_GetBSポジションCnt.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetBSポジションCnt.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_GetBSポジションCnt.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_GetBSポジションCnt.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_GetBSポジションCnt.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_GetBSポジションCnt.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_GetBSポジションCnt.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_GetBSポジションCnt.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_GetBSポジションCnt.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_Cnt約定数 = new SqlCommand("oanda.spCnt約定数", cn);
            cmd_Cnt約定数.CommandType = CommandType.StoredProcedure;
            //cmd_Cnt約定数.CommandTimeout = DB定数.CommandTimeout;
            cmd_Cnt約定数.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_Cnt約定数.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_Cnt約定数.Parameters.Add(new SqlParameter("from", SqlDbType.DateTime));
            cmd_Cnt約定数.Parameters["from"].Direction = ParameterDirection.Input;
            cmd_Cnt約定数.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_Cnt約定数.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_Cnt_Trades_TradeID = new SqlCommand("oanda.spCnt_Trades_TradeID", cn);
            cmd_Cnt_Trades_TradeID.CommandType = CommandType.StoredProcedure;
            //cmd_Cnt_Trades_TradeID.CommandTimeout = DB定数.CommandTimeout;
            cmd_Cnt_Trades_TradeID.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_Cnt_Trades_TradeID.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_Cnt_Trades_TradeID.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_Cnt_Trades_TradeID.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_Cnt_Trades_TradeID.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_Cnt_Trades_TradeID.Parameters["Cnt"].Direction = ParameterDirection.Output;

            cmd_InsertOrderResponse = new SqlCommand("oanda.spInsertOrderResponse", cn);
            cmd_InsertOrderResponse.CommandType = CommandType.StoredProcedure;
            //cmd_InsertOrderResponse.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertOrderResponse.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("time", SqlDbType.DateTime));
            cmd_InsertOrderResponse.Parameters["time"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("instrument", SqlDbType.VarChar));
            cmd_InsertOrderResponse.Parameters["instrument"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("BS開始", SqlDbType.Bit));
            cmd_InsertOrderResponse.Parameters["BS開始"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("price", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["price"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_id", SqlDbType.BigInt));
            cmd_InsertOrderResponse.Parameters["Order_id"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_instrument", SqlDbType.VarChar));
            cmd_InsertOrderResponse.Parameters["Order_instrument"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_units", SqlDbType.Int));
            cmd_InsertOrderResponse.Parameters["Order_units"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_side", SqlDbType.VarChar));
            cmd_InsertOrderResponse.Parameters["Order_side"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_type", SqlDbType.VarChar));
            cmd_InsertOrderResponse.Parameters["Order_type"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_time", SqlDbType.DateTime));
            cmd_InsertOrderResponse.Parameters["Order_time"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_price", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["Order_price"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_takeProfit", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["Order_takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_stopLoss", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["Order_stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_expiry", SqlDbType.VarChar));
            cmd_InsertOrderResponse.Parameters["Order_expiry"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_upperBound", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["Order_upperBound"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_lowerBound", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["Order_lowerBound"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("Order_trailingStop", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["Order_trailingStop"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("通貨ペアNo", SqlDbType.TinyInt));
            cmd_InsertOrderResponse.Parameters["通貨ペアNo"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_id", SqlDbType.BigInt));
            cmd_InsertOrderResponse.Parameters["TradeData_id"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_units", SqlDbType.Int));
            cmd_InsertOrderResponse.Parameters["TradeData_units"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_side", SqlDbType.VarChar));
            cmd_InsertOrderResponse.Parameters["TradeData_side"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_instrument", SqlDbType.VarChar));
            cmd_InsertOrderResponse.Parameters["TradeData_instrument"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_time", SqlDbType.DateTime));
            cmd_InsertOrderResponse.Parameters["TradeData_time"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_price", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["TradeData_price"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_takeProfit", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["TradeData_takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_stopLoss", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["TradeData_stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_trailingStop", SqlDbType.Int));
            cmd_InsertOrderResponse.Parameters["TradeData_trailingStop"].Direction = ParameterDirection.Input;
            cmd_InsertOrderResponse.Parameters.Add(new SqlParameter("TradeData_trailingAmount", SqlDbType.Float));
            cmd_InsertOrderResponse.Parameters["TradeData_trailingAmount"].Direction = ParameterDirection.Input;

            cmd_InsertTrade_リミット変更 = new SqlCommand("oanda.spInsertTrade_リミット変更", cn);
            cmd_InsertTrade_リミット変更.CommandType = CommandType.StoredProcedure;
            cmd_InsertTrade_リミット変更.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertTrade_リミット変更.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("リミット変更対象id", SqlDbType.BigInt));
            cmd_InsertTrade_リミット変更.Parameters["リミット変更対象id"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_InsertTrade_リミット変更.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("units", SqlDbType.Int));
            cmd_InsertTrade_リミット変更.Parameters["units"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("side", SqlDbType.VarChar));
            cmd_InsertTrade_リミット変更.Parameters["side"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("instrument", SqlDbType.VarChar));
            cmd_InsertTrade_リミット変更.Parameters["instrument"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("time", SqlDbType.DateTime));
            cmd_InsertTrade_リミット変更.Parameters["time"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("price", SqlDbType.Float));
            cmd_InsertTrade_リミット変更.Parameters["price"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("takeProfit", SqlDbType.Float));
            cmd_InsertTrade_リミット変更.Parameters["takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("stopLoss", SqlDbType.Float));
            cmd_InsertTrade_リミット変更.Parameters["stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("trailingStop", SqlDbType.Int));
            cmd_InsertTrade_リミット変更.Parameters["trailingStop"].Direction = ParameterDirection.Input;
            cmd_InsertTrade_リミット変更.Parameters.Add(new SqlParameter("trailingAmount", SqlDbType.Float));
            cmd_InsertTrade_リミット変更.Parameters["trailingAmount"].Direction = ParameterDirection.Input;

            cmd_InsertTrade = new SqlCommand("oanda.spInsertTrade", cn);
            cmd_InsertTrade.CommandType = CommandType.StoredProcedure;
            cmd_InsertTrade.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertTrade.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_InsertTrade.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("units", SqlDbType.Int));
            cmd_InsertTrade.Parameters["units"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("side", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["side"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("instrument", SqlDbType.VarChar));
            cmd_InsertTrade.Parameters["instrument"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("time", SqlDbType.DateTime));
            cmd_InsertTrade.Parameters["time"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("price", SqlDbType.Float));
            cmd_InsertTrade.Parameters["price"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("takeProfit", SqlDbType.Float));
            cmd_InsertTrade.Parameters["takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("stopLoss", SqlDbType.Float));
            cmd_InsertTrade.Parameters["stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("trailingStop", SqlDbType.Int));
            cmd_InsertTrade.Parameters["trailingStop"].Direction = ParameterDirection.Input;
            cmd_InsertTrade.Parameters.Add(new SqlParameter("trailingAmount", SqlDbType.Float));
            cmd_InsertTrade.Parameters["trailingAmount"].Direction = ParameterDirection.Input;

            cmd_InsertOrder = new SqlCommand("oanda.spInsertOrder", cn);
            cmd_InsertOrder.CommandType = CommandType.StoredProcedure;
            //cmd_InsertOrder.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertOrder.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("注文削除id", SqlDbType.BigInt));
            cmd_InsertOrder.Parameters["注文削除id"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_InsertOrder.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("units", SqlDbType.Int));
            cmd_InsertOrder.Parameters["units"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("side", SqlDbType.VarChar));
            cmd_InsertOrder.Parameters["side"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("type", SqlDbType.VarChar));
            cmd_InsertOrder.Parameters["type"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("instrument", SqlDbType.VarChar));
            cmd_InsertOrder.Parameters["instrument"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("time", SqlDbType.DateTime));
            cmd_InsertOrder.Parameters["time"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("price", SqlDbType.Float));
            cmd_InsertOrder.Parameters["price"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("takeProfit", SqlDbType.Float));
            cmd_InsertOrder.Parameters["takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("stopLoss", SqlDbType.Float));
            cmd_InsertOrder.Parameters["stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("expiry", SqlDbType.Float));
            cmd_InsertOrder.Parameters["expiry"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("upperBound", SqlDbType.Float));
            cmd_InsertOrder.Parameters["upperBound"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("lowerBound", SqlDbType.Float));
            cmd_InsertOrder.Parameters["lowerBound"].Direction = ParameterDirection.Input;
            cmd_InsertOrder.Parameters.Add(new SqlParameter("trailingStop", SqlDbType.Int));
            cmd_InsertOrder.Parameters["trailingStop"].Direction = ParameterDirection.Input;

            cmd_InsertDeleteTradeResponse = new SqlCommand("oanda.spDeleteTradeResponse", cn);
            cmd_InsertDeleteTradeResponse.CommandType = CommandType.StoredProcedure;
            //cmd_InsertDeleteTradeResponse.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertDeleteTradeResponse.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertDeleteTradeResponse.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertDeleteTradeResponse.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_InsertDeleteTradeResponse.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_InsertDeleteTradeResponse.Parameters.Add(new SqlParameter("price", SqlDbType.Float));
            cmd_InsertDeleteTradeResponse.Parameters["price"].Direction = ParameterDirection.Input;
            cmd_InsertDeleteTradeResponse.Parameters.Add(new SqlParameter("instrument", SqlDbType.VarChar));
            cmd_InsertDeleteTradeResponse.Parameters["instrument"].Direction = ParameterDirection.Input;
            cmd_InsertDeleteTradeResponse.Parameters.Add(new SqlParameter("profit", SqlDbType.Float));
            cmd_InsertDeleteTradeResponse.Parameters["profit"].Direction = ParameterDirection.Input;
            cmd_InsertDeleteTradeResponse.Parameters.Add(new SqlParameter("side", SqlDbType.VarChar));
            cmd_InsertDeleteTradeResponse.Parameters["side"].Direction = ParameterDirection.Input;
            cmd_InsertDeleteTradeResponse.Parameters.Add(new SqlParameter("time", SqlDbType.DateTime));
            cmd_InsertDeleteTradeResponse.Parameters["time"].Direction = ParameterDirection.Input;

            cmd_InsertTransaction = new SqlCommand("oanda.spInsertTransaction", cn);
            cmd_InsertTransaction.CommandType = CommandType.StoredProcedure;
            //cmd_InsertTransaction.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertTransaction.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_InsertTransaction.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("accountId", SqlDbType.Int));
            cmd_InsertTransaction.Parameters["accountId"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("time", SqlDbType.DateTime));
            cmd_InsertTransaction.Parameters["time"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("type", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["type"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("instrument", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["instrument"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("side", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["side"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("units", SqlDbType.Int));
            cmd_InsertTransaction.Parameters["units"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("price", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["price"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("lowerBound", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["lowerBound"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("upperBound", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["upperBound"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("takeProfitPrice", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["takeProfitPrice"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("stopLossPrice", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["stopLossPrice"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("trailingStopLossDistance", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["trailingStopLossDistance"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("pl", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["pl"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("interest", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["interest"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("accountBalance", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["accountBalance"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeId", SqlDbType.BigInt));
            cmd_InsertTransaction.Parameters["tradeId"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("orderId", SqlDbType.BigInt));
            cmd_InsertTransaction.Parameters["orderId"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_id", SqlDbType.BigInt));
            cmd_InsertTransaction.Parameters["tradeOpened_id"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_units", SqlDbType.Int));
            cmd_InsertTransaction.Parameters["tradeOpened_units"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_side", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["tradeOpened_side"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_instrument", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["tradeOpened_instrument"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_time", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["tradeOpened_time"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_price", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeOpened_price"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_takeProfit", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeOpened_takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_stopLoss", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeOpened_stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_trailingStop", SqlDbType.Int));
            cmd_InsertTransaction.Parameters["tradeOpened_trailingStop"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeOpened_trailingAmount", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeOpened_trailingAmount"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_id", SqlDbType.BigInt));
            cmd_InsertTransaction.Parameters["tradeReduced_id"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_units", SqlDbType.Int));
            cmd_InsertTransaction.Parameters["tradeReduced_units"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_side", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["tradeReduced_side"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_instrument", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["tradeReduced_instrument"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_time", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["tradeReduced_time"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_price", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeReduced_price"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_takeProfit", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeReduced_takeProfit"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_stopLoss", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeReduced_stopLoss"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_trailingStop", SqlDbType.Int));
            cmd_InsertTransaction.Parameters["tradeReduced_trailingStop"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("tradeReduced_trailingAmount", SqlDbType.Float));
            cmd_InsertTransaction.Parameters["tradeReduced_trailingAmount"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("reason", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["reason"].Direction = ParameterDirection.Input;
            cmd_InsertTransaction.Parameters.Add(new SqlParameter("expiry", SqlDbType.VarChar));
            cmd_InsertTransaction.Parameters["expiry"].Direction = ParameterDirection.Input;

            cmd_InsertAccount = new SqlCommand("oanda.spInsertAccount", cn);
            cmd_InsertAccount.CommandType = CommandType.StoredProcedure;
            //cmd_InsertAccount.CommandTimeout = DB定数.CommandTimeout;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_InsertAccount.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("日時", SqlDbType.DateTime));
            cmd_InsertAccount.Parameters["日時"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("accountId", SqlDbType.Int));
            cmd_InsertAccount.Parameters["accountId"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("accountName", SqlDbType.VarChar));
            cmd_InsertAccount.Parameters["accountName"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("accountCurrency", SqlDbType.VarChar));
            cmd_InsertAccount.Parameters["accountCurrency"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("marginRate", SqlDbType.Float));
            cmd_InsertAccount.Parameters["marginRate"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("balance", SqlDbType.Float));
            cmd_InsertAccount.Parameters["balance"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("unrealizedPl", SqlDbType.Float));
            cmd_InsertAccount.Parameters["unrealizedPl"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("realizedPl", SqlDbType.Float));
            cmd_InsertAccount.Parameters["realizedPl"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("marginUsed", SqlDbType.Float));
            cmd_InsertAccount.Parameters["marginUsed"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("marginAvail", SqlDbType.Float));
            cmd_InsertAccount.Parameters["marginAvail"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("openTrades", SqlDbType.Int));
            cmd_InsertAccount.Parameters["openTrades"].Direction = ParameterDirection.Input;
            cmd_InsertAccount.Parameters.Add(new SqlParameter("openOrders", SqlDbType.Int));
            cmd_InsertAccount.Parameters["openOrders"].Direction = ParameterDirection.Input;

            cmd_GetSUM差益 = new SqlCommand("oanda.spGetSUM差益", cn);
            cmd_GetSUM差益.CommandType = CommandType.StoredProcedure;
            //cmd_GetSUM差益.CommandTimeout = DB定数.CommandTimeout;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_GetSUM差益.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("FromDate", SqlDbType.DateTime));
            cmd_GetSUM差益.Parameters["FromDate"].Direction = ParameterDirection.Input;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("ToDate", SqlDbType.DateTime));
            cmd_GetSUM差益.Parameters["ToDate"].Direction = ParameterDirection.Input;
            cmd_GetSUM差益.Parameters.Add(new SqlParameter("利益", SqlDbType.Float));
            cmd_GetSUM差益.Parameters["利益"].Direction = ParameterDirection.Output;

            cmd_GetTransactionCnt = new SqlCommand("oanda.spGetTransactionCnt", cn);
            cmd_GetTransactionCnt.CommandType = CommandType.StoredProcedure;
            cmd_GetTransactionCnt.Parameters.Add(new SqlParameter("口座No", SqlDbType.Int));
            cmd_GetTransactionCnt.Parameters["口座No"].Direction = ParameterDirection.Input;
            cmd_GetTransactionCnt.Parameters.Add(new SqlParameter("id", SqlDbType.BigInt));
            cmd_GetTransactionCnt.Parameters["id"].Direction = ParameterDirection.Input;
            cmd_GetTransactionCnt.Parameters.Add(new SqlParameter("accountId", SqlDbType.Int));
            cmd_GetTransactionCnt.Parameters["accountId"].Direction = ParameterDirection.Input;
            cmd_GetTransactionCnt.Parameters.Add(new SqlParameter("time", SqlDbType.DateTime));
            cmd_GetTransactionCnt.Parameters["time"].Direction = ParameterDirection.Input;
            cmd_GetTransactionCnt.Parameters.Add(new SqlParameter("Cnt", SqlDbType.Int));
            cmd_GetTransactionCnt.Parameters["Cnt"].Direction = ParameterDirection.Output;

        }

        public static int GetTransactionCnt(int 口座No, OandaTransaction transaction)
        {
            cmd_GetTransactionCnt.Parameters["口座No"].Value = 口座No;
            cmd_GetTransactionCnt.Parameters["id"].Value = transaction.id;
            cmd_GetTransactionCnt.Parameters["accountId"].Value = transaction.accountId;
            cmd_GetTransactionCnt.Parameters["time"].Value = transaction.time;

            cmd_GetTransactionCnt.ExecuteNonQuery();

            return (int)cmd_GetTransactionCnt.Parameters["Cnt"].Value;
        }

        public static void GetTransaction最終日時()
        {
            try
            {
                cmd_GetTransaction最終日時.Parameters["口座No"].Value = FormData.口座No;

                cmd_GetTransaction最終日時.ExecuteNonQuery();

                if (cmd_GetTransaction最終日時.Parameters["OandaTransaction最終日時"].Value == DBNull.Value)
                {
                    FormData.OandaTransaction最終日時 = DateTime.MinValue;
                    FormData.OandaTransactionLastId = 0;
                }
                else
                {
                    FormData.OandaTransaction最終日時 = (DateTime)cmd_GetTransaction最終日時.Parameters["OandaTransaction最終日時"].Value;
                    FormData.OandaTransactionLastId = (long)cmd_GetTransaction最終日時.Parameters["OandaTransactionLastId"].Value;
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                throw;
            }
        }

        public static List<マイナスInstrument> SelectマイナスInstrument(DateTime 開始日時, DateTime 終了日時)
        {
            try
            {
                cmd_SelectマイナスInstrument.Parameters["口座No"].Value = FormData.口座No;
                cmd_SelectマイナスInstrument.Parameters["from"].Value = 開始日時;
                cmd_SelectマイナスInstrument.Parameters["to"].Value = 終了日時;

                var マイナスInstrumentList = new List<マイナスInstrument>();

                using (var reader = cmd_SelectマイナスInstrument.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        マイナスInstrumentList.Add(new マイナスInstrument()
                        {
                            id = (long)reader["id"],
                            time = (DateTime)reader["time"],
                            instrument = (string)reader["instrument"],
                            interest = (double)reader["interest"]
                        });
                    }
                }

                return マイナスInstrumentList;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                throw;
            }
        }

        public static int GetBSポジションCnt(通貨ぺア取引状況 通貨ぺア取引状況, long id)
        {
            try
            {
                cmd_GetBSポジションCnt.Parameters["口座No"].Value = FormData.口座No;
                cmd_GetBSポジションCnt.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_GetBSポジションCnt.Parameters["id"].Value = id;

                cmd_GetBSポジションCnt.ExecuteNonQuery();

                return (int)cmd_GetBSポジションCnt.Parameters["Cnt"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("id : " + id);
                throw;
            }
        }

        public static int Cnt約定数(DateTime from)
        {
            try
            {
                cmd_Cnt約定数.Parameters["口座No"].Value = FormData.口座No;
                cmd_Cnt約定数.Parameters["from"].Value = from;

                cmd_Cnt約定数.ExecuteNonQuery();

                return (int)cmd_Cnt約定数.Parameters["Cnt"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("from : " + from.ToString());
                throw;
            }
        }

        public static int Cnt_Trades_TradeID(long id)
        {
            try
            {
                cmd_Cnt_Trades_TradeID.Parameters["口座No"].Value = FormData.口座No;
                cmd_Cnt_Trades_TradeID.Parameters["id"].Value = id;

                cmd_Cnt_Trades_TradeID.ExecuteNonQuery();

                return (int)cmd_Cnt_Trades_TradeID.Parameters["Cnt"].Value;
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("id : " + id);
                throw;
            }
        }

        public static void InsertOrderResponse(通貨ぺア取引状況 通貨ぺア取引状況, PostOrderResponse postOrder)
        {
            try
            {
                cmd_InsertOrderResponse.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertOrderResponse.Parameters["通貨ペアNo"].Value = 通貨ぺア取引状況.通貨ペアNo;
                cmd_InsertOrderResponse.Parameters["time"].Value = DateTime.Parse(postOrder.time);
                cmd_InsertOrderResponse.Parameters["instrument"].Value = postOrder.instrument;
                cmd_InsertOrderResponse.Parameters["BS開始"].Value = 通貨ぺア取引状況.BS開始;
                cmd_InsertOrderResponse.Parameters["price"].Value = postOrder.price;

                if (postOrder.orderOpened == null)
                {
                    cmd_InsertOrderResponse.Parameters["Order_id"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_instrument"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_units"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_side"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_type"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_time"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_price"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_takeProfit"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_stopLoss"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_expiry"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_upperBound"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_lowerBound"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["Order_trailingStop"].Value = DBNull.Value;
                }
                else
                {
                    if (postOrder.orderOpened == null) cmd_InsertOrderResponse.Parameters["Order_id"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["Order_id"].Value = postOrder.orderOpened.id;

                    if (postOrder.orderOpened.instrument == null) cmd_InsertOrderResponse.Parameters["Order_instrument"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["Order_instrument"].Value = postOrder.orderOpened.instrument;

                    cmd_InsertOrderResponse.Parameters["Order_units"].Value = postOrder.orderOpened.units;

                    if (postOrder.orderOpened.side == null) cmd_InsertOrderResponse.Parameters["Order_side"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["Order_side"].Value = postOrder.orderOpened.side;

                    if (postOrder.orderOpened.type == null) cmd_InsertOrderResponse.Parameters["Order_type"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["Order_type"].Value = postOrder.orderOpened.type;

                    if (postOrder.orderOpened.time == null) cmd_InsertOrderResponse.Parameters["Order_time"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["Order_time"].Value = DateTime.Parse(postOrder.orderOpened.time);

                    cmd_InsertOrderResponse.Parameters["Order_price"].Value = postOrder.orderOpened.price;

                    cmd_InsertOrderResponse.Parameters["Order_takeProfit"].Value = postOrder.orderOpened.takeProfit;

                    cmd_InsertOrderResponse.Parameters["Order_stopLoss"].Value = postOrder.orderOpened.stopLoss;

                    if (postOrder.orderOpened.expiry == null) cmd_InsertOrderResponse.Parameters["Order_expiry"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["Order_expiry"].Value = postOrder.orderOpened.expiry;

                    cmd_InsertOrderResponse.Parameters["Order_upperBound"].Value = postOrder.orderOpened.upperBound;

                    cmd_InsertOrderResponse.Parameters["Order_lowerBound"].Value = postOrder.orderOpened.lowerBound;

                    cmd_InsertOrderResponse.Parameters["Order_trailingStop"].Value = postOrder.orderOpened.trailingStop;
                }

                if (postOrder.tradeOpened == null)
                {
                    cmd_InsertOrderResponse.Parameters["TradeData_id"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_units"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_side"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_instrument"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_time"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_price"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_takeProfit"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_stopLoss"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_trailingStop"].Value = DBNull.Value;
                    cmd_InsertOrderResponse.Parameters["TradeData_trailingAmount"].Value = DBNull.Value;
                }
                else
                {
                    cmd_InsertOrderResponse.Parameters["TradeData_id"].Value = postOrder.tradeOpened.id;

                    cmd_InsertOrderResponse.Parameters["TradeData_units"].Value = postOrder.tradeOpened.units;

                    if (postOrder.tradeOpened.side == null) cmd_InsertOrderResponse.Parameters["TradeData_side"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["TradeData_side"].Value = postOrder.tradeOpened.side;

                    if (postOrder.tradeOpened.instrument == null) cmd_InsertOrderResponse.Parameters["TradeData_instrument"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["TradeData_instrument"].Value = postOrder.tradeOpened.instrument;

                    if (postOrder.tradeOpened.time == null) cmd_InsertOrderResponse.Parameters["TradeData_time"].Value = DBNull.Value;
                    else cmd_InsertOrderResponse.Parameters["TradeData_time"].Value = DateTime.Parse(postOrder.tradeOpened.time);

                    cmd_InsertOrderResponse.Parameters["TradeData_price"].Value = postOrder.tradeOpened.price;

                    cmd_InsertOrderResponse.Parameters["TradeData_takeProfit"].Value = postOrder.tradeOpened.takeProfit;

                    cmd_InsertOrderResponse.Parameters["TradeData_stopLoss"].Value = postOrder.tradeOpened.stopLoss;

                    cmd_InsertOrderResponse.Parameters["TradeData_trailingStop"].Value = postOrder.tradeOpened.trailingStop;

                    cmd_InsertOrderResponse.Parameters["TradeData_trailingAmount"].Value = postOrder.tradeOpened.trailingAmount;
                }

                cmd_InsertOrderResponse.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("通貨ペアNo : " + 通貨ぺア取引状況.通貨ペアNo.ToString());
                ログ.ログ書き出し("instrument : " + postOrder.instrument);
                ログ.ログ書き出し("time : " + postOrder.time);
                ログ.ログ書き出し("price : " + postOrder.price);
                ログ.ログ書き出し("Order_id : " + postOrder.orderOpened.id.ToString());
                ログ.ログ書き出し("Order_instrument : " + postOrder.orderOpened.instrument);
                ログ.ログ書き出し("Order_units : " + postOrder.orderOpened.units.ToString());
                ログ.ログ書き出し("Order_side : " + postOrder.orderOpened.side);
                ログ.ログ書き出し("Order_type : " + postOrder.orderOpened.type);
                ログ.ログ書き出し("Order_type : " + postOrder.orderOpened.type);
                ログ.ログ書き出し("Order_time : " + postOrder.orderOpened.time);
                ログ.ログ書き出し("Order_price : " + postOrder.orderOpened.price.ToString());
                ログ.ログ書き出し("Order_takeProfit : " + postOrder.orderOpened.takeProfit.ToString());
                ログ.ログ書き出し("Order_stopLoss : " + postOrder.orderOpened.stopLoss.ToString());
                ログ.ログ書き出し("Order_expiry : " + postOrder.orderOpened.expiry);
                ログ.ログ書き出し("Order_upperBound : " + postOrder.orderOpened.upperBound.ToString());
                ログ.ログ書き出し("Order_lowerBound : " + postOrder.orderOpened.lowerBound.ToString());
                ログ.ログ書き出し("Order_trailingStop : " + postOrder.orderOpened.trailingStop.ToString());
                ログ.ログ書き出し("TradeData_id : " + postOrder.tradeOpened.id.ToString());
                ログ.ログ書き出し("TradeData_units : " + postOrder.tradeOpened.units.ToString());
                ログ.ログ書き出し("TradeData_side : " + postOrder.tradeOpened.side);
                ログ.ログ書き出し("TradeData_instrument : " + postOrder.tradeOpened.instrument);
                ログ.ログ書き出し("TradeData_time : " + postOrder.tradeOpened.time);
                ログ.ログ書き出し("TradeData_price : " + postOrder.tradeOpened.price.ToString());
                ログ.ログ書き出し("TradeData_takeProfit : " + postOrder.tradeOpened.takeProfit.ToString());
                ログ.ログ書き出し("TradeData_stopLoss : " + postOrder.tradeOpened.stopLoss.ToString());
                ログ.ログ書き出し("TradeData_trailingStop : " + postOrder.tradeOpened.trailingStop.ToString());
                ログ.ログ書き出し("TradeData_trailingAmount : " + postOrder.tradeOpened.trailingAmount.ToString());
                throw;
            }
        }

        public static void InsertOrder(Order order, long 注文削除id)
        {
            try
            {
                cmd_InsertOrder.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertOrder.Parameters["注文削除id"].Value = 注文削除id;
                cmd_InsertOrder.Parameters["id"].Value = order.id;
                cmd_InsertOrder.Parameters["units"].Value = order.units;
                cmd_InsertOrder.Parameters["side"].Value = order.side;
                cmd_InsertOrder.Parameters["type"].Value = order.type;
                cmd_InsertOrder.Parameters["instrument"].Value = order.instrument;
                cmd_InsertOrder.Parameters["time"].Value = DateTime.Parse(order.time);
                cmd_InsertOrder.Parameters["price"].Value = order.price;
                cmd_InsertOrder.Parameters["takeProfit"].Value = order.takeProfit;
                cmd_InsertOrder.Parameters["stopLoss"].Value = order.stopLoss;
                cmd_InsertOrder.Parameters["expiry"].Value = order.expiry;
                cmd_InsertOrder.Parameters["upperBound"].Value = order.upperBound;
                cmd_InsertOrder.Parameters["lowerBound"].Value = order.lowerBound;
                cmd_InsertOrder.Parameters["trailingStop"].Value = order.trailingStop;

                cmd_InsertOrder.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("注文削除id : " + 注文削除id.ToString());
                ログ.ログ書き出し("order.id : " + order.id);
                ログ.ログ書き出し("order.units : " + order.units);
                ログ.ログ書き出し("order.side : " + order.side);
                ログ.ログ書き出し("order.instrument : " + order.instrument);
                ログ.ログ書き出し("DateTime.Parse(order.time) : " + DateTime.Parse(order.time));
                ログ.ログ書き出し("order.price : " + order.price);
                ログ.ログ書き出し("order.takeProfit : " + order.takeProfit);
                ログ.ログ書き出し("order.stopLoss : " + order.stopLoss);
                ログ.ログ書き出し("order.trailingStop : " + order.trailingStop);
                throw;
            }
        }

        public static void InsertTrade_リミット変更(TradeData trade, long リミット変更対象id)
        {
            try
            {
                cmd_InsertTrade_リミット変更.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertTrade_リミット変更.Parameters["リミット変更対象id"].Value = リミット変更対象id;
                cmd_InsertTrade_リミット変更.Parameters["id"].Value = trade.id;
                cmd_InsertTrade_リミット変更.Parameters["units"].Value = trade.units;
                cmd_InsertTrade_リミット変更.Parameters["side"].Value = trade.side;
                cmd_InsertTrade_リミット変更.Parameters["instrument"].Value = trade.instrument;
                cmd_InsertTrade_リミット変更.Parameters["time"].Value = DateTime.Parse(trade.time);
                cmd_InsertTrade_リミット変更.Parameters["price"].Value = trade.price;
                cmd_InsertTrade_リミット変更.Parameters["takeProfit"].Value = trade.takeProfit;
                cmd_InsertTrade_リミット変更.Parameters["stopLoss"].Value = trade.stopLoss;
                cmd_InsertTrade_リミット変更.Parameters["trailingStop"].Value = trade.trailingStop;
                cmd_InsertTrade_リミット変更.Parameters["trailingAmount"].Value = trade.trailingAmount;

                cmd_InsertTrade_リミット変更.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("リミット変更対象id : " + リミット変更対象id.ToString());
                ログ.ログ書き出し("trade.id : " + trade.id);
                ログ.ログ書き出し("trade.units : " + trade.units);
                ログ.ログ書き出し("trade.side : " + trade.side);
                ログ.ログ書き出し("trade.instrument : " + trade.instrument);
                ログ.ログ書き出し("DateTime.Parse(trade.time) : " + DateTime.Parse(trade.time));
                ログ.ログ書き出し("trade.price : " + trade.price);
                ログ.ログ書き出し("trade.takeProfit : " + trade.takeProfit);
                ログ.ログ書き出し("trade.stopLoss : " + trade.stopLoss);
                ログ.ログ書き出し("trade.trailingStop : " + trade.trailingStop);
                ログ.ログ書き出し("trade.trailingAmount : " + trade.trailingAmount);
                throw;
            }
        }

        public static void InsertTrade(TradeData trade)
        {
            try
            {
                cmd_InsertTrade.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertTrade.Parameters["id"].Value = trade.id;
                cmd_InsertTrade.Parameters["units"].Value = trade.units;
                cmd_InsertTrade.Parameters["side"].Value = trade.side;
                cmd_InsertTrade.Parameters["instrument"].Value = trade.instrument;
                cmd_InsertTrade.Parameters["time"].Value = DateTime.Parse(trade.time);
                cmd_InsertTrade.Parameters["price"].Value = trade.price;
                cmd_InsertTrade.Parameters["takeProfit"].Value = trade.takeProfit;
                cmd_InsertTrade.Parameters["stopLoss"].Value = trade.stopLoss;
                cmd_InsertTrade.Parameters["trailingStop"].Value = trade.trailingStop;
                cmd_InsertTrade.Parameters["trailingAmount"].Value = trade.trailingAmount;

                cmd_InsertTrade.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("trade.id : " + trade.id);
                ログ.ログ書き出し("trade.units : " + trade.units);
                ログ.ログ書き出し("trade.side : " + trade.side);
                ログ.ログ書き出し("trade.instrument : " + trade.instrument);
                ログ.ログ書き出し("DateTime.Parse(trade.time) : " + DateTime.Parse(trade.time));
                ログ.ログ書き出し("trade.price : " + trade.price);
                ログ.ログ書き出し("trade.takeProfit : " + trade.takeProfit);
                ログ.ログ書き出し("trade.stopLoss : " + trade.stopLoss);
                ログ.ログ書き出し("trade.trailingStop : " + trade.trailingStop);
                ログ.ログ書き出し("trade.trailingAmount : " + trade.trailingAmount);
                throw;
            }
        }

        public static void InsertDeleteTradeResponse(DeleteTradeResponse deleteTrade)
        {
            try
            {
                cmd_InsertDeleteTradeResponse.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertDeleteTradeResponse.Parameters["id"].Value = deleteTrade.id;
                cmd_InsertDeleteTradeResponse.Parameters["price"].Value = deleteTrade.price;
                cmd_InsertDeleteTradeResponse.Parameters["instrument"].Value = deleteTrade.instrument;
                cmd_InsertDeleteTradeResponse.Parameters["profit"].Value = deleteTrade.profit;
                cmd_InsertDeleteTradeResponse.Parameters["side"].Value = deleteTrade.side;
                cmd_InsertDeleteTradeResponse.Parameters["time"].Value = DateTime.Parse(deleteTrade.time);

                cmd_InsertDeleteTradeResponse.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("deleteTrade.id : " + deleteTrade.id);
                ログ.ログ書き出し("deleteTrade.price : " + deleteTrade.price);
                ログ.ログ書き出し("deleteTrade.instrument : " + deleteTrade.instrument);
                ログ.ログ書き出し("deleteTrade.profit : " + deleteTrade.profit);
                ログ.ログ書き出し("deleteTrade.side : " + deleteTrade.side);
                ログ.ログ書き出し("deleteTrade.time : " + DateTime.Parse(deleteTrade.time));
                throw;
            }
        }

        public static void InsertTransaction(int 口座No, OandaTransaction transaction)
        {
            try
            {
                cmd_InsertTransaction.Parameters["口座No"].Value = 口座No;
                cmd_InsertTransaction.Parameters["id"].Value = transaction.id;
                cmd_InsertTransaction.Parameters["accountId"].Value = transaction.accountId;
                cmd_InsertTransaction.Parameters["time"].Value = DateTime.Parse(transaction.time);
                cmd_InsertTransaction.Parameters["type"].Value = transaction.type;
                cmd_InsertTransaction.Parameters["instrument"].Value = transaction.instrument == null ? "" : transaction.instrument;
                cmd_InsertTransaction.Parameters["side"].Value = transaction.side == null ? "" : transaction.side;
                cmd_InsertTransaction.Parameters["units"].Value = transaction.units;
                cmd_InsertTransaction.Parameters["price"].Value = transaction.price;
                cmd_InsertTransaction.Parameters["lowerBound"].Value = transaction.lowerBound;
                cmd_InsertTransaction.Parameters["upperBound"].Value = transaction.upperBound;
                cmd_InsertTransaction.Parameters["takeProfitPrice"].Value = transaction.takeProfitPrice;
                cmd_InsertTransaction.Parameters["stopLossPrice"].Value = transaction.stopLossPrice;
                cmd_InsertTransaction.Parameters["trailingStopLossDistance"].Value = transaction.trailingStopLossDistance;
                cmd_InsertTransaction.Parameters["pl"].Value = transaction.pl;
                cmd_InsertTransaction.Parameters["interest"].Value = transaction.interest;
                cmd_InsertTransaction.Parameters["accountBalance"].Value = transaction.accountBalance;
                cmd_InsertTransaction.Parameters["tradeId"].Value = transaction.tradeId;
                cmd_InsertTransaction.Parameters["orderId"].Value = transaction.orderId;
                cmd_InsertTransaction.Parameters["tradeOpened_id"].Value = transaction.tradeOpened == null ? 0 : transaction.tradeOpened.id;
                cmd_InsertTransaction.Parameters["tradeOpened_units"].Value = transaction.tradeOpened == null ? 0 : transaction.tradeOpened.units;
                cmd_InsertTransaction.Parameters["tradeOpened_side"].Value = transaction.tradeOpened == null ? "" : transaction.tradeOpened.side == null ? "" : transaction.tradeOpened.side;
                cmd_InsertTransaction.Parameters["tradeOpened_instrument"].Value = transaction.tradeOpened == null ? "" : transaction.tradeOpened.instrument == null ? "" : transaction.tradeOpened.instrument;
                cmd_InsertTransaction.Parameters["tradeOpened_time"].Value = transaction.tradeOpened == null ? "" : transaction.tradeOpened.time == null ? "" : transaction.tradeOpened.time;
                cmd_InsertTransaction.Parameters["tradeOpened_price"].Value = transaction.tradeOpened == null ? 0 : transaction.tradeOpened.price;
                cmd_InsertTransaction.Parameters["tradeOpened_takeProfit"].Value = transaction.tradeOpened == null ? 0 : transaction.tradeOpened.takeProfit;
                cmd_InsertTransaction.Parameters["tradeOpened_stopLoss"].Value = transaction.tradeOpened == null ? 0 : transaction.tradeOpened.stopLoss;
                cmd_InsertTransaction.Parameters["tradeOpened_trailingStop"].Value = transaction.tradeOpened == null ? 0 : transaction.tradeOpened.trailingStop;
                cmd_InsertTransaction.Parameters["tradeOpened_trailingAmount"].Value = transaction.tradeOpened == null ? 0 : transaction.tradeOpened.trailingAmount;
                cmd_InsertTransaction.Parameters["tradeReduced_id"].Value = transaction.tradeReduced == null ? 0 : transaction.tradeReduced.id;
                cmd_InsertTransaction.Parameters["tradeReduced_units"].Value = transaction.tradeReduced == null ? 0 : transaction.tradeReduced.units;
                cmd_InsertTransaction.Parameters["tradeReduced_side"].Value = transaction.tradeReduced == null ? "" : transaction.tradeReduced.side == null ? "" : transaction.tradeReduced.side;
                cmd_InsertTransaction.Parameters["tradeReduced_instrument"].Value = transaction.tradeReduced == null ? "" : transaction.tradeReduced.instrument == null ? "" : transaction.tradeReduced.instrument;
                cmd_InsertTransaction.Parameters["tradeReduced_time"].Value = transaction.tradeReduced == null ? "" : transaction.tradeReduced.time == null ? "" : transaction.tradeReduced.time;
                cmd_InsertTransaction.Parameters["tradeReduced_price"].Value = transaction.tradeReduced == null ? 0 : transaction.tradeReduced.price;
                cmd_InsertTransaction.Parameters["tradeReduced_takeProfit"].Value = transaction.tradeReduced == null ? 0 : transaction.tradeReduced.takeProfit;
                cmd_InsertTransaction.Parameters["tradeReduced_stopLoss"].Value = transaction.tradeReduced == null ? 0 : transaction.tradeReduced.stopLoss;
                cmd_InsertTransaction.Parameters["tradeReduced_trailingStop"].Value = transaction.tradeReduced == null ? 0 : transaction.tradeReduced.trailingStop;
                cmd_InsertTransaction.Parameters["tradeReduced_trailingAmount"].Value = transaction.tradeReduced == null ? 0 : transaction.tradeReduced.trailingAmount;
                cmd_InsertTransaction.Parameters["reason"].Value = transaction.reason == null ? "" : transaction.reason;
                cmd_InsertTransaction.Parameters["expiry"].Value = transaction.expiry == null ? "" : transaction.expiry;

                cmd_InsertTransaction.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("transaction.id : " + transaction.id);
                ログ.ログ書き出し("transaction.accountId : " + transaction.accountId);
                ログ.ログ書き出し("transaction.time : " + DateTime.Parse(transaction.time));
                ログ.ログ書き出し("transaction.instrument : " + transaction.instrument == null ? "" : transaction.instrument);
                ログ.ログ書き出し("transaction.side : " + transaction.side == null ? "" : transaction.side);
                ログ.ログ書き出し("transaction.units : " + transaction.units);
                ログ.ログ書き出し("transaction.price : " + transaction.price);
                ログ.ログ書き出し("transaction.lowerBound : " + transaction.lowerBound);
                ログ.ログ書き出し("transaction.upperBound : " + transaction.upperBound);
                ログ.ログ書き出し("transaction.takeProfitPrice : " + transaction.takeProfitPrice);
                ログ.ログ書き出し("transaction.stopLossPrice : " + transaction.stopLossPrice);
                ログ.ログ書き出し("transaction.trailingStopLossDistance : " + transaction.trailingStopLossDistance);
                ログ.ログ書き出し("transaction.pl : " + transaction.pl);
                ログ.ログ書き出し("transaction.interest : " + transaction.interest);
                ログ.ログ書き出し("transaction.accountBalance : " + transaction.accountBalance);
                ログ.ログ書き出し("transaction.tradeId : " + transaction.tradeId);
                ログ.ログ書き出し("transaction.orderId : " + transaction.orderId);
                ログ.ログ書き出し("transaction.tradeOpened.id : " + transaction.tradeOpened == null ? "0" : transaction.tradeOpened.id.ToString());
                ログ.ログ書き出し("transaction.tradeOpened.units : " + transaction.tradeOpened == null ? "0" : transaction.tradeOpened.units.ToString());
                ログ.ログ書き出し("transaction.tradeOpened.side : " + transaction.tradeOpened == null ? "" : transaction.tradeOpened.side == null ? "" : transaction.tradeOpened.side);
                ログ.ログ書き出し("transaction.tradeOpened.instrument : " + transaction.tradeOpened == null ? "" : transaction.tradeOpened.instrument == null ? "" : transaction.tradeOpened.instrument);
                ログ.ログ書き出し("transaction.tradeOpened.time : " + transaction.tradeOpened == null ? "" : transaction.tradeOpened.time == null ? "" : transaction.tradeOpened.time);
                ログ.ログ書き出し("transaction.tradeOpened.price : " + transaction.tradeOpened == null ? "0" : transaction.tradeOpened.price.ToString());
                ログ.ログ書き出し("transaction.tradeOpened.takeProfit : " + transaction.tradeOpened == null ? "0" : transaction.tradeOpened.takeProfit.ToString());
                ログ.ログ書き出し("transaction.tradeOpened.stopLoss : " + transaction.tradeOpened == null ? "0" : transaction.tradeOpened.stopLoss.ToString());
                ログ.ログ書き出し("transaction.tradeOpened.trailingStop : " + transaction.tradeOpened == null ? "0" : transaction.tradeOpened.trailingStop.ToString());
                ログ.ログ書き出し("transaction.tradeOpened.trailingAmount : " + transaction.tradeOpened == null ? "0" : transaction.tradeOpened.trailingAmount.ToString());
                ログ.ログ書き出し("transaction.tradeReduced.id : " + transaction.tradeReduced == null ? "0" : transaction.tradeReduced.id.ToString());
                ログ.ログ書き出し("transaction.tradeReduced.units : " + transaction.tradeReduced == null ? "0" : transaction.tradeReduced.units.ToString());
                ログ.ログ書き出し("transaction.tradeReduced.side : " + transaction.tradeReduced == null ? "" : transaction.tradeReduced.side == null ? "" : transaction.tradeReduced.side);
                ログ.ログ書き出し("transaction.tradeReduced.instrument : " + transaction.tradeReduced == null ? "" : transaction.tradeReduced.instrument == null ? "" : transaction.tradeReduced.instrument);
                ログ.ログ書き出し("transaction.tradeReduced.time : " + transaction.tradeReduced == null ? "" : transaction.tradeReduced.time == null ? "" : transaction.tradeReduced.time);
                ログ.ログ書き出し("transaction.tradeReduced.price : " + transaction.tradeReduced == null ? "0" : transaction.tradeReduced.price.ToString());
                ログ.ログ書き出し("transaction.tradeReduced.takeProfit : " + transaction.tradeReduced == null ? "0" : transaction.tradeReduced.takeProfit.ToString());
                ログ.ログ書き出し("transaction.tradeReduced.stopLoss : " + transaction.tradeReduced == null ? "0" : transaction.tradeReduced.stopLoss.ToString());
                ログ.ログ書き出し("transaction.tradeReduced.trailingStop : " + transaction.tradeReduced == null ? "0" : transaction.tradeReduced.trailingStop.ToString());
                ログ.ログ書き出し("transaction.tradeReduced.trailingAmount : " + transaction.tradeReduced == null ? "0" : transaction.tradeReduced.trailingAmount.ToString());
                ログ.ログ書き出し("transaction.reason : " + transaction.reason == null ? "" : transaction.reason);
                ログ.ログ書き出し("transaction.expiry : " + transaction.expiry == null ? "" : transaction.expiry);
                throw;
            }
        }

        public static void InsertAccount(OandaAccount oandaAccount)
        {
            try
            {
                cmd_InsertAccount.Parameters["口座No"].Value = FormData.口座No;
                cmd_InsertAccount.Parameters["日時"].Value = DateTime.Now;
                cmd_InsertAccount.Parameters["accountId"].Value = oandaAccount.accountId;
                cmd_InsertAccount.Parameters["accountName"].Value = oandaAccount.accountName;
                cmd_InsertAccount.Parameters["accountCurrency"].Value = oandaAccount.accountCurrency;
                cmd_InsertAccount.Parameters["marginRate"].Value = oandaAccount.marginRate;
                cmd_InsertAccount.Parameters["balance"].Value = oandaAccount.balance;
                cmd_InsertAccount.Parameters["unrealizedPl"].Value = oandaAccount.unrealizedPl;
                cmd_InsertAccount.Parameters["realizedPl"].Value = oandaAccount.realizedPl;
                cmd_InsertAccount.Parameters["marginUsed"].Value = oandaAccount.marginUsed;
                cmd_InsertAccount.Parameters["marginAvail"].Value = oandaAccount.marginAvail;
                cmd_InsertAccount.Parameters["openTrades"].Value = oandaAccount.openTrades;
                cmd_InsertAccount.Parameters["openOrders"].Value = oandaAccount.openOrders;

                cmd_InsertAccount.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("DateTime.Now : " + DateTime.Now);
                ログ.ログ書き出し("oandaAccount.accountId : " + oandaAccount.accountId);
                ログ.ログ書き出し("oandaAccount.accountName : " + oandaAccount.accountName);
                ログ.ログ書き出し("oandaAccount.accountCurrency : " + oandaAccount.accountCurrency);
                ログ.ログ書き出し("oandaAccount.marginRate : " + oandaAccount.marginRate);
                ログ.ログ書き出し("oandaAccount.balance : " + oandaAccount.balance);
                ログ.ログ書き出し("oandaAccount.unrealizedPl : " + oandaAccount.unrealizedPl);
                ログ.ログ書き出し("oandaAccount.realizedPl : " + oandaAccount.realizedPl);
                ログ.ログ書き出し("oandaAccount.marginUsed : " + oandaAccount.marginUsed);
                ログ.ログ書き出し("oandaAccount.marginAvail : " + oandaAccount.marginAvail);
                ログ.ログ書き出し("oandaAccount.openTrades : " + oandaAccount.openTrades);
                ログ.ログ書き出し("oandaAccount.openOrders : " + oandaAccount.openOrders);
                throw;
            }
        }

        public static double GetSUM差益(DateTime FromDate, DateTime ToDate)
        {
            try
            {
                cmd_GetSUM差益.Parameters["口座No"].Value = FormData.口座No;
                cmd_GetSUM差益.Parameters["FromDate"].Value = FromDate;
                cmd_GetSUM差益.Parameters["ToDate"].Value = ToDate;

                cmd_GetSUM差益.ExecuteNonQuery();

                if (DBNull.Value == cmd_GetSUM差益.Parameters["利益"].Value)
                {
                    return 0;
                }
                else
                {
                    return (double)cmd_GetSUM差益.Parameters["利益"].Value;
                }
            }
            catch (Exception ex)
            {
                ログ.ログ書き出し(ex);
                ログ.ログ書き出し("FormData.口座No : " + FormData.口座No);
                ログ.ログ書き出し("cn.ConnectionString : " + FormData.cn.ConnectionString);
                ログ.ログ書き出し("FromDate : " + FromDate);
                ログ.ログ書き出し("ToDate : " + ToDate);
                throw;
            }
        }


    }
}
