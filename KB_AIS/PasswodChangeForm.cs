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
using System.Security.Cryptography;

namespace KB_AIS
{
    public partial class PasswodChangeForm : Form
    {
        // static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public  Form backForm;
        public string id;
        public string pass;
        public PasswodChangeForm()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var md5 = MD5.Create();
            var hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(oldPasswordTextBox.Text));
            string password = Convert.ToBase64String(hashPassword);

            if (pass== password)
            {
                if (newPasswordTextBox.Text==confirmationTextBox.Text)
                {
                   
                    hashPassword = md5.ComputeHash(Encoding.UTF8.GetBytes(confirmationTextBox.Text));
                     password = Convert.ToBase64String(hashPassword);

                    string query = @"  Update Сотрудники set Пароль = '"+password+"' where ID = '" + id + "'";
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Пароль изменен.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают");
                }
            }
            else
            {
                MessageBox.Show("Старый пароль введен не верно");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            backForm.Enabled = true;
            this.Visible = false;
        }

        private void PasswodChangeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            backForm.Enabled = true;
        }
    }
}
