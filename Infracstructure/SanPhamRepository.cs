using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;
using Domain.Entities; // Gọi tầng Domain

namespace Infracstructure
{
    public class SanPhamRepository
    {
        // Hàm này chuyên đi lấy dữ liệu từ SQL lên
        public List<SanPham> LayDanhSachSanPhamDangBan()
        {
            List<SanPham> dsSanPham = new List<SanPham>();
            string query = "SELECT MaSP, TenSP, GiaBan FROM SanPham WHERE TrangThai = 1 AND SoLuongTon > 0";

            using (SqlConnection conn = Db.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham sp = new SanPham();
                            sp.MaSP = reader["MaSP"].ToString();
                            sp.TenSP = reader["TenSP"].ToString();
                            sp.GiaBan = Convert.ToDecimal(reader["GiaBan"]);

                            dsSanPham.Add(sp);
                        }
                    }
                }
            }
            return dsSanPham;
        }

        public void ThemSanPham(SanPham sp)
        {
            string query = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon, TrangThai) VALUES (@MaSP, @TenSP, @GiaBan, @SoLuongTon, @TrangThai)";

            using (SqlConnection conn = Db.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                    // Mặc định luôn là 0 khi mới tạo danh mục (chưa nhập kho)
                    cmd.Parameters.AddWithValue("@SoLuongTon", sp.SoLuongTon);
                    cmd.Parameters.AddWithValue("@TrangThai", sp.TrangThai);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}