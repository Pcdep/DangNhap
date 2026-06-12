namespace Presentation
{
    partial class FrmHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoaDon));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            HoaDon = new Label();
            btnInHoaDon = new Guna.UI2.WinForms.Guna2Button();
            btnDong = new Guna.UI2.WinForms.Guna2Button();
            lblChiTietDanhSach = new Label();
            lblNgayLap = new Label();
            lblMaHoaDon = new Label();
            lblTongTien = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // HoaDon
            // 
            HoaDon.AutoSize = true;
            HoaDon.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HoaDon.Location = new Point(197, 9);
            HoaDon.Name = "HoaDon";
            HoaDon.Size = new Size(299, 74);
            HoaDon.TabIndex = 0;
            HoaDon.Text = "HÓA ĐƠN";
            // 
            // btnInHoaDon
            // 
            btnInHoaDon.CustomizableEdges = customizableEdges1;
            btnInHoaDon.DisabledState.BorderColor = Color.DarkGray;
            btnInHoaDon.DisabledState.CustomBorderColor = Color.DarkGray;
            btnInHoaDon.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnInHoaDon.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnInHoaDon.Font = new Font("Segoe UI", 9F);
            btnInHoaDon.ForeColor = Color.White;
            btnInHoaDon.Location = new Point(452, 547);
            btnInHoaDon.Name = "btnInHoaDon";
            btnInHoaDon.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnInHoaDon.Size = new Size(192, 38);
            btnInHoaDon.TabIndex = 9;
            btnInHoaDon.Text = "In hóa đơn";
            // 
            // btnDong
            // 
            btnDong.BackgroundImage = (Image)resources.GetObject("btnDong.BackgroundImage");
            btnDong.CustomizableEdges = customizableEdges3;
            btnDong.DisabledState.BorderColor = Color.DarkGray;
            btnDong.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDong.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDong.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDong.FillColor = Color.Transparent;
            btnDong.Font = new Font("Segoe UI", 9F);
            btnDong.ForeColor = Color.White;
            btnDong.Image = (Image)resources.GetObject("btnDong.Image");
            btnDong.ImageSize = new Size(40, 40);
            btnDong.Location = new Point(612, 3);
            btnDong.Name = "btnDong";
            btnDong.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnDong.Size = new Size(59, 62);
            btnDong.TabIndex = 12;
            btnDong.Click += btnDong_Click;
            // 
            // lblChiTietDanhSach
            // 
            lblChiTietDanhSach.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblChiTietDanhSach.Location = new Point(67, 223);
            lblChiTietDanhSach.Name = "lblChiTietDanhSach";
            lblChiTietDanhSach.Size = new Size(544, 257);
            lblChiTietDanhSach.TabIndex = 13;
            lblChiTietDanhSach.Text = "Tổng sản phẩm";
            // 
            // lblNgayLap
            // 
            lblNgayLap.AutoSize = true;
            lblNgayLap.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNgayLap.Location = new Point(206, 119);
            lblNgayLap.Name = "lblNgayLap";
            lblNgayLap.Size = new Size(59, 28);
            lblNgayLap.TabIndex = 14;
            lblNgayLap.Text = "Ngày";
            // 
            // lblMaHoaDon
            // 
            lblMaHoaDon.AutoSize = true;
            lblMaHoaDon.Location = new Point(233, 180);
            lblMaHoaDon.Name = "lblMaHoaDon";
            lblMaHoaDon.Size = new Size(114, 25);
            lblMaHoaDon.TabIndex = 15;
            lblMaHoaDon.Text = "Mã Hóa Đơn";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTongTien.Location = new Point(532, 495);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(95, 28);
            lblTongTien.TabIndex = 16;
            lblTongTien.Text = "Tổng tiền";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(67, 115);
            label1.Name = "label1";
            label1.Size = new Size(133, 32);
            label1.TabIndex = 17;
            label1.Text = "Ngày Mua:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(67, 173);
            label2.Name = "label2";
            label2.Size = new Size(160, 32);
            label2.TabIndex = 18;
            label2.Text = "Mã Hóa Đơn:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(408, 492);
            label3.Name = "label3";
            label3.Size = new Size(128, 32);
            label3.TabIndex = 19;
            label3.Text = "Tổng Tiền:";
            // 
            // FrmHoaDon
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(674, 608);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblTongTien);
            Controls.Add(lblMaHoaDon);
            Controls.Add(lblNgayLap);
            Controls.Add(lblChiTietDanhSach);
            Controls.Add(btnDong);
            Controls.Add(btnInHoaDon);
            Controls.Add(HoaDon);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmHoaDon";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmHoaDon";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label HoaDon;
        private Guna.UI2.WinForms.Guna2Button btnInHoaDon;
        private Guna.UI2.WinForms.Guna2Button btnDong;
        private Label lblChiTietDanhSach;
        private Label lblNgayLap;
        private Label lblMaHoaDon;
        private Label lblTongTien;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}