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
            MessageBox.Show("Chuỗi kết nối thực tế đang dùng là:\n" + Db.ConnString, "Test Kết Nối");
            try
            {
                using (SqlConnection conn = Db.Open())
                {
                    // ✅ Bọc cả 2 INSERT trong Transaction để đảm bảo toàn vẹn
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Lưu HoaDon
                            string queryHoaDon = @"INSERT INTO HoaDon 
                                          (MaHoaDon, NgayLap, TongTien) 
                                          VALUES (@MaHD, @Ngay, @TongTien)";
                            using (SqlCommand cmdHD = new SqlCommand(queryHoaDon, conn, transaction))
                            {
                                cmdHD.Parameters.AddWithValue("@MaHD", _maHoaDonHienTai);
                                cmdHD.Parameters.AddWithValue("@Ngay", DateTime.Now);
                                cmdHD.Parameters.AddWithValue("@TongTien", _tongTien);
                                cmdHD.ExecuteNonQuery();
                            }

                            // 2. Lưu ChiTietHoaDon
                            string queryChiTiet = @"INSERT INTO ChiTietHoaDon 
                                           (MaHoaDon, MaSP, SoLuong, GiaBan) 
                                           VALUES (@MaHD, @MaSP, @SoLuong, @GiaBan)";
                            foreach (var item in _danhSachMua)
                            {
                                using (SqlCommand cmdCT = new SqlCommand(queryChiTiet, conn, transaction))
                                {
                                    cmdCT.Parameters.AddWithValue("@MaHD", _maHoaDonHienTai);
                                    cmdCT.Parameters.AddWithValue("@MaSP", item.MaSP);
                                    cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                    cmdCT.Parameters.AddWithValue("@GiaBan", item.GiaBan);
                                    cmdCT.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit(); // ✅ Commit khi cả 2 đều OK

                            MessageBox.Show("Đã lưu và in hóa đơn thành công!",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception innerEx)
                        {
                            transaction.Rollback();
                            // ✅ Hiện ĐẦY ĐỦ lỗi để debug
                            MessageBox.Show(
                                $"Lỗi INSERT:\n{innerEx.Message}\n\n" +
                                $"Inner: {innerEx.InnerException?.Message}\n\n" +
                                $"Chi tiết: MaHD={_maHoaDonHienTai}, SoMon={_danhSachMua?.Count}",
                                "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được kết nối DB:\n" + ex.Message, "Lỗi Kết Nối");
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
