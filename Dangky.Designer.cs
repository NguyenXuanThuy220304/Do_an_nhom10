namespace Do_an_P10
{
    partial class Dangky
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
            label2 = new Label();
            tk = new TextBox();
            mk = new TextBox();
            label3 = new Label();
            nlmk = new TextBox();
            label4 = new Label();
            label5 = new Label();
            email = new TextBox();
            dk = new Button();
            label1 = new Label();
            em = new TextBox();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            linkDN = new LinkLabel();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 129);
            label2.Name = "label2";
            label2.Size = new Size(140, 22);
            label2.TabIndex = 0;
            label2.Text = "Tên Đăng Nhập";
            // 
            // tk
            // 
            tk.BorderStyle = BorderStyle.FixedSingle;
            tk.Location = new Point(48, 153);
            tk.Margin = new Padding(3, 2, 3, 2);
            tk.Name = "tk";
            tk.Size = new Size(294, 23);
            tk.TabIndex = 1;
            // 
            // mk
            // 
            mk.BorderStyle = BorderStyle.FixedSingle;
            mk.Location = new Point(48, 247);
            mk.Margin = new Padding(3, 2, 3, 2);
            mk.Name = "mk";
            mk.Size = new Size(294, 23);
            mk.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(48, 223);
            label3.Name = "label3";
            label3.Size = new Size(90, 22);
            label3.TabIndex = 2;
            label3.Text = "Mật khẩu";
            // 
            // nlmk
            // 
            nlmk.BorderStyle = BorderStyle.FixedSingle;
            nlmk.Location = new Point(48, 320);
            nlmk.Margin = new Padding(3, 2, 3, 2);
            nlmk.Name = "nlmk";
            nlmk.Size = new Size(294, 23);
            nlmk.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(48, 296);
            label4.Name = "label4";
            label4.Size = new Size(169, 22);
            label4.TabIndex = 4;
            label4.Text = "Xác nhận mật khẩu";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(48, 384);
            label5.Name = "label5";
            label5.Size = new Size(43, 17);
            label5.TabIndex = 4;
            label5.Text = "Email";
            // 
            // email
            // 
            email.Location = new Point(48, 403);
            email.Margin = new Padding(3, 2, 3, 2);
            email.Name = "email";
            email.Size = new Size(294, 23);
            email.TabIndex = 5;
            // 
            // dk
            // 
            dk.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dk.Location = new Point(108, 461);
            dk.Margin = new Padding(3, 2, 3, 2);
            dk.Name = "dk";
            dk.Size = new Size(176, 38);
            dk.TabIndex = 6;
            dk.Text = "Đăng ký";
            dk.UseVisualStyleBackColor = true;
            dk.Click += dk_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 379);
            label1.Name = "label1";
            label1.Size = new Size(58, 22);
            label1.TabIndex = 4;
            label1.Text = "Email";
            // 
            // em
            // 
            em.BorderStyle = BorderStyle.FixedSingle;
            em.Location = new Point(48, 403);
            em.Margin = new Padding(3, 2, 3, 2);
            em.Name = "em";
            em.Size = new Size(294, 23);
            em.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo21;
            pictureBox1.Location = new Point(442, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(472, 467);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(88, 513);
            label7.Name = "label7";
            label7.Size = new Size(136, 19);
            label7.TabIndex = 10;
            label7.Text = "Đã có sẵn tài khoản?";
            // 
            // linkDN
            // 
            linkDN.AutoSize = true;
            linkDN.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkDN.LinkColor = Color.Black;
            linkDN.Location = new Point(221, 513);
            linkDN.Name = "linkDN";
            linkDN.Size = new Size(79, 19);
            linkDN.TabIndex = 11;
            linkDN.TabStop = true;
            linkDN.Text = "Đăng Nhập";
            linkDN.LinkClicked += linkDN_LinkClicked;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(34, 53);
            label6.Name = "label6";
            label6.Size = new Size(250, 31);
            label6.TabIndex = 12;
            label6.Text = "Đăng Ký Tài Khoản";
            // 
            // Dangky
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(959, 587);
            Controls.Add(label6);
            Controls.Add(linkDN);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(dk);
            Controls.Add(em);
            Controls.Add(email);
            Controls.Add(label1);
            Controls.Add(nlmk);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(mk);
            Controls.Add(label3);
            Controls.Add(tk);
            Controls.Add(label2);
            ForeColor = SystemColors.ActiveCaptionText;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Dangky";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dangky";
            Load += Dangky_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private Label label5;
        private TextBox textBox5;
        private Button dk;
        private TextBox tk;
        private TextBox mk;
        private TextBox email;
        private TextBox nlmk;
        private Label label1;
        private TextBox em;
        private PictureBox pictureBox1;
        private Label label7;
        private LinkLabel linkDN;
        private Label label6;
    }
}