using System;
using System.Data.SqlClient;

namespace EMPD1
{
    public class EMPD1
    {
        public static string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public void connect_database()
        {
            try
            {
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("Create Database Ado_Payroll_Service", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            EMPD1 obj=new EMPD1();
            obj.connect_database();
        }
    }
}
