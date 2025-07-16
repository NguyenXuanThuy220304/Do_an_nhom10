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
    public partial class SanPhamControl : UserControl
    {
        private sanpham sp;
        private string tentk;

        public SanPhamControl(sanpham sanpham, string tentk)
        {
            InitializeComponent();
            this.sp = sanpham;
            this.tentk = tentk;

            // Hiển thị thông tin
            lblTenSP.Text = $"{sp.Tensanpham} - {sp.Kichthuoc}";
            lblGia.Text = "Giá: " + sp.Dongia.ToString("N0") + "₫";
            pictureBox1.Image = sp.Hinhanh;

            // Gán sự kiện click
            pictureBox1.Click += PictureBox1_Click;
        }
        private void SanPhamControl_Load(object sender, EventArgs e)
        {

        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            // Mở form mua hàng
            tt_muahang form = new tt_muahang(sp, tentk);
            form.Show();

            // Ẩn form cha (EcoStraws) nếu muốn
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Hide();
            }
        }
    }
}
