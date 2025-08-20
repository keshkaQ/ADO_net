using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Lesson_2_StorageProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Получаем строку подключения из конфигурации
                string constr = ConfigurationManager.ConnectionStrings["Shop_db"].ConnectionString;

                // Используем using для автоматического закрытия подключения
                using (SqlConnection sqlConnection = new SqlConnection(constr))
                {
                    sqlConnection.Open(); // Открываем соединение с БД

                    //// 1.1. Добавление пользователя
                    //Console.WriteLine("------------- Добавление пользователя в таблицу ----------------");
                    //using (SqlCommand cmd = new SqlCommand("dbo.add_user", sqlConnection))
                    //{
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@login", "bykovanton");
                    //    cmd.Parameters.AddWithValue("@password", "bykov2025");
                    //    cmd.Parameters.AddWithValue("@first_name", "Антон");
                    //    cmd.Parameters.AddWithValue("@last_name", "Быков");
                    //    cmd.Parameters.AddWithValue("@patronymic", "Вячеславович");
                    //    cmd.Parameters.AddWithValue("@email", "antonbykov2025@example.com");
                    //    cmd.Parameters.AddWithValue("@phone", "+79248904452");
                    //    int rowsAffected = cmd.ExecuteNonQuery();
                    //    Console.WriteLine(rowsAffected > 0 ? "Пользователь успешно добавлен" : "Ошибка: Пользователь не добавлен");
                    //}

                    //// 1.2. Добавление продукта
                    //Console.WriteLine("\n------------- Добавление продукта в таблицу ----------------");
                    //using (SqlCommand cmd = new SqlCommand("dbo.add_product", sqlConnection))
                    //{
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@name", "Лампа");
                    //    cmd.Parameters.AddWithValue("@description", "Лампа настольная для монитора");
                    //    cmd.Parameters.AddWithValue("@price", 1999.99);
                    //    cmd.Parameters.AddWithValue("@quantity", 40);
                    //    int rowsAffected = cmd.ExecuteNonQuery();
                    //    Console.WriteLine(rowsAffected > 0 ? "Продукт успешно добавлен" : "Ошибка: Продукт не добавлен");
                    //}

                    //// 1.3. Добавление категории
                    //Console.WriteLine("\n------------- Добавление категории ----------------");
                    //using (SqlCommand cmd = new SqlCommand("dbo.add_category", sqlConnection))
                    //{
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@name", "Осветительные приборы");
                    //    cmd.Parameters.AddWithValue("@description", "Люстры, лампы, светильники");
                    //    int rowsAffected = cmd.ExecuteNonQuery();
                    //    Console.WriteLine(rowsAffected > 0 ? "Категория успешно добавлена" : "Ошибка: Категория не добавлена");
                    //}

                    //// 1.4. Присвоение продукту категории 
                    //Console.WriteLine("Список продуктов:");
                    //using (SqlCommand all_products = new SqlCommand("SELECT product_id, name FROM products", sqlConnection))
                    //using (SqlDataReader dr = all_products.ExecuteReader())
                    //{
                    //    Console.WriteLine($"\n{"Product_id",-15} {"Product_name",-15}");
                    //    while (dr.Read())
                    //    {
                    //        Console.WriteLine($"{dr["product_id"],-15} {dr["name"],-15}");
                    //    }
                    //}
                    //Console.WriteLine();
                    //Console.WriteLine("Список категорий:");
                    //using (SqlCommand all_categories = new SqlCommand("SELECT category_id, name FROM categories", sqlConnection))
                    //{
                    //    using (SqlDataReader dr = all_categories.ExecuteReader())
                    //    {
                    //        Console.WriteLine($"\n{"Category_id",-15} {"Category_name",-15}");
                    //        while (dr.Read())
                    //        {
                    //            Console.WriteLine($"{dr["category_id"],-15} {dr["name"],-15}");
                    //        }
                    //    }
                    //}
                    //Console.WriteLine("\n------------- Присвоение продукту его категории ----------------");
                    //int product_id = ReadIntInput("Введите ID продукта: ");
                    //int category_id = ReadIntInput("Введите ID категории: ");
                    //string stp = "dbo.add_category_for_product";
                    //using (SqlCommand cmd = new SqlCommand(stp, sqlConnection))
                    //{
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@product_id", product_id);
                    //    cmd.Parameters.AddWithValue("@category_id", category_id);
                    //    int rowsAffected = cmd.ExecuteNonQuery();
                    //    if (rowsAffected > 0)
                    //    {
                    //        Console.WriteLine($"Категория для продукта {product_id} успешно добавлена");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine($"Ошибка: категория для продукта {product_id} не была добавлена");
                    //    }
                    //}

                    //// 2. Получение данных определенного пользователя с количеством сделанных заказов
                    //Console.WriteLine("Список пользователей:");
                    //using (SqlCommand all_users = new SqlCommand("SELECT user_id, first_name, last_name FROM users", sqlConnection))
                    //using (SqlDataReader dr = all_users.ExecuteReader())
                    //{
                    //    Console.WriteLine($"\n{"User_id",-15} {"First_name",-15} {"Last_name",-15}");
                    //    while (dr.Read())
                    //    {
                    //        Console.WriteLine($"{dr["user_id"],-15} {dr["first_name"],-15} {dr["last_name"],-15}");
                    //    }
                    //}
                    //Console.WriteLine();
                    //Console.WriteLine("\n------------- Получение количества заказов пользователя ----------------");
                    //int user_id = ReadIntInput("Введите id пользователя: ");
                    //string stp = "dbo.get_count_orders_by_user";
                    //using (SqlCommand cmd = new SqlCommand(stp, sqlConnection))
                    //{
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@user_id", user_id);
                    //    int res = Convert.ToInt32(cmd.ExecuteScalar());
                    //    Console.WriteLine($"Количество заказов пользователя с ID = {user_id}: {res}");
                    //}

                    //// 3. Получение списка продуктов по заданной категории
                    //Console.WriteLine("Список категорий:");
                    //using (SqlCommand cmd = new SqlCommand("SELECT name from categories", sqlConnection))
                    //{
                    //    using (SqlDataReader dr = cmd.ExecuteReader())
                    //    {
                    //        while (dr.Read())
                    //        {
                    //            Console.WriteLine($"{dr["name"],-15}");
                    //        }
                    //    }
                    //}
                    //Console.WriteLine();
                    //Console.WriteLine("\n------------- Получение списка продуктов по заданной категории ----------------");
                    //Console.Write("Введите название категории: ");
                    //string category = Console.ReadLine();
                    //string stp = "dbo.get_products_by_category";
                    //using (SqlCommand cmd = new SqlCommand(stp, sqlConnection))
                    //{
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.AddWithValue("@category_name", category);
                    //    using (SqlDataReader dr = cmd.ExecuteReader())
                    //    {
                    //        if (dr.HasRows)
                    //        {
                    //            Console.WriteLine($"\n{"Продукт",-15} {"Категория",-15}");
                    //            while (dr.Read())
                    //            {
                    //                Console.WriteLine($"{dr["product_name"],-15} {dr["category_name"],-15}");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("Ничего не найдено");
                    //        }

                    //    }
                    //}

                    //// 4. Поиск продуктов по названию и по диапазону цены
                    //Console.WriteLine("\n------------- Поиск продуктов по названию и по диапазону цены ----------------");
                    //Console.Write("Введите название продукта: ");
                    //string productName = Console.ReadLine();
                    //decimal minPrice = ReadDecimalInput("Введите минимальную цену: ");
                    //decimal maxPrice = ReadDecimalInput("Введите максимальную цену: ");
                    //string stp = "dbo.get_products_by_name_and_price";
                    //using (SqlCommand command = new SqlCommand(stp, sqlConnection))
                    //{
                    //    command.CommandType = CommandType.StoredProcedure;
                    //    command.Parameters.AddWithValue("@name", productName);
                    //    command.Parameters.AddWithValue("@min_price", minPrice);
                    //    command.Parameters.AddWithValue("@max_price", maxPrice);
                    //    using (SqlDataReader dr = command.ExecuteReader())
                    //    {
                    //        if (dr.HasRows)
                    //        {
                    //            Console.WriteLine($"\n{"Название",-15}{"Цена",-15}{"Описание",-15}");
                    //            while (dr.Read())
                    //            {
                    //                Console.WriteLine($"{dr["name"],-15}{dr["price"],-15}{dr["description"],-15}");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("Ничего не найдено");
                    //        }
                    //    }
                    //}

                    //// 5. Вывод всех заказов пользователя в определённый диапазоне дат
                    //Console.WriteLine("\n------------- Вывод всех заказов пользователя в определённый диапазоне дат ----------------");
                    //int user_id = ReadIntInput("Введите id пользователя: ");
                    //Console.Write("Введите начальное значение даты (yyyy-mm-dd): ");
                    //DateTime start_date = Convert.ToDateTime(Console.ReadLine());
                    //Console.Write("Введите конечно значение даты (yyyy-mm-dd): ");
                    //DateTime end_date = Convert.ToDateTime(Console.ReadLine());
                    //string stp = "dbo.get_orders_by_range_date";
                    //using (SqlCommand command = new SqlCommand(stp, sqlConnection))
                    //{
                    //    command.CommandType = CommandType.StoredProcedure;
                    //    command.Parameters.AddWithValue("@user_id", user_id);
                    //    command.Parameters.AddWithValue("@start_date", start_date);
                    //    command.Parameters.AddWithValue("@end_date", end_date);
                    //    using (SqlDataReader dr = command.ExecuteReader())
                    //    {
                    //        if (dr.HasRows)
                    //        {
                    //            Console.WriteLine($"{"Order_id",-20}{"User_id",-20}{"Дата заказа",-20}{"Стоимость",-20}{"Статус заказа",-20}");
                    //            while (dr.Read())
                    //            {
                    //                Console.WriteLine($"{dr["order_id"],-20}{dr["user_id"],-20}{dr["date_created"],-20}{dr["total_price"],-20}{dr["order_status"],-15}");
                    //            }
                    //        }
                    //        else
                    //        {
                    //            Console.WriteLine("Ничего не найдено");
                    //        }
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                // Обрабатываем возможные ошибки
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        static int ReadIntInput(string text)
        {
            while (true)
            {
                Console.Write(text);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка: введите целое число!");
            }
        }
        static decimal ReadDecimalInput(string text)
        {
            while (true)
            {
                Console.Write(text);
                if (decimal.TryParse(Console.ReadLine(), out decimal result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка: введите десятичное число!");
            }
        }
    }
}
