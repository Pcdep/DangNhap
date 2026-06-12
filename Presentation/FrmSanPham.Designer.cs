namespace Presentation
{
    partial class FrmSanPham
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSanPham));
            dgvSanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlChiTiet = new Panel();
            btnBaoHetHang = new Guna.UI2.WinForms.Guna2Button();
            txtThongTinSanPham = new TextBox();
            btnLuu = new Button();
            btnThem = new Button();
            tsTrangThai = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            txtSoLuongTon = new TextBox();
            txtGiaBan = new TextBox();
            txtTenSP = new TextBox();
            txtMaSP = new TextBox();
            btnChonAnh = new Guna.UI2.WinForms.Guna2Button();
            picHinhAnh = new PictureBox();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colTonKho = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            pnlChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // dgvSanPham
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvSanPham.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPham.ColumnHeadersHeight = 27;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colGiaBan, colTonKho, colTrangThai, Column1 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSanPham.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSanPham.GridColor = Color.FromArgb(231, 229, 255);
            dgvSanPham.Location = new Point(23, 24);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 62;
            dgvSanPham.Size = new Size(891, 370);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvSanPham.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvSanPham.ThemeStyle.HeaderStyle.Height = 27;
            dgvSanPham.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvSanPham.ThemeStyle.RowsStyle.Height = 33;
            dgvSanPham.CellClick += dgvSanPham_CellClick;
            dgvSanPham.CellContentClick += dgvSanPham_CellClick;
            // 
            // pnlChiTiet
            // 
            pnlChiTiet.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlChiTiet.Controls.Add(btnBaoHetHang);
            pnlChiTiet.Controls.Add(txtThongTinSanPham);
            pnlChiTiet.Controls.Add(btnLuu);
            pnlChiTiet.Controls.Add(btnThem);
            pnlChiTiet.Controls.Add(tsTrangThai);
            pnlChiTiet.Controls.Add(txtSoLuongTon);
            pnlChiTiet.Controls.Add(txtGiaBan);
            pnlChiTiet.Controls.Add(txtTenSP);
            pnlChiTiet.Controls.Add(txtMaSP);
            pnlChiTiet.Controls.Add(btnChonAnh);
            pnlChiTiet.Controls.Add(picHinhAnh);
            pnlChiTiet.Location = new Point(23, 415);
            pnlChiTiet.Name = "pnlChiTiet";
            pnlChiTiet.Size = new Size(891, 286);
            pnlChiTiet.TabIndex = 1;
            // 
            // btnBaoHetHang
            // 
            btnBaoHetHang.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBaoHetHang.CustomizableEdges = customizableEdges1;
            btnBaoHetHang.DisabledState.BorderColor = Color.DarkGray;
            btnBaoHetHang.DisabledState.CustomBorderColor = Color.DarkGray;
            btnBaoHetHang.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnBaoHetHang.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnBaoHetHang.Font = new Font("Segoe UI", 9F);
            btnBaoHetHang.ForeColor = Color.White;
            btnBaoHetHang.Location = new Point(743, 70);
            btnBaoHetHang.Name = "btnBaoHetHang";
            btnBaoHetHang.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnBaoHetHang.Size = new Size(133, 57);
            btnBaoHetHang.TabIndex = 12;
            btnBaoHetHang.Text = "Báo cáo hết hàng";
            btnBaoHetHang.Click += btnBaoHetHang_Click;
            // 
            // txtThongTinSanPham
            // 
            txtThongTinSanPham.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtThongTinSanPham.Location = new Point(233, 218);
            txtThongTinSanPham.Multiline = true;
            txtThongTinSanPham.Name = "txtThongTinSanPham";
            txtThongTinSanPham.Size = new Size(493, 56);
            txtThongTinSanPham.TabIndex = 11;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuu.Location = new Point(743, 217);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(133, 57);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnThem.Location = new Point(743, 143);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(133, 57);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // tsTrangThai
            // 
            tsTrangThai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tsTrangThai.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            tsTrangThai.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            tsTrangThai.CheckedState.InnerBorderColor = Color.White;
            tsTrangThai.CheckedState.InnerColor = Color.White;
            tsTrangThai.CustomizableEdges = customizableEdges3;
            tsTrangThai.Location = new Point(807, 17);
            tsTrangThai.Name = "tsTrangThai";
            tsTrangThai.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tsTrangThai.Size = new Size(69, 39);
            tsTrangThai.TabIndex = 6;
            tsTrangThai.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            tsTrangThai.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            tsTrangThai.UncheckedState.InnerBorderColor = Color.White;
            tsTrangThai.UncheckedState.InnerColor = Color.White;
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Anchor = AnchorStyles.Right;
            txtSoLuongTon.Location = new Point(501, 143);
            txtSoLuongTon.Multiline = true;
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.ReadOnly = true;
            txtSoLuongTon.Size = new Size(225, 48);
            txtSoLuongTon.TabIndex = 5;
            txtSoLuongTon.Text = "Số lượng tồn";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtGiaBan.Location = new Point(233, 143);
            txtGiaBan.Multiline = true;
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(241, 48);
            txtGiaBan.TabIndex = 4;
            txtGiaBan.Text = "Giá bán";
            // 
            // txtTenSP
            // 
            txtTenSP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTenSP.Location = new Point(233, 80);
            txtTenSP.Multiline = true;
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(493, 48);
            txtTenSP.TabIndex = 3;
            txtTenSP.Text = "Tên mỹ phẩm";
            // 
            // txtMaSP
            // 
            txtMaSP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtMaSP.Location = new Point(233, 17);
            txtMaSP.Multiline = true;
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(493, 48);
            txtMaSP.TabIndex = 2;
            txtMaSP.Text = "Mã sản phẩm";
            // 
            // btnChonAnh
            // 
            btnChonAnh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnChonAnh.CustomizableEdges = customizableEdges5;
            btnChonAnh.DisabledState.BorderColor = Color.DarkGray;
            btnChonAnh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChonAnh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChonAnh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChonAnh.Font = new Font("Segoe UI", 9F);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(22, 217);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnChonAnh.Size = new Size(180, 57);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.BackColor = Color.White;
            picHinhAnh.Location = new Point(22, 17);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(180, 180);
            picHinhAnh.TabIndex = 0;
            picHinhAnh.TabStop = false;
            // 
            // colMaSP
            // 
            colMaSP.DataPropertyName = "MaSP";
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 8;
            colMaSP.Name = "colMaSP";
            // 
            // colTenSP
            // 
            colTenSP.DataPropertyName = "TenSP";
            colTenSP.HeaderText = "Tên Sản phẩm";
            colTenSP.MinimumWidth = 8;
            colTenSP.Name = "colTenSP";
            // 
            // colGiaBan
            // 
            colGiaBan.DataPropertyName = "GiaBan";
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.MinimumWidth = 8;
            colGiaBan.Name = "colGiaBan";
            // 
            // colTonKho
            // 
            colTonKho.DataPropertyName = "SoLuongTon";
            colTonKho.HeaderText = "Tồn kho";
            colTonKho.MinimumWidth = 8;
            colTonKho.Name = "colTonKho";
            // 
            // colTrangThai
            // 
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 8;
            colTrangThai.Name = "colTrangThai";
            colTrangThai.Resizable = DataGridViewTriState.True;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "ThongTinSanPham";
            Column1.HeaderText = "Thông Tin";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // FrmSanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(938, 734);
            Controls.Add(dgvSanPham);
            Controls.Add(pnlChiTiet);
            DoubleBuffered = true;
            Name = "FrmSanPham";
            Text = "FrmSanPham";
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            pnlChiTiet.ResumeLayout(false);
            pnlChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2DataGridView dgvSanPham;
        private Panel pnlChiTiet;
        private TextBox txtMaSP;
        private Guna.UI2.WinForms.Guna2Button btnChonAnh;
        private PictureBox picHinhAnh;
        private TextBox txtSoLuongTon;
        private TextBox txtGiaBan;
        private TextBox txtTenSP;
        private Button btnLuu;
        private Button btnThem;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsTrangThai;
        private TextBox txtThongTinSanPham;
        private Guna.UI2.WinForms.Guna2Button btnBaoHetHang;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colTonKho;
        private DataGridViewTextBoxColumn colTrangThai;
        private DataGridViewTextBoxColumn Column1;
    }
}