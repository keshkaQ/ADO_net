//using System;
//using System.Configuration;
//using System.Data;
//using System.Data.SqlClient;

//namespace Lesson_2_StorageProcedure
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            string constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;

//            using (SqlConnection SQLConnection = new SqlConnection(constr))
//            {
//                SQLConnection.Open();
//                // 1. CustomerAll
//                //string stpCustomerAll = "stp_CustomerAll";
//                //SqlCommand sqlCommand = new SqlCommand(stpCustomerAll, SQLConnection);
//                //sqlCommand.CommandType = System.Data.CommandType.StoredProcedure; // определяем явно хранимую процедуру

//                //SqlDataReader dr = sqlCommand.ExecuteReader();
//                //while (dr.Read())
//                //{
//                //    Console.WriteLine($"{dr["id"],-15}{dr["LastName"],-15}{Convert.ToDateTime(dr["DateOfBirth"]).ToString("yyyy-MM-dd"),-15}");
//                //}
//                //dr.Close();

//                //// 2. CustomerAdd
//                // Объявление переменной с именем хранимой процедуры в SQL Server
//                //string cust_add = "stp_CustomerAdd";

//                //// Создание команды для выполнения хранимой процедуры
//                //// Параметры: имя процедуры и подключение к БД
//                //SqlCommand cmd = new SqlCommand(cust_add, SQLConnection);

//                //// Указываем, что выполняем именно хранимую процедуру (а не обычный SQL-запрос)
//                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

//                //// Добавление входных параметров в хранимую процедуру
//                //cmd.Parameters.AddWithValue("@FirstName", "Kirill");       // Имя клиента
//                //cmd.Parameters.AddWithValue("@LastName", "Banar");         // Фамилия клиента
//                //cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.Now.ToShortDateString());  // Дата рождения (текущая дата)

//                //// Добавление выходного параметра для получения ID нового клиента
//                //// Указываем тип данных - INT
//                //SqlParameter cust_id = cmd.Parameters.Add("@id", System.Data.SqlDbType.Int);

//                //// Устанавливаем направление параметра как OUTPUT (возвращаемый)
//                //cust_id.Direction = ParameterDirection.Output;

//                //// Выполнение хранимой процедуры
//                //cmd.ExecuteNonQuery();

//                //// Вывод значения выходного параметра (ID добавленного клиента)
//                //// Приводим значение к типу int, так как параметр объявлен как SqlDbType.Int
//                //Console.WriteLine($"{(int)cust_id.Value}");

//                // 3. Поиск по ID
//                //string searchById = "stp_EmployeeByID";
//                //using (SqlCommand cmd = new SqlCommand(searchById, SQLConnection))
//                //{
//                //    cmd.CommandType = CommandType.StoredProcedure;
//                //    cmd.Parameters.AddWithValue("@employeeId",3);
//                //    using (SqlDataReader reader = cmd.ExecuteReader())
//                //    {
//                //        Console.WriteLine($"{"ID",-20}{"Имя",-20}{"Фамилия",-20}{"Зарплата",-20}");
//                //        while (reader.Read())
//                //        {
//                //            Console.WriteLine($"{reader["EmployeeId"],-20}{reader["FirstName"],-20}{reader["LastName"],-20} {reader["Salary"]}");
//                //        }
//                //    }
//                //}
//                // 4. Удаление по ID
//                //string deleteById = "stp_Delete_Customer_By_ID";
//                //using (SqlCommand cmd = new SqlCommand(deleteById, SQLConnection))
//                //{
//                //    cmd.CommandType = CommandType.StoredProcedure;
//                //    cmd.Parameters.AddWithValue("@customerId", 7);
//                //    int rowsAffected = cmd.ExecuteNonQuery();
//                //    Console.WriteLine(rowsAffected == 1? "Удаление прошло успешно" : "Удаление не выполнено");
//                //}                
//            }
//        }
//    }
//}
