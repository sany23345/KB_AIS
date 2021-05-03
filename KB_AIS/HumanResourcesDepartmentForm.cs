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

    public partial class HumanResourcesDepartmentForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        string id;
        string pass;
        public string IdPeople;

        public Form avtorisaitionForm;
        public HumanResourcesDepartmentForm()
        {
            InitializeComponent();
        }
        public void PasswordChange()
        {
            timer1.Stop();

            MessageBox.Show("Вам необходимо изменить пароль!!!");
            PasswodChangeForm passwodChangeForm = new PasswodChangeForm();
            passwodChangeForm.backForm = this;
            passwodChangeForm.id = IdPeople;
            passwodChangeForm.pass = pass;
            passwodChangeForm.Visible = true;
            this.Enabled = false;

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
            startDateTimePicker.MaxDate = DateTime.Now;

            query = @"Select Пароль from Сотрудники  
                                where ID='" + IdPeople + "' ";
            sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            pass = dataTable.Rows[0]["Пароль"].ToString();



            if (pass == "4QrcOUm6Wau+VuBX8g+IPg==")
            {
                timer1.Start();
            }
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.humanRDForm = this;
            addForm.Visible = true;
            this.Visible = false;
        }

        private void HumanResourcesDepartmentForm_VisibleChanged(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            RedactForm redactForm = new RedactForm();
            redactForm.humanRDForm = this;
            redactForm.Visible = true;
            this.Visible = false;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Visible = false;//свойство формы для ограничения действия пользователя
            HistoryForm historyForm = new HistoryForm(); //создание формы добавления
            historyForm.humanRDForm = this; //связь между формами
            historyForm.Visible=true; //открытие формы AddForm  
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Visible = false;//свойство формы для ограничения действия пользователя
            HistoryChangeForm  historyChangeForm = new HistoryChangeForm(); //создание формы добавления
            historyChangeForm.humanRDForm = this; //связь между формами
            historyChangeForm.Visible = true; //открытие формы AddForm  
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                PrintOutSertificateForm printOutSertificateForm = new PrintOutSertificateForm();
                printOutSertificateForm.id = id;
                printOutSertificateForm.humanRDForm = this;
                printOutSertificateForm.Visible = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Выбирите сотрудника!!!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            PasswordChange();
        }
    }
}