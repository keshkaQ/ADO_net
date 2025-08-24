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

namespace Exam_ADO_NET.DataLayer
{
    public class User_DataLayer : IUserRepository
    {
        public readonly string _connectionString;
        public User_DataLayer()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Shop_db"].ConnectionString;
        }
        public bool AddUser(UserModel userModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.add_user", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@login", userModel.Login);
                    cmd.Parameters.AddWithValue("@password", userModel.Password);
                    cmd.Parameters.AddWithValue("@first_name", userModel.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", userModel.LastName);
                    cmd.Parameters.AddWithValue("@patronymic", userModel.Patronymic);
                    cmd.Parameters.AddWithValue("@email", userModel.Email);
                    cmd.Parameters.AddWithValue("@phone", userModel.Phone);
                    var outputParam = new SqlParameter
                    {
                        ParameterName = "@is_added",
                        SqlDbType = SqlDbType.Bit,
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);
                    cmd.ExecuteNonQuery();
                    return (bool)outputParam.Value;
                }
            }
        }
        public bool DeleteUser(int userId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.delete_user", sqlConnection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", userId);
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
        public List<UserModel> GetAllUsers()
        {
            var allUsers = new List<UserModel>();
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (var cmd = new SqlCommand("SELECT * FROM Users", sqlConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allUsers.Add(new UserModel(
                                (int)reader["user_id"],
                                reader["login"].ToString(),
                                reader["password"].ToString(),
                                reader["first_name"].ToString(),
                                reader["last_name"].ToString(),
                                reader["patronymic"].ToString(), 
                                reader["email"].ToString(),
                                reader["phone"].ToString(),      
                                Convert.ToDateTime(reader["registration_date"])
                            ));
                        }
                    }
                }
            }
            return allUsers;
        }
        public bool UpdateUser(UserModel updatedUser)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.update_user", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", updatedUser.Id);
                    cmd.Parameters.AddWithValue("@login", updatedUser.Login);
                    cmd.Parameters.AddWithValue("@password", updatedUser.Password);
                    cmd.Parameters.AddWithValue("@first_name", updatedUser.FirstName);
                    cmd.Parameters.AddWithValue("@last_name", updatedUser.LastName);
                    cmd.Parameters.AddWithValue("@patronymic", updatedUser.Patronymic);
                    cmd.Parameters.AddWithValue("@email", updatedUser.Email);
                    cmd.Parameters.AddWithValue("@phone", updatedUser.Phone);

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
        public UserModel GetUserById(int user_id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.get_user_by_id", sqlConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id",user_id);
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read()) 
                            {
                                return new UserModel
                                {
                                    Id = (int)reader["user_id"],
                                    Login = reader["login"].ToString(),
                                    Password = reader["login"].ToString(),
                                    FirstName = reader["login"].ToString(),
                                    LastName = reader["login"].ToString(),
                                    Patronymic = reader["login"].ToString(),
                                    Email = reader["email"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    RegistrationDate = Convert.ToDateTime(reader["registration_date"])
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
