using Microsoft.Reporting.WinForms;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class ReportDutyForm : Form
    {
        DateTime dateTime1 = DateTime.Now;
        public DateTime stDate, enDate;
        public string markreport;
        public Form dutyForm;

        static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);

        public ReportDutyForm()
        {
            InitializeComponent();
        }

        private void ReportDutyForm_Load(object sender, EventArgs e)
        {
            var startDate = dateTime1;
            var endDate = dateTime1;

            if (markreport == "1")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);

                string queryString = @"Select Сотрудники.ID, Сотрудники.ФИО, Sum(DATEDIFF(hour,Начало_рабочего_времени,Конец_рабочего_времени) % 24) as Часы  From Рабочее_время
                        inner join Сотрудники on Сотрудники.ID=Рабочее_время.ID_удостоверения
                        Where Начало_рабочего_времени between '"+ startDate.ToString("yyyyMMdd")+ "' and '" + endDate.ToString("yyyyMMdd") + "' GROUP BY ФИО,Сотрудники.ID";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(ReportDuty.Staff);
                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportDuty.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по рабочему времени"));
            }
            else if (markreport == "2")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddYears(1);

                string queryString = @"Select Сотрудники.ID, Сотрудники.ФИО, Sum(DATEDIFF(hour,Начало_рабочего_времени,Конец_рабочего_времени) % 24) as Часы  From Рабочее_время
                        inner join Сотрудники on Сотрудники.ID=Рабочее_время.ID_удостоверения
                        Where Начало_рабочего_времени between '" + startDate.ToString("yyyy0101") + "' and '" + endDate.ToString("yyyy0101") + "' GROUP BY ФИО,Сотрудники.ID";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(ReportDuty.Staff);
                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportDuty.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по рабочему времени"));

            }
            else if (markreport == "3")
            {
                string queryString = @"Select Сотрудники.ID, Сотрудники.ФИО, Sum(DATEDIFF(hour,Начало_рабочего_времени,Конец_рабочего_времени) % 24) as Часы  From Рабочее_время
                        inner join Сотрудники on Сотрудники.ID=Рабочее_время.ID_удостоверения
                        Where Начало_рабочего_времени between '" + stDate.ToString("yyyyMMdd") + "' and '" + enDate.ToString("yyyyMMdd") + "' GROUP BY ФИО,Сотрудники.ID";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(ReportDuty.Staff);
                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportDuty.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по рабочему времени"));

            }


            this.reportViewer1.RefreshReport();
        }

        private void ReportDutyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            dutyForm.Visible = true;
        }
    }
}
