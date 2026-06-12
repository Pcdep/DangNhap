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
            // 👉 ĐOẠN CODE LƯU HÓA ĐƠN XUỐNG DATABASE
            try
            {
                // Thay thế chuỗi kết nối này bằng chuỗi kết nối thực tế trong dự án của bạn (ví dụ: Db.Open())
                using (SqlConnection conn = Db.Open())
                {
                    // 1. Lưu vào bảng HoaDon
                    string queryHoaDon = "INSERT INTO HoaDon (MaHoaDon, NgayLap, TongTien) VALUES (@MaHD, @Ngay, @TongTien)";
                    using (SqlCommand cmdHD = new SqlCommand(queryHoaDon, conn))
                    {
                        cmdHD.Parameters.AddWithValue("@MaHD", _maHoaDonHienTai);
                        cmdHD.Parameters.AddWithValue("@Ngay", DateTime.Now);
                        cmdHD.Parameters.AddWithValue("@TongTien", _tongTien);
                        cmdHD.ExecuteNonQuery();
                    }

                    // 2. Lưu từng món vào bảng ChiTietHoaDon
                    string queryChiTiet = "INSERT INTO ChiTietHoaDon (MaHoaDon, MaSP, SoLuong, GiaBan) VALUES (@MaHD, @MaSP, @SoLuong, @GiaBan)";
                    foreach (var item in _danhSachMua)
                    {
                        using (SqlCommand cmdCT = new SqlCommand(queryChiTiet, conn))
                        {
                            cmdCT.Parameters.AddWithValue("@MaHD", _maHoaDonHienTai);
                            cmdCT.Parameters.AddWithValue("@MaSP", item.MaSP); // Quan trọng: Đảm bảo class ItemGioHang của bạn có thuộc tính MaSP
                            cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                            cmdCT.Parameters.AddWithValue("@GiaBan", item.GiaBan);
                            cmdCT.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Hệ thống đang kết nối máy in Bill...\nĐã lưu và in hóa đơn thành công!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.Message, "Lỗi Hệ Thống");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
