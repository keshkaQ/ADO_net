//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lesson_1_connection
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string connect = "Server = KIRILLPC;Database = BV425_CompanyDB;Trusted_Connection = True;"; // строка подключения
//            SqlConnection sqlConnection = new SqlConnection(connect); // соединение
//            sqlConnection.Open();
//            {
//                // 1. Все сотрудники
//                Console.WriteLine("------------- FIRST COMMAND ----------------");
//                var cmd = new SqlCommand("SELECT * FROM Employee", sqlConnection); // команда
//                SqlDataReader dr = cmd.ExecuteReader(); // объект класса, куда читаем данные из таблицы
//                // если вернуть одно значение, то ExecuteScalar()
//                while (dr.Read())
//                {
//
//                    Console.WriteLine($" {dr["employeeId"],-15} {dr["LastName"],-15} {dr["Salary"], -15}");
//                }
//                dr.Close();

//                // 2. Сотрудники с зарплатой >= 1800
//                Console.WriteLine("------------- SECOND COMMAND ----------------");
//                cmd = new SqlCommand("SELECT * FROM Employee WHERE Salary >= 1800 ORDER BY SALARY DESC ", sqlConnection);
//                dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    Console.WriteLine($" {dr["employeeId"],-15} {dr["LastName"],-15} {dr["Salary"],-15}");
//                }
//                dr.Close();

//                // 3. Сотрудники с должностями
//                Console.WriteLine("------------- THIRD COMMAND ----------------");
//                cmd = new SqlCommand("SELECT FirstName,LastName,PositionName FROM Employee " +
//                    "JOIN Position on Position.PositionId = Employee.PositionId ", sqlConnection);
//                dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    Console.WriteLine($" {dr["FirstName"],-15} {dr["LastName"],-15} {dr["PositionName"],-15}");
//                }
//                dr.Close();

//                // 4. Клиенты, имена которых начинаются на 'I'
//                Console.WriteLine("------------- FOURTH COMMAND ----------------");
//                cmd = new SqlCommand("SELECT Id, FirstName,LastName FROM Customers " +
//                    "WHERE FirstName LIKE 'I%' ", sqlConnection);
//                dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    Console.WriteLine($" {dr["ID"],-15} {dr["FirstName"],-15} {dr["LastName"],-15}");
//                }
//                dr.Close();

//                //  5. Сотрудники 2000 года рождения
//                Console.WriteLine("------------- FIFTH COMMAND ----------------");
//                cmd = new SqlCommand("SELECT FirstName,LastName,BirthDate FROM Employee " +
//                    "WHERE BirthDate BETWEEN '2000-01-01' AND '2001-01-01' ", sqlConnection);
//                dr = cmd.ExecuteReader();
//                while (dr.Read())
//                {
//                    Console.WriteLine($" {dr["FirstName"],-15} {dr["LastName"],-15} {Convert.ToDateTime(dr["BirthDate"]).ToString("yyyy-MM-dd"),-15}");
//                }
//            }
//            sqlConnection.Close();
//        }
//    }
//}
