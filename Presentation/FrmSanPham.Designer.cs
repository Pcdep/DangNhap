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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSanPham));
            pnlDanhSach = new Panel();
            pnlChiTiet = new Panel();
            dgvSanPham = new Guna.UI2.WinForms.Guna2DataGridView();
            colMaSP = new DataGridViewTextBoxColumn();
            colTenSP = new DataGridViewTextBoxColumn();
            colGiaBan = new DataGridViewTextBoxColumn();
            colTonKho = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewTextBoxColumn();
            picSanPham = new PictureBox();
            btnChonAnh = new Guna.UI2.WinForms.Guna2Button();
            txtMaSP = new TextBox();
            txtTenSP = new TextBox();
            txtGiaBan = new TextBox();
            txtTonKho = new TextBox();
            tsTrangThai = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            btnThem = new Button();
            btnLuu = new Button();
            btnXoa = new Button();
            btnBoQua = new Button();
            pnlDanhSach.SuspendLayout();
            pnlChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
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
            // pnlChiTiet
            // 
            pnlChiTiet.Controls.Add(btnBoQua);
            pnlChiTiet.Controls.Add(btnXoa);
            pnlChiTiet.Controls.Add(btnLuu);
            pnlChiTiet.Controls.Add(btnThem);
            pnlChiTiet.Controls.Add(tsTrangThai);
            pnlChiTiet.Controls.Add(txtTonKho);
            pnlChiTiet.Controls.Add(txtGiaBan);
            pnlChiTiet.Controls.Add(txtTenSP);
            pnlChiTiet.Controls.Add(txtMaSP);
            pnlChiTiet.Controls.Add(btnChonAnh);
            pnlChiTiet.Controls.Add(picSanPham);
            pnlChiTiet.Location = new Point(48, 351);
            pnlChiTiet.Name = "pnlChiTiet";
            pnlChiTiet.Size = new Size(891, 240);
            pnlChiTiet.TabIndex = 1;
            // 
            // dgvSanPham
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvSanPham.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { colMaSP, colTenSP, colGiaBan, colTonKho, colTrangThai });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSanPham.DefaultCellStyle = dataGridViewCellStyle3;
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
            dgvSanPham.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            // picSanPham
            // 
            picSanPham.Location = new Point(22, 17);
            picSanPham.Name = "picSanPham";
            picSanPham.Size = new Size(174, 160);
            picSanPham.TabIndex = 0;
            picSanPham.TabStop = false;
            // 
            // btnChonAnh
            // 
            btnChonAnh.CustomizableEdges = customizableEdges3;
            btnChonAnh.DisabledState.BorderColor = Color.DarkGray;
            btnChonAnh.DisabledState.CustomBorderColor = Color.DarkGray;
            btnChonAnh.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnChonAnh.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnChonAnh.Font = new Font("Segoe UI", 9F);
            btnChonAnh.ForeColor = Color.White;
            btnChonAnh.Location = new Point(22, 183);
            btnChonAnh.Name = "btnChonAnh";
            btnChonAnh.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnChonAnh.Size = new Size(174, 45);
            btnChonAnh.TabIndex = 1;
            btnChonAnh.Text = "Chọn ảnh";
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
            // txtTenSP
            // 
            txtTenSP.Location = new Point(233, 91);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(150, 31);
            txtTenSP.TabIndex = 3;
            txtTenSP.Text = "Tên mỹ phẩm";
            // 
            // txtGiaBan
            // 
            txtGiaBan.Location = new Point(233, 146);
            txtGiaBan.Name = "txtGiaBan";
            txtGiaBan.Size = new Size(150, 31);
            txtGiaBan.TabIndex = 4;
            txtGiaBan.Text = "Giá bán";
            // 
            // txtTonKho
            // 
            txtTonKho.Location = new Point(545, 35);
            txtTonKho.Name = "txtTonKho";
            txtTonKho.ReadOnly = true;
            txtTonKho.Size = new Size(150, 31);
            txtTonKho.TabIndex = 5;
            txtTonKho.Text = "Số lượng tồn";
            // 
            // tsTrangThai
            // 
            tsTrangThai.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
            tsTrangThai.CheckedState.FillColor = Color.FromArgb(94, 148, 255);
            tsTrangThai.CheckedState.InnerBorderColor = Color.White;
            tsTrangThai.CheckedState.InnerColor = Color.White;
            tsTrangThai.CustomizableEdges = customizableEdges1;
            tsTrangThai.Location = new Point(824, 17);
            tsTrangThai.Name = "tsTrangThai";
            tsTrangThai.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tsTrangThai.Size = new Size(52, 30);
            tsTrangThai.TabIndex = 6;
            tsTrangThai.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
            tsTrangThai.UncheckedState.FillColor = Color.FromArgb(125, 137, 149);
            tsTrangThai.UncheckedState.InnerBorderColor = Color.White;
            tsTrangThai.UncheckedState.InnerColor = Color.White;
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
            // btnLuu
            // 
            btnLuu.Location = new Point(662, 113);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(96, 45);
            btnLuu.TabIndex = 8;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = true;
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
            // btnBoQua
            // 
            btnBoQua.Location = new Point(662, 172);
            btnBoQua.Name = "btnBoQua";
            btnBoQua.Size = new Size(96, 45);
            btnBoQua.TabIndex = 10;
            btnBoQua.Text = "Bỏ Qua";
            btnBoQua.UseVisualStyleBackColor = true;
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
            pnlChiTiet.ResumeLayout(false);
            pnlChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
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
        private PictureBox picSanPham;
        private TextBox txtTonKho;
        private TextBox txtGiaBan;
        private TextBox txtTenSP;
        private Button btnBoQua;
        private Button btnXoa;
        private Button btnLuu;
        private Button btnThem;
        private Guna.UI2.WinForms.Guna2ToggleSwitch tsTrangThai;
    }
}