using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace Lesson_3_CommandBuilder
{
    internal class Program
    {
        SqlCommandBuilder sqlCommandBuilder;
        static void Main(string[] args)
        {
            string constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            using (SqlConnection SQLConnection = new SqlConnection(constr))
            {
                SQLConnection.Open();

                //string cust_add = "stp_CustomerAdd";
                //SqlCommand cmd = new SqlCommand(cust_add, SQLConnection);
                //cmd.CommandType = CommandType.StoredProcedure;

                //SqlCommandBuilder.DeriveParameters(cmd);

                //cmd.Parameters[4].Value = DBNull.Value; // 4 столбец - количество столбцов + 1
                //cmd.Parameters[1].Value = "Anton";
                //cmd.Parameters[2].Value = "Koshkin";
                //cmd.Parameters[3].Value = DateTime.Now.ToShortDateString();

                //cmd.ExecuteNonQuery();
                //int new_id = (int)cmd.Parameters[4].Value;
                //Console.WriteLine(new_id);

                // with return
                string cust_add = "stp_CustomerAdd_2";
                SqlCommand cmd = new SqlCommand(cust_add, SQLConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlCommandBuilder.DeriveParameters(cmd);

                cmd.Parameters[0].Value = DBNull.Value; // 0 - номер столбца как в и самой БД
                cmd.Parameters[1].Value = "Nikita";
                cmd.Parameters[2].Value = "Mohov";
                cmd.Parameters[3].Value = DateTime.Now.ToShortDateString();

                cmd.ExecuteNonQuery();
                int new_id = (int)cmd.Parameters[0].Value;
                Console.WriteLine(new_id);
            }
        }
    }
}
