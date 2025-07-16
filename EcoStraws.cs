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
    public partial class EcoStraws : Form
    {
        private string tentk;
        public EcoStraws(string tentk)
        {
            InitializeComponent();
            this.tentk = tentk;
        }
        Modify modify = new Modify();
        private void phi45_Click(object sender, EventArgs e)
        {
            Button phi45 = sender as Button;
            sanpham sp = phi45.Tag as sanpham;

            tt_muahang form = new tt_muahang(sp, tentk);
            form.Show();
            this.Hide();
        }
        List<sanpham> allProducts = new List<sanpham>();
        private void EcoStraws_Load(object sender, EventArgs e)
        {
            // Danh sách sản phẩm để load
            List<(int MaSP, Image hinh)> dsSp = new List<(int, Image)>
    {
        (1, Properties.Resources.Ong_hut_gao_phi_4_5),
        (2,   Properties.Resources.Ong_hut_gao_phi_6),
        (3,   Properties.Resources.Ong_hut_gao_phi_8),
        (4,  Properties.Resources.Ong_hut_gao_phi_13),
        (5,  Properties.Resources.onghutcophi4_5),
        (7,  Properties.Resources.onghutcophi13),
        (10,  Properties.Resources.onghutcophi13),
        (11,  Properties.Resources.onghutbamiaphi6),
        (12,  Properties.Resources.onghutbamiaphi13),
        (13,  Properties.Resources.onghuttre),
        (14,  Properties.Resources.onghuttrephi6_12_13)

    };

            foreach (var item in dsSp)
            {
                string sql = $"SELECT MaSP, TenSP, KichThuoc, MauSac,  GiaBan , SoLuongTon FROM sanpham WHERE MaSP= '{item.MaSP}'";
                var list = modify.sp(sql);

                if (list.Count > 0)
                {
                    var sp = list[0];
                    sp.Hinhanh = item.hinh;

                    // Thêm vào danh sách allProducts
                    allProducts.Add(sp);
                }
            }

            // Hiển thị ra flowLayoutPanel1
            DisplayProducts(allProducts);

            // Gán tên tài khoản lên label nếu muốn
            t.Text = tentk;
        }

        private void phi6_Click(object sender, EventArgs e)
        {
            Button phi6 = sender as Button;
            sanpham sp = phi6.Tag as sanpham;

            tt_muahang form = new tt_muahang(sp, tentk);
            form.Show();
            this.Hide();
        }

        private void phi8_Click(object sender, EventArgs e)
        {
            Button phi8 = sender as Button;
            sanpham sp = phi8.Tag as sanpham;

            tt_muahang form = new tt_muahang(sp, tentk);
            form.Show();
            this.Hide();
        }

        private void phi13_Click(object sender, EventArgs e)
        {
            Button phi13 = sender as Button;
            sanpham sp = phi13.Tag as sanpham;

            tt_muahang form = new tt_muahang(sp, tentk);
            form.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Dangnhap dangnhap = new Dangnhap();
            dangnhap.Show();
        }

        private void gio_Click(object sender, EventArgs e)
        {
            GioHangForm gio = new GioHangForm(tentk);
            gio.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void DisplayProducts(List<sanpham> products)
        {
            panelmathang.Controls.Clear();

            foreach (var sp in products)
            {
                var control = new SanPhamControl(sp, tentk);
                panelmathang.Controls.Add(control);
            }
        }
        private void Tk_TextChanged(object sender, EventArgs e)
        {
            string keyword = Tk.Text.ToLower();
            var filtered = allProducts.Where(sp => sp.Tensanpham.ToLower().Contains(keyword)
                                                || sp.Kichthuoc.ToLower().Contains(keyword)
                                                || sp.Mausac.ToLower().Contains(keyword))
                                      .ToList();
            DisplayProducts(filtered);
        }

        private void t_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelmathang_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
