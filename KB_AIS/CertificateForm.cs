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
    public partial class CertificateForm : Form
    {
        // static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);

        public Form avtorisationForm;
        public string id,FIO,position,dateOfIssue,expirationDate;

        private void CertificateForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            avtorisationForm.Visible = true;
        }

        private void completionMarkButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите оставить отметку о завершении работы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"select * from Рабочее_время
                            where ID_удостоверения='" + id + "' and Конец_рабочего_времени BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "' AND '" + DateTime.Now.AddDays(1).ToString("yyyyMMdd") + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    query = @"UPDATE Рабочее_время set Конец_рабочего_времени='" + DateTime.Now.ToString("yyyyMMdd HH:mm:00") + "' where ID_удостоверения='" + id + "'";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Отметка принята, дата и время окончания работы " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:00"));
                }
                else if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Отметка уже была принята сегодня");
                }
            }
        }

        private void goingWorkMarkButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите оставить отметку о начале работы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                string query = @"select * from Рабочее_время
                            where ID_удостоверения='" + id + "' and Начало_рабочего_времени BETWEEN '" + DateTime.Now.ToString("yyyyMMdd") + "' AND '" + DateTime.Now.AddDays(1).ToString("yyyyMMdd") + "'";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    MessageBox.Show("Отметка уже была принята сегодня");
                }
                else if (dataTable.Rows.Count == 0)
                {
                    query = @" Insert into Рабочее_время values('" + id + "','" + DateTime.Now.ToString("yyyyMMdd HH:mm:00") + "','')";
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Отметка принята, дата и время выхода " + DateTime.Now.ToString("yyyy.MM.dd HH:mm:00"));
                }
            }
        }

        private void CertificateForm_Load(object sender, EventArgs e)
        {
            numberTextBox.Text = id;
            fioTextBox.Text = FIO;
            positionTextBox.Text = position;
            dataOfIssueTextBox.Text =DateTime.Parse(dateOfIssue).ToString("dd.MM.yyyy г.");
            expirationDateTextBox.Text = DateTime.Parse(expirationDate).ToString("dd.MM.yyyy г.");
        }

        public CertificateForm()
        {
            InitializeComponent();
        }
    }
}
