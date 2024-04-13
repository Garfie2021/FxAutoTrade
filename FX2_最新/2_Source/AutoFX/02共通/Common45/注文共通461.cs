using System;
using System.Data.SqlClient;
using 共通Data;
using Common;

namespace Common461
{
    public static class 注文共通461
    {
        public static void BS終了_再処理(DateTime n分前)
        {
            foreach (var 通貨ぺア取引状況 in FormData.通貨ぺア別取引状況)
            {
                //Task.Run(() =>
                //{
                注文共通.BS終了_再処理_通貨ぺア取引状況(n分前, 通貨ぺア取引状況);
                //});
            }
        }
    }
}
