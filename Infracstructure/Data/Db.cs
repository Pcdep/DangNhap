using System;
using System.Configuration;
using System.Data.SqlClient;

public static class Db
{

    public static string ConnString
    {
        get
        {
            var cs = ConfigurationManager.ConnectionStrings["DbSql"];
            if (cs == null || string.IsNullOrWhiteSpace(cs.ConnectionString))
                throw new InvalidOperationException("Thiếu connection string DbSql trong App.config.");
            return cs.ConnectionString;
        }
    }

    public static SqlConnection Open()
    {
        SqlConnection cn = new SqlConnection(ConnString);
        cn.Open();
        return cn;
    }
}
