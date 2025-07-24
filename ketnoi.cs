using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Do_an_P10
{
    internal class ketnoi
    {
        private static string kn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Du_An_Ban_Hang\App_EcoStrawsHKT\Data_Do_An.mdf;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new  SqlConnection(kn);
        }
    }
}
