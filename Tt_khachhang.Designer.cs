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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tt_khachhang));
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
            label1.Location = new Point(46, 19);
            label1.Name = "label1";
            label1.Size = new Size(243, 26);
            label1.TabIndex = 2;
            label1.Text = "Thông tin khách hàng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.8F);
            label3.Location = new Point(47, 160);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 3;
            label3.Text = "Số điện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 10.8F);
            label4.Location = new Point(47, 252);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // ht
            // 
            ht.BorderStyle = BorderStyle.FixedSingle;
            ht.Font = new Font("Times New Roman", 9.75F);
            ht.Location = new Point(47, 103);
            ht.Name = "ht";
            ht.Size = new Size(359, 26);
            ht.TabIndex = 4;
            // 
            // sdt
            // 
            sdt.BorderStyle = BorderStyle.FixedSingle;
            sdt.Font = new Font("Times New Roman", 9.75F);
            sdt.Location = new Point(47, 187);
            sdt.Name = "sdt";
            sdt.Size = new Size(359, 26);
            sdt.TabIndex = 4;
            // 
            // mail
            // 
            mail.BorderStyle = BorderStyle.FixedSingle;
            mail.Font = new Font("Times New Roman", 9.75F);
            mail.Location = new Point(47, 276);
            mail.Name = "mail";
            mail.Size = new Size(359, 26);
            mail.TabIndex = 4;
            // 
            // luu
            // 
            luu.BackColor = SystemColors.ButtonHighlight;
            luu.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            luu.ForeColor = SystemColors.ActiveCaptionText;
            luu.Location = new Point(311, 411);
            luu.Name = "luu";
            luu.Size = new Size(95, 41);
            luu.TabIndex = 5;
            luu.Text = "Lưu";
            luu.UseVisualStyleBackColor = false;
            luu.Click += luu_Click;
            // 
            // ttk
            // 
            ttk.BackColor = Color.White;
            ttk.BorderStyle = BorderStyle.FixedSingle;
            ttk.Location = new Point(288, 21);
            ttk.Name = "ttk";
            ttk.ReadOnly = true;
            ttk.Size = new Size(118, 27);
            ttk.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.8F);
            label5.Location = new Point(47, 339);
            label5.Name = "label5";
            label5.Size = new Size(60, 20);
            label5.TabIndex = 3;
            label5.Text = "Địa chỉ";
            // 
            // ad
            // 
            ad.BorderStyle = BorderStyle.FixedSingle;
            ad.Font = new Font("Times New Roman", 9.75F);
            ad.Location = new Point(47, 365);
            ad.Margin = new Padding(2, 3, 2, 3);
            ad.Name = "ad";
            ad.Size = new Size(359, 26);
            ad.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.8F);
            label2.Location = new Point(47, 76);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
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
            panel1.Location = new Point(341, 144);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(457, 467);
            panel1.TabIndex = 9;
            // 
            // btnQL
            // 
            btnQL.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQL.Location = new Point(50, 412);
            btnQL.Margin = new Padding(3, 4, 3, 4);
            btnQL.Name = "btnQL";
            btnQL.Size = new Size(95, 41);
            btnQL.TabIndex = 9;
            btnQL.Text = "Quay Lại";
            btnQL.UseVisualStyleBackColor = true;
            btnQL.Click += btnQL_Click;
            // 
            // Tt_khachhang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1103, 764);
            Controls.Add(panel1);
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