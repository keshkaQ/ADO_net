using Exam_ADO_NET.Interfaces;
using Exam_ADO_NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Exam_ADO_NET.DataLayer
{
    public class Product_DataLayer : IProductRepository
    {
        private readonly string _connectionString;
        public Product_DataLayer()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Shop_db"].ConnectionString;
        }
        public bool AddProduct(ProductModel product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.add_product", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@description", product.Description);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                    var outputParam = new SqlParameter
                    {
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Bit,
                        ParameterName = "@is_added"
                    };
                    cmd.Parameters.Add(outputParam);
                    cmd.ExecuteNonQuery();
                    return (bool)outputParam.Value;
                }
            }
        }
        public bool UpdateProduct(ProductModel updatedProduct)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.update_product", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", updatedProduct.Id);
                    cmd.Parameters.AddWithValue("@name", updatedProduct.Name);
                    cmd.Parameters.AddWithValue("@description", updatedProduct.Description);
                    cmd.Parameters.AddWithValue("@price", updatedProduct.Price);
                    cmd.Parameters.AddWithValue("@quantity", updatedProduct.Quantity);
                    var outputParam = new SqlParameter
                    {
                        ParameterName = "@is_updated",
                        SqlDbType = SqlDbType.Bit,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);
                    cmd.ExecuteNonQuery();
                    return (bool)outputParam.Value;
                }
            }
        }
        public List<ProductModel> GetAllProducts()
        {
            var allProducts = new List<ProductModel>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Products", sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allProducts.Add(new ProductModel(
                                (int)reader["product_id"],
                                reader["name"].ToString(),
                                reader["description"].ToString(),
                                (decimal)reader["price"],
                                (int)reader["quantity"],
                                Convert.ToDateTime(reader["date_added"].ToString())
                            ));
                        }
                    }
                }
            }
            return allProducts;
        }
        public bool DeleteProduct(int product_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.delete_product", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                    var outputParameter = new SqlParameter
                    {
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Bit,
                        ParameterName = "@is_deleted"
                    };
                    cmd.Parameters.Add(outputParameter);
                    cmd.ExecuteNonQuery();
                    return (bool)outputParameter.Value;
                }
            }
        }
        public ProductModel GetProductById(int product_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.get_product_by_id", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", product_id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return new ProductModel
                                {
                                    Id = (int)reader["product_id"],
                                    Name = reader["name"].ToString(),
                                    Description = reader["description"].ToString(),
                                    Price = (decimal)reader["price"],
                                    Quantity = (int)reader["quantity"],
                                    DateAdded = Convert.ToDateTime(reader["date_added"])
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}

