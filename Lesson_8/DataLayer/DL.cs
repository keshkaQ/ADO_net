using Lesson_8.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8.DataLayer
{
    public class DL
    {
        public static class Customer
        {
            public static IEnumerable<CustomerModel> GetAllCustomers()
            {
                using(var db = new BV425_CompanyDBEntities())
                {
                    List<CustomerModel> customers = new List<CustomerModel>();
                    var res = db.stp_CustomerAll().ToList();
                    foreach(var customer in res)
                    {
                        customers.Add(new CustomerModel
                        {
                            id = customer.id,
                            FirstName = customer.FirstName,
                            LastName = customer.LastName,
                            DateOfBirth = customer.DateOfBirth,
                        });
                    } 
                    return customers;
                }
            }
            public static CustomerModel GetCustomer(int id)
            {
                using(var db = new BV425_CompanyDBEntities())
                {
                    var res = db.stp_CustomerByID(id).First();
                    return new CustomerModel
                    {
                        id = res.id,
                        LastName = res.LastName,
                        FirstName = res.FirstName,
                        DateOfBirth = res.DateOfBirth
                    };
                }
            }
            public static int AddCustomer()
            {
                using (var db = new BV425_CompanyDBEntities())
                {
                    var idParameter = new ObjectParameter("id", typeof(int));
                    var res = db.stp_CustomerAdd("Mihail", "Bykov", Convert.ToDateTime("2002-01-01"), idParameter);
                    int customerId = (int)idParameter.Value;
                    return customerId;
                }
            }
        }
    }
}
