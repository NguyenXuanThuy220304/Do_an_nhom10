using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Do_an_P10
{
    public partial class tt_muahang : Form
    {
        private sanpham Sanpham;
        private string tentk;
        Modify modify = new Modify();

        public tt_muahang(sanpham sp, string tentk)
        {
            InitializeComponent();
            this.tentk = tentk;
            Sanpham = sp;

            gia.Text = sp.Dongia.ToString();
            tensp.Text = sp.Tensanpham;
            anh.Image = sp.Hinhanh;
            int slt = sp.Soluong ;
            slton.Text = $"Số lượng: {slt}";
            // Thêm số lượng từ 1 đến 10 vào ListBox (hoặc ComboBox)
            //      sl.Items.Clear();
            //      for (int i = 1; i <= slt; i++)
            //      {
            //          sl.Items.Add(i.ToString());
            //      }
            //       sl.SelectedIndex = 0; // Mặc định chọn 1
            sl.Items.Clear();
            for (int i = 1; i <= slt; i++)
            {
                sl.Items.Add(i.ToString());
            }
            if (sl.Items.Count > 0)
            {
                sl.SelectedIndex = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EcoStraws eco = new EcoStraws(tentk);
            eco.Show();
            this.Hide();
        }

        private void dh_Click_1(object sender, EventArgs e)
        {
            if (sl.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = int.Parse(sl.SelectedItem.ToString());

            Giohang item = new Giohang
            {
                MaSP = Sanpham.MaSP,
                TenSanPham = Sanpham.Tensanpham,
                DonGia = Sanpham.Dongia,
                SoLuong = soLuong
            };

            GioHangData.Instance.ThemSanPham(item);

            MessageBox.Show($"Đã thêm '{item.TenSanPham}' ({item.SoLuong}) vào giỏ hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Mở giỏ hàng
            GioHangForm gioHangForm = new GioHangForm(tentk);
            gioHangForm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
