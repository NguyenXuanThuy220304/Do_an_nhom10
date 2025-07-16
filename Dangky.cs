using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Do_an_P10
{
    public partial class Dangky : Form
    {
        public Dangky()
        {
            InitializeComponent();
        }
        public bool checkacc(string ac)
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{5,24}$");
        }
        public bool checkemail(string e)
        {
            if (string.IsNullOrWhiteSpace(e)) return false;
            e = e.Trim(); // Xóa khoảng trắng đầu/cuối nếu có
            return Regex.IsMatch(e, @"^[a-zA-Z0-9_.]{3,50}@gmail\.com(\.vn)?$");
        }

        Modify modify = new Modify();
        private void dk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Email.Text = [" + em.Text + "]");
            String tentk = tk.Text;
            String matk = mk.Text;
            String xacnhanmk = nlmk.Text;
            String Email = em.Text;
            if (!checkacc(tentk)) { MessageBox.Show("Vui lòng nhập tên tài khoản dài 5-24 ky tu, ky tu chu, so, chu hoa, chu thuong"); return; }
            if (!checkacc(matk)) { MessageBox.Show("vui long nhap ten mat khau dai 5-24 ky tu, ky tu chu, so, chu hoa, chu thuong"); return; }
            if (xacnhanmk != matk) { MessageBox.Show("vui long kiem tra lai mat khau"); return; }
            if (!checkemail(Email))
            {
                MessageBox.Show("Email nhập: [" + Email + "]");
                MessageBox.Show("vui long nhap dung dinh dang email"); return;
            }
            if (modify.tk("Select * from taikhoan where email = '" + Email + "'").Count != 0) { MessageBox.Show("email nay da duoc su dung!"); return; }
            try
            {
                string query = "Insert into taikhoan values ('" + tentk + "','" + matk + "','" + Email + "')";
                modify.Commad(query);
                if (MessageBox.Show("Đăng ký thành công! Bạn có muốn đăng nhập ngay", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                    Dangnhap dangnhap = new Dangnhap();
                    dangnhap.Show();
                }
            }
            catch
            {
                MessageBox.Show("ten tai khoan da duoc su dung! Vui long dang ky ten tai khoan khac.");
            }
        }

        private void Dangky_Load(object sender, EventArgs e)
        {

        }

        private void linkDN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Dangnhap dn = new Dangnhap();
            dn.Show();
            this.Hide();
        }

    }
}
