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

    public partial class Prolongation : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form HRDForm;
        public Prolongation()
        {
            InitializeComponent();
        }

        public void LoadTable()
        {
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and 
                Удалено=0 and DATENAME(MONTH,Действителен_по)+'-'+DATENAME(YEAR,Действителен_по)=DATENAME(MONTH,GETDATE())+'-'+DATENAME(YEAR,GETDATE())";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTableProlonfation = new DataTable();
            sqlDataAdapter.Fill(dataTableProlonfation);
            dataGridView1.DataSource = dataTableProlonfation;
        }

        private void Prolongation_Load(object sender, EventArgs e)
        {
            LoadTable();
            prolongationDateTimePicker.MinDate = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HRDForm.Visible = true;
            this.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                nameTextBox.Text = row.Cells["ФИО"].Value.ToString();
                numberTextBox.Text = row.Cells["Номер_удостоверения"].Value.ToString();
            }
        }

        private void prolongationButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(numberTextBox.Text))
            {
                string query = @"insert into История_продления_удостоверений values ('" + prolongationDateTimePicker.Value.ToString("yyyy.MM.dd") + "','" + numberTextBox.Text + "')";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Удостоверение продлено!");
                nameTextBox.Text = null;
                numberTextBox.Text = null;
                LoadTable();
            }
            else
            {
                MessageBox.Show("Выбирите удостоверение!");
            }
        }

        private void Prolongation_FormClosed(object sender, FormClosedEventArgs e)
        {
            HRDForm.Visible = true;
        }
    }
}
