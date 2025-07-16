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
            Button button1;
            label1 = new Label();
            email = new TextBox();
            xacnhan = new Button();
            panel1 = new Panel();
            label2 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(50, 233);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(87, 32);
            label1.TabIndex = 0;
            label1.Text = "Email";
            label1.Click += label1_Click;
            // 
            // email
            // 
            email.BorderStyle = BorderStyle.FixedSingle;
            email.Location = new Point(159, 235);
            email.Margin = new Padding(4, 3, 4, 3);
            email.Name = "email";
            email.Size = new Size(345, 31);
            email.TabIndex = 1;
            // 
            // xacnhan
            // 
            xacnhan.BackColor = SystemColors.Control;
            xacnhan.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            xacnhan.ForeColor = Color.Black;
            xacnhan.Location = new Point(57, 417);
            xacnhan.Margin = new Padding(4, 3, 4, 3);
            xacnhan.Name = "xacnhan";
            xacnhan.Size = new Size(187, 73);
            xacnhan.TabIndex = 4;
            xacnhan.Text = "Xác nhận";
            xacnhan.UseVisualStyleBackColor = false;
            xacnhan.Click += xacnhan_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Honeydew;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(email);
            panel1.Controls.Add(xacnhan);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(414, 200);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(571, 583);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(317, 417);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(187, 73);
            button1.TabIndex = 6;
            button1.Text = "Quay Lại";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.ForestGreen;
            label2.Location = new Point(137, 65);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(296, 47);
            label2.TabIndex = 5;
            label2.Text = "Quên mật khẩu";
            label2.Click += label2_Click;
            // 
            // quenmatkhau
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(192, 255, 192);
            ClientSize = new Size(1369, 973);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
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