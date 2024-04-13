using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 定数
{
    public static class コマンドライン
    {
        public static List<string> CommandLine候補;

        static コマンドライン()
        {
            CommandLine候補 = new List<string>();
            CommandLine候補.Add("Auto;OANDA_DemoB;0;Master");
            CommandLine候補.Add("Auto;OANDA_DemoB;1;Slave");
            CommandLine候補.Add("Auto;OANDA_DemoB_ACV;0;Master");
            CommandLine候補.Add("Auto;OANDA_DemoB_ACV;1;Slave");
            CommandLine候補.Add("Auto;OANDA_RealA;0;Master");
            CommandLine候補.Add("Auto;OANDA_RealA;1;Slave");
            CommandLine候補.Add("Auto;OANDA_RealA;2;Slave");
            CommandLine候補.Add("Auto;OANDA_RealA;3;Slave");
            CommandLine候補.Add("Auto;OANDA_RealA_ACV;0;Master");
            CommandLine候補.Add("Auto;OANDA_RealA_ACV;1;Slave");
            //CommandLine候補.Add("Auto;FXCM_DemoA;UK;FXCMv1");
            //CommandLine候補.Add("Auto;FXCM_DemoB;UK;FXCMv1");
            //CommandLine候補.Add("Auto;RealA_FX;UK;FXCMv1");
        }
    }

}
