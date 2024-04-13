using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Siamese
{
	public static class Cシステム設定
	{
		public static string ExeFilePath = @"C:\AutoFX2\AutoFx_Form.exe";
		public static string txtログフォルダ = @"C:\AutoFX2\log";
		public static string BatFilePath = @"C:\AutoFX2\Start_RealB_2370741683_FX.bat";

		// 注文設定 //
		public static int ポジション増加数_直近n時間 = 0;		// txtポジション増加数_直近n時間.Text
		public static int 差損益気増加数_直近n日間 = 0;			// txt差損益気増加数_直近n日間.Text
		public static double BonusStage発生_リミット拡張幅 = 0;			// txtBonusStage発生_リミット拡張幅.Text		

		// Order //
		public static double 余剰金割合_Order対象通貨ペアを減らす開始点 = 0;	// txt余剰金割合_Order対象通貨ペアを減らす開始点.Text
		public static double 余剰金割合_Order限界点 = 0;						// txt余剰金割合_Order限界点.Text
		public static int Order対象を減少させないOrder数 = 0;					// txtOrder対象を減少させないOrder数.Text
		public static byte Rate幅を求めるn日間_Order間隔最小値 = 0;				// txtシステム設定_Rate幅を求めるn日間_Order間隔最小値.Text
		public static double 前日の高値底値とOrder間隔最小値の割合 = 0;			// txt前日の高値底値とOrder間隔最小値の割合.Text
		public static byte Rate幅を求めるn日間_リミット = 0;						// txtシステム設定_Rate幅を求めるn日間_リミット.Text
		public static double 前日の高値底値とリミットの割合 = 0;				// txt前日の高値底値とリミットの割合.Text
		public static double Order間隔増加割合 = 0;								// txtシステム_Order間隔増加割合.Text
		public static double 自動更新Rate幅はOrder間隔のn倍 = 0;				// txtシステム_自動更新Rate幅はOrder間隔のn倍.Text
		public static int AtMarket = 0;											// txtシステム設定_AtMarket.Text

		// Close Trade //
		public static double 余剰金割合の限界点 = 0;					// txt余剰金割合の限界点.Text
		public static int CloseTrade_nヵ月前からあるポジション = 0;		// txtシステム設定_CloseTrade_nヵ月前からあるポジション.Text
		public static int CloseTrade_n以上であればCloseする = 0;		// txtシステム設定_CloseTrade_n以上であればCloseする.Text

		// 出金 Monthly //
		public static DateTime 出金可能にする開始日時;		// txt出金可能にする開始日時.Text
		public static int 出金可能にする取引証拠金;			// txt出金可能にする取引証拠金.Text
		public static byte 出金可能にする利益Percent;		// txt出金可能にする利益Percent.Text

		// その他 //
		public static int 日付はn時くぎり = 0;		// txtシステム設定_日付はn時くぎり.Text
		public static string ログフォルダ = "";		// txtログフォルダ.Text


	}
}
