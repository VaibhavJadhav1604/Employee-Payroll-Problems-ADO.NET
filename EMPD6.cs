using System;
using System.Data.SqlClient;

namespace EMPD6
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
    public class EMPD6
    {
        public static string str = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Ado_Payroll_Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con = new SqlConnection(str);
        public double sum()
        {
            double salary;
            con.Open();
            SqlCommand cmd=new SqlCommand("Select SUM(BasicPay) FROM Employee WHERE Gender = 'M' GROUP BY Gender;", con);
            SqlDataReader dr=cmd.ExecuteReader();
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    salary = dr.GetDouble(0);
                    return salary;
                }
            }
            con.Close();
            return 1;
        }
        public double avg()
        {
            double salary;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select AVG(BasicPay) FROM Employee WHERE Gender = 'M' GROUP BY Gender;", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    salary = dr.GetDouble(0);
                    return salary;
                }
            }
            con.Close();
            return 1;
        }
        public double min()
        {
            double salary;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select MIN(BasicPay) FROM Employee WHERE Gender = 'M' GROUP BY Gender;", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    salary = dr.GetDouble(0);
                    return salary;
                }
            }
            con.Close();
            return 1;
        }
        public double max()
        {
            double salary;
            con.Open();
            SqlCommand cmd = new SqlCommand("Select MAX(BasicPay) FROM Employee WHERE Gender = 'M' GROUP BY Gender;", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    salary = dr.GetDouble(0);
                    return salary;
                }
            }
            con.Close();
            return 1;
        }
        static void Main(string[] args)
        {
            EMPD6 obj=new EMPD6();
            Console.WriteLine("1.Sum Of Salary");
            Console.WriteLine("2.Average Of Salary");
            Console.WriteLine("3.Minimum Of Salary");
            Console.WriteLine("4.Maximum Of Salary");
            Console.Write("Enter Option:");
            int a=Convert.ToInt32(Console.ReadLine());
            switch(a)
            {
                case 1:
                    Console.Write("Sum Of Salary Is:"+ obj.sum());
                    break;
                case 2:
                    Console.Write("Average Salary Is:" + obj.avg());
                    obj.avg(); 
                    break;
                case 3:
                    Console.Write("Minimum Salary Is:" + obj.min());
                    obj.min();
                    break;
                case 4:
                    Console.Write("Maximum Salary Is:" + obj.max());
                    obj.max();
                    break;
            }
        }
    }
}
