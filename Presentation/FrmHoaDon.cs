using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Presentation.FrmGioHang;

namespace Presentation
{
    public partial class FrmHoaDon : Form
    {
        // Khai báo 2 biến để "nhớ" dữ liệu truyền sang
        private List<ItemGioHang> _danhSachMua;
        private decimal _tongTien;
        private string _maHoaDonHienTai;

        public FrmHoaDon(List<ItemGioHang> danhSachMua, decimal tongTien)
        {
            InitializeComponent();

            // Gán vào biến toàn cục để lát nữa nút In còn dùng
            _danhSachMua = danhSachMua;
            _tongTien = tongTien;

            // 1. Tạo ngày giờ hiện tại và sinh mã hóa đơn tự động
            if (lblNgayLap != null)
                lblNgayLap.Text = "Ngày lập: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // TẠO VÀ LƯU MÃ HÓA ĐƠN
            _maHoaDonHienTai = "HD-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            if (lblMaHoaDon != null)
                lblMaHoaDon.Text = "Mã HD: " + _maHoaDonHienTai;

            // 2. TẠO CHUỖI DANH SÁCH MÓN HÀNG
            string billText = "";
            foreach (var item in danhSachMua)
            {
                billText += $"{item.TenSP}\n";
                billText += $"Số Lượng:  {item.SoLuong} \n  Giá Bán:    {item.GiaBan:N0} đ\n";
            }

            if (lblChiTietDanhSach != null)
                lblChiTietDanhSach.Text = billText;

            // 3. In tổng tiền chữ to ở dưới cùng
            if (lblTongTien != null)
                lblTongTien.Text = tongTien.ToString("N0") + " VNĐ";
        }




        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Đóng gói dữ liệu vào Entities
                Domain.Entities.HoaDon hd = new Domain.Entities.HoaDon
                {
                    MaHoaDon = _maHoaDonHienTai,
                    NgayLap = DateTime.Now,
                    TongTien = _tongTien
                };

                List<Domain.Entities.ChiTietHoaDon> dsChiTiet = new List<Domain.Entities.ChiTietHoaDon>();
                foreach (var item in _danhSachMua)
                {
                    dsChiTiet.Add(new Domain.Entities.ChiTietHoaDon
                    {
                        MaHoaDon = _maHoaDonHienTai,
                        MaSP = item.MaSP,
                        SoLuong = item.SoLuong,
                        GiaBan = item.GiaBan
                    });
                }

                // 2. Gọi UseCase ở tầng Application
                Application.Services.LuuHoaDonUseCase useCase = new Application.Services.LuuHoaDonUseCase();
                bool ketQua = useCase.Execute(hd, dsChiTiet);

                // 3. Hiển thị kết quả
                if (ketQua)
                {
                    MessageBox.Show("Hệ thống đang kết nối máy in Bill...\nĐã lưu và in hóa đơn thành công!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu hóa đơn vào cơ sở dữ liệu!", "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống:\n" + ex.Message, "Lỗi Kết Nối");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
