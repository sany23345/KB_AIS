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
        public string markreport,idCertificate;
        public Form dutyForm;

        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
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

                string queryString = @"Select  Удостоверение.Номер_удостоверения as ID,Сотрудники.Фамилия+' '+ Сотрудники.Имя+' '+ Сотрудники.Отчество as ФИО,Sum(DATEDIFF(hour,Начало_рабочего_времени,Конец_рабочего_времени) % 24) as Часы from Рабочее_время
                        inner join Удостоверение on Удостоверение.Номер_удостоверения=Рабочее_время.Номер_удостоверения
                        inner join История_изменений_должностей on История_изменений_должностей.ID=Удостоверение.ID_изменения_должностей
                        inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                        Where Начало_рабочего_времени between '" + startDate.ToString("yyyyMMdd")+ "' and '" + endDate.ToString("yyyyMMdd") + "' and Истекло=0" +
                        "Group by Удостоверение.Номер_удостоверения,Сотрудники.Фамилия, Сотрудники.Имя,Сотрудники.Отчество";

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

                string queryString = @"Select  Удостоверение.Номер_удостоверения as ID,Сотрудники.Фамилия+' '+ Сотрудники.Имя+' '+ Сотрудники.Отчество as ФИО,Sum(DATEDIFF(hour,Начало_рабочего_времени,Конец_рабочего_времени) % 24) as Часы from Рабочее_время
                        inner join Удостоверение on Удостоверение.Номер_удостоверения=Рабочее_время.Номер_удостоверения
                        inner join История_изменений_должностей on История_изменений_должностей.ID=Удостоверение.ID_изменения_должностей
                        inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                        Where Начало_рабочего_времени between '" + startDate.ToString("yyyy0101") + "' and '" + endDate.ToString("yyyy0101") + "' and Истекло=0" +
                        " Group by Удостоверение.Номер_удостоверения,Сотрудники.Фамилия, Сотрудники.Имя,Сотрудники.Отчество";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(ReportDuty.Staff);
                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportDuty.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по рабочему времени"));

            }
            else if (markreport == "3")
            {
                string queryString = @"Select  Удостоверение.Номер_удостоверения as ID,Сотрудники.Фамилия+' '+ Сотрудники.Имя+' '+ Сотрудники.Отчество as ФИО,Sum(DATEDIFF(hour,Начало_рабочего_времени,Конец_рабочего_времени) % 24) as Часы from Рабочее_время
                        inner join Удостоверение on Удостоверение.Номер_удостоверения=Рабочее_время.Номер_удостоверения
                        inner join История_изменений_должностей on История_изменений_должностей.ID=Удостоверение.ID_изменения_должностей
                        inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                        Where Начало_рабочего_времени between '" + stDate.ToString("yyyyMMdd 06:00") + "' and '" + enDate.ToString("yyyyMMdd 23:00")+ "' and Истекло=0" +
                        " Group by Удостоверение.Номер_удостоверения,Сотрудники.Фамилия, Сотрудники.Имя,Сотрудники.Отчество";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(ReportDuty.Staff);
                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportDuty.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по рабочему времени"));

            }
            else if (markreport == "4")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);

                string queryString = @"Select  Удостоверение.Номер_удостоверения as ID,Сотрудники.Фамилия+' '+ Сотрудники.Имя+' '+ Сотрудники.Отчество as ФИО,Sum(DATEDIFF(hour,Начало_рабочего_времени,Конец_рабочего_времени) % 24) as Часы from Рабочее_время
                        inner join Удостоверение on Удостоверение.Номер_удостоверения=Рабочее_время.Номер_удостоверения
                        inner join История_изменений_должностей on История_изменений_должностей.ID=Удостоверение.ID_изменения_должностей
                        inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                        Where Начало_рабочего_времени between '" + startDate.ToString("yyyyMMdd") + "' and '" + endDate.ToString("yyyyMMdd") + "' and Истекло=0 and Удостоверение.Номер_удостоверения='"+ idCertificate + "'" +
                        "Group by Удостоверение.Номер_удостоверения,Сотрудники.Фамилия, Сотрудники.Имя,Сотрудники.Отчество";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(ReportDuty.Staff);
                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\source\repos\KB_AIS\KB_AIS\ReportDuty.rdlc";
                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
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
