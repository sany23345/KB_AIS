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
using System.Security.Cryptography;

namespace KB_AIS
{
    public partial class AddForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form humanRDForm;
        public AddForm()
        {
            InitializeComponent();
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            string query = "Select * from Должности";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            positioncomboBox.DataSource = dataTable;
            positioncomboBox.ValueMember = "ID";
            positioncomboBox.DisplayMember = "Название_должности";
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

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }

        private void cancellationButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            humanRDForm.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(surnameTextBox.Text)&& !string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(patronymicTextBox.Text) &&
                !string.IsNullOrEmpty(telephoneTextBox.Text) && !string.IsNullOrEmpty(idPassportTextBox.Text) && !string.IsNullOrEmpty(seriesPassportTextBox.Text))
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите сохранить данные?", "Внимание!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string query = @" select Max(ID) from Удостоверение";
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    int id = int.Parse(dataTable.Rows[0][0].ToString());
                    id++;

                    var md5 = MD5.Create();
                    var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes("123456"));
                    string password = Convert.ToBase64String(hashPassword);

                    query = @"Insert Into Удостоверение(ID,Дата_выдачи,Дата_истечения_срока_действия)
                        values ('" + id + "' , '" + dateOfIssueTimePicker.Value.ToString("yyyy.MM.dd") + "' , '" + expirationDateTimePicker.Value.ToString("yyyy.MM.dd") + "'); " +
                        "Insert Into Сотрудники(ID,ФИО,Должность,Контактный_телефон, Номер_паспорта, Серия_паспорта, Пароль,Удалено) " +
                        "values ('" + id + "', '" + surnameTextBox.Text + " " + nameTextBox.Text + " " + patronymicTextBox.Text + "', '" + positioncomboBox.SelectedValue + "', '" + telephoneTextBox.Text + "', '" + idPassportTextBox.Text + "', '" + seriesPassportTextBox.Text + "', '"+ password + "','0')";

                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Сотрудник добавлен!!!");

                    PrintOutSertificateForm printOutSertificateForm = new PrintOutSertificateForm();
                    printOutSertificateForm.id = id.ToString();
                    printOutSertificateForm.humanRDForm = this;
                    printOutSertificateForm.Visible = true;
                    this.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!!!");
            }
        }
    }
}
