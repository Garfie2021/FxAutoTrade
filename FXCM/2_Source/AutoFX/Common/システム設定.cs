using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DB;

namespace Common
{
	public static class システム設定
	{
		// システム
		public static string CommandLine = "";
		public static string ExeFilePath;
		public static string DBConnectionString = "";
		public static string Trade時間内 = "";
		public static Encoding Enc = Encoding.GetEncoding("Shift_JIS");

		// 口座
		public static string Fxcm口座種別 = "";
		public static string FxcmConnection = "";
		public static string FxcmUsername = "";
		public static string FxcmPassword = "";

		// 注文設定 //
		public static int ポジション増加数_直近n時間 = -24;			// txtポジション増加数_直近n時間.Text
		public static int 差損益気増加数_直近n日間 = 3;				// txt差損益気増加数_直近n日間.Text
		public static double BS発生_リミット拡張幅 = 0.1;	// txtBS発生_リミット拡張幅.Text		
		//public static double 余剰金割合_Order対象通貨ペアを減らす開始点 = 0;

		// Order //
		public static double 余剰金割合_Order対象通貨ペアを減らす開始点 = 0;	// txt余剰金割合_Order対象通貨ペアを減らす開始点.Text
		public static double 余剰金割合_Order限界点 = 15;						// txt余剰金割合_Order限界点.Text
		public static int Order対象を減少させないOrder数 = 3;					// txtOrder対象を減少させないOrder数.Text
		public static byte Rate幅を求めるn日間_Order間隔最小値 = 7;				// txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Text
		public static double 前日の高値底値とOrder間隔最小値の割合 = 0;			// txt前日の高値底値とOrder間隔最小値の割合.Text
		public static byte Rate幅を求めるn日間_リミット = 7;					// txtシステム設定_Rate幅を求めるn日間_リミット.Text
		public static double 前日の高値底値とリミットの割合 = 20;				// txt前日の高値底値とリミットの割合.Text
		public static double Order間隔増加割合 = 20;							// txtシステム_Order間隔増加割合.Text
		public static double 自動更新Rate幅はOrder間隔のn倍 = 2.5;				// txtシステム_自動更新Rate幅はOrder間隔のn倍.Text
		public static int AtMarket = 5;											// txtシステム設定_AtMarket.Text
		public static int ポジション1つ辺りの変動リスク = 25000;				// 1ポジションあたり25000円の変動までは耐える
		public static int 注文可能限界数 = 25;									// 注文単位を1づつ増やす際の注文可能限界数
		public static int n日以上前のポジションは決済 = 90;
		public static bool n日以上前のポジション決済をスキップ = true;

		// Close Trade //
		public static double 余剰金割合の限界点 = 2;					// txt余剰金割合の限界点.Text
		public static int CloseTrade_nヵ月前からあるポジション = -1;	// txtシステム設定_CloseTrade_nヵ月前からあるポジション.Text
		public static int CloseTrade_n以上であればCloseする = 50;		// txtシステム設定_CloseTrade_n以上であればCloseする.Text

		// 出金 Monthly //
		public static DateTime 出金可能にする開始日時 = DateTime.Parse("2014/04/21 00:00:00");		// txt出金可能にする開始日時.Text
		public static int 出金可能にする取引証拠金 = 2500000;										// txt出金可能にする取引証拠金.Text
		public static byte 出金可能にする利益Percent = 80;											// txt出金可能にする利益Percent.Text

		// その他 //
		public static int 日付はn時くぎり = 6;		// txtシステム設定_日付はn時くぎり.Text
		public static string ログフォルダ = "";		// txtログフォルダ.Text


		public static string DB接続先(string 口座)
		{
			if (口座 == "RealA_FX")
			{
				#if RELEASE
				return "Data Source=localhost;Initial Catalog=FXCM_RealA;Integrated Security=True";
                #else
                return "Data Source=1111.5;Initial Catalog=FXCM_RealA;User ID=sa;Password=1111";
				#endif
			}
			else if (口座 == "RealB_FX")
			{
				#if RELEASE
				return "Data Source=localhost;Initial Catalog=RealB_FX;Integrated Security=True";
				#else
				return "Data Source=1111.5;Initial Catalog=RealB_FX;User ID=sa;Password=1111";
				#endif
			}
			else if (口座 == "RealB_2370741682_FX")
			{
				#if RELEASE
				return "Data Source=localhost;Initial Catalog=RealB_2370741682_FX;Integrated Security=True";
				#else
				return "Data Source=1111.5;Initial Catalog=RealB_2370741682_FX;User ID=sa;Password=1111";
				#endif
			}
			else if (口座 == "RealB_2370741683_FX")
			{
				#if RELEASE
				return "Data Source=localhost;Initial Catalog=RealB_2370741683_FX;Integrated Security=True";
				#else
				return "Data Source=1111.5;Initial Catalog=RealB_2370741683_FX;User ID=sa;Password=1111";
				#endif
			}
			else if (口座 == "DemoA_FX")
			{
				#if RELEASE
				return "Data Source=localhost;Initial Catalog=FXCM_DemoA;Integrated Security=True";
                #else
                return "Data Source=1111.5;Initial Catalog=FXCM_DemoA;User ID=sa;Password=1111";
				#endif
			}
			else if (口座 == "DemoB_FX")
			{
				#if RELEASE
				return "Data Source=localhost;Initial Catalog=DemoB_FX;Integrated Security=True";
				#else
				return "Data Source=124.39.204.212;Initial Catalog=DemoB_FX;User ID=sa;Password=1111";
				#endif
			}

			return "";
		}

		private static void DemoA_FX()
		{
			システム設定.ExeFilePath = @"C:\AutoFX\DemoA_FX\AutoFx_Form.exe";
			システム設定.ログフォルダ = @"C:\AutoFX\DemoA_FX\log";

			システム設定.Fxcm口座種別 = "個人";
			システム設定.FxcmConnection = "Demo";
			システム設定.FxcmUsername = "D102498055001";
			システム設定.FxcmPassword = "1111";

			システム設定.余剰金割合_Order対象通貨ペアを減らす開始点 = 25;
			システム設定.前日の高値底値とOrder間隔最小値の割合 = 50;

			システム設定.n日以上前のポジションは決済 = 7;
			システム設定.n日以上前のポジション決済をスキップ = true;

			システム設定.DBConnectionString = DB接続先("DemoA_FX");
		}

		private static void DemoB_FX()
		{
			// FXCM UK のデモ口座

			システム設定.ExeFilePath = @"C:\AutoFX\DemoB_FX\AutoFx_Form.exe";
			システム設定.ログフォルダ = @"C:\AutoFX\DemoB_FX\log";

			システム設定.Fxcm口座種別 = "個人";
			システム設定.FxcmConnection = "Demo";
			システム設定.FxcmUsername = "D102498055001";
			システム設定.FxcmPassword = "1111";

			システム設定.余剰金割合_Order対象通貨ペアを減らす開始点 = 25;

			システム設定.n日以上前のポジションは決済 = 7;
			システム設定.n日以上前のポジション決済をスキップ = true;

			システム設定.DBConnectionString = DB接続先("DemoB_FX");
		}

		private static void RealA_FX()
		{
			システム設定.ExeFilePath = @"C:\AutoFX\RealA_FX\AutoFx_Form.exe";
			システム設定.ログフォルダ = @"C:\AutoFX\RealA_FX\log";

			システム設定.Fxcm口座種別 = "個人";
			システム設定.FxcmConnection = "Real";
			システム設定.FxcmUsername = "111";
			システム設定.FxcmPassword = "1111";

			システム設定.余剰金割合_Order対象通貨ペアを減らす開始点 = 15;	// 委託口座は25以上にする
			システム設定.前日の高値底値とOrder間隔最小値の割合 = 99;

			システム設定.DBConnectionString = DB接続先("RealA_FX");
		}

		private static void RealB_FX()
		{
			システム設定.ExeFilePath = @"C:\AutoFX\RealB_FX\AutoFx_Form.exe";
			システム設定.ログフォルダ = @"C:\AutoFX\RealB_FX\log";

			システム設定.Fxcm口座種別 = "法人";
			システム設定.FxcmConnection = "Real";
			システム設定.FxcmUsername = "111";
			システム設定.FxcmPassword = "1111";

			システム設定.余剰金割合_Order対象通貨ペアを減らす開始点 = 35;
			システム設定.前日の高値底値とOrder間隔最小値の割合 = 95;

			システム設定.余剰金割合_Order限界点 = 35;

			システム設定.DBConnectionString = DB接続先("RealB_FX");
		}
		private static void RealB_2370741682_FX()
		{
			システム設定.ExeFilePath = @"C:\AutoFX\RealB_2370741682_FX\AutoFx_Form.exe";
			システム設定.ログフォルダ = @"C:\AutoFX\RealB_2370741682_FX\log";

			システム設定.Fxcm口座種別 = "法人";
			システム設定.FxcmConnection = "Real";
			システム設定.FxcmUsername = "2370741682";
			システム設定.FxcmPassword = "1111";

			システム設定.余剰金割合_Order対象通貨ペアを減らす開始点 = 35;
			システム設定.前日の高値底値とOrder間隔最小値の割合 = 95;

			システム設定.余剰金割合_Order限界点 = 35;

			システム設定.DBConnectionString = DB接続先("RealB_2370741682_FX");
		}
		private static void RealB_2370741683_FX()
		{
			システム設定.ExeFilePath = @"C:\AutoFX\RealB_2370741683_FX\AutoFx_Form.exe";
			システム設定.ログフォルダ = @"C:\AutoFX\RealB_2370741683_FX\log";

			システム設定.Fxcm口座種別 = "法人";
			システム設定.FxcmConnection = "Real";
			システム設定.FxcmUsername = "2370741683";
			システム設定.FxcmPassword = "1111";

			システム設定.余剰金割合_Order対象通貨ペアを減らす開始点 = 35;
			システム設定.前日の高値底値とOrder間隔最小値の割合 = 99;
			システム設定.余剰金割合_Order限界点 = 35;

			システム設定.DBConnectionString = DB接続先("RealB_2370741683_FX");
		}

		public static void CommandLineから環境設定()
		{
			if (システム設定.CommandLine.IndexOf("RealA_FX", StringComparison.Ordinal) > -1)
			{
				RealA_FX();
			}
			else if (システム設定.CommandLine.IndexOf("RealB_FX", StringComparison.Ordinal) > -1)
			{
				RealB_FX();
			}
			else if (システム設定.CommandLine.IndexOf("RealB_2370741682_FX", StringComparison.Ordinal) > -1)
			{
				RealB_2370741682_FX();
			}
			else if (システム設定.CommandLine.IndexOf("RealB_2370741683_FX", StringComparison.Ordinal) > -1)
			{
				RealB_2370741683_FX();
			}
			else if (システム設定.CommandLine.IndexOf("DemoA_FX", StringComparison.Ordinal) > -1)
			{
				DemoA_FX();
			}
			else if (システム設定.CommandLine.IndexOf("DemoB_FX", StringComparison.Ordinal) > -1)
			{
				DemoB_FX();
			}


            oder.LogPath = システム設定.ログフォルダ;
		}

	}
}
