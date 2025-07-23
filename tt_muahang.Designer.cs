namespace Do_an_P10
{
    partial class tt_muahang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tt_muahang));
            tensp = new TextBox();
            gia = new TextBox();
            label3 = new Label();
            sl = new ListBox();
            slton = new Label();
            anh = new PictureBox();
            label1 = new Label();
            ql = new Button();
            dh = new Button();
            panel1 = new Panel();
            label5 = new Label();
            label4 = new Label();
            dathang = new Button();
            ((System.ComponentModel.ISupportInitialize)anh).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tensp
            // 
            tensp.BorderStyle = BorderStyle.FixedSingle;
            tensp.Font = new Font("Times New Roman", 11.25F);
            tensp.Location = new Point(299, 489);
            tensp.Margin = new Padding(4);
            tensp.Name = "tensp";
            tensp.Size = new Size(350, 33);
            tensp.TabIndex = 5;
            // 
            // gia
            // 
            gia.BorderStyle = BorderStyle.FixedSingle;
            gia.Font = new Font("Times New Roman", 11.25F);
            gia.Location = new Point(299, 251);
            gia.Margin = new Padding(4);
            gia.Name = "gia";
            gia.Size = new Size(350, 33);
            gia.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(300, 449);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(87, 32);
            label3.TabIndex = 3;
            label3.Text = "Mô tả";
            // 
            // sl
            // 
            sl.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sl.FormattingEnabled = true;
            sl.ItemHeight = 28;
            sl.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            sl.Location = new Point(300, 374);
            sl.Margin = new Padding(4);
            sl.Name = "sl";
            sl.Size = new Size(346, 32);
            sl.TabIndex = 2;
            // 
            // slton
            // 
            slton.AutoSize = true;
            slton.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            slton.Location = new Point(300, 334);
            slton.Margin = new Padding(4, 0, 4, 0);
            slton.Name = "slton";
            slton.Size = new Size(123, 32);
            slton.TabIndex = 1;
            slton.Text = "Số lượng";
            // 
            // anh
            // 
            anh.BackColor = Color.White;
            anh.BackgroundImageLayout = ImageLayout.Stretch;
            anh.Location = new Point(52, 220);
            anh.Margin = new Padding(4);
            anh.Name = "anh";
            anh.Size = new Size(199, 244);
            anh.SizeMode = PictureBoxSizeMode.StretchImage;
            anh.TabIndex = 0;
            anh.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(299, 216);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 32);
            label1.TabIndex = 1;
            label1.Text = "Đơn giá";
            // 
            // ql
            // 
            ql.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ql.Location = new Point(66, 614);
            ql.Margin = new Padding(4);
            ql.Name = "ql";
            ql.Size = new Size(153, 67);
            ql.TabIndex = 4;
            ql.Text = "Quay lại";
            ql.UseVisualStyleBackColor = true;
            ql.Click += button1_Click;
            // 
            // dh
            // 
            dh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dh.Location = new Point(283, 614);
            dh.Margin = new Padding(4);
            dh.Name = "dh";
            dh.Size = new Size(153, 67);
            dh.TabIndex = 6;
            dh.Text = "Thêm vào \r\ngiỏ hàng";
            dh.UseVisualStyleBackColor = true;
            dh.Click += dh_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(anh);
            panel1.Controls.Add(dathang);
            panel1.Controls.Add(dh);
            panel1.Controls.Add(tensp);
            panel1.Controls.Add(ql);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(sl);
            panel1.Controls.Add(gia);
            panel1.Controls.Add(slton);
            panel1.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel1.Location = new Point(351, 120);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(714, 750);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(239, 125);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(252, 41);
            label5.TabIndex = 8;
            label5.Text = "Phiếu Đặt hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(204, 40);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(330, 51);
            label4.TabIndex = 7;
            label4.Text = "EcoStraws HKT";
            // 
            // dathang
            // 
            dathang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dathang.Location = new Point(500, 614);
            dathang.Margin = new Padding(4);
            dathang.Name = "dathang";
            dathang.Size = new Size(153, 67);
            dathang.TabIndex = 6;
            dathang.Text = "Đặt hàng";
            dathang.UseVisualStyleBackColor = true;
            dathang.Click += dathang_Click;
            // 
            // tt_muahang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1369, 984);
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "tt_muahang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "tt_muahang";
            ((System.ComponentModel.ISupportInitialize)anh).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox anh;
        private ListBox sl;
        private Label slton;
        private Label label3;
        private TextBox tensp;
        private TextBox gia;
        private Label label1;
        private Button ql;
        private Button dh;
        private Panel panel1;
        private Label label4;
        private Label label5;
        private Button dathang;
    }
}