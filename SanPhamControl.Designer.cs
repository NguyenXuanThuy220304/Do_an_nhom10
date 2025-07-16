namespace Do_an_P10
{
    partial class SanPhamControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            lblTenSP = new Label();
            lblGia = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(25, 22);
            pictureBox1.Margin = new Padding(4, 4, 4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(225, 288);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblTenSP.Location = new Point(46, 318);
            lblTenSP.Margin = new Padding(4, 0, 4, 0);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(60, 23);
            lblTenSP.TabIndex = 1;
            lblTenSP.Text = "label1";
            // 
            // lblGia
            // 
            lblGia.AutoSize = true;
            lblGia.Font = new Font("Times New Roman", 10F, FontStyle.Bold);
            lblGia.Location = new Point(79, 363);
            lblGia.Margin = new Padding(4, 0, 4, 0);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(60, 23);
            lblGia.TabIndex = 2;
            lblGia.Text = "label1";
            // 
            // SanPhamControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblGia);
            Controls.Add(lblTenSP);
            Controls.Add(pictureBox1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "SanPhamControl";
            Size = new Size(274, 414);
            Load += SanPhamControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label lblTenSP;
        private Label lblGia;
    }
}
