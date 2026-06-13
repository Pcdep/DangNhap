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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoTro));
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
            groupBox1 = new GroupBox();
            groupBox3 = new GroupBox();
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLichSuMua).BeginInit();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // txtSoLuongTra
            // 
            txtSoLuongTra.Location = new Point(122, 152);
            txtSoLuongTra.Name = "txtSoLuongTra";
            txtSoLuongTra.Size = new Size(208, 31);
            txtSoLuongTra.TabIndex = 1;
            // 
            // txtLyDo
            // 
            txtLyDo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtLyDo.Location = new Point(23, 245);
            txtLyDo.Multiline = true;
            txtLyDo.Name = "txtLyDo";
            txtLyDo.Size = new Size(893, 98);
            txtLyDo.TabIndex = 2;
            // 
            // btnTaoPhieu
            // 
            btnTaoPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTaoPhieu.CustomizableEdges = customizableEdges1;
            btnTaoPhieu.DisabledState.BorderColor = Color.DarkGray;
            btnTaoPhieu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTaoPhieu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTaoPhieu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTaoPhieu.Font = new Font("Segoe UI", 9F);
            btnTaoPhieu.ForeColor = Color.White;
            btnTaoPhieu.Location = new Point(759, 357);
            btnTaoPhieu.Name = "btnTaoPhieu";
            btnTaoPhieu.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnTaoPhieu.Size = new Size(157, 59);
            btnTaoPhieu.TabIndex = 3;
            btnTaoPhieu.Text = "Tạo Phiếu";
            btnTaoPhieu.Click += btnTaoPhieu_Click;
            // 
            // txtMaHoaDon
            // 
            txtMaHoaDon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMaHoaDon.Location = new Point(18, 38);
            txtMaHoaDon.Name = "txtMaHoaDon";
            txtMaHoaDon.Size = new Size(491, 31);
            txtMaHoaDon.TabIndex = 4;
            // 
            // txtMaSP
            // 
            txtMaSP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtMaSP.Location = new Point(15, 39);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(308, 31);
            txtMaSP.TabIndex = 5;
            // 
            // dgvLichSuMua
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvLichSuMua.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvLichSuMua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            dgvLichSuMua.Location = new Point(23, 431);
            dgvLichSuMua.Name = "dgvLichSuMua";
            dgvLichSuMua.RowHeadersVisible = false;
            dgvLichSuMua.RowHeadersWidth = 62;
            dgvLichSuMua.Size = new Size(893, 279);
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
            btnTraCuu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTraCuu.CustomizableEdges = customizableEdges3;
            btnTraCuu.DisabledState.BorderColor = Color.DarkGray;
            btnTraCuu.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTraCuu.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTraCuu.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTraCuu.Font = new Font("Segoe UI", 9F);
            btnTraCuu.ForeColor = Color.White;
            btnTraCuu.Location = new Point(578, 357);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnTraCuu.Size = new Size(157, 63);
            btnTraCuu.TabIndex = 8;
            btnTraCuu.Text = "Tra Cứu";
            btnTraCuu.Click += btnTraCuu_Click;
            // 
            // txtNgayMua
            // 
            txtNgayMua.Location = new Point(459, 149);
            txtNgayMua.Name = "txtNgayMua";
            txtNgayMua.Size = new Size(276, 31);
            txtNgayMua.TabIndex = 9;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(txtMaSP);
            groupBox1.Location = new Point(578, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(338, 92);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mã Sản Phẩm";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(txtMaHoaDon);
            groupBox3.Location = new Point(23, 25);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(526, 87);
            groupBox3.TabIndex = 12;
            groupBox3.TabStop = false;
            groupBox3.Text = "Mã Hóa Đơn";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(23, 155);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 18;
            label2.Text = "Số Lượng:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(355, 155);
            label1.Name = "label1";
            label1.Size = new Size(98, 25);
            label1.TabIndex = 19;
            label1.Text = "Ngày Mua:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(23, 205);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 20;
            label3.Text = "Lý Do:";
            label3.Click += label3_Click;
            // 
            // FrmHoTro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(938, 734);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(txtNgayMua);
            Controls.Add(btnTraCuu);
            Controls.Add(dgvLichSuMua);
            Controls.Add(btnTaoPhieu);
            Controls.Add(txtLyDo);
            Controls.Add(txtSoLuongTra);
            DoubleBuffered = true;
            Name = "FrmHoTro";
            Text = "FrmHoTro";
            Load += FrmHoTro_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLichSuMua).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Label label2;
        private Label label1;
        private Label label3;
    }
}