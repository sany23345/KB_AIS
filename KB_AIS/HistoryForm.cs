using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО] from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер = История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID = История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей = История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения = Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений
                where История_продления_удостоверений.Номер_удостоверения = Удостоверение.Номер_удостоверения) and Удалено = 0 and Фамилия like '"+searchByNameTextBox.Text+"%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void searchByIdTextBox_TextChanged(object sender, EventArgs e) //событие поиска по номеру удостоверения
        {
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО] from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер = История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID = История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей = История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения = Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений
                where История_продления_удостоверений.Номер_удостоверения = Удостоверение.Номер_удостоверения) and Удалено = 0 and Табельный_номер like '"+searchByIdTextBox.Text+"%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void HistoryForm_Load(object sender, EventArgs e) //событие при загрузки формы
        {
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО] from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
						 where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0";
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
            string query = @"Select Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where  Удалено=0 and Табельный_номер ='"+id+"'";
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
