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
    public partial class FormChiTietDonHang : Form
    {
        public FormChiTietDonHang(string tenSP, int soLuong, decimal donGia, DateTime ngayTao, string khachHang, string ghiChu)
        {
            InitializeComponent();

            txtTenCTSP.Text = tenSP;
            txtSlCTSP.Text = soLuong.ToString();
            txtDgCTSP.Text = donGia.ToString("N0") + " VND";
            txtTienCTSP.Text = (soLuong * donGia).ToString("N0") + " VND";
            txtNgayCTSP.Text = ngayTao.ToShortDateString();
            txtKHCTSP.Text = khachHang;
            txtGhiChuCTSP.Text = ghiChu;

        }
        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
