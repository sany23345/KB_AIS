using Microsoft.Reporting.WinForms;
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
    public partial class PrintOutSertificateForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public string id;
        public PrintOutSertificateForm()
        {
            InitializeComponent();
        }

        private void PrintOutSertificateForm_Load(object sender, EventArgs e)
        {
            string query = @"Select Сотрудники.Id, ФИО, Должности.Название_должности,Удостоверение.Дата_выдачи,Удостоверение.Дата_истечения_срока_действия From Сотрудники
            inner join Должности on Должности.ID=Сотрудники.Должность
            Inner join Удостоверение on Удостоверение.ID=Сотрудники.ID  
            where Сотрудники.Id=5;";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query,sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            string[] mas = dataTable.Rows[0][1].ToString().Split(' ');

        
            reportViewer1.LocalReport.SetParameters(new ReportParameter("IdCertificate", dataTable.Rows[0][0].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("FIO", mas[0].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Name", mas[1].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pathonic", mas[2].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Position", dataTable.Rows[0][2].ToString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Date",DateTime.Parse(dataTable.Rows[0][3].ToString()).ToString("dd.MM.yyyy г.")));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("DataDay", DateTime.Parse(dataTable.Rows[0][4].ToString()).ToString("dd")));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MouthDate", DateTime.Parse(dataTable.Rows[0][4].ToString()).ToString("MMMM")));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("YearDate", DateTime.Parse(dataTable.Rows[0][4].ToString()).ToString("yyyy г.")));
            this.reportViewer1.RefreshReport();
        }
    }
}
