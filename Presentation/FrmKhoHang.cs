using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain.Entities;       // Gọi thực thể PhieuNhap, ChiTietPhieuNhap
using Application.Services;  // Gọi ThemPhieuNhapUseCase và LayDanhSachSanPhamUseCase
using Infracstructure.Services;

namespace Presentation
{
    public partial class FrmKhoHang : Form
    {
        // Danh sách đệm để lưu các chi tiết sản phẩm người dùng chọn TRÊN GIAO DIỆN (Chưa lưu CSDL)
        private List<ChiTietPhieuNhap> _listChiTietTam = new List<ChiTietPhieuNhap>();

        public FrmKhoHang()
        {
            InitializeComponent();
            this.Load += FrmKhoHang_Load;

            if (cboNhaCungCap != null)
                cboNhaCungCap.SelectedIndexChanged += CboNhaCungCap_SelectedIndexChanged;

            if (cboSanPhamNCC != null)
                cboSanPhamNCC.SelectedIndexChanged += CboSanPhamNCC_SelectedIndexChanged;

            if (btnThemVaoPhieu != null)
                btnThemVaoPhieu.Click += btnThemVaoPhieu_Click;

            if (btnLuuPhieuNhap != null)
                btnLuuPhieuNhap.Click += btnLuuPhieuNhap_Click;

            if (dgvDanhSachTongKho != null)
                dgvDanhSachTongKho.CellClick += dgvDanhSachTongKho_CellClick;
        }

        private void FrmKhoHang_Load(object sender, EventArgs e)
        {
            if (txtMaPN != null)
            {
                txtMaPN.Text = "PN-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                txtMaPN.ReadOnly = true;
            }


            // Nạp dữ liệu lên 2 Tab
            LoadTabDanhSachTong();
            LoadLaiLuoiChoDuyet();
            ToMauCanhBaoHetHang();
            LoadComboNhaCungCap();
            CaiDatBangTamGrid();

            if (cboTrangThaiGiao != null)
            {
                cboTrangThaiGiao.Items.Clear();
                cboTrangThaiGiao.Items.Add("Đã giao");
                cboTrangThaiGiao.Items.Add("Đang vận chuyển");
                cboTrangThaiGiao.Items.Add("Chờ xử lý");
                cboTrangThaiGiao.SelectedIndex = 0; // Mặc định chọn dòng đầu tiên
            }
        }

        private void LoadLaiLuoiChoDuyet()
        {
            try
            {
                // Gọi thẳng xuống Repository để lấy danh sách (Hoặc bạn có thể tạo UseCase trung gian nếu muốn chuẩn 100% 3 tầng)
                Infracstructure.Services.PhieuTraRepository repo = new Infracstructure.Services.PhieuTraRepository();

                if (dgvPhieuChoDuyet != null)
                {
                    dgvPhieuChoDuyet.AutoGenerateColumns = false; // Tắt tự sinh cột thừa
                    dgvPhieuChoDuyet.DataSource = null;           // Xóa dữ liệu cũ
                    dgvPhieuChoDuyet.DataSource = repo.LayDanhSachChoDuyet(); // Đổ dữ liệu mới vào
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu chờ duyệt: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ToMauCanhBaoHetHang()
        {
            if (dgvDanhSachTongKho == null) return;

            foreach (DataGridViewRow row in dgvDanhSachTongKho.Rows)
            {
                if (row.DataBoundItem is SanPham sp)
                {
                    // Nếu phát hiện có cờ Yêu Cầu Nhập = true (1)
                    if (sp.YeuCauNhap == true)
                    {
                        // Tô màu nền dòng đó thành Đỏ nhạt để báo động
                        row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                        row.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
        }

        private void LoadTabDanhSachTong()
        {
            try
            {
                LayTatCaSanPhamTrongKhoUseCase useCase = new LayTatCaSanPhamTrongKhoUseCase();
                var ds = useCase.Execute();

                if (dgvDanhSachTongKho != null)
                {
                    dgvDanhSachTongKho.AutoGenerateColumns = false;
                    dgvDanhSachTongKho.DataSource = null;
                    dgvDanhSachTongKho.DataSource = ds;


                }

                // 👉 TÍNH TOÁN VÀ HIỂN THỊ THỐNG KÊ TỔNG KHO
                int tongSanPham = 0;
                decimal tongGiaTri = 0;

                foreach (var item in ds)
                {
                    tongSanPham += item.SoLuongTon;
                    tongGiaTri += (item.SoLuongTon * item.GiaNhap);
                }

                if (lblTongSoLuongKho != null)
                    lblTongSoLuongKho.Text = tongSanPham.ToString("N0");

                if (lblTongGiaTriKho != null)
                    lblTongGiaTriKho.Text = tongGiaTri.ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh sách tổng kho: " + ex.Message, "Lỗi");
            }
        }



        private void dgvDanhSachTongKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click hợp lệ và KHÔNG click vào dòng trống dưới cùng (IsNewRow)
            if (e.RowIndex >= 0 && !dgvDanhSachTongKho.Rows[e.RowIndex].IsNewRow)
            {
                // Lấy đối tượng SanPham đang nằm ngầm dưới dòng được click
                if (dgvDanhSachTongKho.Rows[e.RowIndex].DataBoundItem is Domain.Entities.SanPham sp)
                {
                    // 1. Đẩy tên công ty
                    if (txtChiTietCongTy != null)
                        txtChiTietCongTy.Text = sp.TenNCC;



                    // 3. Đẩy Trạng thái giao
                    if (txtChiTietTrangThaiGiao != null)
                        txtChiTietTrangThaiGiao.Text = sp.TrangThaiGiao;

                    // 4. Đẩy Ngày nhập (Xử lý trường hợp hàng chưa từng được nhập kho)
                    if (txtChiTietNgayNhap != null)
                    {
                        if (sp.NgayNhapCuoi.HasValue) // Kiểm tra xem CSDL có ngày nhập không (khác NULL)
                        {
                            // Định dạng hiển thị đầy đủ: Ngày/Tháng/Năm Giờ:Phút
                            txtChiTietNgayNhap.Text = sp.NgayNhapCuoi.Value.ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            txtChiTietNgayNhap.Text = "Chưa từng nhập kho";
                        }
                    }
                }
            }
        }

        // ==========================================
        // THAO TÁC XỬ LÝ TRÊN TAB 2: NHẬP HÀNG (CHI TIẾT)
        // ==========================================
        private void LoadComboNhaCungCap()
        {
            try
            {
                LayTatCaNhaCungCapUseCase useCase = new LayTatCaNhaCungCapUseCase();
                var ds = useCase.Execute();
                if (cboNhaCungCap != null)
                {
                    cboNhaCungCap.DataSource = ds;
                    cboNhaCungCap.DisplayMember = "TenNCC"; // Hiển thị tên công ty
                    cboNhaCungCap.ValueMember = "MaNCC";   // Giá trị ngầm là Mã công ty
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải danh sách công ty: " + ex.Message); }
        }

        private void CboNhaCungCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra an toàn xem có đang chọn gì không
            if (cboNhaCungCap.SelectedValue == null) return;

            string maNCC = "";

            // Bẫy lỗi kinh điển: Nếu SelectedValue là một Object NhaCungCap thay vì chuỗi
            if (cboNhaCungCap.SelectedValue is NhaCungCap ncc)
            {
                maNCC = ncc.MaNCC;
            }
            else
            {
                maNCC = cboNhaCungCap.SelectedValue.ToString();
            }

            // Nếu lỡ lấy ra chuỗi rỗng thì không làm gì cả
            if (string.IsNullOrEmpty(maNCC) || maNCC == "Domain.Entities.NhaCungCap") return;

            try
            {
                LaySanPhamTheoNCCUseCase useCase = new LaySanPhamTheoNCCUseCase();
                var dsSanPhamTheoNCC = useCase.Execute(maNCC);

                if (cboSanPhamNCC != null)
                {
                    // Reset lại DataSource trước khi nạp mới để không bị kẹt bộ nhớ
                    cboSanPhamNCC.DataSource = null;

                    cboSanPhamNCC.DataSource = dsSanPhamTheoNCC;
                    cboSanPhamNCC.DisplayMember = "TenSP";
                    cboSanPhamNCC.ValueMember = "MaSP";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc sản phẩm: " + ex.Message);
            }
        }


        private void CboSanPhamNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSanPhamNCC.SelectedItem is SanPham sp)
            {
                // Tự điền Đơn vị tính
                if (txtDonViTinh != null) txtDonViTinh.Text = sp.DonViTinh;

                // Tự điền Giá Nhập và KHÓA LẠI không cho thủ kho tự sửa
                if (txtGiaNhap != null)
                {
                    txtGiaNhap.Text = sp.GiaNhap.ToString("N0"); // Hiện số có dấu phẩy
                    txtGiaNhap.ReadOnly = true; // Chốt cứng giá từ công ty đưa ra
                }
            }
        }


        private void CaiDatBangTamGrid()
        {
            if (dgvChiTietTam != null)
            {
                dgvChiTietTam.Columns.Clear();
                dgvChiTietTam.Columns.Add("MaSP", "Mã Sản Phẩm");
                dgvChiTietTam.Columns.Add("TenSP", "Tên Sản Phẩm");
                dgvChiTietTam.Columns.Add("SoLuong", "Số Lượng Nhập");
                dgvChiTietTam.Columns.Add("GiaNhap", "Giá Nhập");
            }
        }

        // HÀNH ĐỘNG 1: Bấm nút thêm món hàng vào danh sách tạm trên lưới hiển thị
        private void btnThemVaoPhieu_Click(object sender, EventArgs e)
        {
            if (cboSanPhamNCC == null || cboSanPhamNCC.SelectedItem == null) return;
            if (string.IsNullOrWhiteSpace(txtGiaNhap.Text)) return;

            SanPham spDuocChon = (SanPham)cboSanPhamNCC.SelectedItem;

            // Đọc số lượng từ NumericUpDown (hoặc chuyển đổi từ TextBox nếu bạn dùng TextBox)
            int soLuong = (numSoLuongNhap != null) ? (int)numSoLuongNhap.Value : 1;

            string giaText = txtGiaNhap.Text.Replace(",", "").Replace(".", "");
            decimal giaNhap = Convert.ToDecimal(giaText);

            // Đóng gói tạm vào đối tượng chi tiết
            ChiTietPhieuNhap ct = new ChiTietPhieuNhap
            {
                MaPN = txtMaPN.Text,
                MaSP = spDuocChon.MaSP,
                SoLuongNhap = soLuong,
                GiaNhap = giaNhap
            };

            _listChiTietTam.Add(ct);

            // Đẩy trực quan lên lưới tạm cho người dùng xem
            if (dgvChiTietTam != null)
            {
                dgvChiTietTam.Rows.Add(ct.MaSP, spDuocChon.TenSP, ct.SoLuongNhap, ct.GiaNhap.ToString("N0"));
            }

            CapNhatTongTienHienThi();
        }

        private decimal TinhTongTienPhiu()
        {
            decimal tong = 0;
            foreach (var item in _listChiTietTam)
            {
                tong += (item.SoLuongNhap * item.GiaNhap);
            }
            return tong;
        }

        private void CapNhatTongTienHienThi()
        {
            decimal tong = 0;
            foreach (var item in _listChiTietTam)
            {
                tong += (item.SoLuongNhap * item.GiaNhap);
            }

            if (lblTongTienPhiu != null)
            {
                lblTongTienPhiu.Text = "Tổng tiền phiếu: " + tong.ToString("N0") + " VNĐ";
            }
        }

        // HÀNH ĐỘNG 2: BẤM NÚT LƯU PHIẾU NHẬP (Triệu hồi 4 tầng kích hoạt số lượng kho)
        private void btnLuuPhieuNhap_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tongTien = 0;
                foreach (var item in _listChiTietTam) tongTien += (item.SoLuongNhap * item.GiaNhap);

                // 1. Tạo đối tượng Phiếu Nhập
                PhieuNhap pn = new PhieuNhap
                {
                    MaPN = txtMaPN.Text,
                    NgayNhap = (dtpNgayNhap != null) ? dtpNgayNhap.Value : DateTime.Now,
                    TongTien = tongTien
                };

                // 2. Gọi UseCase thực thi 4 tầng để lưu xuống SQL Server
                ThemPhieuNhapUseCase useCase = new ThemPhieuNhapUseCase();
                useCase.Execute(pn, _listChiTietTam);

                MessageBox.Show("Lưu phiếu nhập kho thành công! Số lượng tồn kho đã được kích hoạt tăng trưởng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 3. Reset dọn dẹp Form sau khi lưu
                _listChiTietTam.Clear();
                if (dgvChiTietTam != null) dgvChiTietTam.Rows.Clear();
                if (lblTongTienPhiu != null) lblTongTienPhiu.Text = "Tổng tiền phiếu: 0 VNĐ";

                FrmKhoHang_Load(sender, e); // Tải lại mã phiếu và bảng tổng kho mới
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thực thi lưu phiếu: " + ex.Message, "Thao tác thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmKhoHang_Load_1(object sender, EventArgs e)
        {

        }

        private void btnChuyenSangNhapHang_Click(object sender, EventArgs e)
        {
            if (guna2TabControl1 != null)
            {
                guna2TabControl1.SelectedTab = tabPage2;
            }
        }

        private void lblChiTietCongTy_Click(object sender, EventArgs e)
        {

        }

        private void txtChiTietCongTy_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string maPhieu = txtMaPhieu_Kho.Text; // Lấy từ click lưới
            string maSP = txtMaSP_Kho.Text;
            int soLuong = Convert.ToInt32(txtSoLuong_Kho.Text);

            Application.Services.DuyetPhieuTraUseCase useCase = new Application.Services.DuyetPhieuTraUseCase();

            // Đẩy trạng thái "Đã duyệt" xuống UseCase để nó tự động cộng vào kho
            if (useCase.Execute(maPhieu, "Đã duyệt", maSP, soLuong))
            {
                MessageBox.Show("Đã duyệt phiếu và cộng hàng vào kho thành công!");
                LoadLaiLuoiChoDuyet(); // Refresh lại lưới
            }
        }

        private void btnTuChoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaPhieu_Kho.Text))
            {
                MessageBox.Show("Vui lòng chọn một phiếu trên bảng để thao tác!", "Cảnh báo");
                return;
            }

            string maPhieu = txtMaPhieu_Kho.Text;
            Application.Services.DuyetPhieuTraUseCase useCase = new Application.Services.DuyetPhieuTraUseCase();

            if (useCase.Execute(maPhieu, "Từ chối", "", 0))
            {
                MessageBox.Show("Đã từ chối phiếu trả hàng. Vui lòng trả lại hàng cho khách!");
                LoadLaiLuoiChoDuyet();

                // Xóa trắng TextBox sau khi duyệt xong
                txtMaPhieu_Kho.Clear();
                txtMaSP_Kho.Clear();
                txtSoLuong_Kho.Clear();
            }
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvPhieuChoDuyet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào tiêu đề cột hoặc vùng trống
            if (e.RowIndex >= 0 && e.RowIndex < dgvPhieuChoDuyet.Rows.Count)
            {
                DataGridViewRow row = dgvPhieuChoDuyet.Rows[e.RowIndex];

                // Đổ dữ liệu từ lưới xuống Textbox dưới kho (Nhớ đảm bảo Name của cột DataGridView gõ đúng chữ)
                if (row.Cells["MaPhieu"].Value != null)
                    txtMaPhieu_Kho.Text = row.Cells["MaPhieu"].Value.ToString();

                if (row.Cells["colMaSP"].Value != null)
                    txtMaSP_Kho.Text = row.Cells["colMaSP"].Value.ToString();

                if (row.Cells["SoLuongTra"].Value != null)
                    txtSoLuong_Kho.Text = row.Cells["SoLuongTra"].Value.ToString();
            }
        }
    }
}