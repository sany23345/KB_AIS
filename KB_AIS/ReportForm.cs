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
    public partial class ReportForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public string markreport;
        public Form humanRDForm;
        DateTime dateTime1 = DateTime.Now;
        public DateTime stDate, enDate;

        public ReportForm()
        {
            InitializeComponent();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {
            var startDate = dateTime1;
            var endDate = dateTime1;

            if (markreport == "1")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);

                string queryString = @"Select Удостоверение.ID,Сотрудники.ФИО , Дата_выдачи,Дата_истечения_срока_действия From Удостоверение 
                        Inner Join Сотрудники on Сотрудники.ID = Удостоверение.ID 
			            where Удалено=0 and Дата_выдачи between '" + startDate.ToString("yyyyMMdd") + "' and '" + endDate.ToString("yyyyMMdd") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(Report.DataTable1);
                reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportSOC.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по выданным удостоверениям"));
            }
            else if (markreport == "2")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddYears(1);

                string queryString = @"Select Удостоверение.ID,Сотрудники.ФИО , Дата_выдачи,Дата_истечения_срока_действия From Удостоверение 
                        Inner Join Сотрудники on Сотрудники.ID = Удостоверение.ID 
			            where Удалено=0 and Дата_выдачи between '" + startDate.ToString("yyyy0101") + "' and '" + endDate.ToString("yyyy0101") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(Report.DataTable1);

                reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по выданным удостоверениям"));
            }
            else if (markreport == "3")
            {
                string queryString = @"Select Удостоверение.ID,Сотрудники.ФИО , Дата_выдачи,Дата_истечения_срока_действия From Удостоверение 
                        Inner Join Сотрудники on Сотрудники.ID = Удостоверение.ID 
			            where Удалено=0 and Дата_выдачи between '" + stDate.ToString("yyyyMMdd") + "' and '" + enDate.ToString("yyyyMMdd") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(Report.DataTable1);

                reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по выданным удостоверениям"));
            }
            if (markreport == "4")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);

                string queryString = @"Select Удостоверение.ID,Сотрудники.ФИО , Дата_выдачи,Дата_истечения_срока_действия From Удостоверение 
            Inner Join Сотрудники on Сотрудники.ID = Удостоверение.ID
			where  Day( Дата_истечения_срока_действия) < Day(GETDATE()) and Year( Дата_истечения_срока_действия)=Year(GETDATE()) and Удалено=0";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(Report.DataTable1);
                reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportSOC.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            }
            else if (markreport == "5")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddYears(1);

                string queryString = @"Select Удостоверение.ID,Сотрудники.ФИО , Дата_выдачи,Дата_истечения_срока_действия From Удостоверение 
            Inner Join Сотрудники on Сотрудники.ID = Удостоверение.ID
			where Year( Дата_истечения_срока_действия)=Year(GETDATE()) and Удалено=0";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(Report.DataTable1);

                reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            }
            else if (markreport == "6")
            {
                string queryString = @"Select Удостоверение.ID,Сотрудники.ФИО , Дата_выдачи,Дата_истечения_срока_действия From Удостоверение 
                        Inner Join Сотрудники on Сотрудники.ID = Удостоверение.ID 
			            where Удалено=0 and Дата_истечения_срока_действия between '" + stDate.ToString("yyyyMMdd") + "' and '" + enDate.ToString("yyyyMMdd") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(Report.DataTable1);

                reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            }

            this.reportViewer1.RefreshReport();
        }

        private void ReportForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }
    }
}

  
