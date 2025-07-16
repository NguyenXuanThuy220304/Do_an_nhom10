using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an_P10
{
    internal class taikhoan
    {
        private string tentaikhoan;
        private string matkhau;
        private string email;
        public taikhoan()
        {
        }
        public taikhoan(string tentaikhoan, string matkhau, string email)
        {
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
            this.email = email;
        }
        public string Tentaikhoan { get => tentaikhoan; set => tentaikhoan = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }

        public string Email { get => email; set => email = value; } 
    }
}
