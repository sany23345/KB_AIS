﻿using System;
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

    public partial class HumanResourcesDepartmentForm : Form
    {
        // static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        string id;


        public Form avtorisaitionForm;
        public HumanResourcesDepartmentForm()
        {
            InitializeComponent();
        }

        public void RefreshTable() //метод для обновления таблицы
        {
            string query = @"Select Сотрудники.ID,[ФИО],[Серия_паспорта],[Номер_паспорта],
            [Контактный_телефон],Должности.Название_должности,[Пароль], Удостоверение.Дата_выдачи, Удостоверение.Дата_истечения_срока_действия from  Сотрудники
            Inner join Должности on Должности.ID = Сотрудники.Должность			
			Inner join Удостоверение on Удостоверение.ID=Сотрудники.ID
            Where Удалено=0";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();      
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        public void LoadEducationalTable() //метод для загрузки образования сотрудника
        {
            string query = @"Select Название_учебного_заведения, Дата_начала_обучения, Дата_окончания_обучения, Вид_образования.Вид_образования, Специальность,Форма_обучения.Форма_обучения
            From Образование 
            Inner Join Вид_образования on Вид_образования.ID = Образование.Вид_образования
            Inner Join Форма_обучения on Форма_обучения.ID = Образование.Форма_обучения
            where Сотрудник = '" + id + "';";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }


        private void HumanResourcesDepartmentForm_Load(object sender, EventArgs e) //событие при загрузки формы
        {
            string query = "Select * from Вид_образования";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            tupeEducationComboBox.DataSource = dataTable;
            tupeEducationComboBox.ValueMember = "ID";
            tupeEducationComboBox.DisplayMember = "Вид_образования";
            
            query = "Select * from Форма_обучения";
            sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable1 = new DataTable();
            sqlDataAdapter.Fill(dataTable1);
            formEducationalComboBox.DataSource = dataTable1;
            formEducationalComboBox.ValueMember = "ID";
            formEducationalComboBox.DisplayMember = "Форма_обучения";

            RefreshTable();

            finishDateTimePicker.MaxDate = DateTime.Now;
            startDateTimePicker.MaxDate= DateTime.Now;
        }

        private void HumanResourcesDepartmentForm_FormClosed(object sender, FormClosedEventArgs e) //событие при закрытии формы
        {
            avtorisaitionForm.Visible = true;
        }

        private void searchNameTextBox_TextChanged(object sender, EventArgs e) //событие при вводе в TextBox ФИО сотрудника
        {
            string query = @"Select Сотрудники.ID,[ФИО],[Серия_паспорта],[Номер_паспорта],
            [Контактный_телефон],Должности.Название_должности,[Пароль], Удостоверение.Дата_выдачи, Удостоверение.Дата_истечения_срока_действия from  Сотрудники
            Inner join Должности on Должности.ID = Сотрудники.Должность
			Inner join Удостоверение on Удостоверение.ID=Сотрудники.ID
            WHERE ФИО LIKE '" + searchNameTextBox.Text + "%' and Удалено=0;";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void searchDateTimePicker_ValueChanged(object sender, EventArgs e) //событие при вводе в DataTimePicker даты выдачи удостоверения сотрудника
        {
            string query = @"Select Сотрудники.ID,[ФИО],[Серия_паспорта],[Номер_паспорта],
            [Контактный_телефон],Должности.Название_должности,[Пароль], Удостоверение.Дата_выдачи, Удостоверение.Дата_истечения_срока_действия from  Сотрудники
            Inner join Должности on Должности.ID = Сотрудники.Должность
			Inner join Удостоверение on Удостоверение.ID=Сотрудники.ID
            where  Удостоверение.Дата_выдачи = '" + searchDateTimePicker.Value.ToString("yyyy.MM.dd") + "' and Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void updateButton_Click(object sender, EventArgs e) //событие по нажатию кнопки "Обновить"
        {
            RefreshTable();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e) // событие выбора странички в TabControl
        {
            if (e.TabPageIndex == 1)
            {
                LoadEducationalTable();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) //событие по нажатию на ячейку в DataGridView
        {
            foreach (DataGridViewRow  row in dataGridView1.SelectedRows)
            {
                id = row.Cells[0].Value.ToString();
            }
        }

        private void saveButton_Click(object sender, EventArgs e) //событие при нажатии кнопки "Сохранить"
        {
            if (!string.IsNullOrEmpty(nameEducationalTextBox.Text) && !string.IsNullOrEmpty(tupeEducationComboBox.Text) && !string.IsNullOrEmpty(specialtyTextBox.Text) && !string.IsNullOrEmpty(formEducationalComboBox.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите сохранить данные?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dialogResult)
                {
                    string query = @"Insert Into Образование(Название_учебного_заведения, Дата_начала_обучения, Дата_окончания_обучения, Вид_образования, Сотрудник, Специальность, Форма_обучения) 
                     values('" + nameEducationalTextBox.Text + "', '" + startDateTimePicker.Value.ToString("yyyyMMdd") + "', '" + finishDateTimePicker.Value.ToString("yyyyMMdd") + "', '" + tupeEducationComboBox.SelectedValue + "', '" + id + "', '" + specialtyTextBox.Text + "', '" + formEducationalComboBox.SelectedValue + "')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();

                    LoadEducationalTable();

                    nameEducationalTextBox.Text = null;
                    specialtyTextBox.Text = null;
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля", "Внимание!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id = row.Cells[0].Value.ToString();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"Update Сотрудники Set Удалено = 1 where ID='" + id + "'";
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                RefreshTable();
            }
        }
    }
}