//using System;
//using System.Configuration;
//using System.Data.SqlClient;

//namespace Lesson3
//{
//    internal class Homework_CommandBuilder
//    {
//        static void Main()
//        {
//            string constr = ConfigurationManager.ConnectionStrings["Shop_db"].ConnectionString;
//            using (SqlConnection connection = new SqlConnection(constr))
//            {
//                connection.Open();
//                // 1. Добавление пользователя
//                Console.WriteLine("------------- Добавление пользователя в таблицу ----------------");
//                using (SqlCommand command = new SqlCommand("dbo.add_user", connection))
//                {
//                    command.CommandType = System.Data.CommandType.StoredProcedure;
//                    SqlCommandBuilder.DeriveParameters(command);
//                    command.Parameters[1].Value = "terehov12";
//                    command.Parameters[2].Value = "terehov_password";
//                    command.Parameters[3].Value = "Алексей";
//                    command.Parameters[4].Value = "Терехов";
//                    command.Parameters[5].Value = "Алексеевич";
//                    command.Parameters[6].Value = "terexovalex@gmail.com";
//                    command.Parameters[7].Value = "+79304058890";
//                    int rowsAffected = command.ExecuteNonQuery();
//                    Console.WriteLine(rowsAffected > 0 ? "Пользователь успешно добавлен" : "Ошибка: Пользователь не добавлен");
//                }

//                // 2. Добавление продукта
//                Console.WriteLine("\n------------- Добавление продукта в таблицу ----------------");
//                using (SqlCommand command = new SqlCommand("dbo.add_product", connection))
//                {
//                    command.CommandType = System.Data.CommandType.StoredProcedure;
//                    SqlCommandBuilder.DeriveParameters(command);
//                    command.Parameters[1].Value = "Мышь компьютерная";
//                    command.Parameters[2].Value = "Беспроводная компьютерная мышь";
//                    command.Parameters[3].Value = 999.99;
//                    command.Parameters[4].Value = 12;
//                    int rowsAffected = command.ExecuteNonQuery();
//                    Console.WriteLine(rowsAffected > 0 ? "Продукт успешно добавлен" : "Ошибка: Продукт не добавлен");
//                }
//                // 3. Добавление категории
//                Console.WriteLine("\n------------- Добавление категории ----------------");
//                using (SqlCommand command = new SqlCommand("dbo.add_category", connection))
//                {
//                    command.CommandType = System.Data.CommandType.StoredProcedure;
//                    SqlCommandBuilder.DeriveParameters(command);
//                    command.Parameters[1].Value = "Компьютерная периферия";
//                    command.Parameters[2].Value = "USB-флешки, адаптеры, переходники, мышки";
//                    int rowsAffected = command.ExecuteNonQuery();
//                    Console.WriteLine(rowsAffected > 0 ? "Категория успешно добавлена" : "Ошибка: Категория не добавлена");
//                }
//                // 4. Присвоение продукту категории 
//                Console.WriteLine("Список продуктов:");
//                using (SqlCommand command = new SqlCommand("SELECT product_id, name FROM products", connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        Console.WriteLine($"\n{"Product_id",-15} {"Product_name",-15}");
//                        while (reader.Read())
//                        {
//                            Console.WriteLine($"{reader["product_id"],-15}{reader["name"],-15}");
//                        }
//                    }
//                }
//                Console.WriteLine();
//                Console.WriteLine("Список категорий:");
//                using (SqlCommand command = new SqlCommand("SELECT category_id, name FROM categories", connection))
//                {
//                    using (SqlDataReader reader = command.ExecuteReader())
//                    {
//                        Console.WriteLine($"\n{"Category_id",-15} {"Category_name",-15}");
//                        while (reader.Read())
//                        {
//                            Console.WriteLine($"{reader["category_id"],-15}{reader["name"],-15}");
//                        }
//                    }
//                }
//                int product_id = ReadIntInput("Введите ID продукта: ");
//                int category_id = ReadIntInput("Введите ID категории: ");
//                using (SqlCommand command = new SqlCommand("dbo.add_category_for_product", connection))
//                {
//                    command.CommandType = System.Data.CommandType.StoredProcedure;
//                    SqlCommandBuilder.DeriveParameters(command);
//                    command.Parameters[1].Value = product_id;
//                    command.Parameters[2].Value = category_id;
//                    int rowsAffected = command.ExecuteNonQuery();
//                    Console.WriteLine(rowsAffected == 1 ?
//                        $"Категория для продукта {product_id} успешно добавлена"
//                        : "Ошибка: категория для продукта {product_id} не была добавлена");
//                }
//            }
//        }
//        static int ReadIntInput(string message)
//        {
//            while (true)
//            {
//                Console.Write(message);
//                if (int.TryParse(Console.ReadLine(), out int value))
//                {
//                    return value;
//                }
//                Console.WriteLine("Ошибка: введите целое число!");
//            }
//        }
//    }
//}
