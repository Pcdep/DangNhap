using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infracstructure
{
    public class PhieuNhapRepository
    {
        // Hàm lưu toàn bộ Phiếu Nhập và tự động kích hoạt số lượng tồn kho của Sản phẩm
        public void LuuPhieuNhap(PhieuNhap pn, List<ChiTietPhieuNhap> dsChiTiet)
        {
            using (SqlConnection conn = Db.Open())
            {
                // Khởi tạo Transaction để đảm bảo an toàn dữ liệu 3 bảng
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // LỆNH 1: INSERT VÀO BẢNG PHIEUNHAP
                        string queryPN = "INSERT INTO PhieuNhap (MaPN, NgayNhap, TongTien) VALUES (@MaPN, @NgayNhap, @TongTien)";
                        using (SqlCommand cmdPN = new SqlCommand(queryPN, conn, transaction))
                        {
                            cmdPN.Parameters.AddWithValue("@MaPN", pn.MaPN);
                            cmdPN.Parameters.AddWithValue("@NgayNhap", pn.NgayNhap);
                            cmdPN.Parameters.AddWithValue("@TongTien", pn.TongTien);
                            cmdPN.ExecuteNonQuery();
                        }

                        // VÒNG LẶP XỬ LÝ TỪNG MẶT HÀNG TRONG PHIẾU
                        foreach (var ct in dsChiTiet)
                        {
                            // LỆNH 2: INSERT VÀO BẢNG CHITIETPHIEUNHAP
                            string queryCT = "INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, GiaNhap) VALUES (@MaPN, @MaSP, @SoLuongNhap, @GiaNhap)";
                            using (SqlCommand cmdCT = new SqlCommand(queryCT, conn, transaction))
                            {
                                cmdCT.Parameters.AddWithValue("@MaPN", ct.MaPN);
                                cmdCT.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                cmdCT.Parameters.AddWithValue("@SoLuongNhap", ct.SoLuongNhap);
                                cmdCT.Parameters.AddWithValue("@GiaNhap", ct.GiaNhap);
                                cmdCT.ExecuteNonQuery();
                            }

                            // LỆNH 3: UPDATE CỘNG DỒN SỐ LƯỢNG TỒN KHO TRONG BẢNG SANPHAM
                            // Phép tính cộng dồn (SoLuongTon = SoLuongTon + @SoLuongNhap) giúp bảo toàn kho khi nhập nhiều đợt
                            string queryUpdateKho = "UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuongNhap, NgayNhapCuoi = @NgayNhapCuoi, MaPNCuoi = @MaPNCuoi WHERE MaSP = @MaSP";
                            using (SqlCommand cmdUp = new SqlCommand(queryUpdateKho, conn, transaction))
                            {
                                cmdUp.Parameters.AddWithValue("@MaSP", ct.MaSP);
                                cmdUp.Parameters.AddWithValue("@SoLuongNhap", ct.SoLuongNhap);
                                cmdUp.Parameters.AddWithValue("@NgayNhapCuoi", pn.NgayNhap);
                                cmdUp.Parameters.AddWithValue("@MaPNCuoi", pn.MaPN); // Lưu Mã phiếu nhập vào
                                cmdUp.ExecuteNonQuery();
                            }
                        }

                        // Nếu cả 3 lệnh trên đều chạy êm đẹp, chính thức xác nhận lưu vào ổ cứng
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Nếu có bất kỳ lỗi nào xảy ra, lập tức hủy bỏ toàn bộ luồng dữ liệu rác để bảo vệ kho
                        transaction.Rollback();
                        throw new Exception("Lỗi hệ thống khi xử lý lưu kho: " + ex.Message);
                    }
                }
            }
        }
    }
}
