using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace FileInport
{
	public static class CDB
	{
		#region メンバ変数


		public static DataSet1TableAdapters.T_通貨ペアMstTableAdapter T_通貨ペアMstTableAdapter = new DataSet1TableAdapters.T_通貨ペアMstTableAdapter();
		public static DataSet1.T_通貨ペアMstDataTable T_通貨ペアMstDataTable = new DataSet1.T_通貨ペアMstDataTable();

		public static DataSet1TableAdapters.T_Indicator_1m_DMITableAdapter T_Indicator_1m_DMITableAdapter = new DataSet1TableAdapters.T_Indicator_1m_DMITableAdapter();
		public static DataSet1.T_Indicator_1m_DMIDataTable T_Indicator_1m_DMIDataTable = new DataSet1.T_Indicator_1m_DMIDataTable();

		public static DataSet1TableAdapters.T_Rate_1mTableAdapter T_Rate_1mTableAdapter = new DataSet1TableAdapters.T_Rate_1mTableAdapter();
		public static DataSet1.T_Rate_1mDataTable T_Rate_1mDataTable = new DataSet1.T_Rate_1mDataTable();

		public static DataSet1TableAdapters.T_Rate_15mTableAdapter T_Rate_15mTableAdapter = new DataSet1TableAdapters.T_Rate_15mTableAdapter();
		public static DataSet1.T_Rate_15mDataTable T_Rate_15mDataTable = new DataSet1.T_Rate_15mDataTable();

		public static DataSet1TableAdapters.T_Rate_HourlyTableAdapter T_Rate_HourlyTableAdapter = new DataSet1TableAdapters.T_Rate_HourlyTableAdapter();
		public static DataSet1.T_Rate_HourlyDataTable T_Rate_HourlymDataTable = new DataSet1.T_Rate_HourlyDataTable();

		public static DataSet1TableAdapters.T_Rate_DailyTableAdapter T_Rate_DailyTableAdapter = new DataSet1TableAdapters.T_Rate_DailyTableAdapter();
		public static DataSet1.T_Rate_DailyDataTable T_Rate_DailymDataTable = new DataSet1.T_Rate_DailyDataTable();

		public static DataSet1TableAdapters.T_Rate_MonthlyTableAdapter T_Rate_MonthlyTableAdapter = new DataSet1TableAdapters.T_Rate_MonthlyTableAdapter();
		public static DataSet1.T_Rate_MonthlyDataTable T_Rate_MonthlyDataTable = new DataSet1.T_Rate_MonthlyDataTable();

		public static int CommandTimeout = 600;	// 10分

		#endregion


		public static void ExecSP(string SP名)
		{
			using (SqlConnection cn = new SqlConnection())
			{
				cn.ConnectionString = Properties.Settings.Default.FX_RealAConnectionString;
				cn.Open();

				SqlCommand cmd = new SqlCommand(SP名, cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandTimeout = CommandTimeout;

				cmd.ExecuteReader();
			}
		}
	}
}
