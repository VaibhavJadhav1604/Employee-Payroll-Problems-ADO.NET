using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EMPD7;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
       EMPD7.EMPD7 obj = new EMPD7.EMPD7();
       [TestMethod]
        public void TestMethod1()
        {
            Employee e = new Employee();

            e.employeename = "AAA";
            e.employeephonenumber = "123654789";
            e.employeeaddress = "indore";
            e.employeedepartment = "HR";
            e.employeegender = "M";
            e.basicpay = 25000;
            e.deduction = 100;
            e.taxablepay = 200;
            e.tax = 100;
            e.netpay = 200;
            e.date = DateTime.Now;
            e.city = "Rajasthan";
            e.country = "India";
            int expected = 1;
            int actual = obj.addemployee(e);
            Assert.AreEqual(expected, actual);
        }
    }
}
