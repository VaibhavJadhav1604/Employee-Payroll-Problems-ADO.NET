using System;
using System.Data.SqlClient;

namespace EMPD5
{
    public class Employee
    {
        public int employeeid { get; set; }
        public string employeename { get; set; }
        public string employeephonenumber { get; set; }
        public string employeeaddress { get; set; }
        public string employeedepartment { get; set; }
        public string employeegender { get; set; }
        public double basicpay { get; set; }
        public double deduction { get; set; }
        public double taxablepay { get; set; }
        public double tax { get; set; }
        public double netpay { get; set; }
        public DateTime date { get; set; }
        public string city { get; set; }
        public string country { get; set; }
    }
    public class EMPD5
    {
        public static string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado_Payroll_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con = new SqlConnection(str);
        public void EmployeeBetweenDates(Employee emp)
        {
            try
            {
                using (this.con)
                {
                    SqlCommand cmd = new SqlCommand("EmployeeBetweenDates", this.con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SDate", emp.date);
                    cmd.Parameters.AddWithValue("EDate", emp.date);
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            emp.employeeid = reader.GetInt32(0);
                            emp.employeename = reader.GetString(1);
                            emp.employeephonenumber = reader.GetString(2);
                            emp.employeeaddress = reader.GetString(3);
                            emp.employeedepartment = reader.GetString(4);
                            emp.employeegender = reader.GetString(5);
                            emp.basicpay = reader.GetDouble(6);
                            emp.deduction = reader.GetDouble(7);
                            emp.taxablepay = reader.GetDouble(8);
                            emp.tax = reader.GetDouble(9);
                            emp.netpay = reader.GetDouble(10);
                            emp.date = reader.GetDateTime(11);
                            emp.city = reader.GetString(12);
                            emp.country = reader.GetString(13);

                            Console.WriteLine("EmployeeId:" + emp.employeeid);
                            Console.WriteLine("EmployeeName:" + emp.employeename);
                            Console.WriteLine("PhoneNumber:" + emp.employeephonenumber);
                            Console.WriteLine("Address:" + emp.employeeaddress);
                            Console.WriteLine("Department:" + emp.employeedepartment);
                            Console.WriteLine("Gender:" + emp.employeegender);
                            Console.WriteLine("BasicPay:" + emp.basicpay);
                            Console.WriteLine("Deduction:" + emp.deduction);
                            Console.WriteLine("TaxablePay:" + emp.taxablepay);
                            Console.WriteLine("Tax:" + emp.tax);
                            Console.WriteLine("NetPay:" + emp.netpay);
                            Console.WriteLine("Date:" + emp.date);
                            Console.WriteLine("City:" + emp.city);
                            Console.WriteLine("Country:" + emp.country);
                            Console.WriteLine("\n");
                        }
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            EMPD5 obj = new EMPD5();
            Employee emp = new Employee();

            emp.date = Convert.ToDateTime("2019/01/01");
            emp.date = Convert.ToDateTime("2019/11/01");

            obj.EmployeeBetweenDates(emp);
        }
    }
}
