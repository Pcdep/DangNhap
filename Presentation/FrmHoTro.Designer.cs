namespace Presentation
{
    partial class FrmHoTro
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtSoLuongTra = new TextBox();
            txtLyDo = new TextBox();
            btnTaoPhieu = new Guna.UI2.WinForms.Guna2Button();
            txtMaHoaDon = new TextBox();
            txtMaSP = new TextBox();
            dgvLichSuMua = new Guna.UI2.WinForms.Guna2DataGridView();
            MaHoaDon = new DataGridViewTextBoxColumn();
            NgayLap = new DataGridViewTextBoxColumn();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            SoLuong = new DataGridViewTextBoxColumn();
            GiaBan = new DataGridViewTextBoxColumn();
            ThanhTien = new DataGridViewTextBoxColumn();
            btnTraCuu = new Guna.UI2.WinForms.Guna2Button();
            txtNgayMua = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuMua).BeginInit();
            SuspendLayout();
            // 
            // txtSoLuongTra
            // 
            txtSoLuongTra.Location = new Point(102, 434);
            txtSoLuongTra.Name = "txtSoLuongTra";
            txtSoLuongTra.Size = new Size(318, 31);
            txtSoLuongTra.TabIndex = 1;
            // 
            // txtLyDo
            // 
            txtLyDo.Location = new Point(102, 488);
            txtLyDo.Name = "txtLyDo";
            txtLyDo.Size = new Size(318, 31);
            txtLyDo.TabIndex = 2;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.CustomizableEdges = customizableEdges1;
            btnTaoPhieu.DisabledState.BorderColor = Color.DarkGray;
            btnTaoPhieu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTaoPhieu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTaoPhieu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTaoPhieu.Font = new Font("Segoe UI", 9F);
            btnTaoPhieu.ForeColor = Color.White;
            btnTaoPhieu.Location = new Point(708, 669);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTaoPhieu.Size = new Size(170, 34);
            btnTaoPhieu.TabIndex = 3;
            btnTaoPhieu.Text = "Tạo Phiếu";
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // txtMaHoaDon
            // 
            txtMaHoaDon.Location = new Point(112, 365);
            txtMaHoaDon.Name = "txtMaHoaDon";
            txtMaHoaDon.Size = new Size(308, 31);
            txtMaHoaDon.TabIndex = 4;
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(112, 299);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(308, 31);
            txtMaSP.TabIndex = 5;
            // 
            // dgvLichSuMua
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvLichSuMua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvLichSuMua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvLichSuMua.ColumnHeadersHeight = 52;
            dgvLichSuMua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvLichSuMua.Columns.AddRange(new DataGridViewColumn[] { MaHoaDon, NgayLap, MaSP, TenSP, SoLuong, GiaBan, ThanhTien });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvLichSuMua.DefaultCellStyle = dataGridViewCellStyle3;
            dgvLichSuMua.GridColor = Color.FromArgb(231, 229, 255);
            dgvLichSuMua.Location = new Point(67, 33);
            dgvLichSuMua.Name = "dgvLichSuMua";
            dgvLichSuMua.RowHeadersVisible = false;
            dgvLichSuMua.RowHeadersWidth = 62;
            dgvLichSuMua.Size = new Size(811, 230);
            dgvLichSuMua.TabIndex = 7;
            dgvLichSuMua.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvLichSuMua.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvLichSuMua.ThemeStyle.HeaderStyle.Height = 52;
            dgvLichSuMua.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvLichSuMua.ThemeStyle.RowsStyle.Height = 33;
            dgvLichSuMua.CellClick += dgvLichSuMua_CellClick;
            // 
            // MaHoaDon
            // 
            MaHoaDon.DataPropertyName = "MaHoaDon";
            MaHoaDon.HeaderText = "Mã Hóa Đơn";
            MaHoaDon.MinimumWidth = 8;
            MaHoaDon.Name = "MaHoaDon";
            // 
            // NgayLap
            // 
            NgayLap.DataPropertyName = "NgayLap";
            NgayLap.HeaderText = "Ngày Mua";
            NgayLap.MinimumWidth = 8;
            NgayLap.Name = "NgayLap";
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã Sản Phẩm";
            MaSP.MinimumWidth = 8;
            MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            TenSP.DataPropertyName = "TenSP";
            TenSP.HeaderText = "Tên Sản Phẩm";
            TenSP.MinimumWidth = 8;
            TenSP.Name = "TenSP";
            // 
            // SoLuong
            // 
            SoLuong.DataPropertyName = "SoLuong";
            SoLuong.HeaderText = "Số Lượng Đã Mua";
            SoLuong.MinimumWidth = 8;
            SoLuong.Name = "SoLuong";
            // 
            // GiaBan
            // 
            GiaBan.DataPropertyName = "GiaBan";
            GiaBan.HeaderText = "Đơn Giá";
            GiaBan.MinimumWidth = 8;
            GiaBan.Name = "GiaBan";
            // 
            // ThanhTien
            // 
            ThanhTien.DataPropertyName = "ThanhTien";
            ThanhTien.HeaderText = "Thành Tiền";
            ThanhTien.MinimumWidth = 8;
            ThanhTien.Name = "ThanhTien";
            // 
            // btnTraCuu
            // 
            btnTraCuu.CustomizableEdges = customizableEdges3;
            btnTraCuu.DisabledState.BorderColor = Color.DarkGray;
            btnTraCuu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTraCuu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTraCuu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTraCuu.Font = new Font("Segoe UI", 9F);
            btnTraCuu.ForeColor = Color.White;
            btnTraCuu.Location = new Point(553, 669);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnTraCuu.Size = new Size(132, 34);
            btnTraCuu.TabIndex = 8;
            btnTraCuu.Text = "Tra Cứu";
            btnTraCuu.Click += btnTraCuu_Click;
            // 
            // txtNgayMua
            // 
            txtNgayMua.Location = new Point(546, 299);
            txtNgayMua.Name = "txtNgayMua";
            txtNgayMua.Size = new Size(231, 31);
            txtNgayMua.TabIndex = 9;
            // 
            // FrmHoTro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(938, 734);
            Controls.Add(txtNgayMua);
            Controls.Add(btnTraCuu);
            Controls.Add(dgvLichSuMua);
            Controls.Add(txtMaSP);
            Controls.Add(txtMaHoaDon);
            Controls.Add(btnTaoPhieu);
            Controls.Add(txtLyDo);
            Controls.Add(txtSoLuongTra);
            Name = "FrmHoTro";
            Text = "FrmHoTro";
            Load += FrmHoTro_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichSuMua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtSoLuongTra;
        private TextBox txtLyDo;
        private Guna.UI2.WinForms.Guna2Button btnTaoPhieu;
        private TextBox txtMaHoaDon;
        private TextBox txtMaSP;
        private Guna.UI2.WinForms.Guna2DataGridView dgvLichSuMua;
        private Guna.UI2.WinForms.Guna2Button btnTraCuu;
        private DataGridViewTextBoxColumn MaHoaDon;
        private DataGridViewTextBoxColumn NgayLap;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn SoLuong;
        private DataGridViewTextBoxColumn GiaBan;
        private DataGridViewTextBoxColumn ThanhTien;
        private TextBox txtNgayMua;
    }
}