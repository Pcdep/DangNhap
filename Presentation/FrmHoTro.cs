using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class FrmHoTro : Form
    {

        private int _soLuongMax = 0;
        public FrmHoTro()
        {
            InitializeComponent();
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtMaHoaDon.Text) ||
                string.IsNullOrWhiteSpace(txtMaSP.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuongTra.Text) ||
                string.IsNullOrWhiteSpace(txtLyDo.Text) ||
                string.IsNullOrWhiteSpace(txtNgayMua.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin (Mã HD, Mã SP, Số lượng, Lý do) trước khi tạo phiếu!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại ngay lập tức, không chạy code bên dưới nữa
            }

            // 👉 2. TRẠM KIỂM SOÁT SỐ 2: SỐ LƯỢNG PHẢI LÀ CON SỐ
            int soLuongTra;
            if (!int.TryParse(txtSoLuongTra.Text, out soLuongTra))
            {
                MessageBox.Show("Số lượng trả phải là một con số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 👉 CHỐT CHẶN BẢO VỆ: KHÔNG CHO TRẢ QUÁ SỐ ĐÃ MUA HOẶC SỐ ÂM
            if (soLuongTra <= 0)
            {
                MessageBox.Show("Số lượng trả phải lớn hơn 0!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (soLuongTra > _soLuongMax)
            {
                MessageBox.Show($"Gian lận! Sản phẩm này khách chỉ mua {_soLuongMax} cái, không thể trả {soLuongTra} cái!", "Lỗi nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Domain.Entities.PhieuTra phieuMoi = new Domain.Entities.PhieuTra();
                phieuMoi.MaHoaDon = txtMaHoaDon.Text;
                phieuMoi.MaSP = txtMaSP.Text;
                phieuMoi.SoLuongTra = soLuongTra; // Dùng luôn biến soLuongTra đã ép kiểu an toàn ở trên
                phieuMoi.LyDo = txtLyDo.Text;

                DateTime ngayMua = Convert.ToDateTime(txtNgayMua.Text);

                // Gọi tầng Application
                Application.Services.LapPhieuTraUseCase useCase = new Application.Services.LapPhieuTraUseCase();
                string ketQua = useCase.Execute(phieuMoi, ngayMua);

                if (ketQua == "Thành công")
                {
                    MessageBox.Show("Đã tạo phiếu. Vui lòng chuyển hàng vào kho chờ duyệt!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Xóa rỗng các ô nhập liệu sau khi tạo xong để chuẩn bị cho phiếu tiếp theo
                    txtMaHoaDon.Clear();
                    txtMaSP.Clear();
                    txtSoLuongTra.Clear();
                    txtLyDo.Clear();
                    txtNgayMua.Clear();
                }
                else
                {
                    MessageBox.Show(ketQua, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý dữ liệu: " + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmHoTro_Load(object sender, EventArgs e)
        {
            try
            {
                Infrastructure.Services.HoaDonRepository repo = new Infrastructure.Services.HoaDonRepository();

                if (dgvLichSuMua != null)
                {
                    dgvLichSuMua.AutoGenerateColumns = false;
                    dgvLichSuMua.DataSource = repo.LayTatCaLichSuMuaHang();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử mua hàng: " + ex.Message);
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHoaDon.Text.Trim();
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập Mã Hóa Đơn cần tra cứu!", "Thông báo");
                return;
            }

            Infrastructure.Services.HoaDonRepository repo = new Infrastructure.Services.HoaDonRepository();

            // 1. Tìm Hóa đơn và gán Ngày Mua lên Label
            DateTime? ngayMua = repo.LayNgayLapHoaDon(maHD);
            if (ngayMua == null)
            {
                MessageBox.Show("Không tìm thấy Hóa Đơn này trên hệ thống!", "Lỗi");
                // Xóa trắng lưới nếu nhập sai
                if (dgvLichSuMua != null) dgvLichSuMua.DataSource = null;
                return;
            }

            // Nếu tìm thấy, gán ngày lên Label (Đổi định dạng thành yyyy-MM-dd để UseCase dễ tính toán)
            if (txtNgayMua != null)
                txtNgayMua.Text = ngayMua.Value.ToString("yyyy-MM-dd");

            // 2. Đổ danh sách sản phẩm lên DataGridView
            if (dgvLichSuMua != null)
            {
                dgvLichSuMua.AutoGenerateColumns = false;
                dgvLichSuMua.DataSource = repo.LayChiTietHoaDon(maHD);
            }
        }

        private void dgvLichSuMua_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bỏ qua nếu click vào tiêu đề
            if (e.RowIndex < 0 || e.RowIndex >= dgvLichSuMua.Rows.Count) return;

            try
            {
                DataGridViewRow row = dgvLichSuMua.Rows[e.RowIndex];

                // 1. Gán Mã HD và Mã SP
                if (txtMaHoaDon != null)
                    txtMaHoaDon.Text = row.Cells["MaHoaDon"]?.Value?.ToString() ?? "";

                if (txtMaSP != null)
                    txtMaSP.Text = row.Cells["MaSP"]?.Value?.ToString() ?? "";

                // 2. Gán Ngày Mua
                if (row.Cells["NgayLap"]?.Value != null)
                {
                    DateTime ngayLap = Convert.ToDateTime(row.Cells["NgayLap"].Value);
                    if (txtNgayMua != null)
                        txtNgayMua.Text = ngayLap.ToString("yyyy-MM-dd");
                }

                // 👉 3. BẮT BUỘC PHẢI CÓ: Cập nhật biến _soLuongMax để chống gian lận
                if (row.Cells["SoLuong"]?.Value != null)
                {
                    _soLuongMax = Convert.ToInt32(row.Cells["SoLuong"].Value);

                    // Gán luôn vào ô TextBox để nhân viên đỡ phải gõ
                    if (txtSoLuongTra != null)
                        txtSoLuongTra.Text = _soLuongMax.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc dòng: " + ex.Message, "Lỗi");
            }
        }
    }
}

