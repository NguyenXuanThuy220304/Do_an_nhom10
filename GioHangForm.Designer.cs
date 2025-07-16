namespace Do_an_P10
{
    partial class GioHangForm
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
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            txtEmail = new TextBox();
            txtDiaChi = new TextBox();
            txtSDT = new TextBox();
            txtHoTen = new TextBox();
            labelEmail = new Label();
            labelDC = new Label();
            labelSDT = new Label();
            labelHT = new Label();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(dataGridView1);
            groupBox1.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(1, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1083, 736);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giỏ hàng của bạn";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtEmail);
            groupBox2.Controls.Add(txtDiaChi);
            groupBox2.Controls.Add(txtSDT);
            groupBox2.Controls.Add(txtHoTen);
            groupBox2.Controls.Add(labelEmail);
            groupBox2.Controls.Add(labelDC);
            groupBox2.Controls.Add(labelSDT);
            groupBox2.Controls.Add(labelHT);
            groupBox2.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(25, 93);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(462, 536);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thông Tin Khách hàng";
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(22, 439);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(412, 35);
            txtEmail.TabIndex = 7;
            // 
            // txtDiaChi
            // 
            txtDiaChi.BackColor = Color.White;
            txtDiaChi.BorderStyle = BorderStyle.FixedSingle;
            txtDiaChi.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDiaChi.Location = new Point(22, 319);
            txtDiaChi.Margin = new Padding(3, 4, 3, 4);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.ReadOnly = true;
            txtDiaChi.Size = new Size(412, 35);
            txtDiaChi.TabIndex = 6;
            // 
            // txtSDT
            // 
            txtSDT.BackColor = Color.White;
            txtSDT.BorderStyle = BorderStyle.FixedSingle;
            txtSDT.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSDT.Location = new Point(22, 205);
            txtSDT.Margin = new Padding(3, 4, 3, 4);
            txtSDT.Name = "txtSDT";
            txtSDT.ReadOnly = true;
            txtSDT.Size = new Size(412, 35);
            txtSDT.TabIndex = 5;
            // 
            // txtHoTen
            // 
            txtHoTen.BackColor = Color.White;
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtHoTen.Location = new Point(22, 100);
            txtHoTen.Margin = new Padding(3, 4, 3, 4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.ReadOnly = true;
            txtHoTen.Size = new Size(412, 35);
            txtHoTen.TabIndex = 4;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmail.Location = new Point(22, 404);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(77, 29);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "Email";
            // 
            // labelDC
            // 
            labelDC.AutoSize = true;
            labelDC.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDC.Location = new Point(22, 284);
            labelDC.Name = "labelDC";
            labelDC.Size = new Size(94, 29);
            labelDC.TabIndex = 2;
            labelDC.Text = "Địa Chỉ";
            // 
            // labelSDT
            // 
            labelSDT.AutoSize = true;
            labelSDT.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelSDT.Location = new Point(22, 171);
            labelSDT.Name = "labelSDT";
            labelSDT.Size = new Size(150, 29);
            labelSDT.TabIndex = 1;
            labelSDT.Text = "Số điện thoại";
            // 
            // labelHT
            // 
            labelHT.AutoSize = true;
            labelHT.Font = new Font("Times New Roman", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelHT.Location = new Point(22, 65);
            labelHT.Name = "labelHT";
            labelHT.Size = new Size(82, 29);
            labelHT.TabIndex = 0;
            labelHT.Text = "Họ tên";
            // 
            // button2
            // 
            button2.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(880, 681);
            button2.Name = "button2";
            button2.Size = new Size(155, 41);
            button2.TabIndex = 2;
            button2.Text = "Đặt hàng";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(26, 676);
            button1.Name = "button1";
            button1.Size = new Size(155, 41);
            button1.TabIndex = 1;
            button1.Text = "Quay lại";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ImeMode = ImeMode.NoControl;
            dataGridView1.Location = new Point(510, 48);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(526, 600);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // GioHangForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 752);
            Controls.Add(groupBox1);
            Name = "GioHangForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GioHangForm";
            Load += GioHangForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Button button2;
        private Button button1;
        private GroupBox groupBox2;
        private Label labelHT;
        private Label labelSDT;
        private Label labelDC;
        private Label labelEmail;
        private TextBox txtHoTen;
        private TextBox txtEmail;
        private TextBox txtDiaChi;
        private TextBox txtSDT;
    }
}