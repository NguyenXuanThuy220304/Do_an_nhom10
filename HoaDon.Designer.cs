namespace Do_an_P10
{
    partial class HoaDon
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
            label1 = new Label();
            groupBox1 = new GroupBox();
            trangt = new TextBox();
            label6 = new Label();
            thanht = new TextBox();
            label5 = new Label();
            date = new TextBox();
            label4 = new Label();
            mad = new TextBox();
            label3 = new Label();
            mak = new TextBox();
            label2 = new Label();
            xuat = new LinkLabel();
            Qrcode = new PictureBox();
            label7 = new Label();
            label8 = new Label();
            lbnhapma = new TextBox();
            label9 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Qrcode).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(166, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(154, 45);
            label1.TabIndex = 0;
            label1.Text = "Hoá đơn";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(trangt);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(thanht);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(date);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(mad);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(mak);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(16, 63);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(474, 357);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "EcoStrawsHKT";
            // 
            // trangt
            // 
            trangt.Location = new Point(106, 298);
            trangt.Margin = new Padding(4, 3, 4, 3);
            trangt.Name = "trangt";
            trangt.ReadOnly = true;
            trangt.Size = new Size(348, 39);
            trangt.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(9, 312);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(89, 25);
            label6.TabIndex = 0;
            label6.Text = "Trạng thái";
            label6.Click += label3_Click;
            // 
            // thanht
            // 
            thanht.Location = new Point(106, 215);
            thanht.Margin = new Padding(4, 3, 4, 3);
            thanht.Name = "thanht";
            thanht.ReadOnly = true;
            thanht.Size = new Size(348, 39);
            thanht.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(9, 227);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(94, 25);
            label5.TabIndex = 0;
            label5.Text = "Thành tiền";
            label5.Click += label3_Click;
            // 
            // date
            // 
            date.Location = new Point(106, 133);
            date.Margin = new Padding(4, 3, 4, 3);
            date.Name = "date";
            date.ReadOnly = true;
            date.Size = new Size(348, 39);
            date.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(9, 147);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 0;
            label4.Text = "Ngày";
            label4.Click += label3_Click;
            // 
            // mad
            // 
            mad.Location = new Point(343, 53);
            mad.Margin = new Padding(4, 3, 4, 3);
            mad.Name = "mad";
            mad.ReadOnly = true;
            mad.Size = new Size(111, 39);
            mad.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(246, 67);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(74, 25);
            label3.TabIndex = 0;
            label3.Text = "Mã đơn";
            label3.Click += label3_Click;
            // 
            // mak
            // 
            mak.Location = new Point(106, 53);
            mak.Margin = new Padding(4, 3, 4, 3);
            mak.Name = "mak";
            mak.ReadOnly = true;
            mak.Size = new Size(111, 39);
            mak.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(9, 67);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 0;
            label2.Text = "Mã khách";
            // 
            // xuat
            // 
            xuat.AutoSize = true;
            xuat.LinkColor = Color.Black;
            xuat.Location = new Point(370, 777);
            xuat.Margin = new Padding(4, 0, 4, 0);
            xuat.Name = "xuat";
            xuat.Size = new Size(120, 25);
            xuat.TabIndex = 2;
            xuat.TabStop = true;
            xuat.Text = "Xuất hoá đơn";
            xuat.LinkClicked += xuat_LinkClicked;
            // 
            // Qrcode
            // 
            Qrcode.Location = new Point(140, 427);
            Qrcode.Margin = new Padding(4, 3, 4, 3);
            Qrcode.Name = "Qrcode";
            Qrcode.Size = new Size(243, 227);
            Qrcode.SizeMode = PictureBoxSizeMode.Zoom;
            Qrcode.TabIndex = 4;
            Qrcode.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(140, 658);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(240, 25);
            label7.TabIndex = 0;
            label7.Text = "MB Bank: 020722032722411";
            label7.Click += label3_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(154, 683);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(204, 25);
            label8.TabIndex = 0;
            label8.Text = "Cửa hàng EcoStrawsHKT";
            label8.Click += label3_Click;
            // 
            // lbnhapma
            // 
            lbnhapma.BorderStyle = BorderStyle.FixedSingle;
            lbnhapma.Location = new Point(190, 725);
            lbnhapma.Name = "lbnhapma";
            lbnhapma.Size = new Size(217, 31);
            lbnhapma.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(99, 728);
            label9.Name = "label9";
            label9.Size = new Size(85, 25);
            label9.TabIndex = 6;
            label9.Text = "Nhập mã";
            // 
            // HoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 821);
            Controls.Add(label9);
            Controls.Add(lbnhapma);
            Controls.Add(Qrcode);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(xuat);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "HoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HoaDon";
            Load += HoaDon_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Qrcode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private TextBox mak;
        private Label label2;
        private TextBox mad;
        private Label label3;
        private TextBox trangt;
        private Label label6;
        private TextBox thanht;
        private Label label5;
        private TextBox date;
        private Label label4;
        private LinkLabel xuat;
        private PictureBox Qrcode;
        private Label label7;
        private Label label8;
        private TextBox lbnhapma;
        private Label label9;
    }
}