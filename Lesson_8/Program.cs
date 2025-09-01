using Lesson_8;
using Lesson_8.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_8_EF_DBFirst;
using Lesson_8.DataLayer;

namespace Lesson_8_EF_DBFirst
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BV425_CompanyDBEntities())
            {
                //// All
                //IEnumerable<CustomerModel> customers = DL.Customer.GetAllCustomers();
                //foreach (var customer in customers)
                //{
                //    Console.WriteLine(customer);
                //}

                //// By Id
                //CustomerModel cust = DL.Customer.GetCustomer(2);
                //Console.WriteLine(cust);

                // Add Customer
                var res = DL.Customer.AddCustomer();
                Console.WriteLine($"Id нового пользователя: {res}");
            }
        }
    }
}
