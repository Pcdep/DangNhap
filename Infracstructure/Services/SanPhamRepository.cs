using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Domain;
using Domain.Entities;

namespace Infracstructure.Services
{
    public class SanPhamRepository
    {
        // Hàm này chuyên đi lấy dữ liệu từ SQL lên
        public List<SanPham> LayDanhSachSanPhamDangBan()
        {
            List<SanPham> dsSanPham = new List<SanPham>();
            // Sửa lại câu lệnh SQL cho chuẩn xác
            string query = "SELECT MaSP, TenSP, GiaBan, ThongTinSanPham FROM SanPham WHERE TrangThai = 1 AND SoLuongTon > 0";

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
                            sp.ThongTinSanPham = reader["ThongTinSanPham"] != DBNull.Value ? reader["ThongTinSanPham"].ToString() : "";

                            dsSanPham.Add(sp);
                        }
                    }
                }
            }
            return dsSanPham;
        }

        public List<SanPham> LayDanhSachSanPham()
        {
            List<SanPham> dsSanPham = new List<SanPham>();
            // Không dùng WHERE để quét tất cả sản phẩm
            string query = "SELECT MaSP, TenSP, GiaBan, SoLuongTon, TrangThai, ThongTinSanPham, HinhAnh FROM SanPham";

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
                            sp.SoLuongTon = Convert.ToInt32(reader["SoLuongTon"]);
                            sp.TrangThai = Convert.ToBoolean(reader["TrangThai"]);
                            sp.ThongTinSanPham = reader["ThongTinSanPham"] != DBNull.Value ? reader["ThongTinSanPham"].ToString() : "";
                            sp.HinhAnh = reader["HinhAnh"] != DBNull.Value ? reader["HinhAnh"].ToString() : "";

                            dsSanPham.Add(sp);
                        }
                    }
                }
            }
            return dsSanPham;
        }


        // Hàm 1: Lấy tất cả sản phẩm kèm tên nhà cung cấp phục vụ Tab 1 (Danh sách tổng)
        public List<SanPham> LayTatCaSanPhamTrongKho()
        {
            List<SanPham> list = new List<SanPham>();
            // Cập nhật câu Select: Bốc tất cả các cột
            string query = @"SELECT sp.*, ncc.TenNCC 
                     FROM SanPham sp 
                     LEFT JOIN NhaCungCap ncc ON sp.MaNCC = ncc.MaNCC";
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
                            sp.SoLuongTon = Convert.ToInt32(reader["SoLuongTon"]);
                            sp.MaNCC = reader["MaNCC"].ToString();
                            sp.TenNCC = reader["TenNCC"].ToString();
                            sp.DonViTinh = reader["DonViTinh"] != DBNull.Value ? reader["DonViTinh"].ToString() : "";
                            sp.TrangThaiGiao = reader["TrangThaiGiao"] != DBNull.Value ? reader["TrangThaiGiao"].ToString() : "";
                            sp.MaPNCuoi = reader["MaPNCuoi"] != DBNull.Value ? reader["MaPNCuoi"].ToString() : "";
                            sp.GiaNhap = reader["GiaNhap"] != DBNull.Value ? Convert.ToDecimal(reader["GiaNhap"]) : 0;

                            // 👉 LẤY NGÀY NHẬP CUỐI:
                            if (reader["NgayNhapCuoi"] != DBNull.Value)
                            {
                                sp.NgayNhapCuoi = Convert.ToDateTime(reader["NgayNhapCuoi"]);
                            }

                            list.Add(sp);
                        }
                    }
                }
            }
            return list;
        }

        public List<SanPham> LaySanPhamTheoNhaCungCap(string maNCC)
        {
            List<SanPham> list = new List<SanPham>();
            // Thêm MaPNCuoi vào Select để không bị sập phần mềm
            string query = "SELECT MaSP, TenSP, GiaBan, DonViTinh, GiaNhap, MaPNCuoi FROM SanPham WHERE MaNCC = @MaNCC";
            using (SqlConnection conn = Db.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPham sp = new SanPham();
                            sp.MaSP = reader["MaSP"].ToString();
                            sp.TenSP = reader["TenSP"].ToString();
                            sp.GiaBan = Convert.ToDecimal(reader["GiaBan"]);

                            sp.DonViTinh = reader["DonViTinh"] != DBNull.Value ? reader["DonViTinh"].ToString() : "Chưa rõ";
                            sp.GiaNhap = reader["GiaNhap"] != DBNull.Value ? Convert.ToDecimal(reader["GiaNhap"]) : 0;
                            sp.MaPNCuoi = reader["MaPNCuoi"] != DBNull.Value ? reader["MaPNCuoi"].ToString() : "";

                            list.Add(sp);
                        }
                    }
                }
            }
            return list;
        }

        public void ThemSanPham(SanPham sp)
        {
            // Bổ sung ThongTinSanPham
            string query = "INSERT INTO SanPham (MaSP, TenSP, GiaBan, SoLuongTon, TrangThai, ThongTinSanPham, HinhAnh) VALUES (@MaSP, @TenSP, @GiaBan, @SoLuongTon, @TrangThai, @ThongTinSanPham, @HinhAnh)";
            using (SqlConnection conn = Db.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                    cmd.Parameters.AddWithValue("@SoLuongTon", 0);

                    // 👉 ÉP MẶC ĐỊNH LÀ 0 (NGỪNG KINH DOANH / CHƯA MỞ BÁN)
                    cmd.Parameters.AddWithValue("@TrangThai", 0);

                    // Thêm thông tin mô tả
                    cmd.Parameters.AddWithValue("@ThongTinSanPham", string.IsNullOrEmpty(sp.ThongTinSanPham) ? "" : sp.ThongTinSanPham);

                    // Thêm đường dẫn hình ảnh
                    cmd.Parameters.AddWithValue("@HinhAnh", string.IsNullOrEmpty(sp.HinhAnh) ? "" : sp.HinhAnh);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CapNhatSanPham(SanPham sp)
        {
            // Lệnh UPDATE dùng MaSP làm điều kiện lọc khóa chính
            string query = "UPDATE SanPham SET TenSP = @TenSP, GiaBan = @GiaBan, TrangThai = @TrangThai, ThongTinSanPham = @ThongTinSanPham, HinhAnh = @HinhAnh WHERE MaSP = @MaSP";

            using (SqlConnection conn = Db.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", sp.MaSP);
                    cmd.Parameters.AddWithValue("@TenSP", sp.TenSP);
                    cmd.Parameters.AddWithValue("@GiaBan", sp.GiaBan);
                    cmd.Parameters.AddWithValue("@TrangThai", sp.TrangThai);
                    cmd.Parameters.AddWithValue("@ThongTinSanPham", string.IsNullOrEmpty(sp.ThongTinSanPham) ? "" : sp.ThongTinSanPham);
                    cmd.Parameters.AddWithValue("@HinhAnh", string.IsNullOrEmpty(sp.HinhAnh) ? "" : sp.HinhAnh);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public bool TruTonKhoKhiBanHang(string maSP, int soLuongBan)
        {
            // Lệnh UPDATE có ràng buộc: Chỉ trừ khi số lượng tồn kho lớn hơn hoặc bằng số lượng bán
            string query = "UPDATE SanPham SET SoLuongTon = SoLuongTon - @SoLuongBan WHERE MaSP = @MaSP AND SoLuongTon >= @SoLuongBan";
            using (SqlConnection conn = Db.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaSP", maSP);
                    cmd.Parameters.AddWithValue("@SoLuongBan", soLuongBan);

                    // ExecuteNonQuery trả về số dòng bị ảnh hưởng. Nếu > 0 nghĩa là trừ thành công.
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool CongTonKho(string maSP, int soLuongTra)
        {
            string query = "UPDATE SanPham SET SoLuongTon = SoLuongTon + @SoLuongTra WHERE MaSP = @MaSP";
            using (SqlConnection conn = Db.Open()) // Nhớ dùng đúng class Db của bạn
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SoLuongTra", soLuongTra);
                cmd.Parameters.AddWithValue("@MaSP", maSP);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }

}