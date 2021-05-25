using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace KB_AIS
{
    public partial class PrintOutSertificateForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public string id;
        public Form humanRDForm;
        public PrintOutSertificateForm()
        {
            InitializeComponent();
        }

        private void PrintOutSertificateForm_Load(object sender, EventArgs e)
        {
            string query = @"Select Сотрудники.Фамилия,Сотрудники.Имя,Сотрудники.Отчество,Должности.Название_должности,Удостоверение.Номер_удостоверения,
                    Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                    inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                    where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0 and Удостоверение.Номер_удостоверения='"+id+"'";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
        
            reportViewer1.LocalReport.SetParameters(new ReportParameter("IdCertificate", dataTable.Rows[0][4].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("FIO", dataTable.Rows[0][0].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Name", dataTable.Rows[0][1].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pathonic", dataTable.Rows[0][2].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Position", dataTable.Rows[0][3].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Date",DateTime.Parse(dataTable.Rows[0][5].ToString()).ToString("dd.MM.yyyy г.")));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("DataDay", DateTime.Parse(dataTable.Rows[0][6].ToString()).ToString("dd")));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MouthDate", DateTime.Parse(dataTable.Rows[0][6].ToString()).ToString("MMMM")));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("YearDate", DateTime.Parse(dataTable.Rows[0][6].ToString()).ToString("yyyy г.")));
            this.reportViewer1.RefreshReport();
        }

        private void PrintOutSertificateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }
    }
}
