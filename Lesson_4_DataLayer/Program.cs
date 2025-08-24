using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson_4_DataLayer.Models;
using Lesson_4_DataLayer.DataLayer;
using System.Data;
// DataLayer - DataAccessLayer,DA,DAL

namespace Lesson_4_DataLayer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CustomerModel customer1 = DL.Customer.GetById(1);
            //CustomerModel customer2 = DL.Customer.GetById(2);
            //Console.WriteLine(customer1);
            //Console.WriteLine(customer2);

            //int id = DL.Customer.InsertCustomer(new CustomerModel ( 0, "Viktor", "Kotov", new DateTime(2024, 3, 4) ));
            //Console.WriteLine(id);

            List<CustomerModel> customers = DL.Customer.GetAllCustomers();
            foreach (CustomerModel customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
