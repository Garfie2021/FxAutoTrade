using 定数;

namespace Maintenance_Form
{
    public class Maintenance共通
    {
        public static string GetConnectionString(string server, string database)
        {
            return "Data Source=" + server + ";Initial Catalog=" + database + ";User ID=sa;Password=1111";
        }
    }


    public class Maintenance条件選択
    {
        public string CommandLine = null;
        public Company Company;
        public Contry Contry;


        public Maintenance条件選択 Clone()
        {
            return new Maintenance条件選択()
            {
                CommandLine = this.CommandLine,
                Company = this.Company,
                Contry = this.Contry,
            };
        }
    }



}
