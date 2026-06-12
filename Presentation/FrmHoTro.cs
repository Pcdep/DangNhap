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
        public FrmHoTro()
        {
            InitializeComponent();
        }

        private void btnTaoPhieu_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ giao diện
            Domain.Entities.PhieuTra phieuMoi = new Domain.Entities.PhieuTra();
            phieuMoi.MaHoaDon = txtMaHoaDon.Text;
            phieuMoi.MaSP = txtMaSP.Text; // Lấy từ dòng click trên DataGridView
            phieuMoi.SoLuongTra = Convert.ToInt32(txtSoLuongTra.Text);
            phieuMoi.LyDo = txtLyDo.Text;

            // Giả sử bạn lấy được Ngày Mua từ lúc tra cứu Hóa Đơn
            DateTime ngayMua = Convert.ToDateTime(lblNgayMua.Text);

            // Gọi tầng Application
            Application.Services.LapPhieuTraUseCase useCase = new Application.Services.LapPhieuTraUseCase();
            string ketQua = useCase.Execute(phieuMoi, ngayMua);

            if (ketQua == "Thành công")
            {
                MessageBox.Show("Đã tạo phiếu. Vui lòng chuyển hàng vào kho chờ duyệt!", "Thành công");
                // Reset giao diện
            }
            else
            {
                MessageBox.Show(ketQua, "Cảnh báo"); // Hiện lỗi 7 ngày hoặc lỗi DB
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
            lblNgayMua.Text = ngayMua.Value.ToString("yyyy-MM-dd");

            // 2. Đổ danh sách sản phẩm lên DataGridView
            if (dgvLichSuMua != null)
            {
                dgvLichSuMua.AutoGenerateColumns = false;
                dgvLichSuMua.DataSource = repo.LayChiTietHoaDon(maHD);
            }
        }

        private void dgvLichSuMua_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}

