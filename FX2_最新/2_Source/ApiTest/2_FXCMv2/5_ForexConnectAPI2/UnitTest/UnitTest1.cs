using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order;
using Common;

namespace UnitTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestOrderC()
		{
			/*
			using (SqlConnection cn = new SqlConnection())
			{
				cn.ConnectionString = "Data Source=1111.8;Initial Catalog=FX_DemoA;User ID=sa;Password=1111";
				cn.Open();

				OrderC.全てのポジションをクローズする(cn);
				
				bool chkRate記録以降の処理をスキップ = true;
				bool chkポジション更新_成行_をスキップ = true;

				OrderC.OrderV1(cn);

				trad.DB記録_Trades(cn);
			}
			*/
		}
	}
}
