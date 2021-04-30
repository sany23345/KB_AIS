using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KB_AIS
{
    public partial class HistoryChangeForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form humanRDForm;
        string id;
        public HistoryChangeForm()
        {
            InitializeComponent();
        }

        private void TextBoxIsLetter_KeyPress(object sender, KeyPressEventArgs e) // собтие на ограничение ввода цифр
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void TextBoxIsDigit_KeyPress(object sender, KeyPressEventArgs e)// собтие на ограничение ввода букв
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e) //событие при нажатии на кнопку "Закрыть"
        {
            humanRDForm.Visible = true;
            this.Visible = false;
        }

        private void HistoryChangeForm_FormClosed(object sender, FormClosedEventArgs e) //событие при закрытии формы
        {
            humanRDForm.Visible = true;
        }

        private void HistoryChangeForm_Load(object sender, EventArgs e) //событие при загрузки формы
        {
            string query = @"Select ID, ФИО From Сотрудники 
                            Where Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows) //выбираем в строке только id по которому будем редактировать
            {
                id = item.Cells[0].Value.ToString();
            }
            string query = @"Select ID_сотрудника, ФИО,Номер_телефона, Серия_паспорта,Номер_паспорта,Должности.Название_должности,Дата_изменения From История_изменений
            inner join Должности on Должности.ID=История_изменений.Должность
            where ID_сотрудника='" + id+"'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }

        private void searchByNameTextBox_TextChanged(object sender, EventArgs e) //событие поиска по фамилии сотрудника
        {
            string query = "Select ID, ФИО From Сотрудники where ФИО like '" + searchByNameTextBox.Text + "%' and Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void searchByIdTextBox_TextChanged(object sender, EventArgs e)//событие поиска по номеру удостоверения сотрудника
        {
            string query = "Select ID, ФИО From Сотрудники where ID like '" + searchByIdTextBox.Text + "%' and Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
