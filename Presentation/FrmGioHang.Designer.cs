namespace Presentation
{
    partial class FrmGioHang
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGioHang));
            btnXoa = new Guna.UI2.WinForms.Guna2Button();
            btnMua = new Guna.UI2.WinForms.Guna2Button();
            dgvSanPhamMua = new Guna.UI2.WinForms.Guna2DataGridView();
            Column1 = new DataGridViewCheckBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            txtTongSoLuong = new TextBox();
            txtTongTien = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamMua).BeginInit();
            SuspendLayout();
            // 
            // btnXoa
            // 
            btnXoa.CustomizableEdges = customizableEdges1;
            btnXoa.DisabledState.BorderColor = Color.DarkGray;
            btnXoa.DisabledState.CustomBorderColor = Color.DarkGray;
            btnXoa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnXoa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnXoa.Font = new Font("Segoe UI", 9F);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(458, 502);
            btnXoa.Name = "btnXoa";
            btnXoa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnXoa.Size = new Size(166, 52);
            btnXoa.TabIndex = 1;
            btnXoa.Text = "Xóa Sản Phẩm";
            btnXoa.Click += btnXoa_Click;
            // 
            // btnMua
            // 
            btnMua.CustomizableEdges = customizableEdges3;
            btnMua.DisabledState.BorderColor = Color.DarkGray;
            btnMua.DisabledState.CustomBorderColor = Color.DarkGray;
            btnMua.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnMua.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnMua.Font = new Font("Segoe UI", 9F);
            btnMua.ForeColor = Color.White;
            btnMua.Location = new Point(242, 502);
            btnMua.Name = "btnMua";
            btnMua.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnMua.Size = new Size(166, 52);
            btnMua.TabIndex = 2;
            btnMua.Text = "Mua";
            btnMua.Click += btnMua_Click;
            // 
            // dgvSanPhamMua
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvSanPhamMua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvSanPhamMua.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvSanPhamMua.ColumnHeadersHeight = 52;
            dgvSanPhamMua.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvSanPhamMua.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvSanPhamMua.DefaultCellStyle = dataGridViewCellStyle3;
            dgvSanPhamMua.GridColor = Color.FromArgb(231, 229, 255);
            dgvSanPhamMua.Location = new Point(49, 51);
            dgvSanPhamMua.Name = "dgvSanPhamMua";
            dgvSanPhamMua.RowHeadersVisible = false;
            dgvSanPhamMua.RowHeadersWidth = 62;
            dgvSanPhamMua.Size = new Size(799, 225);
            dgvSanPhamMua.TabIndex = 3;
            dgvSanPhamMua.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvSanPhamMua.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvSanPhamMua.ThemeStyle.HeaderStyle.Height = 52;
            dgvSanPhamMua.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvSanPhamMua.ThemeStyle.RowsStyle.Height = 33;
            dgvSanPhamMua.CellValueChanged += dgvSanPhamMua_CellValueChanged;
            dgvSanPhamMua.CurrentCellDirtyStateChanged += dgvSanPhamMua_CurrentCellDirtyStateChanged_1;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "ChonMua";
            Column1.HeaderText = "Chọn Mua";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Resizable = DataGridViewTriState.True;
            Column1.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "MaSP";
            Column2.HeaderText = "Mã Sản Phẩm";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.DataPropertyName = "TenSP";
            Column3.HeaderText = "Tên Sản Phẩm";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.DataPropertyName = "GiaBan";
            Column4.HeaderText = "Giá Bán";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.DataPropertyName = "SoLuong";
            Column5.HeaderText = "Số Lượng";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.DataPropertyName = "ThongTin";
            Column6.HeaderText = "Thông Tin";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.DataPropertyName = "ThanhTien";
            Column7.HeaderText = "Thành Tiền";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            // 
            // txtTongSoLuong
            // 
            txtTongSoLuong.Location = new Point(101, 364);
            txtTongSoLuong.Name = "txtTongSoLuong";
            txtTongSoLuong.Size = new Size(150, 31);
            txtTongSoLuong.TabIndex = 4;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new Point(512, 374);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new Size(150, 31);
            txtTongTien.TabIndex = 5;
            // 
            // FrmGioHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(938, 734);
            Controls.Add(txtTongTien);
            Controls.Add(txtTongSoLuong);
            Controls.Add(dgvSanPhamMua);
            Controls.Add(btnMua);
            Controls.Add(btnXoa);
            DoubleBuffered = true;
            Name = "FrmGioHang";
            Text = "FrmGioHang";
            ((System.ComponentModel.ISupportInitialize)dgvSanPhamMua).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnXoa;
        private Guna.UI2.WinForms.Guna2Button btnMua;
        private Guna.UI2.WinForms.Guna2DataGridView dgvSanPhamMua;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private TextBox txtTongSoLuong;
        private TextBox txtTongTien;
    }
}