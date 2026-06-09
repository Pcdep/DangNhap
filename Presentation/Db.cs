using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Presentation
{
    public static class Db
    {
        public static SqlConnection Open()
        {
            var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(cs))
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found in config.");

            var conn = new SqlConnection(cs);
            conn.Open();
            return conn;
        }
    }
}
