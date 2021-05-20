
namespace KB_AIS
{
    partial class RedactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedactForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cancellationButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.searchNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchByIdTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateOfIssueTimePicker = new System.Windows.Forms.DateTimePicker();
            this.expirationDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.seriesPassportTextBox = new System.Windows.Forms.TextBox();
            this.idPassportTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.positioncomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(595, 451);
            this.dataGridView1.TabIndex = 128;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cancellationButton
            // 
            this.cancellationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.cancellationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancellationButton.Location = new System.Drawing.Point(602, 409);
            this.cancellationButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancellationButton.Name = "cancellationButton";
            this.cancellationButton.Size = new System.Drawing.Size(177, 34);
            this.cancellationButton.TabIndex = 120;
            this.cancellationButton.Text = "Отмена";
            this.cancellationButton.UseVisualStyleBackColor = true;
            this.cancellationButton.Click += new System.EventHandler(this.cancellationButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(983, 409);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(177, 34);
            this.saveButton.TabIndex = 119;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 222);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 19);
            this.label14.TabIndex = 118;
            this.label14.Text = "Название должности";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 188);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 19);
            this.label17.TabIndex = 117;
            this.label17.Text = "Контактный телефон";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 154);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 19);
            this.label18.TabIndex = 116;
            this.label18.Text = "Номер паспорта";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 120);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 19);
            this.label19.TabIndex = 115;
            this.label19.Text = "Серия паспорта";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 18);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 19);
            this.label20.TabIndex = 114;
            this.label20.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 132;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 134;
            this.label2.Text = "Отчество";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(603, 45);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(140, 19);
            this.label21.TabIndex = 136;
            this.label21.Text = "Поиск по фамилии:";
            // 
            // searchNameTextBox
            // 
            this.searchNameTextBox.Location = new System.Drawing.Point(839, 42);
            this.searchNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchNameTextBox.Name = "searchNameTextBox";
            this.searchNameTextBox.Size = new System.Drawing.Size(324, 26);
            this.searchNameTextBox.TabIndex = 135;
            this.searchNameTextBox.TextChanged += new System.EventHandler(this.searchNameTextBox_TextChanged);
            this.searchNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(603, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 19);
            this.label3.TabIndex = 140;
            this.label3.Text = "Поиск по номеру удостоверения:";
            // 
            // searchByIdTextBox
            // 
            this.searchByIdTextBox.Location = new System.Drawing.Point(839, 8);
            this.searchByIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchByIdTextBox.Name = "searchByIdTextBox";
            this.searchByIdTextBox.Size = new System.Drawing.Size(324, 26);
            this.searchByIdTextBox.TabIndex = 139;
            this.searchByIdTextBox.TextChanged += new System.EventHandler(this.searchByIdTextBox_TextChanged);
            this.searchByIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsDigit_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateOfIssueTimePicker);
            this.groupBox1.Controls.Add(this.expirationDateTimePicker);
            this.groupBox1.Controls.Add(this.surnameTextBox);
            this.groupBox1.Controls.Add(this.patronymicTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.seriesPassportTextBox);
            this.groupBox1.Controls.Add(this.idPassportTextBox);
            this.groupBox1.Controls.Add(this.telephoneTextBox);
            this.groupBox1.Controls.Add(this.positioncomboBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(602, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 327);
            this.groupBox1.TabIndex = 141;
            this.groupBox1.TabStop = false;
            // 
            // dateOfIssueTimePicker
            // 
            this.dateOfIssueTimePicker.Location = new System.Drawing.Point(180, 257);
            this.dateOfIssueTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateOfIssueTimePicker.Name = "dateOfIssueTimePicker";
            this.dateOfIssueTimePicker.Size = new System.Drawing.Size(370, 26);
            this.dateOfIssueTimePicker.TabIndex = 147;
            // 
            // expirationDateTimePicker
            // 
            this.expirationDateTimePicker.Location = new System.Drawing.Point(180, 291);
            this.expirationDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.expirationDateTimePicker.Name = "expirationDateTimePicker";
            this.expirationDateTimePicker.Size = new System.Drawing.Size(370, 26);
            this.expirationDateTimePicker.TabIndex = 146;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(180, 15);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(370, 26);
            this.surnameTextBox.TabIndex = 139;
            this.surnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Location = new System.Drawing.Point(181, 83);
            this.patronymicTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(370, 26);
            this.patronymicTextBox.TabIndex = 140;
            this.patronymicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(180, 49);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(370, 26);
            this.nameTextBox.TabIndex = 141;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // seriesPassportTextBox
            // 
            this.seriesPassportTextBox.Location = new System.Drawing.Point(180, 117);
            this.seriesPassportTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.seriesPassportTextBox.MaxLength = 4;
            this.seriesPassportTextBox.Name = "seriesPassportTextBox";
            this.seriesPassportTextBox.Size = new System.Drawing.Size(370, 26);
            this.seriesPassportTextBox.TabIndex = 142;
            this.seriesPassportTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsDigit_KeyPress);
            // 
            // idPassportTextBox
            // 
            this.idPassportTextBox.Location = new System.Drawing.Point(180, 151);
            this.idPassportTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.idPassportTextBox.MaxLength = 6;
            this.idPassportTextBox.Name = "idPassportTextBox";
            this.idPassportTextBox.Size = new System.Drawing.Size(370, 26);
            this.idPassportTextBox.TabIndex = 143;
            this.idPassportTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsDigit_KeyPress);
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Location = new System.Drawing.Point(180, 185);
            this.telephoneTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.telephoneTextBox.MaxLength = 12;
            this.telephoneTextBox.Name = "telephoneTextBox";
            this.telephoneTextBox.Size = new System.Drawing.Size(370, 26);
            this.telephoneTextBox.TabIndex = 144;
            this.telephoneTextBox.TextChanged += new System.EventHandler(this.telephoneTextBox_TextChanged);
            this.telephoneTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsDigit_KeyPress);
            // 
            // positioncomboBox
            // 
            this.positioncomboBox.DisplayMember = "ID";
            this.positioncomboBox.FormattingEnabled = true;
            this.positioncomboBox.Location = new System.Drawing.Point(180, 219);
            this.positioncomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.positioncomboBox.Name = "positioncomboBox";
            this.positioncomboBox.Size = new System.Drawing.Size(370, 27);
            this.positioncomboBox.TabIndex = 145;
            this.positioncomboBox.ValueMember = "ID";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 298);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 19);
            this.label6.TabIndex = 137;
            this.label6.Text = "Дата окончания уд-ния";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 264);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 19);
            this.label8.TabIndex = 138;
            this.label8.Text = "Дата выдачи уд-ния";
            // 
            // RedactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1173, 451);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchByIdTextBox);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.searchNameTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cancellationButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RedactForm";
            this.Text = "RedactForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RedactForm_FormClosed);
            this.Load += new System.EventHandler(this.RedactForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancellationButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox searchNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchByIdTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox seriesPassportTextBox;
        private System.Windows.Forms.TextBox idPassportTextBox;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.ComboBox positioncomboBox;
        private System.Windows.Forms.DateTimePicker dateOfIssueTimePicker;
        private System.Windows.Forms.DateTimePicker expirationDateTimePicker;
    }
}