using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class CertificateForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        string pass;

        public Form avtorisationForm;
        public string id;

        private void CertificateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            avtorisationForm.Visible = true;
        }

        private void CertificateForm_Load(object sender, EventArgs e) //событие при загрузки формы
        {

            string quary = @"Select Сотрудники.Фото, Сотрудники.Фамилия + ' ' + Сотрудники.Имя + ' ' + Сотрудники.Отчество as [ФИО],Должности.Название_должности,Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер = История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID = История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей = История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения = Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений
                where История_продления_удостоверений.Номер_удостоверения = Удостоверение.Номер_удостоверения) and Удалено = 0  and Табельный_номер = '"+ id + "'and Истекло=0";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(quary,sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            pictureBox1.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(dataTable.Rows[0]["Фото"].ToString())));
            numberTextBox.Text = dataTable.Rows[0]["Номер_удостоверения"].ToString();
            fioTextBox.Text = dataTable.Rows[0]["ФИО"].ToString();
            positionTextBox.Text = dataTable.Rows[0]["Название_должности"].ToString();
            dataOfIssueTextBox.Text = DateTime.Parse(dataTable.Rows[0]["Дата_выдачи"].ToString()).ToString("dd.MM.yyyy");
            expirationDateTextBox.Text = DateTime.Parse(dataTable.Rows[0]["Действителен_по"].ToString()).ToString("dd.MM.yyyy");     
        }
           
        public CertificateForm()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            ReportDutyForm reportForm = new ReportDutyForm();
            reportForm.markreport = "4";
            reportForm.idCertificate = numberTextBox.Text;
            reportForm.dutyForm = this;
            reportForm.Visible = true;
            this.Visible = false;
        }

        private void CertificateForm_Shown(object sender, EventArgs e)
        {
            string query = @"Select Пароль from Сотрудники
                   where Табельный_номер = '" + id + "' ";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            pass = dataTable.Rows[0]["Пароль"].ToString();

            if (pass == "4QrcOUm6Wau+VuBX8g+IPg==")
            {
                MessageBox.Show("Вам необходимо изменить пароль!!!");
                PasswodChangeForm passwodChangeForm = new PasswodChangeForm();
                passwodChangeForm.backForm = this;
                passwodChangeForm.id = id;
                passwodChangeForm.pass = pass;
                passwodChangeForm.Visible = true;
                this.Enabled = false;
            }
        }
    }
}
