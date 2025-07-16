using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_an_P10
{
    public partial class quenmatkhau : Form
    {
        public quenmatkhau()
        {
            InitializeComponent();
        }

        private void mkm_TextChanged(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        private void xacnhan_Click(object sender, EventArgs e)
        {
            String Email = email.Text;
            if (Email.Trim() == "") { MessageBox.Show("Vui lòng nhập email!"); return; }
            else
            {
                String query = "Select * from taikhoan where email = '" + Email + "'";
                if (modify.tk(query).Count != 0)
                {
                    MessageBox.Show("Nật khẩu của bạn: " + modify.tk(query)[0].Matkhau, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dangnhap dn = new Dangnhap();
                    dn.Show();
                    this.Hide();
                }
                else MessageBox.Show("Email không tồn tại!");

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dangnhap dn = new Dangnhap();
            dn.Show();
            this.Hide();
        }
    }
}
