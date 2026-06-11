using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Domain.Entities;       // Gọi thực thể PhieuNhap, ChiTietPhieuNhap
using Application.Services;  // Gọi ThemPhieuNhapUseCase và LayDanhSachSanPhamUseCase

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
                    dgvDanhSachTongKho.DataSource = null;
                    dgvDanhSachTongKho.DataSource = ds;

                    // Ẩn các cột không cần thiết
                    if (dgvDanhSachTongKho.Columns["GiaBan"] != null) dgvDanhSachTongKho.Columns["GiaBan"].Visible = false;
                    if (dgvDanhSachTongKho.Columns["TrangThai"] != null) dgvDanhSachTongKho.Columns["TrangThai"].Visible = false;
                    if (dgvDanhSachTongKho.Columns["YeuCauNhap"] != null) dgvDanhSachTongKho.Columns["YeuCauNhap"].Visible = false;
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
            // Khi click vào một dòng sản phẩm, bốc thông tin mở rộng hiện lên Panel quản trị bên phải
            if (e.RowIndex >= 0 && dgvDanhSachTongKho.Rows[e.RowIndex].DataBoundItem is SanPham sp)
            {
                if (lblChiTietCongTy != null)
                    lblChiTietCongTy.Text = "Công ty: " + (string.IsNullOrEmpty(sp.TenNCC) ? "Chưa xác định" : sp.TenNCC);

                if (lblChiTietDonVi != null)
                    lblChiTietDonVi.Text = "Đơn vị tính: " + (string.IsNullOrEmpty(sp.DonViTinh) ? "Thỏi" : sp.DonViTinh);

                if (lblChiTietTrangThaiGiao != null)
                    lblChiTietTrangThaiGiao.Text = "Trạng thái: " + (string.IsNullOrEmpty(sp.TrangThaiGiao) ? "Đã giao" : sp.TrangThaiGiao);
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
    }
}