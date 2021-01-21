using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ProductProject.DataAccessLayer.Concrete.AdoNet
{
    public class DBMS
    {
        private static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductProjectDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static string Connection
        {
            get { return connectionString; }
        }
        public static bool ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
