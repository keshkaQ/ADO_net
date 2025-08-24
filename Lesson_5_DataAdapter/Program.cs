using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

// Порядок выполнения:
/* 1. Создать адаптер, в параметры передать sql-выражение и соединение                  SqlDataAdapter dataAdapter = new SqlDataAdapter("sql", sqlConnection);
 * 2. Создать CommandBuilder и передать в него адаптер                                  SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(dataAdapter);
 * 3. Создать DataSet. Заполнить DataSet данными из базы через DataAdapter.Fill.        DataSet dataSet = new DataSet();
 * 4. Создать DataTable и получить данные из таблицы                                    DataTable dataTable = new DataTable();
 * 4. Читаем строки DataRow, если необходимо чтение                                     foreach (DataRow dr in dtPosition.Rows)
 */


namespace Lesson_5_DataAdapter
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // 1. Получение всех должностей из БД
                // Создаем DataAdapter для выполнения SQL-запроса. Запрос выбирает все данные из таблицы Position с сортировкой по второму столбцу (PositionName)
                SqlDataAdapter positionAllAdapter = new SqlDataAdapter("SELECT * FROM Position ORDER BY 2", sqlConnection);

                // Создаем CommandBuilder и передаем в него адаптер
                SqlCommandBuilder cmdPosition = new SqlCommandBuilder(positionAllAdapter);

                // Создаем DataSet для хранения данных в памяти
                DataSet dataSetPosition = new DataSet();

                // Заполняем DataSet данными из базы через DataAdapter. "Positions" - имя таблицы в DataSet
                positionAllAdapter.Fill(dataSetPosition, "Positions");

                // Получаем ссылку на DataTable с данными 
                DataTable dtPosition = dataSetPosition.Tables["Positions"];

                // Перебираем все строки в таблице 
                foreach (DataRow dr in dtPosition.Rows)
                {
                    Console.WriteLine($"{dr["PositionID"],-5} {dr["PositionName"]}");
                }

                // 2. Получение всех заказчиков
                // Создание адаптера данных для работы с базой
                SqlDataAdapter allCustomers = new SqlDataAdapter();

                // Настройка команды для выборки данных (используется хранимая процедура)
                allCustomers.SelectCommand = new SqlCommand("stp_CustomerAll", sqlConnection);
                // Указываем, что команда является хранимой процедурой
                allCustomers.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Создаем SqlCommandBuilder для автоматической генерации SQL-команд
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(allCustomers);

                // Создаем DataSet для хранения данных, полученных из базы
                DataSet dsAllCustomers = new DataSet();

                // Заполняем DataSet данными, выполняя хранимую процедуру. "Customers" - имя таблицы в DataSet
                allCustomers.Fill(dsAllCustomers, "Customers");

                // Получаем ссылку на таблицу с данными 
                DataTable dt = dsAllCustomers.Tables["Customers"];

                // Перебираем все строки 
                foreach (DataRow dataRow in dt.Rows)
                {
                    Console.WriteLine($"{dataRow["FirstName"],-15} {dataRow["LastName"],-15} {Convert.ToDateTime(dataRow["DateOfBirth"]).ToShortDateString(),-15}");
                }

                // 3. Добавление заказчика
                // Создаем DataAdapter для выполнения SQL-запроса. Запрос выбирает всех заказчиков из таблицы Customers
                SqlDataAdapter customerAdapter = new SqlDataAdapter("SELECT * FROM Customers", sqlConnection);

                // Создаем SqlCommandBuilder для автоматической генерации SQL-команд
                SqlCommandBuilder CustomerSqlCommandBuilder = new SqlCommandBuilder(customerAdapter);

                // Создаем DataSet для хранения данных, полученных из базы
                DataSet dataSetAllCustomers = new DataSet();

                // Заполняем DataSet данными. "Customers" - имя таблицы в DataSet
                customerAdapter.Fill(dataSetAllCustomers, "Customers");

                //Получаем ссылку на таблицу с данными Customers
                DataTable dtCustomer = dataSetAllCustomers.Tables["Customers"];

                // Создаем новую строку для добавления в БД
                DataRow newCustomer = dtCustomer.NewRow();

                // Заполняем строчку таблицы и добавляем ее в БД
                newCustomer[1] = "Mikhail";
                newCustomer[2] = "Serov";
                newCustomer[3] = DateTime.Now.ToShortDateString();
                dtCustomer.Rows.Add(newCustomer);

                // Перебираем строчки из таблицы
                foreach (DataRow dataRow in dtCustomer.Rows)
                {
                    Console.WriteLine($"{dataRow["id"],-15}{dataRow["FirstName"],-15} {dataRow["LastName"],-15} {Convert.ToDateTime(dataRow["DateOfBirth"]).ToShortDateString(),-15}");
                }
                Console.WriteLine("------------------------------------");

                // обновляем БД
                customerAdapter.Update(dataSetAllCustomers, "Customers");
                dtCustomer.Clear();
                customerAdapter.Fill(dataSetAllCustomers, "Customers");
                foreach (DataRow dataRow in dtCustomer.Rows)
                {
                    Console.WriteLine($"{dataRow["id"],-15}{dataRow["FirstName"],-15} {dataRow["LastName"],-15} {Convert.ToDateTime(dataRow["DateOfBirth"]).ToShortDateString(),-15}");
                }

                Console.WriteLine("------------------------------------");

                // 4. Удаление заказчика из БД
                // Создаем SqlDataAdapter для выборки всех данных из таблицы Customers
                SqlDataAdapter AdapterCustomer = new SqlDataAdapter("SELECT * FROM Customers", sqlConnection);

                // Создаем SqlCommandBuilder для автоматической генерации SQL-команд (INSERT, UPDATE, DELETE) 
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(AdapterCustomer);

                // Создаем DataSet для хранения данных из базы данных
                DataSet allCustomersDataSet = new DataSet();

                // Заполняем DataSet данными из базы данных через adapter, Customers - имя таблицы в DataSet
                AdapterCustomer.Fill(allCustomersDataSet, "Customers");

                // Получаем ссылку на DataTable из DataSet
                DataTable dataTableCustomer = allCustomersDataSet.Tables["Customers"];

                // Устанавливаем первичный ключ для DataTable
                dataTableCustomer.PrimaryKey = new DataColumn[] { dataTableCustomer.Columns["id"] };

                // Ищем строку с id = 13 для удаления. Метод Find() работает только если установлен PrimaryKey
                DataRow row_delete = dataTableCustomer.Rows.Find(13);

                // Проверяем, найдена ли строка для удаления, если находит - то удаляем
                if (row_delete != null)
                {
                    row_delete.Delete();
                    Console.WriteLine("Удалено");
                }
                else
                {
                    Console.WriteLine("Не удалено");
                }

                // Обновление данных в  БД
                AdapterCustomer.Update(allCustomersDataSet, "Customers");

                // Очищаем DataTable от старых данных
                dataTableCustomer.Clear();

                // Заново заполняем DataTable данными из базы данных, чтобы увидеть актуальное состояние после удаления
                AdapterCustomer.Fill(allCustomersDataSet, "Customers");

                foreach (DataRow dataRow in dataTableCustomer.Rows)
                {
                    Console.WriteLine($"{dataRow["id"],-15}{dataRow["FirstName"],-15} {dataRow["LastName"],-15} {Convert.ToDateTime(dataRow["DateOfBirth"]).ToShortDateString(),-15}");
                }
            }
        }
    }
}
