using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KB_AIS
{

    public partial class HumanResourcesDepartmentForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        string id,fio;
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
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Сотрудники.Серия_паспорта,
                Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
						 where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();      
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        public void LoadEducationalTable() //метод для загрузки образования сотрудника
        {
            string query = @"Select Образование.ID, Название_учебного_заведения,Дата_начала_обучения,Дата_окончания_обучения,Вид_образования.Вид_образования,Форма_обучения.Форма_обучения,Специальность from Образование
                        inner join Вид_образования on Вид_образования.ID=Образование.Вид_образования
                        inner join Форма_обучения on Форма_обучения.ID=Образование.Форма_обучения
                        inner join Сотрудники on Сотрудники.Табельный_номер=Образование.Табельный_номер_сотрудника
                        where Табельный_номер_сотрудника='" + id + "';";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
            FiotextBox.Text = fio;
            dataGridView2.Columns["ID"].Visible = false;
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

        }

        private void HumanResourcesDepartmentForm_FormClosed(object sender, FormClosedEventArgs e) //событие при закрытии формы
        {
            avtorisaitionForm.Visible = true;
        }

        private void searchNameTextBox_TextChanged(object sender, EventArgs e) //событие при вводе в TextBox ФИО сотрудника
        {
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Сотрудники.Серия_паспорта,
                Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = ( SELECT max(Действителен_по)
                      FROM История_продления_удостоверений) and Удалено=0 and Фамилия like '"+ searchNameTextBox.Text + "%';";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void searchDateTimePicker_ValueChanged(object sender, EventArgs e) //событие при вводе в DataTimePicker даты выдачи удостоверения сотрудника
        {
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Сотрудники.Серия_паспорта,
                Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = ( SELECT max(Действителен_по)
                      FROM История_продления_удостоверений) and Удалено=0 and Дата_выдачи ='"+searchDateTimePicker.Value+"';";
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
                    string query = @"Insert Into Образование(Название_учебного_заведения, Дата_начала_обучения, Дата_окончания_обучения, Вид_образования, Табельный_номер_сотрудника, Специальность, Форма_обучения) 
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
                fio= row.Cells[1].Value.ToString();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e) //событие по нажатию кнопки "Удалить запись"
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"Update Сотрудники Set Удалено = 1 where Табельный_номер='" + id + "'";
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

        private void заТекущийМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.markreport = "1";
            reportForm.humanRDForm = this;
            reportForm.Visible = true;
            this.Visible = false;
        }

        private void заТекущийГодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.markreport = "2";
            reportForm.humanRDForm = this;
            reportForm.Visible = true;
            this.Visible = false;
        }

        private void заОпределенныйПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeriodForm periodForm = new PeriodForm();
            periodForm.humanRDForm = this;
            periodForm.mark = "1";
            periodForm.Visible = true;
            this.Visible = false;
        }

        private void заТекущийМесяцToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.markreport = "4";
            reportForm.humanRDForm = this;
            reportForm.Visible = true;
            this.Visible = false;
        }

        private void заТекущийГодToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.markreport = "5";
            reportForm.humanRDForm = this;
            reportForm.Visible = true;
            this.Visible = false;
        }

        private void prolongationButton_Click(object sender, EventArgs e)
        {
             Prolongation prolongation = new Prolongation();
                    prolongation.HRDForm = this;
                    prolongation.Visible = true;
                    this.Visible = false;
        }

        private void HumanResourcesDepartmentForm_Shown(object sender, EventArgs e)
        {

           string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Сотрудники.Серия_паспорта,
                Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения,
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

            if (dataTableProlonfation.Rows.Count != 0)
            {
                DialogResult dialogResult = MessageBox.Show("Срок действия удостоверений скоро истечё! Продлить срок действия?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    Prolongation prolongation = new Prolongation();
                    prolongation.HRDForm = this;
                    prolongation.Visible = true;
                    this.Visible = false;
                }
            }

            /////Переделать

            //query = @"Select Пароль from Сотрудники  
            //                    where ID='" + IdPeople + "' ";
            //sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            //dataTable = new DataTable();
            //sqlDataAdapter.Fill(dataTable);
            //pass = dataTable.Rows[0]["Пароль"].ToString();



            //if (pass == "4QrcOUm6Wau+VuBX8g+IPg==")
            //{
            //    timer1.Start();
            //} 



        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CertificateForm certificateForm = new CertificateForm();
            certificateForm.id = IdPeople;
            certificateForm.avtorisationForm = this;
            certificateForm.Visible = true;
            this.Visible = false;
        }

        private void заОпределенныйПериодToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PeriodForm periodForm = new PeriodForm();
            periodForm.humanRDForm = this;
            periodForm.mark = "2";
            periodForm.Visible = true;
            this.Visible = false;
        }
    }
}