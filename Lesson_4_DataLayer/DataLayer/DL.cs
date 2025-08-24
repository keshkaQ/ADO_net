using Lesson_4_DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Lesson_4_DataLayer.DataLayer.DL;

namespace Lesson_4_DataLayer.DataLayer
{
    public class DL
    {
        public static string ConnectionString { get; private set; } = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
        private static SqlConnection connection;
  
        public static class Customer
        {
            public static CustomerModel GetById(int customerId)
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand getCustomer = new SqlCommand("stp_CustomerByID", sqlConnection);
                    getCustomer.CommandType = CommandType.StoredProcedure;
                    getCustomer.Parameters.AddWithValue("@customerId", customerId);
                    using (SqlDataReader dataReader = getCustomer.ExecuteReader())
                    {
                        CustomerModel customerModel = null;
                        while (dataReader.Read())
                        {
                            customerModel = new CustomerModel((int)dataReader["id"], dataReader["FirstName"].ToString(),
                                dataReader["LastName"].ToString(), DateTime.Parse(dataReader["DateOfBirth"].ToString()));
                        }
                        return customerModel;
                    }
                }
            }
            public static int InsertCustomer(CustomerModel tmp)
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand insertCustomer = new SqlCommand("stp_CustomerAdd", sqlConnection);
                    insertCustomer.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(insertCustomer);
                    insertCustomer.Parameters[4].Value = tmp.Id;
                    insertCustomer.Parameters[1].Value = tmp.FirstName;
                    insertCustomer.Parameters[2].Value = tmp.LastName;
                    insertCustomer.Parameters[3].Value = tmp.DateOfBirth;
                    insertCustomer.ExecuteNonQuery();
                    int new_id = (int)insertCustomer.Parameters[4].Value;
                    return new_id;
                }
            }
            public static List<CustomerModel> GetAllCustomers()
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    sqlConnection.Open();
                    SqlCommand getAll = new SqlCommand("stp_CustomerAll", sqlConnection);
                    getAll.CommandType = CommandType.StoredProcedure;
                    List<CustomerModel> customers = new List<CustomerModel>();
                    using (SqlDataReader dataReader = getAll.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            CustomerModel customer = new CustomerModel((int)dataReader["id"], dataReader["FirstName"].ToString(),
                                dataReader["LastName"].ToString(), DateTime.Parse(dataReader["DateOfBirth"].ToString()));
                            customers.Add(customer);
                        }
                        return customers;
                    }
                }
            }
        }
    }
}
