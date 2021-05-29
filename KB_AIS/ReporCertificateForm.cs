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
    public partial class ReporCertificateForm : Form
    {        
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public string markreport;
        public Form humanRDForm;
        DateTime dateTime1 = DateTime.Now;
        public DateTime stDate, enDate;

        public ReporCertificateForm()
        {
            InitializeComponent();
        }

        private void ReporCertificateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }

        private void ReporCertificateForm_Load(object sender, EventArgs e)
        {
            var startDate = dateTime1;
            var endDate = dateTime1;

            if (markreport == "1")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);

                string queryString = @"Select Удостоверение.Номер_удостоверения as ID, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],
                    Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по as Дата_истечения_срока_действия from История_изменений_должностей
                    inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                    where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and 
                    Удалено=0 and Истекло=0 and Дата_выдачи between '" + startDate.ToString("yyyyMMdd") + "' and '" + endDate.ToString("yyyyMMdd") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(DataReportCertificate.DataTable1);

                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по выданным удостоверениям"));
            }
            else if (markreport == "2")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddYears(1);

                string queryString = @"Select Удостоверение.Номер_удостоверения as ID, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],
                    Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по as Дата_истечения_срока_действия from История_изменений_должностей
                    inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                     where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and 
                    Удалено=0 and Истекло=0 and Дата_выдачи between '" + startDate.ToString("yyyy0101") + "' and '" + endDate.ToString("yyyy0101") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(DataReportCertificate.DataTable1);

                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("01.01.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("01.01.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по выданным удостоверениям"));
            }
            else if (markreport == "3")
            {
                string queryString = @"Select Удостоверение.Номер_удостоверения as ID, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],
                    Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по as Дата_истечения_срока_действия from История_изменений_должностей
                    inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                    where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and 
			        Удалено=0 and Истекло=0 and Дата_выдачи between '" + stDate.ToString("yyyyMMdd") + "' and '" + enDate.ToString("yyyyMMdd") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(DataReportCertificate.DataTable1);

                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по выданным удостоверениям"));
            }
            if (markreport == "4")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddMonths(1).AddDays(-1);

                string queryString = @"Select Удостоверение.Номер_удостоверения as ID, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],
                    Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по as Дата_истечения_срока_действия from История_изменений_должностей
                    inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                    where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and 
			        Удалено=0 and Истекло=0 and  Day( Действителен_по) < Day(GETDATE()) and Year( Действителен_по)=Year(GETDATE())";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(DataReportCertificate.DataTable1);

                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            }
            else if (markreport == "5")
            {
                startDate = new DateTime(dateTime1.Year, dateTime1.Month, 1);
                endDate = startDate.AddYears(1);

                string queryString = @"Select Удостоверение.Номер_удостоверения as ID, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],
                    Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по as Дата_истечения_срока_действия from История_изменений_должностей
                    inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                    where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and 
			        Удалено=0 and Истекло=0 and Year( Действителен_по)=Year(GETDATE())";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(DataReportCertificate.DataTable1);

                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", startDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", endDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            }
            else if (markreport == "6")
            {
                string queryString = @"Select Удостоверение.Номер_удостоверения as ID, Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],
                    Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по as Дата_истечения_срока_действия from История_изменений_должностей
                    inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                    inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                    inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                    inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                    where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and 
			        Удалено=0 and Истекло=0 and Действителен_по between '" + stDate.ToString("yyyyMMdd") + "' and '" + enDate.ToString("yyyyMMdd") + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
                adapter.Fill(DataReportCertificate.DataTable1);

                //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\ReportSOC.rdlc";

                reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            }
            //else if (markreport == "7")
            //{
            //    //            string queryString = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Сотрудники.Серия_паспорта,
            //    //            Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения
            //    //from История_изменений_должностей
            //    //            inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
            //    //            inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
            //    //            inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
            //    //            inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
            //    //            where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
            //    //		 where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0 and Истекло=0";

            //    //            SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
            //    //            adapter.Fill(FullData.DataTable1);

            //    //            reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\FullDataReport.rdlc";

            //    //reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
            //    //reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
            //    //reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            //}
            this.reportViewer1.RefreshReport();
        }
    }
}
