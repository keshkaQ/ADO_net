using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson_6_Form_DGV
{
    public partial class Form1 : Form
    {
        private DataSet _dataSet;
        private SqlDataAdapter _adapter;
        private SqlCommandBuilder _commandBuilder;
        private string constr = String.Empty;

        public Form1()
        {
            InitializeComponent();
            constr = ConfigurationManager.ConnectionStrings["Company_db"].ConnectionString;
        }

        private void bt_fill_click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Введите SQL-запрос");
                return;
            }

            try
            {
                using (var sqlConnection = new SqlConnection(constr))
                {
                    _adapter = new SqlDataAdapter(textBox1.Text, sqlConnection);
                    _commandBuilder = new SqlCommandBuilder(_adapter);
                    _dataSet = new DataSet();
                    sqlConnection.Open();
                    _adapter.Fill(_dataSet, "TableFromBd");
                    dataGridView1.DataSource = _dataSet.Tables["TableFromBd"];
                    MessageBox.Show("Данные успешно загружены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void bt_update_click(object sender, EventArgs e)
        {
            if (_dataSet == null)
            {
                MessageBox.Show("Сначала выполните запрос к базе данных (кнопка Fill)");
                return;
            }
            try
            {
                using (var sqlConnection = new SqlConnection(constr))
                {
                    _adapter.SelectCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    _adapter.Update(_dataSet, "TableFromBd");
                    MessageBox.Show("Данные успешно обновлены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }
    }
}
