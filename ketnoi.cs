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
        private static string kn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\Do_an_nhom10\Data_Do_An.mdf;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new  SqlConnection(kn);
        }
    }
}
