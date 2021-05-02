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
