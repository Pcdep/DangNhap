namespace Presentation
{
    partial class FrmChiTietSanPham
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            picHinhAnh = new PictureBox();
            lblTenSP = new Label();
            lblGiaSP = new Label();
            numSoLuong = new Guna.UI2.WinForms.Guna2NumericUpDown();
            btnThemGioHang = new Guna.UI2.WinForms.Guna2Button();
            btnDatNgay = new Guna.UI2.WinForms.Guna2Button();
            btnHuy = new Guna.UI2.WinForms.Guna2Button();
            lblThongTinSanPham = new Label();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            SuspendLayout();
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(33, 88);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(240, 217);
            picHinhAnh.TabIndex = 0;
            picHinhAnh.TabStop = false;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Font = new Font("Segoe UI", 22F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTenSP.Location = new Point(314, 109);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(560, 60);
            lblTenSP.TabIndex = 1;
            lblTenSP.Text = "Nước hoa............................";
            // 
            // lblGiaSP
            // 
            lblGiaSP.AutoSize = true;
            lblGiaSP.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGiaSP.Location = new Point(314, 188);
            lblGiaSP.Name = "lblGiaSP";
            lblGiaSP.Size = new Size(153, 45);
            lblGiaSP.TabIndex = 2;
            lblGiaSP.Text = "100 VNĐ";
            // 
            // numSoLuong
            // 
            numSoLuong.BackColor = Color.Transparent;
            numSoLuong.CustomizableEdges = customizableEdges1;
            numSoLuong.Font = new Font("Segoe UI", 9F);
            numSoLuong.Location = new Point(328, 244);
            numSoLuong.Margin = new Padding(4, 5, 4, 5);
            numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.ShadowDecoration.CustomizableEdges = customizableEdges2;
            numSoLuong.Size = new Size(214, 61);
            numSoLuong.TabIndex = 3;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThemGioHang
            // 
            btnThemGioHang.CustomizableEdges = customizableEdges3;
            btnThemGioHang.DisabledState.BorderColor = Color.DarkGray;
            btnThemGioHang.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThemGioHang.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThemGioHang.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThemGioHang.Font = new Font("Segoe UI", 9F);
            btnThemGioHang.ForeColor = Color.White;
            btnThemGioHang.Location = new Point(483, 517);
            btnThemGioHang.Name = "btnThemGioHang";
            btnThemGioHang.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnThemGioHang.Size = new Size(205, 59);
            btnThemGioHang.TabIndex = 5;
            btnThemGioHang.Text = "Thêm vào giỏ hàng";
            btnThemGioHang.Click += btnThemGioHang_Click;
            // 
            // btnDatNgay
            // 
            btnDatNgay.CustomizableEdges = customizableEdges5;
            btnDatNgay.DisabledState.BorderColor = Color.DarkGray;
            btnDatNgay.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDatNgay.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDatNgay.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDatNgay.Font = new Font("Segoe UI", 9F);
            btnDatNgay.ForeColor = Color.White;
            btnDatNgay.Location = new Point(759, 517);
            btnDatNgay.Name = "btnDatNgay";
            btnDatNgay.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnDatNgay.Size = new Size(216, 59);
            btnDatNgay.TabIndex = 6;
            btnDatNgay.Text = "Đặt ngay";
            btnDatNgay.Click += btnDatNgay_Click;
            // 
            // btnHuy
            // 
            btnHuy.CustomizableEdges = customizableEdges7;
            btnHuy.DisabledState.BorderColor = Color.DarkGray;
            btnHuy.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHuy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHuy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHuy.Font = new Font("Segoe UI", 9F);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(878, 12);
            btnHuy.Name = "btnHuy";
            btnHuy.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnHuy.Size = new Size(121, 54);
            btnHuy.TabIndex = 7;
            btnHuy.Text = "Tắt";
            btnHuy.Click += btnHuy_Click;
            // 
            // lblThongTinSanPham
            // 
            lblThongTinSanPham.Font = new Font("Segoe UI", 14F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblThongTinSanPham.Location = new Point(33, 354);
            lblThongTinSanPham.Name = "lblThongTinSanPham";
            lblThongTinSanPham.Size = new Size(942, 135);
            lblThongTinSanPham.TabIndex = 8;
            lblThongTinSanPham.Text = "Thông tin sản phẩm";
            lblThongTinSanPham.Click += label2_Click;
            // 
            // FrmChiTietSanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 616);
            Controls.Add(lblThongTinSanPham);
            Controls.Add(btnHuy);
            Controls.Add(btnDatNgay);
            Controls.Add(btnThemGioHang);
            Controls.Add(numSoLuong);
            Controls.Add(lblGiaSP);
            Controls.Add(lblTenSP);
            Controls.Add(picHinhAnh);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmChiTietSanPham";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmChiTietSanPham";
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picHinhAnh;
        private Label lblTenSP;
        private Label lblGiaSP;
        private Guna.UI2.WinForms.Guna2NumericUpDown numSoLuong;
        private Guna.UI2.WinForms.Guna2Button btnThemGioHang;
        private Guna.UI2.WinForms.Guna2Button btnDatNgay;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Label lblThongTinSanPham;
    }
}