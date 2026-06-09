using System;
using System.Data.SqlClient;

namespace Infracstructure.Data
{
    public static class Db
    {
        // CHUỖI KẾT NỐI CHUẨN: Đã thêm TrustServerCertificate và MultipleActiveResultSets
        // Hãy chọn 1 trong các dòng Data Source phù hợp với máy của bạn dưới đây:

        // Trường hợp 1: Dành cho SQL Server thường (Dấu chấm)
        //private static string connectionString = @"Data Source=.;Initial Catalog=MyPham;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

        // Trường hợp 2: Dành cho SQL Server Express (Bỏ ẩn dòng dưới nếu máy bạn dùng SQLEXPRESS)
        private static string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=MyPham;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}