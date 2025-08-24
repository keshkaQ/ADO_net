using Exam_ADO_NET.Interfaces;
using Exam_ADO_NET.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_ADO_NET.DataLayers
{
    public class Category_DataLayer:ICategoryRepository
    {
        public readonly string _connectionString;
        public Category_DataLayer()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Shop_db"].ConnectionString;
        }
        public bool AddCategory(CategoryModel model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.add_category", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@description", model.Description);
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
        public bool DeleteCategory(int category_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.delete_category", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category_id", category_id);
                    var outputParam = new SqlParameter
                    {
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Bit,
                        ParameterName = "@is_deleted"
                    };
                    cmd.Parameters.Add(outputParam);
                    cmd.ExecuteNonQuery();
                    return (bool)outputParam.Value;
                }
            }
        }
        public List<CategoryModel> GetAllCategories()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Categories", sqlConnection))
                {
                    List<CategoryModel> allCategories = new List<CategoryModel>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                allCategories.Add(new CategoryModel((int)reader["category_id"], reader["name"].ToString(), reader["description"].ToString()));
                            }
                        }
                        return allCategories;
                    }
                }
            }
        }
        public bool UpdateCategory(CategoryModel model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.update_category", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category_id", model.Id);
                    cmd.Parameters.AddWithValue("@name", model.Name);
                    cmd.Parameters.AddWithValue("@description", model.Description);
                    var outputParameter = new SqlParameter
                    {
                        Direction = ParameterDirection.Output,
                        SqlDbType = SqlDbType.Bit,
                        ParameterName = "@is_updated"
                    };
                    cmd.Parameters.Add(outputParameter);
                    cmd.ExecuteNonQuery();
                    return (bool)outputParameter.Value;
                }
            }
        }
        public CategoryModel GetCategoryById(int categoryId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.get_category_by_id", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@category_id", categoryId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                return new CategoryModel
                                {
                                    Id = (int)reader["category_id"],
                                    Name = reader["name"].ToString(),
                                    Description = reader["description"].ToString()
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
