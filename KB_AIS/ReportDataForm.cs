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
    public partial class ReportDataForm : Form
    {
        // static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form humanRDForm;

        public ReportDataForm()
        {
            InitializeComponent();
        }

        private void ReportDataForm_Load(object sender, EventArgs e)
        {
            string queryString = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Сотрудники.Серия_паспорта,
                            Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения
                            from История_изменений_должностей
                            inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                            inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                            inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                            inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                            where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                		    where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0 and Истекло=0";

            SqlDataAdapter adapter = new SqlDataAdapter(queryString, sqlConnection);
            adapter.Fill(FullDataSet.DataTable1);

            //reportViewer1.LocalReport.ReportPath = @"C:\Users\saha3\OneDrive\Рабочий стол\KB_AIS\KB_AIS\FullDataReport.rdlc";

            //reportViewer1.LocalReport.SetParameters(new ReportParameter("StartDate", stDate.ToString("dd.MM.yyyy")));
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("EndDate", enDate.ToString("dd.MM.yyyy")));
            //reportViewer1.LocalReport.SetParameters(new ReportParameter("NameReport", "по истекшим удостоверениям"));
            this.reportViewer1.RefreshReport();
        }

        private void ReportDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }
    }
}
