using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class CertificateForm : Form
    {
        static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        string pass;

        public Form avtorisationForm;
        public string id,FIO,position,dateOfIssue,expirationDate;

        private void timer1_Tick(object sender, EventArgs e)
        {
            PasswordChange();
        }

        public void PasswordChange()
        {
            timer1.Stop();

            MessageBox.Show("Вам необходимо изменить пароль!!!");
            PasswodChangeForm passwodChangeForm = new PasswodChangeForm();
            passwodChangeForm.backForm = this;
            passwodChangeForm.id = id;
            passwodChangeForm.pass = pass;
            passwodChangeForm.Visible = true;
            this.Enabled = false;
        }


        private void CertificateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            avtorisationForm.Visible = true;
        }

        private void CertificateForm_Load(object sender, EventArgs e) //событие при загрузки формы
        {
            numberTextBox.Text = id;
            fioTextBox.Text = FIO;
            positionTextBox.Text = position;
            dataOfIssueTextBox.Text = DateTime.Parse(dateOfIssue).ToString("dd.MM.yyyy г.");
            expirationDateTextBox.Text = DateTime.Parse(expirationDate).ToString("dd.MM.yyyy г.");

            string query = @"Select Пароль from Сотрудники  
                                where ID='" + id + "' ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            pass = dataTable.Rows[0]["Пароль"].ToString();

            if (pass == "4QrcOUm6Wau+VuBX8g+IPg==")
            {
                timer1.Start();
            }
        }
           
        public CertificateForm()
        {
            InitializeComponent();
        }
    }
}
