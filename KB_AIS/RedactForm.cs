using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class RedactForm : Form
    {
        //static string connection = @"Data Source=DESKTOP-MR4F90M\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        static string connection = @"Data Source=DESKTOP-DJUDJM1\SQLEXPRESS;Initial Catalog=PP;Integrated Security=True";
        SqlConnection sqlConnection = new SqlConnection(connection);
        public Form humanRDForm;
        string image;
        DataTable data = new DataTable();
        string filePath;
        public RedactForm()
        {
            InitializeComponent();
        }

        private void RedactForm_Load(object sender, EventArgs e)
        {
            string query = @"Select Сотрудники.Табельный_номер,Сотрудники.Фамилия +' '+Сотрудники.Имя+' '+Сотрудники.Отчество as [ФИО],Сотрудники.Серия_паспорта,
                Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
						 where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            searchByNameComboBox.ValueMember = "Табельный_номер";
            searchByNameComboBox.DisplayMember = "ФИО";
            searchByNameComboBox.DataSource = dataTable;
            searchByNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            searchByNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;          
        }

        private void TextBoxIsLetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void TextBoxIsDigit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void telephoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (telephoneTextBox.Text == "8")
                    telephoneTextBox.Text = "+7";
                if (telephoneTextBox.Text == "+")
                    telephoneTextBox.Text = "+7";
                if (telephoneTextBox.Text == "7")
                    telephoneTextBox.Text = "+7";
                if (int.Parse(telephoneTextBox.Text) >= 0 && int.Parse(telephoneTextBox.Text) <= 9)
                    telephoneTextBox.Text = "+7";
                telephoneTextBox.SelectionStart = telephoneTextBox.Text.Length;
            }
            catch (Exception) { }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (searchByNameComboBox.DataSource != null)
            {
                string query = @"Select Сотрудники.Фото,Сотрудники.Табельный_номер,Сотрудники.Фамилия,Сотрудники.Имя,Сотрудники.Отчество,Сотрудники.Серия_паспорта,
                Сотрудники.Номер_паспорта,Сотрудники.Номер_телефона,Должности.Название_должности,Удостоверение.Номер_удостоверения,
                Удостоверение.Дата_выдачи,История_продления_удостоверений.Действителен_по from История_изменений_должностей
                inner join Сотрудники on Сотрудники.Табельный_номер=История_изменений_должностей.Табельный_номер_сотрудника
                inner join Должности on Должности.ID=История_изменений_должностей.ID_Должности
                inner join Удостоверение on Удостоверение.ID_изменения_должностей=История_изменений_должностей.ID
                inner join История_продления_удостоверений on История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения
                where Действителен_по = (SELECT max(Действителен_по) FROM История_продления_удостоверений 
						 where История_продления_удостоверений.Номер_удостоверения=Удостоверение.Номер_удостоверения) and Удалено=0 and Табельный_номер='" + searchByNameComboBox.SelectedValue.ToString() + "'";

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                pictureBox1.Image = Image.FromStream(new MemoryStream(Convert.FromBase64String(dataTable.Rows[0]["Фото"].ToString())));
                idPersonnelNumberTextBox.Text = dataTable.Rows[0]["Табельный_номер"].ToString();
                idNumberTextBox.Text = dataTable.Rows[0]["Номер_удостоверения"].ToString();
                surnameTextBox.Text = dataTable.Rows[0]["Фамилия"].ToString();
                nameTextBox.Text = dataTable.Rows[0]["Имя"].ToString();
                patronymicTextBox.Text = dataTable.Rows[0]["Отчество"].ToString();
                seriesPassportTextBox.Text = dataTable.Rows[0]["Серия_паспорта"].ToString();
                idPassportTextBox.Text = dataTable.Rows[0]["Номер_паспорта"].ToString();
                telephoneTextBox.Text = dataTable.Rows[0]["Номер_телефона"].ToString();
                positioncomboBox.Text = dataTable.Rows[0]["Название_должности"].ToString();
            }
        }

        private void photoButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "png files (*.png)|*.png|jpg files(*.jpg)|*.jpg|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filePath);             
            }
        }

        private void cancellationButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            humanRDForm.Visible = true;
        }

        private void RedactForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e) //событие по нажатию кнопки "Сохранить"
        {
            DialogResult dialogResult = MessageBox.Show("Вы точно уверены что хотите сохранить изменения???", "Предупреждение!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            image = Convert.ToBase64String(File.ReadAllBytes(filePath));

            if (dialogResult == DialogResult.Yes)
            {
                string query = @"Update Сотрудники set 
                    Фамилия='"+surnameTextBox.Text+"',Имя= '"+nameTextBox.Text+"', Отчество = '"+patronymicTextBox.Text+"',Серия_паспорта = '"+seriesPassportTextBox.Text+"',Номер_паспорта = '"+idPassportTextBox.Text+"',Номер_телефона = '"+telephoneTextBox.Text+"',Фото = '"+image+"'where Табельный_номер='" + searchByNameComboBox.SelectedValue.ToString() + "'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Данные изменены");
            }
        }
    }
}
