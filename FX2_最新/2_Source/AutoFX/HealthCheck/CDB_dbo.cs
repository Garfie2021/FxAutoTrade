using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthCheck
{
	class CDB_dbo
	{
		public static int CommandTimeout = 600000000;	// 10分

		#region 接続先設定

		public static void RealA_FX()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=RealA_FX;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=RealA_FX;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}

		public static void RealA_Kabu()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=RealA_Kabu;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=RealA_Kabu;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}

		public static void RealA_XAU()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=RealA_XAU;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=RealA_XAU;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}

		public static void RealB_FX()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=RealB_FX;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=RealB_FX;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}
		public static void RealB_Kabu()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=RealB_Kabu;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=RealB_Kabu;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}
		public static void RealB_XAU()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=RealB_XAU;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=RealB_XAU;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}

		public static void DemoA_FX()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=DemoA_FX;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=DemoA_FX;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}
		public static void DemoA_Kabu()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=DemoA_Kabu;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=DemoA_Kabu;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}
		public static void DemoA_XAU()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=DemoA_XAU;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=DemoA_XAU;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}

		public static void DemoB_FX()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=DemoB_FX;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=124.39.204.212;Initial Catalog=DemoB_FX;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}

		public static void DemoD()
		{
			#if RELEASE
				Properties.Settings.Default.FXConnectionString = "Data Source=localhost;Initial Catalog=DemoD_FX;Integrated Security=True";
			#else
				Properties.Settings.Default.FXConnectionString = "Data Source=1111;Initial Catalog=DemoD_FX;User ID=sa;Password=1111";
			#endif

			Properties.Settings.Default.Save();
		}

		#endregion


	}
}
