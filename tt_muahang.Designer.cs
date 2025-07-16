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
            ((System.ComponentModel.ISupportInitialize)anh).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tensp
            // 
            tensp.BorderStyle = BorderStyle.FixedSingle;
            tensp.Font = new Font("Times New Roman", 11.25F);
            tensp.Location = new Point(239, 391);
            tensp.Name = "tensp";
            tensp.Size = new Size(280, 29);
            tensp.TabIndex = 5;
            // 
            // gia
            // 
            gia.BorderStyle = BorderStyle.FixedSingle;
            gia.Font = new Font("Times New Roman", 11.25F);
            gia.Location = new Point(239, 201);
            gia.Name = "gia";
            gia.Size = new Size(280, 29);
            gia.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(240, 359);
            label3.Name = "label3";
            label3.Size = new Size(73, 26);
            label3.TabIndex = 3;
            label3.Text = "Mô tả";
            // 
            // sl
            // 
            sl.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            sl.FormattingEnabled = true;
            sl.ItemHeight = 23;
            sl.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            sl.Location = new Point(240, 299);
            sl.Name = "sl";
            sl.Size = new Size(278, 27);
            sl.TabIndex = 2;
            // 
            // slton
            // 
            slton.AutoSize = true;
            slton.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            slton.Location = new Point(240, 267);
            slton.Name = "slton";
            slton.Size = new Size(102, 26);
            slton.TabIndex = 1;
            slton.Text = "Số lượng";
            // 
            // anh
            // 
            anh.BackColor = Color.White;
            anh.BackgroundImageLayout = ImageLayout.Stretch;
            anh.Location = new Point(42, 176);
            anh.Name = "anh";
            anh.Size = new Size(159, 195);
            anh.SizeMode = PictureBoxSizeMode.StretchImage;
            anh.TabIndex = 0;
            anh.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(239, 173);
            label1.Name = "label1";
            label1.Size = new Size(92, 26);
            label1.TabIndex = 1;
            label1.Text = "Đơn giá";
            // 
            // ql
            // 
            ql.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ql.Location = new Point(82, 477);
            ql.Name = "ql";
            ql.Size = new Size(119, 56);
            ql.TabIndex = 4;
            ql.Text = "Quay lại";
            ql.UseVisualStyleBackColor = true;
            ql.Click += button1_Click;
            // 
            // dh
            // 
            dh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dh.Location = new Point(386, 477);
            dh.Name = "dh";
            dh.Size = new Size(119, 56);
            dh.TabIndex = 6;
            dh.Text = "Đặt hàng";
            dh.UseVisualStyleBackColor = true;
            dh.Click += dh_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(anh);
            panel1.Controls.Add(dh);
            panel1.Controls.Add(tensp);
            panel1.Controls.Add(ql);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(sl);
            panel1.Controls.Add(gia);
            panel1.Controls.Add(slton);
            panel1.Font = new Font("Microsoft Sans Serif", 8.25F);
            panel1.Location = new Point(281, 96);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 600);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(191, 100);
            label5.Name = "label5";
            label5.Size = new Size(211, 35);
            label5.TabIndex = 8;
            label5.Text = "Phiếu Đặt hàng";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(163, 32);
            label4.Name = "label4";
            label4.Size = new Size(277, 42);
            label4.TabIndex = 7;
            label4.Text = "EcoStraws HKT";
            // 
            // tt_muahang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            BackgroundImage = Properties.Resources.phan_huy_03_thang;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1095, 787);
            Controls.Add(panel1);
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
    }
}