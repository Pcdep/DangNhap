using System.Collections.Generic;
using System.Data.SqlClient;
using Domain.Entities;

namespace Infracstructure
{
    public class NhaCungCapRepository
    {
        public List<NhaCungCap> LayTatCaNhaCungCap()
        {
            List<NhaCungCap> list = new List<NhaCungCap>();
            string query = "SELECT * FROM NhaCungCap";
            using (SqlConnection conn = Db.Open())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            NhaCungCap ncc = new NhaCungCap();
                            ncc.MaNCC = reader["MaNCC"].ToString();
                            ncc.TenNCC = reader["TenNCC"].ToString();
                            list.Add(ncc);
                        }
                    }
                }
            }
            return list;
        }
    }
}