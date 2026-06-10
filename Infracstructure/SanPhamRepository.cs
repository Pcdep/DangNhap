using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain; // Gọi tầng Domain

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
    }
}