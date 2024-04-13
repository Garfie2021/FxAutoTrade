using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Data.SqlClient;
using System.Data;
using SystemCommon;
using FXCM;

namespace AutoFx_Form
{
	public static class CDB_acv
	{
		public static DFX_acvTableAdapters.T_RateHistory_PastTableAdapter T_RateHistory_PastTableAdapter = new DFX_acvTableAdapters.T_RateHistory_PastTableAdapter();
		public static DFX_acv.T_RateHistory_PastDataTable T_RateHistory_PastDataTable = new DFX_acv.T_RateHistory_PastDataTable();

	}
}
