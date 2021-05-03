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
    public partial class DutyForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
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
            string query = @"Select ID, ФИО From Сотрудники
                            Where Удалено = 0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            avtorisationForm.Visible = true;
            this.Visible = false;
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

        private void completionMarkButton_Click(object sender, EventArgs e) //событие по нажатию на кнопку "Поставить отметку о завершении работы"
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите оставить отметку о завершении работы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"select * from Рабочее_время
                            where ID_удостоверения='" + id + "' and Конец_рабочего_времени BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "' AND '" + DateTime.Now.AddDays(1).ToString("yyyyMMdd") + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    query = @"UPDATE Рабочее_время set Конец_рабочего_времени='" + DateTime.Now.ToString("yyyyMMdd HH:mm:00") + "' where ID_удостоверения='" + id + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Отметка принята, дата и время окончания работы " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:00"));
                }
                else if (dataTable.Rows.Count > 0)
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
                            where ID_удостоверения='" + id + "' and Начало_рабочего_времени BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "' AND '" + DateTime.Now.AddDays(1).ToString("yyyyMMdd") + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Отметка уже была принята сегодня");
                }
                else if (dataTable.Rows.Count == 0)
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
    }
}
