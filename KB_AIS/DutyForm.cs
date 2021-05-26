using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class DutyForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        DataTable dataTable = new DataTable();

        public Form avtorisationForm;
        string id;
        public string IdPeople;
        string pass;

        public DutyForm()
        {
            InitializeComponent();
        }

        private void DutyForm_Load(object sender, EventArgs e)
        {
            string query = @"Select Фото, Удостоверение.Номер_удостоверения, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО]
                from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dataTable.Rows[i]["Номер_удостоверения"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dataTable.Rows[i]["ФИО"].ToString();
            }


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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            avtorisationForm.Visible = true;
            this.Visible = false;
        }

        private void searchByNameTextBox_TextChanged(object sender, EventArgs e) //событие поиска по фамилии сотрудника
        {
            dataGridView1.Rows.Clear();
            dataTable.Clear();
            string query = @"Select Фото, Удостоверение.Номер_удостоверения, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО]
                from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0 and Фамилия like '" + searchByNameTextBox.Text+"%'";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dataTable.Rows[i]["Номер_удостоверения"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dataTable.Rows[i]["ФИО"].ToString();
            }
        }

        private void searchByIdTextBox_TextChanged(object sender, EventArgs e) //событие поиска по номеру удостоверения
        {
            dataGridView1.Rows.Clear();
            dataTable.Clear();
            string query = @"Select Фото, Удостоверение.Номер_удостоверения, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО]
                from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0 and Удостоверение.Номер_удостоверения like '" + searchByIdTextBox.Text + "%'";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dataTable.Rows[i]["Номер_удостоверения"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dataTable.Rows[i]["ФИО"].ToString();
            }
        }

        private void completionMarkButton_Click(object sender, EventArgs e) //событие по нажатию на кнопку "Поставить отметку о завершении работы"
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите оставить отметку о завершении работы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"select * from Рабочее_время
                            where Номер_удостоверения='" + id + "' and Конец_рабочего_времени BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "' AND '" + DateTime.Now.AddDays(1).ToString("yyyyMMdd") + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTableTime = new DataTable();
                sqlDataAdapter.Fill(dataTableTime);

                if (dataTableTime.Rows.Count == 0)
                {
                    query = @"UPDATE Рабочее_время set Конец_рабочего_времени='" + DateTime.Now.ToString("yyyyMMdd HH:mm:00") + "' where Номер_удостоверения='" + id + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Отметка принята, дата и время окончания работы " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:00"));
                }
                else if (dataTableTime.Rows.Count > 0)
                {
                    MessageBox.Show("Отметка уже была принята сегодня");
                }
            }
        }

        private void goingWorkMarkButton_Click(object sender, EventArgs e) //событие по нажатию на кнопку "Поставить отметку о начале работы"
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите оставить отметку о начале работы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"select * from Рабочее_время
                            where Номер_удостоверения='" + id + "' and Начало_рабочего_времени BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "' AND '" + DateTime.Now.AddDays(1).ToString("yyyyMMdd") + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTableTime = new DataTable();
                sqlDataAdapter.Fill(dataTableTime);

                if (dataTableTime.Rows.Count > 0)
                {
                    MessageBox.Show("Отметка уже была принята сегодня");
                }
                else if (dataTableTime.Rows.Count == 0)
                {
                    query = @" Insert into Рабочее_время values('" + id + "','" + DateTime.Now.ToString("yyyyMMdd HH:mm:00") + "','')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Отметка принята, дата и время выхода " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:00"));
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows) //выбираем в строке только id по которому будем редактировать
            {
                id = item.Cells[0].Value.ToString();
                pictureBox2.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(dataTable.Rows[e.RowIndex]["Фото"].ToString())));
            }
        }

        private void DutyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            avtorisationForm.Visible = true;
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

        private void timer1_Tick(object sender, EventArgs e)
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

        private void рабочееВремяЗаТекущийМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDutyForm reportForm = new ReportDutyForm();
            reportForm.markreport = "1";
            reportForm.dutyForm = this;
            reportForm.Visible = true;
            this.Visible = false;
        }

        private void заТекущийГодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDutyForm reportForm = new ReportDutyForm();
            reportForm.markreport = "2";
            reportForm.dutyForm = this;
            reportForm.Visible = true;
            this.Visible = false;
        }

        private void рабочееВремяЗаОпределенныйПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PeriodForm periodForm = new PeriodForm();
            periodForm.humanRDForm = this;
            periodForm.mark = "3";
            periodForm.Visible = true;
            this.Visible = false;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CertificateForm certificateForm = new CertificateForm();
            certificateForm.id = IdPeople;
            certificateForm.avtorisationForm = this;
            certificateForm.Visible = true;
            this.Visible = false;
        }
    }
}
