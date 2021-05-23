using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class AddForm : Form
    {
       // static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form humanRDForm;
        string image;
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
            expirationDateTimePicker.MinDate = DateTime.Now;
            expirationDateTimePicker.Value = DateTime.Now.AddYears(1);
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

        private void saveButton_Click(object sender, EventArgs e) // событие по нажатию кнопки "Сохранить"
        {
            if (!string.IsNullOrEmpty(surnameTextBox.Text)&& !string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(patronymicTextBox.Text) &&
                !string.IsNullOrEmpty(telephoneTextBox.Text) && !string.IsNullOrEmpty(idPassportTextBox.Text) && !string.IsNullOrEmpty(seriesPassportTextBox.Text) && pictureBox1.Image!=null)
            {
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите сохранить данные?", "Внимание!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    if (dateOfIssueTimePicker.Value.ToString("yyyy.MM.dd") == expirationDateTimePicker.Value.ToString("yyyy.MM.dd"))
                    {
                        MessageBox.Show("Измените дату окончания срока дейсвия удостоверения!");
                    }
                    else
                    {
                        //var md5 = MD5.Create();
                        //var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes("123456"));
                        //string password = Convert.ToBase64String(hashPassword);

                        string query = @"Insert into Сотрудники values ('"+seriesPassportTextBox.Text+"','"+idPassportTextBox.Text+"','"+telephoneTextBox.Text+"','123456','0','"+ image + "','"+surnameTextBox.Text+"','"+nameTextBox.Text+"','"+patronymicTextBox.Text+"');";

                        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        query = @"Select Max(Табельный_номер) from Сотрудники";
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                        DataTable dataTableIdIEmployee = new DataTable();
                        sqlDataAdapter.Fill(dataTableIdIEmployee);

                        int idIEmployee = int.Parse(dataTableIdIEmployee.Rows[0][0].ToString());
              

                        query = @"Insert into История_изменений_должностей values ('"+idIEmployee+"','"+positioncomboBox.SelectedValue.ToString()+"','"+DateTime.Now.ToString("yyyy.MM.dd")+"')";

                        sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        query = @"Select Max(ID) from История_изменений_должностей";
                        sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                        DataTable dataTableHistory = new DataTable();
                        sqlDataAdapter.Fill(dataTableHistory);

                        int idHistory = int.Parse(dataTableHistory.Rows[0][0].ToString());
                     

                        query = @"Insert into Удостоверение values('"+dateOfIssueTimePicker.Value.ToString("yyyy.MM.dd") +"','"+idHistory+"','0');";

                        sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        query = @"Select MAX(Номер_удостоверения)from Удостоверение";
                        sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                        DataTable dataTableCertification = new DataTable();
                        sqlDataAdapter.Fill(dataTableCertification);

                        int idCertification = int.Parse(dataTableCertification.Rows[0][0].ToString());
                    

                        query = @"insert into История_продления_удостоверений values ('"+expirationDateTimePicker.Value.ToString("yyyy.MM.dd") +"','"+ idCertification + "')";

                        sqlCommand = new SqlCommand(query, sqlConnection);
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();

                        MessageBox.Show("Запись добавлена!!!");

                        //PrintOutSertificateForm printOutSertificateForm = new PrintOutSertificateForm();
                        //printOutSertificateForm.id = id.ToString();
                        //printOutSertificateForm.humanRDForm = this;
                        //printOutSertificateForm.Visible = true;
                        //this.Visible = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath;
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "png files (*.png)|*.png|jpg files(*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
                image = Convert.ToBase64String(File.ReadAllBytes(filePath));
            }
        }
    }
}
