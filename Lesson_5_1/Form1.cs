using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Lesson_5_1
{
    public partial class Form1 : Form
    {
        // Подключение к базе данных
        SqlConnection sqlConnection = null;
        // Адаптер для работы с данными
        SqlDataAdapter adapter = null;
        // Набор данных для хранения результатов запросов
        DataSet dataSet = null;
        // Строка подключения к базе данных
        string constr = String.Empty;
        // Путь к выбранному файлу изображения
        string fileName = String.Empty;

        public Form1()
        {
            InitializeComponent();
            // Получение строки подключения из конфигурационного файла
            constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
            // Инициализация подключения к базе данных
            sqlConnection = new SqlConnection(constr);
        }

        // Обработчик клика по кнопке загрузки изображения
        private void button_load_picture_click(object sender, EventArgs e)
        {
            // Создание диалогового окна для выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Установка фильтра для графических файлов
            openFileDialog.Filter = "Графические файлы | *.bmp; *.png; *.jpeg; *.gif; *jpg; *.jfif";
            openFileDialog.FileName = "";

            // Если пользователь выбрал файл и нажал OK
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Сохранение пути к файлу
                fileName = openFileDialog.FileName;
                // Загрузка изображения в базу данных
                LoadPicture();
            }
        }

        // Метод для загрузки изображения в базу данных
        private void LoadPicture()
        {
            try
            {
                // Создание копии изображения в виде массива байтов
                byte[] bytes = CreateCopy();

                // Открытие подключения к базе данных
                sqlConnection.Open();

                // Создание SQL-команды для вставки данных
                using (SqlCommand command = new SqlCommand("INSERT INTO Pictures (Customer_ID, _Name, Picture) VALUES(@customer_id,@name,@picture)",sqlConnection))
                {
                    // Проверка, что ID клиента указан
                    if (textBox1.Text == null || textBox1.Text.Length == 0)
                    {
                        MessageBox.Show("ID клиента не указан");
                        return;
                    }

                    // Получение числа из textBox1.Text
                    int index = -1;
                    int.TryParse(textBox1.Text, out index);

                    // Добавление параметров к команде
                    command.Parameters.Add("@customer_id", SqlDbType.Int).Value = index;
                    command.Parameters.Add("@name", SqlDbType.NVarChar, 500).Value = fileName;
                    command.Parameters.Add("@picture", SqlDbType.Image, bytes.Length).Value = bytes;

                    // Выполнение команды
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                // Обработка ошибок при загрузке изображения
                MessageBox.Show("Error LoadPicture");
            }
            finally
            {
                // Закрытие подключения в блоке finally
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }

        // Метод для создания уменьшенной копии изображения
        private byte[] CreateCopy()
        {
            try
            {
                // Загрузка изображения из файла
                Image image = Image.FromFile(fileName);

                // Максимальные размеры для уменьшенной копии
                int maxWidth = 300, maxHeight = 300;

                // Расчет коэффициентов масштабирования
                double ratioX = (double)maxWidth / image.Width;
                double ratioY = (double)maxHeight / image.Height;
                double ratio = Math.Min(ratioX, ratioY);

                // Расчет новых размеров изображения
                int newWidth = (int)(image.Width * ratio);
                int newHeight = (int)(image.Height * ratio);

                // Создание нового bitmap - создает пустое изображение нужного размера
                Image img = new Bitmap(newWidth, newHeight);

                // Создаем графический контекст для рисования на новом изображении
                Graphics g = Graphics.FromImage(img);

                // Рисуем оригинальное изображение на новом с масштабированием
                g.DrawImage(image, 0, 0, newWidth, newHeight);

                // Создаем поток в памяти для хранения данных
                MemoryStream memoryStream = new MemoryStream();

                // Сохраняем изображение в поток в формате PNG
                img.Save(memoryStream, ImageFormat.Png);

                // Записываем буферы в поток
                memoryStream.Flush();

                // Перемещаем указатель позиции потока в начало для чтения
                memoryStream.Seek(0, SeekOrigin.Begin);

                // Создаем BinaryReader для чтения бинарных данных из потока
                BinaryReader br = new BinaryReader(memoryStream);

                // Читаем все байты из потока
                byte[] buf = br.ReadBytes((int)memoryStream.Length);

                // Возвращаем массив байтов
                return buf;
            }
            catch (Exception)
            {
                // Обработка ошибок при создании копии
                MessageBox.Show("Error CreateCopy");
                return null;
            }
        }

        // Обработчик клика по кнопке показа одного изображения
        private void Show_one_click(object sender, EventArgs e)
        {
            try
            {
                // Проверка, что ID клиента указан
                if (textBox1.Text == null || textBox1.Text.Length == 0)
                {
                    MessageBox.Show("Укажите id клиента");
                    return;
                }

                int index = -1;
                int.TryParse(textBox1.Text, out index);

                // Проверка корректности формата ID
                if (index == -1)
                {
                    MessageBox.Show("Укажите id клиента в правильном формате");
                    return;
                }

                // Создание адаптера для выборки изображения по ID клиента
                adapter = new SqlDataAdapter("SELECT Picture FROM Pictures WHERE Customer_ID=@Id", sqlConnection);
                SqlCommandBuilder cmb = new SqlCommandBuilder(adapter);

                // Добавление параметра ID к команде
                adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = index;

                // Заполнение DataSet данными
                dataSet = new DataSet();
                adapter.Fill(dataSet);

                // Получение массива байтов изображения из DataSet
                byte[] bytes = (byte[])dataSet.Tables[0].Rows[0]["Picture"];

                // Создание MemoryStream из байтов
                MemoryStream ms = new MemoryStream(bytes);

                // Отображение изображения в pictureBox
                pictureBox1.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                // Обработка ошибок при отображении изображения
                MessageBox.Show(ex.Message);
            }
        }

        // Обработчик клика по кнопке показа всех изображений
        private void ShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Создание адаптера для выборки всех записей из таблицы Pictures
                adapter = new SqlDataAdapter("SELECT * FROM dbo.Pictures;", sqlConnection);
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);

                // Заполнение DataSet данными
                dataSet = new DataSet();
                adapter.Fill(dataSet, "picture");

                // Привязка данных к DataGridView
                dataGridView1.DataSource = dataSet.Tables["Picture"];
            }
            catch (Exception ex)
            {
                // Обработка ошибок при отображении всех изображений
                MessageBox.Show(ex.Message);
            }
        }
    }
}