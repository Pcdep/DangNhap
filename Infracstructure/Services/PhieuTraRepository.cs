using Domain.Entities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstructure.Services
{
    public class PhieuTraRepository
    {
        // 1. Lưu phiếu trả mới (Trạng thái mặc định: Chờ duyệt)
        public bool ThemPhieuTra(PhieuTra phieu)
        {
            string query = @"INSERT INTO PhieuTra (MaPhieu, MaHoaDon, MaSP, SoLuongTra, LyDo, NgayLap, TrangThai) 
                             VALUES (@MaPhieu, @MaHoaDon, @MaSP, @SoLuongTra, @LyDo, @NgayLap, N'Chờ duyệt')";
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieu", phieu.MaPhieu);
                cmd.Parameters.AddWithValue("@MaHoaDon", phieu.MaHoaDon);
                cmd.Parameters.AddWithValue("@MaSP", phieu.MaSP);
                cmd.Parameters.AddWithValue("@SoLuongTra", phieu.SoLuongTra);
                cmd.Parameters.AddWithValue("@LyDo", phieu.LyDo);
                cmd.Parameters.AddWithValue("@NgayLap", phieu.NgayLap);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 2. Lấy danh sách phiếu "Chờ duyệt" cho FrmKhoHang
        public List<PhieuTra> LayDanhSachChoDuyet()
        {
            List<PhieuTra> list = new List<PhieuTra>();
            string query = @"SELECT p.*, s.TenSP 
                     FROM PhieuTra p 
                     JOIN SanPham s ON p.MaSP = s.MaSP 
                     WHERE p.TrangThai = N'Chờ duyệt'";
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new PhieuTra
                    {
                        MaPhieu = reader["MaPhieu"].ToString(),
                        MaHoaDon = reader["MaHoaDon"].ToString(),
                        TenSP = reader["TenSP"].ToString(),
                        MaSP = reader["MaSP"].ToString(),
                        SoLuongTra = Convert.ToInt32(reader["SoLuongTra"]),
                        LyDo = reader["LyDo"].ToString(),
                        NgayLap = Convert.ToDateTime(reader["NgayLap"]),
                        TrangThai = reader["TrangThai"].ToString()
                    });
                }
            }
            return list;
        }

        // 3. Thủ kho cập nhật trạng thái phiếu
        public bool CapNhatTrangThai(string maPhieu, string trangThaiMoi)
        {
            string query = "UPDATE PhieuTra SET TrangThai = @TrangThai WHERE MaPhieu = @MaPhieu";
            using (SqlConnection conn = Db.Open())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TrangThai", trangThaiMoi);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
