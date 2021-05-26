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
    public partial class WorkCertificationForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form HRDForm;
        string idCertificate,position;
        public WorkCertificationForm()
        {
            InitializeComponent();
        }

        public void UpdateTable()
        {
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Удостоверение.Номер_удостоверения, Должности.Название_должности
                        from История_изменений_должностей
                        inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                        inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                        inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                        inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                        where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
                        where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0 and Истекло=0";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void WorkCertificationForm_Load(object sender, EventArgs e)
        {
            UpdateTable();

           string query = @"Select * From Должности";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            DataTable dataTablePosition = new DataTable();
            sqlDataAdapter.Fill(dataTablePosition);

            positioncomboBox.DataSource = dataTablePosition;
            positioncomboBox.ValueMember = "ID";
            positioncomboBox.DisplayMember = "Название_должности";

            expirationDateTimePicker.MinDate = DateTime.Now;
            expirationDateTimePicker.Value = DateTime.Now.AddYears(1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                numberTextBox.Text = row.Cells[0].Value.ToString();
                nameTextBox.Text = row.Cells[1].Value.ToString();
                positioncomboBox.Text = row.Cells[3].Value.ToString();
                position = row.Cells[3].Value.ToString();
                idCertificate=row.Cells[2].Value.ToString();
            }
        }

        private void redactPositionButton_Click(object sender, EventArgs e)
        {
            if (position != positioncomboBox.Text)
            {
                string query = @"Update Удостоверение set Истекло = 1 where Номер_удостоверения ='" + idCertificate + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                query = @"Insert into История_изменений_должностей values ('" + numberTextBox.Text + "','" + positioncomboBox.SelectedValue.ToString() + "','" + DateTime.Now.ToString("yyyy.MM.dd") + "')";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                query = @"Select Max(ID) from История_изменений_должностей";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTableHistory = new DataTable();
                sqlDataAdapter.Fill(dataTableHistory);

                int idHistory = int.Parse(dataTableHistory.Rows[0][0].ToString());

                query = @"Insert into Удостоверение values('" + dateOfIssueTimePicker.Value.ToString("yyyy.MM.dd") + "','" + idHistory + "','0');";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                query = @"Select MAX(Номер_удостоверения)from Удостоверение";
                sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTableCertification = new DataTable();
                sqlDataAdapter.Fill(dataTableCertification);

                int idCertification = int.Parse(dataTableCertification.Rows[0][0].ToString());


                query = @"insert into История_продления_удостоверений values ('" + expirationDateTimePicker.Value.ToString("yyyy.MM.dd") + "','" + idCertification + "')";

                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                MessageBox.Show("Должность изменена!");

                PrintOutSertificateForm printOutSertificateForm = new PrintOutSertificateForm();
                printOutSertificateForm.id = idCertification.ToString();
                printOutSertificateForm.humanRDForm = this;
                printOutSertificateForm.Visible = true;
                this.Visible = false;
                UpdateTable();
            }
            else
            {
                MessageBox.Show("Измените должность");
            }

        }

        private void WorkCertificationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HRDForm.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            HRDForm.Visible = true;
        }
    }
}
