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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSanPham));
            pnlDanhSach = new Panel();
            dgvSanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colTonKho = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            pnlChiTiet = new Panel();
            btnBoQua = new Button();
            btnXoa = new Button();
            btnLuu = new Button();
            btnThem = new Button();
            tsTrangThai = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            txtSoLuongTon = new TextBox();
            txtGiaBan = new TextBox();
            txtTenSP = new TextBox();
            txtMaSP = new TextBox();
            btnChonAnh = new Guna.UI2.WinForms.Guna2Button();
            picHinhAnh = new PictureBox();
            pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            pnlChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).BeginInit();
            SuspendLayout();
            // 
            // pnlDanhSach
            // 
            pnlDanhSach.Controls.Add(dgvSanPham);
            pnlDanhSach.Location = new Point(48, 24);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Size = new Size(891, 307);
            pnlDanhSach.TabIndex = 0;
            // 
            // dgvSanPham
            // 
            dataGridViewCellStyle4.BackColor = Color.White;
            dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.White;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgvSanPham.ColumnHeadersHeight = 27;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colGiaBan, colTonKho, colTrangThai });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.White;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dgvSanPham.DefaultCellStyle = dataGridViewCellStyle6;
            dgvSanPham.Dock = DockStyle.Fill;
            dgvSanPham.GridColor = Color.FromArgb(231, 229, 255);
            dgvSanPham.Location = new Point(0, 0);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersVisible = false;
            dgvSanPham.RowHeadersWidth = 62;
            dgvSanPham.Size = new Size(891, 307);
            dgvSanPham.TabIndex = 0;
            dgvSanPham.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvSanPham.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvSanPham.ThemeStyle.HeaderStyle.Height = 27;
            dgvSanPham.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvSanPham.ThemeStyle.RowsStyle.Height = 33;
            // 
            // colMaSP
            // 
            colMaSP.HeaderText = "Mã SP";
            colMaSP.MinimumWidth = 8;
            colMaSP.Name = "colMaSP";
            // 
            // colTenSP
            // 
            colTenSP.HeaderText = "Tên Sản phẩm";
            colTenSP.MinimumWidth = 8;
            colTenSP.Name = "colTenSP";
            // 
            // colGiaBan
            // 
            colGiaBan.HeaderText = "Giá bán";
            colGiaBan.MinimumWidth = 8;
            colGiaBan.Name = "colGiaBan";
            // 
            // colTonKho
            // 
            colTonKho.HeaderText = "Tồn kho";
            colTonKho.MinimumWidth = 8;
            colTonKho.Name = "colTonKho";
            // 
            // colTrangThai
            // 
            colTrangThai.HeaderText = "Trạng thái";
            colTrangThai.MinimumWidth = 8;
            colTrangThai.Name = "colTrangThai";
            // 
            // pnlChiTiet
            // 
            pnlChiTiet.Controls.Add(btnBoQua);
            pnlChiTiet.Controls.Add(btnXoa);
            pnlChiTiet.Controls.Add(btnLuu);
            pnlChiTiet.Controls.Add(btnThem);
            pnlChiTiet.Controls.Add(tsTrangThai);
            pnlChiTiet.Controls.Add(txtSoLuongTon);
            pnlChiTiet.Controls.Add(txtGiaBan);
            pnlChiTiet.Controls.Add(txtTenSP);
            pnlChiTiet.Controls.Add(txtMaSP);
            pnlChiTiet.Controls.Add(btnChonAnh);
            pnlChiTiet.Controls.Add(picHinhAnh);
            pnlChiTiet.Location = new Point(48, 351);
            pnlChiTiet.Name = "pnlChiTiet";
            pnlChiTiet.Size = new Size(891, 240);
            pnlChiTiet.TabIndex = 1;
            // 
            // btnBoQua
            // 
            btnBoQua.Location = new Point(662, 172);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(96, 45);
            btnBoQua.TabIndex = 10;
            btnBoQua.Text = "Bỏ Qua";
            btnBoQua.UseVisualStyleBackColor = true;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(509, 172);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(115, 45);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            btnLuu.Location = new Point(662, 113);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(96, 45);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(509, 113);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(115, 45);
            btnThem.TabIndex = 7;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // tsTrangThai
            // 
            tsTrangThai.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            tsTrangThai.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            tsTrangThai.CheckedState.InnerBorderColor = Color.White;
            tsTrangThai.CheckedState.InnerColor = Color.White;
            tsTrangThai.CustomizableEdges = customizableEdges5;
            tsTrangThai.Location = new Point(824, 17);
            tsTrangThai.Name = "tsTrangThai";
            tsTrangThai.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tsTrangThai.Size = new Size(52, 30);
            tsTrangThai.TabIndex = 6;
            tsTrangThai.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            tsTrangThai.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            tsTrangThai.UncheckedState.InnerBorderColor = Color.White;
            tsTrangThai.UncheckedState.InnerColor = Color.White;
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Location = new Point(545, 35);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.ReadOnly = true;
            txtSoLuongTon.Size = new Size(150, 31);
            txtSoLuongTon.TabIndex = 5;
            txtSoLuongTon.Text = "Số lượng tồn";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(233, 146);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(150, 31);
            txtGiaBan.TabIndex = 4;
            txtGiaBan.Text = "Giá bán";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(233, 91);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(150, 31);
            txtTenSP.TabIndex = 3;
            txtTenSP.Text = "Tên mỹ phẩm";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(233, 35);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.ReadOnly = true;
            txtMaSP.Size = new Size(150, 31);
            txtMaSP.TabIndex = 2;
            txtMaSP.Text = "Mã sản phẩm";
            // 
            // btnChonAnh
            // 
            btnChonAnh.CustomizableEdges = customizableEdges7;
            btnChonAnh.DisabledState.BorderColor = Color.DarkGray;
            btnChonAnh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChonAnh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChonAnh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChonAnh.Font = new Font("Segoe UI", 9F);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(22, 183);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnChonAnh.Size = new Size(174, 45);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Chọn ảnh";
            btnChonAnh.Click += btnChonAnh_Click;
            // 
            // picHinhAnh
            // 
            picHinhAnh.Location = new Point(22, 17);
            picHinhAnh.Name = "picHinhAnh";
            picHinhAnh.Size = new Size(174, 160);
            picHinhAnh.TabIndex = 0;
            picHinhAnh.TabStop = false;
            // 
            // FrmSanPham
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(974, 603);
            Controls.Add(pnlChiTiet);
            Controls.Add(pnlDanhSach);
            DoubleBuffered = true;
            Name = "FrmSanPham";
            Text = "FrmSanPham";
            pnlDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            pnlChiTiet.ResumeLayout(false);
            pnlChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picHinhAnh).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDanhSach;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSanPham;
        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colGiaBan;
        private DataGridViewTextBoxColumn colTonKho;
        private DataGridViewTextBoxColumn colTrangThai;
        private Panel pnlChiTiet;
        private TextBox txtMaSP;
        private Guna.UI2.WinForms.Guna2Button btnChonAnh;
        private PictureBox picHinhAnh;
        private TextBox txtSoLuongTon;
        private TextBox txtGiaBan;
        private TextBox txtTenSP;
        private Button btnBoQua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnThem;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsTrangThai;
    }
}