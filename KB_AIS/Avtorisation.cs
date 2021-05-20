using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class Avtorisation : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);

        public Avtorisation()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e) //событие по нажатию кнопки "Вход"
        {
            //var md5 = MD5.Create(); //создание хеш алгоритма 
            //var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordTextBox.Text)); // вычисление хеш алгоритма для заданного массива
            //string password = Convert.ToBase64String(hashPassword); //преобразование хеш массива в строковое представление

            string query = @"Select История_изменений_должностей.ID, Сотрудники.Фамилия,Сотрудники.Табельный_номер,Сотрудники.Пароль,
                    Дата_вступления_в_должность,Должности.Название_должности, Удостоверение.Номер_удостоверения  From История_изменений_должностей
                    inner join  Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join  Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join  Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    where Табельный_номер='"+loginTexBox.Text+"' and Пароль='"+passwordTextBox.Text+"' and Истекло=0";


            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Данные введены не верно");
            }
            else
            {
                if (dataTable.Rows[0]["Название_должности"].ToString() == "Сотрудник отдела кадров")
                {
                    HumanResourcesDepartmentForm departmentForm = new HumanResourcesDepartmentForm();
                    departmentForm.avtorisaitionForm = this;
                    departmentForm.IdPeople = dataTable.Rows[0][0].ToString();
                    departmentForm.Visible = true;
                    this.Visible = false;
                }
                else if(dataTable.Rows[0]["Название_должности"].ToString() == "Дежурный")
                {
                    DutyForm dutyForm = new DutyForm();
                    dutyForm.avtorisationForm = this;
                    dutyForm.IdPeople= dataTable.Rows[0][0].ToString(); 
                    dutyForm.Visible = true;
                    this.Visible = false;
                }
                else 
                {
                    CertificateForm certificateForm = new CertificateForm();
                    certificateForm.id = dataTable.Rows[0][0].ToString();
                    certificateForm.FIO = dataTable.Rows[0][1].ToString();
                    certificateForm.position = dataTable.Rows[0][3].ToString();
                    certificateForm.dateOfIssue = dataTable.Rows[0][4].ToString();
                    certificateForm.expirationDate = dataTable.Rows[0][5].ToString();
                    certificateForm.avtorisationForm = this;
                    certificateForm.Visible = true;
                    this.Visible = false;
                }

                loginTexBox.Text = null;
                passwordTextBox.Text = null;
            }
        }
    }
}
