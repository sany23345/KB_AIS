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
    public partial class HistoryForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        string id;
       public Form humanRDForm;
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void searchByNameTextBox_TextChanged(object sender, EventArgs e) //событие поиска по фамилии сотрудника
        {
            string query = "Select ID, ФИО From Сотрудники where ФИО like '" + searchByNameTextBox.Text + "%' and Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void searchByIdTextBox_TextChanged(object sender, EventArgs e) //событие поиска по номеру удостоверения
        {
            string query = "Select ID, ФИО From Сотрудники where ID like '" + searchByIdTextBox.Text + "%' and Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void HistoryForm_Load(object sender, EventArgs e) //событие при загрузки формы
        {
            string query = @"Select ID, ФИО From Сотрудники 
                            Where Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) // событие при клике на ячейку в таблице
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows) //выбираем в строке только id по которому будем редактировать
            {
                id = item.Cells[0].Value.ToString();
            }
            string query = @"Select id_Сотрудника,Сотрудники.ФИО,Дата_Выдачи,Дата_Истечения_Срока_Действия from История_выданых_удостоверений
                            Inner Join Сотрудники on Сотрудники.ID = История_выданых_удостоверений.id_Сотрудника
                                where id_Сотрудника = '" + id + "' and Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            humanRDForm.Visible = true;
            this.Visible = false;
        }
        private void TextBoxIsLetter_KeyPress(object sender, KeyPressEventArgs e)
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
        private void TextBoxIsDigit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void HistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }
    }
}
