using Domain.Entities;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Infrastructure.Services
{
    public class HoaDonRepository
    {
        // 1. Hàm lấy Ngày mua hàng để kiểm tra hạn 7 ngày
        public DateTime? LayNgayLapHoaDon(string maHoaDon)
        {
            string query = "SELECT NgayLap FROM HoaDon WHERE MaHoaDon = @MaHD";
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHD", maHoaDon);
                object result = cmd.ExecuteScalar();
                if (result != null) return Convert.ToDateTime(result);
                return null; // Không tìm thấy hóa đơn
            }
        }

        // 2. Hàm lấy danh sách các món đã mua trong Hóa đơn đó
        public DataTable LayChiTietHoaDon(string maHoaDon)
        {
            DataTable dt = new DataTable();
            // Kết hợp (JOIN) bảng ChiTietHoaDon và SanPham để lấy tên SP
            string query = @"SELECT c.MaHoaDon, h.NgayLap, c.MaSP, s.TenSP, c.SoLuong, c.GiaBan, (c.SoLuong * c.GiaBan) as ThanhTien 
                     FROM ChiTietHoaDon c 
                     JOIN HoaDon h ON c.MaHoaDon = h.MaHoaDon
                     JOIN SanPham s ON c.MaSP = s.MaSP 
                     WHERE c.MaHoaDon = @MaHD";

            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaHD", maHoaDon);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public DataTable LayTatCaLichSuMuaHang()
        {
            DataTable dt = new DataTable();
            // Gộp 3 bảng: ChiTietHoaDon, HoaDon và SanPham lại với nhau
            string query = @"SELECT c.MaHoaDon, h.NgayLap, c.MaSP, s.TenSP, c.SoLuong, c.GiaBan, (c.SoLuong * c.GiaBan) as ThanhTien 
                     FROM ChiTietHoaDon c 
                     JOIN HoaDon h ON c.MaHoaDon = h.MaHoaDon 
                     JOIN SanPham s ON c.MaSP = s.MaSP
                     ORDER BY h.NgayLap DESC";

            using (System.Data.SqlClient.SqlConnection conn = Db.Open())
            using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query, conn))
            {
                using (System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }


        public bool ThemHoaDon(HoaDon hd, System.Collections.Generic.List<ChiTietHoaDon> dsChiTiet)
        {
            try
            {
                using (SqlConnection conn = Db.Open())
                {
                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. Lưu HoaDon
                            string queryHoaDon = @"INSERT INTO HoaDon (MaHoaDon, NgayLap, TongTien) VALUES (@MaHD, @Ngay, @TongTien)";
                            using (SqlCommand cmdHD = new SqlCommand(queryHoaDon, conn, transaction))
                            {
                                cmdHD.Parameters.AddWithValue("@MaHD", hd.MaHoaDon);
                                cmdHD.Parameters.AddWithValue("@Ngay", hd.NgayLap);
                                cmdHD.Parameters.AddWithValue("@TongTien", hd.TongTien);
                                cmdHD.ExecuteNonQuery();
                            }

                            // 2. Lưu ChiTietHoaDon
                            string queryChiTiet = @"INSERT INTO ChiTietHoaDon (MaHoaDon, MaSP, SoLuong, GiaBan) VALUES (@MaHD, @MaSP, @SoLuong, @GiaBan)";
                            foreach (var item in dsChiTiet)
                            {
                                using (SqlCommand cmdCT = new SqlCommand(queryChiTiet, conn, transaction))
                                {
                                    cmdCT.Parameters.AddWithValue("@MaHD", item.MaHoaDon);
                                    cmdCT.Parameters.AddWithValue("@MaSP", item.MaSP);
                                    cmdCT.Parameters.AddWithValue("@SoLuong", item.SoLuong);
                                    cmdCT.Parameters.AddWithValue("@GiaBan", item.GiaBan);
                                    cmdCT.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}