using System;

namespace 定数
{
    public static class DB定数
    {
        public const int CommandTimeout = 0;    // 制限無し

        public static string GetDBConnectionString(string CommandLine)
        {
            if (CommandLine.IndexOf("OANDA_DemoB_ACV", StringComparison.Ordinal) > -1)
            {
                return DB定数.GetConnectionString("OANDA_DemoB_ACV");
            }
            else if (CommandLine.IndexOf("OANDA_DemoB", StringComparison.Ordinal) > -1)
            {
                return DB定数.GetConnectionString("OANDA_DemoB");
            }
            else if (CommandLine.IndexOf("OANDA_RealA_ACV", StringComparison.Ordinal) > -1)
            {
                return DB定数.GetConnectionString("OANDA_RealA_ACV");
            }
            else if (CommandLine.IndexOf("OANDA_RealA", StringComparison.Ordinal) > -1)
            {
                return DB定数.GetConnectionString("OANDA_RealA");
            }
            else if (CommandLine.IndexOf("OANDA_RealB_ACV", StringComparison.Ordinal) > -1)
            {
                return DB定数.GetConnectionString("OANDA_RealB_ACV");
            }
            else if (CommandLine.IndexOf("OANDA_RealB", StringComparison.Ordinal) > -1)
            {
                return DB定数.GetConnectionString("OANDA_RealB");
            }
            else if (CommandLine.IndexOf("FXCM_RealA", StringComparison.Ordinal) > -1)
            {
                return DB定数.GetConnectionString("FXCM_RealA");
            }
            else
            {
                return DB定数.GetConnectionString("FXCM_DemoA");
            }
        }

        public static string GetConnectionString(string InitialCatalog)
        {
#if RELEASE
    			return "Data Source=localhost;Initial Catalog=" + InitialCatalog + ";Integrated Security=True";
#else
            return "Data Source=1111.5;Initial Catalog=" + InitialCatalog + ";User ID=sa;Password=1111";
#endif
        }

    }
}
