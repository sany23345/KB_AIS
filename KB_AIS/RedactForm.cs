using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class RedactForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form humanRDForm;
        string id = "";
        string idPosition;
        string OldData;
        string OldDataExit;
        string name, surname, patronymic, tel, seriaPassport, idPassport, position;
        string[] mas;
        DataTable data = new DataTable();
        public RedactForm()
        {
            InitializeComponent();
        }
        public void RefreshTable()
        {
           string query = @"Select ID,ФИО from  Сотрудники  Where Удалено=0";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void RedactForm_Load(object sender, EventArgs e)
        {
            string query = "Select * from Должности";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            positioncomboBox.DataSource = dataTable;
            positioncomboBox.ValueMember = "ID";
            positioncomboBox.DisplayMember = "Название_должности";

            RefreshTable();


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
        private void telephoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (telephoneTextBox.Text == "8")
                    telephoneTextBox.Text = "+7";
                if (telephoneTextBox.Text == "+")
                    telephoneTextBox.Text = "+7";
                if (telephoneTextBox.Text == "7")
                    telephoneTextBox.Text = "+7";
                if (int.Parse(telephoneTextBox.Text) >= 0 && int.Parse(telephoneTextBox.Text) <= 9)
                    telephoneTextBox.Text = "+7";
                telephoneTextBox.SelectionStart = telephoneTextBox.Text.Length;
            }
            catch (Exception) { }
        }

        private void cancellationButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            humanRDForm.Visible = true;
        }

        private void RedactForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                id = row.Cells[0].Value.ToString();
            }

            string query = @"Select Сотрудники.ID,[ФИО],[Серия_паспорта],[Номер_паспорта],
            [Контактный_телефон],Должности.Название_должности,[Пароль], Удостоверение.Дата_выдачи, Удостоверение.Дата_истечения_срока_действия from Сотрудники
            Inner join Должности on Должности.ID = Сотрудники.Должность			
			Inner join Удостоверение on Удостоверение.ID=Сотрудники.ID
            where Сотрудники.ID = '" +id+ "';";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query,sqlConnection);
           
            dataAdapter.Fill(data);

            mas = data.Rows[0]["ФИО"].ToString().Split(' ');

            surnameTextBox.Text = mas[0];
            nameTextBox.Text = mas[1];
            patronymicTextBox.Text = mas[2];

            seriesPassportTextBox.Text = data.Rows[0]["Серия_паспорта"].ToString();
            idPassportTextBox.Text = data.Rows[0]["Номер_паспорта"].ToString();
            telephoneTextBox.Text = data.Rows[0]["Контактный_телефон"].ToString();
            positioncomboBox.Text = data.Rows[0]["Название_должности"].ToString();
            dateOfIssueTimePicker.Value = DateTime.Parse(data.Rows[0]["Дата_выдачи"].ToString());
            expirationDateTimePicker.Value = DateTime.Parse(data.Rows[0]["Дата_истечения_срока_действия"].ToString());
            seriesPassportTextBox.Text = data.Rows[0]["Серия_паспорта"].ToString();

            idPosition = positioncomboBox.SelectedValue.ToString();

            OldData = dateOfIssueTimePicker.Value.ToString("yyyy.MM.dd");
            OldDataExit = expirationDateTimePicker.Value.ToString("yyyy.MM.dd");
        }

        private void searchByIdTextBox_TextChanged(object sender, EventArgs e)
        {
            string query = @"Select ID,ФИО from  Сотрудники  
                        Where Удалено=0 and ID like '"+searchByIdTextBox.Text+"%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void searchNameTextBox_TextChanged(object sender, EventArgs e)
        {
            string query = @"Select ID,ФИО from  Сотрудники  
                        Where Удалено=0 and ФИО like '" + searchNameTextBox.Text + "%'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно уверены что хотите сохранить изменения???", "Предупреждение!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                string query = @"Update Удостоверение set Дата_выдачи= '" + dateOfIssueTimePicker.Value.ToString("yyyy.MM.dd") + "', Дата_истечения_срока_действия='" + expirationDateTimePicker.Value.ToString("yyyy.MM.dd") + "' where ID = '" + id + "';"
                + "Update Сотрудники set ФИО= '" + surnameTextBox.Text +" "+nameTextBox.Text+" "+patronymicTextBox.Text+ "' ,Серия_паспорта= '" + seriesPassportTextBox.Text + "' ,Номер_паспорта= '" + idPassportTextBox.Text + "',"
                + "Контактный_телефон= '" + telephoneTextBox.Text + "' , Должность ='" + positioncomboBox.SelectedValue + "' "
                + "where ID = '" + id + "';" +
                "Insert into История_выданых_удостоверений(id_Сотрудника,id_Удостоверения,Дата_Выдачи,Дата_Истечения_Срока_Действия) values ('" + id + "','" + id + "','" + OldData + "','" + OldDataExit + "');" +
                " Insert into История_изменений (ID_Сотрудника,ФИО,Серия_паспорта,Номер_паспорта,Должность,Дата_изменения,Номер_телефона) " +
                " values('"+ id + "', '" + mas[0] + " " + mas[1] + " " + mas[2] + "','" + data.Rows[0]["Серия_паспорта"].ToString() + "', '"+ data.Rows[0]["Номер_паспорта"].ToString() + "', '"+ idPosition+"', '" +DateTime.Now.ToString("yyyy.MM.dd")+"','"+data.Rows[0]["Контактный_телефон"] +"'); ";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Данные изменены");
                RefreshTable();
            }
        }
    }
}
