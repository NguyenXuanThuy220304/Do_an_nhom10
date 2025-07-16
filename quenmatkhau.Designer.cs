namespace Do_an_P10
{
    partial class quenmatkhau
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
            email = new TextBox();
            xacnhan = new Button();
            panel1 = new Panel();
            button1 = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(40, 121);
            label1.Name = "label1";
            label1.Size = new Size(63, 22);
            label1.TabIndex = 0;
            label1.Text = "Email ";
            // 
            // email
            // 
            email.BorderStyle = BorderStyle.FixedSingle;
            email.Location = new Point(40, 171);
            email.Margin = new Padding(3, 2, 3, 2);
            email.Name = "email";
            email.Size = new Size(313, 23);
            email.TabIndex = 1;
            // 
            // xacnhan
            // 
            xacnhan.BackColor = Color.LimeGreen;
            xacnhan.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            xacnhan.ForeColor = Color.White;
            xacnhan.Location = new Point(40, 250);
            xacnhan.Margin = new Padding(3, 2, 3, 2);
            xacnhan.Name = "xacnhan";
            xacnhan.Size = new Size(131, 44);
            xacnhan.TabIndex = 4;
            xacnhan.Text = "Xác nhận";
            xacnhan.UseVisualStyleBackColor = false;
            xacnhan.Click += xacnhan_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(email);
            panel1.Controls.Add(xacnhan);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(290, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 350);
            panel1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.LimeGreen;
            button1.Location = new Point(222, 250);
            button1.Name = "button1";
            button1.Size = new Size(131, 44);
            button1.TabIndex = 6;
            button1.Text = "Quay Lại";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(77, 39);
            label2.Name = "label2";
            label2.Size = new Size(255, 31);
            label2.TabIndex = 5;
            label2.Text = "Cập Nhật Mật Khẩu";
            // 
            // quenmatkhau
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(958, 584);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "quenmatkhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "quenmatkhau";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox email;
        private Button xacnhan;
        private Panel panel1;
        private Label label2;
        private Button button1;
    }
}