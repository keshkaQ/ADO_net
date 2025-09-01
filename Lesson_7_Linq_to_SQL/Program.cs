using Lesson_7_Linq_to_SQL.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;

namespace Lesson_7_Linq_to_SQL
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            using (DataContext dataContext = new DataContext(connectionString))
            {
                // All Customers
                Console.WriteLine("--------------- All Customer ------------------------");
                Table<Customer> customers = dataContext.GetTable<Customer>();
                Show(customers);
                // Top 2
                Console.WriteLine("--------------- Top 2 ------------------------");
                List<Customer> top2 = customers.Take(2).ToList();
                Show(top2);
                // Customer by ID
                Console.WriteLine("--------------- Customer by ID ------------------------");
                //Customer cust = customers.FirstOrDefault(x=>x.Id == 3);
                var custById = from c in customers where c.Id == 3 select c;
                Show(custById);

                // Customer.Year >=2000
                Console.WriteLine("--------------- Customer.Year >=2000 ------------------------");
                var custByYear = from c in customers where c.DateOfBirth.Year >= 2000 select c;
                // var custByYear1 = customers.Where(x => x.DateOfBirth.Year >= 2025).ToList();
                Show(custByYear);

                // Customer.Name starts with 'T'
                Console.WriteLine("--------------- Customer.Name starts with 'T' ------------------------");
                var custStartsWith = from c in customers where c.FirstName.StartsWith("T") select c;
                Show(custStartsWith);

                // Add Customer
                Customer newCustomer = new Customer { FirstName = "Anton", LastName = "Valuev", DateOfBirth = DateTime.Now };
                customers.InsertOnSubmit(newCustomer);
                dataContext.SubmitChanges();
                Console.WriteLine("--------------- All Customers after Update ------------------------");
                Show(customers);

                // Customer Edit
                Customer c_edit = customers.Where(c => c.Id == 2).First();
                c_edit.LastName += "_redacted";
                Console.WriteLine(c_edit);
                Console.WriteLine("--------------- Customer (id = 2) after edit ------------------------");
                dataContext.SubmitChanges();
                Show(customers);
            }
        }
        static void Show(IEnumerable<Customer> customers)
        {
            foreach (var cust in customers)
            {
                Console.WriteLine(cust);
            }
        }
    }
}
