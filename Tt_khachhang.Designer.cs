namespace Do_an_P10
{
    partial class Tt_khachhang
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
            label3 = new Label();
            label4 = new Label();
            ht = new TextBox();
            sdt = new TextBox();
            mail = new TextBox();
            luu = new Button();
            ttk = new TextBox();
            label5 = new Label();
            ad = new TextBox();
            label2 = new Label();
            panel1 = new Panel();
            btnQL = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(46, 14);
            label1.Name = "label1";
            label1.Size = new Size(194, 22);
            label1.TabIndex = 2;
            label1.Text = "Thông tin khách hàng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 120);
            label3.Name = "label3";
            label3.Size = new Size(92, 17);
            label3.TabIndex = 3;
            label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(41, 189);
            label4.Name = "label4";
            label4.Size = new Size(45, 17);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // ht
            // 
            ht.BorderStyle = BorderStyle.FixedSingle;
            ht.Font = new Font("Times New Roman", 9.75F);
            ht.Location = new Point(41, 77);
            ht.Margin = new Padding(3, 2, 3, 2);
            ht.Name = "ht";
            ht.Size = new Size(314, 22);
            ht.TabIndex = 4;
            // 
            // sdt
            // 
            sdt.BorderStyle = BorderStyle.FixedSingle;
            sdt.Font = new Font("Times New Roman", 9.75F);
            sdt.Location = new Point(41, 140);
            sdt.Margin = new Padding(3, 2, 3, 2);
            sdt.Name = "sdt";
            sdt.Size = new Size(314, 22);
            sdt.TabIndex = 4;
            // 
            // mail
            // 
            mail.BorderStyle = BorderStyle.FixedSingle;
            mail.Font = new Font("Times New Roman", 9.75F);
            mail.Location = new Point(41, 207);
            mail.Margin = new Padding(3, 2, 3, 2);
            mail.Name = "mail";
            mail.Size = new Size(314, 22);
            mail.TabIndex = 4;
            // 
            // luu
            // 
            luu.BackColor = SystemColors.ButtonHighlight;
            luu.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            luu.ForeColor = SystemColors.ActiveCaptionText;
            luu.Location = new Point(272, 308);
            luu.Margin = new Padding(3, 2, 3, 2);
            luu.Name = "luu";
            luu.Size = new Size(83, 31);
            luu.TabIndex = 5;
            luu.Text = "Lưu";
            luu.UseVisualStyleBackColor = false;
            luu.Click += luu_Click;
            // 
            // ttk
            // 
            ttk.BackColor = Color.White;
            ttk.BorderStyle = BorderStyle.FixedSingle;
            ttk.Location = new Point(236, 16);
            ttk.Margin = new Padding(3, 2, 3, 2);
            ttk.Name = "ttk";
            ttk.ReadOnly = true;
            ttk.Size = new Size(110, 23);
            ttk.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(41, 254);
            label5.Name = "label5";
            label5.Size = new Size(53, 17);
            label5.TabIndex = 3;
            label5.Text = "Địa chỉ";
            // 
            // ad
            // 
            ad.BorderStyle = BorderStyle.FixedSingle;
            ad.Font = new Font("Times New Roman", 9.75F);
            ad.Location = new Point(41, 274);
            ad.Margin = new Padding(2);
            ad.Name = "ad";
            ad.Size = new Size(314, 22);
            ad.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(41, 57);
            label2.Name = "label2";
            label2.Size = new Size(58, 17);
            label2.TabIndex = 8;
            label2.Text = "Họ Tên";
            // 
            // panel1
            // 
            panel1.BackColor = Color.MintCream;
            panel1.Controls.Add(btnQL);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(luu);
            panel1.Controls.Add(ad);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(sdt);
            panel1.Controls.Add(ttk);
            panel1.Controls.Add(mail);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(ht);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(298, 108);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 350);
            panel1.TabIndex = 9;
            // 
            // btnQL
            // 
            btnQL.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQL.Location = new Point(44, 309);
            btnQL.Name = "btnQL";
            btnQL.Size = new Size(83, 31);
            btnQL.TabIndex = 9;
            btnQL.Text = "Quay Lại";
            btnQL.UseVisualStyleBackColor = true;
            btnQL.Click += btnQL_Click;
            // 
            // Tt_khachhang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.ong_hut_gao_duoc_lam_tu_bot_gao_va_tinh_bot_san5;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(965, 573);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Tt_khachhang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            Load += Tt_khachhang_Load_1;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox ht;
        private TextBox sdt;
        private TextBox add;
        private Button luu;
        private TextBox ttk;
        private TextBox mail;
        private Label label5;
        private TextBox textBox1;
        private TextBox ad;
        private Label label2;
        private Panel panel1;
        private Button btnQL;
    }
}