using System;
using System.Data.SqlClient;
using System.Configuration; // Необходим для активации ConfigurationManager, подключить в ссылках проекта

namespace Lesson_1_connection
{
    class Program
    {
        static void Main(string[] args)
        {
            //string connect = "Server = KIRILLPC;Database = BV425_CompanyDB;Trusted_Connection = True;"; // строка подключения, вынесли в app.config

            string constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString; // подключение строки из app.config
            
            // Подключение к DataBase через using
            using (SqlConnection SQLConnection = new SqlConnection(constr))
            {
                SQLConnection.Open();   // открываем подключение

                // Код работы с БД
                //Console.WriteLine("------------- FIRST COMMAND WITH ExecuteReader ----------------");
                //var cmd = new SqlCommand("SELECT * FROM Employee", SQLConnection); 
                //SqlDataReader dr = cmd.ExecuteReader(); 
                //while (dr.Read())
                //{
                //    Console.WriteLine($" {dr["employeeId"],-15} {dr["LastName"],-15} {dr["Salary"],-15}");
                //}
                //dr.Close();

                Console.WriteLine("------------- SECOND COMMAND WITH ExecuteScalar ----------------");
                var cmd = new SqlCommand("SELECT SUM(Salary) as sum FROM Employee", SQLConnection);
                var res = cmd.ExecuteScalar();
                Console.WriteLine(res);

                Console.WriteLine("------------- THIRD COMMAND WITH ExecuteNonQuery ----------------");
                cmd = new SqlCommand("INSERT INTO Position(PositionName) VALUES('Director')", SQLConnection);
                int result = cmd.ExecuteNonQuery();
                Console.WriteLine($"Количество затронутых записей: {result}");
            }
        }
    }
}
