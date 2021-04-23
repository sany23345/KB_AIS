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
    public partial class Avtorisation : Form
    {
       // static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);


        public Avtorisation()
        {
            InitializeComponent();
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string qwere = @"Select Сотрудники.ID,ФИО,Пароль,Должности.Название_должности, Удостоверение.Дата_выдачи,Удостоверение.Дата_истечения_срока_действия From Сотрудники
                inner join Должности on Должности.ID=Сотрудники.Должность
                inner join Удостоверение on Удостоверение.ID = Сотрудники.ID
                where Удалено=0 and Сотрудники.ID='" + loginTexBox.Text+"' and Пароль='"+passwordTextBox.Text+"'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(qwere,sqlConnection);
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
                    departmentForm.Visible = true;
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
            }
        }
    }
}
