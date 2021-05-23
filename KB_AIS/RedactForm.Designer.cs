
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.idNumberTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.idPersonnelNumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.patronymicTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.seriesPassportTextBox = new System.Windows.Forms.TextBox();
            this.idPassportTextBox = new System.Windows.Forms.TextBox();
            this.telephoneTextBox = new System.Windows.Forms.TextBox();
            this.positioncomboBox = new System.Windows.Forms.ComboBox();
            this.searchByNameComboBox = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.photoButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancellationButton
            // 
            this.cancellationButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.cancellationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancellationButton.Location = new System.Drawing.Point(13, 241);
            this.cancellationButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancellationButton.Name = "cancellationButton";
            this.cancellationButton.Size = new System.Drawing.Size(196, 34);
            this.cancellationButton.TabIndex = 120;
            this.cancellationButton.Text = "Отмена";
            this.cancellationButton.UseVisualStyleBackColor = true;
            this.cancellationButton.Click += new System.EventHandler(this.cancellationButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(12, 283);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(197, 34);
            this.saveButton.TabIndex = 119;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 290);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 19);
            this.label14.TabIndex = 118;
            this.label14.Text = "Название должности";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 256);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(152, 19);
            this.label17.TabIndex = 117;
            this.label17.Text = "Контактный телефон";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 222);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 19);
            this.label18.TabIndex = 116;
            this.label18.Text = "Номер паспорта";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 188);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 19);
            this.label19.TabIndex = 115;
            this.label19.Text = "Серия паспорта";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 86);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 19);
            this.label20.TabIndex = 114;
            this.label20.Text = "Фамилия";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 120);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 132;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 134;
            this.label2.Text = "Отчество";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(223, 15);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(137, 19);
            this.label21.TabIndex = 136;
            this.label21.Text = "Поиск по фамилии";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.idNumberTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.idPersonnelNumberTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.surnameTextBox);
            this.groupBox1.Controls.Add(this.patronymicTextBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.seriesPassportTextBox);
            this.groupBox1.Controls.Add(this.idPassportTextBox);
            this.groupBox1.Controls.Add(this.telephoneTextBox);
            this.groupBox1.Controls.Add(this.positioncomboBox);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(216, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 322);
            this.groupBox1.TabIndex = 141;
            this.groupBox1.TabStop = false;
            // 
            // idNumberTextBox
            // 
            this.idNumberTextBox.Location = new System.Drawing.Point(180, 49);
            this.idNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.idNumberTextBox.Name = "idNumberTextBox";
            this.idNumberTextBox.ReadOnly = true;
            this.idNumberTextBox.Size = new System.Drawing.Size(370, 26);
            this.idNumberTextBox.TabIndex = 151;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 19);
            this.label4.TabIndex = 150;
            this.label4.Text = "Номер удостоверения";
            // 
            // idPersonnelNumberTextBox
            // 
            this.idPersonnelNumberTextBox.Location = new System.Drawing.Point(180, 15);
            this.idPersonnelNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.idPersonnelNumberTextBox.Name = "idPersonnelNumberTextBox";
            this.idPersonnelNumberTextBox.ReadOnly = true;
            this.idPersonnelNumberTextBox.Size = new System.Drawing.Size(370, 26);
            this.idPersonnelNumberTextBox.TabIndex = 149;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 19);
            this.label3.TabIndex = 148;
            this.label3.Text = "Табельный номер";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(180, 83);
            this.surnameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(370, 26);
            this.surnameTextBox.TabIndex = 139;
            this.surnameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // patronymicTextBox
            // 
            this.patronymicTextBox.Location = new System.Drawing.Point(181, 151);
            this.patronymicTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.patronymicTextBox.Name = "patronymicTextBox";
            this.patronymicTextBox.Size = new System.Drawing.Size(370, 26);
            this.patronymicTextBox.TabIndex = 140;
            this.patronymicTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(180, 117);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(370, 26);
            this.nameTextBox.TabIndex = 141;
            this.nameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // seriesPassportTextBox
            // 
            this.seriesPassportTextBox.Location = new System.Drawing.Point(180, 185);
            this.seriesPassportTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.seriesPassportTextBox.MaxLength = 4;
            this.seriesPassportTextBox.Name = "seriesPassportTextBox";
            this.seriesPassportTextBox.Size = new System.Drawing.Size(370, 26);
            this.seriesPassportTextBox.TabIndex = 142;
            this.seriesPassportTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsDigit_KeyPress);
            // 
            // idPassportTextBox
            // 
            this.idPassportTextBox.Location = new System.Drawing.Point(180, 219);
            this.idPassportTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.idPassportTextBox.MaxLength = 6;
            this.idPassportTextBox.Name = "idPassportTextBox";
            this.idPassportTextBox.Size = new System.Drawing.Size(370, 26);
            this.idPassportTextBox.TabIndex = 143;
            this.idPassportTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsDigit_KeyPress);
            // 
            // telephoneTextBox
            // 
            this.telephoneTextBox.Location = new System.Drawing.Point(180, 253);
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
            this.positioncomboBox.Location = new System.Drawing.Point(180, 287);
            this.positioncomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.positioncomboBox.Name = "positioncomboBox";
            this.positioncomboBox.Size = new System.Drawing.Size(370, 27);
            this.positioncomboBox.TabIndex = 145;
            this.positioncomboBox.ValueMember = "ID";
            // 
            // searchByNameComboBox
            // 
            this.searchByNameComboBox.FormattingEnabled = true;
            this.searchByNameComboBox.Location = new System.Drawing.Point(396, 12);
            this.searchByNameComboBox.Name = "searchByNameComboBox";
            this.searchByNameComboBox.Size = new System.Drawing.Size(370, 27);
            this.searchByNameComboBox.TabIndex = 142;
            this.searchByNameComboBox.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 143;
            this.pictureBox1.TabStop = false;
            // 
            // photoButton
            // 
            this.photoButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.photoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.photoButton.Location = new System.Drawing.Point(13, 199);
            this.photoButton.Margin = new System.Windows.Forms.Padding(4);
            this.photoButton.Name = "photoButton";
            this.photoButton.Size = new System.Drawing.Size(196, 34);
            this.photoButton.TabIndex = 144;
            this.photoButton.Text = "Изменить фото";
            this.photoButton.UseVisualStyleBackColor = true;
            this.photoButton.Click += new System.EventHandler(this.photoButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // RedactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(788, 373);
            this.Controls.Add(this.photoButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.searchByNameComboBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cancellationButton);
            this.Controls.Add(this.saveButton);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RedactForm";
            this.Text = "RedactForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RedactForm_FormClosed);
            this.Load += new System.EventHandler(this.RedactForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.TextBox patronymicTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox seriesPassportTextBox;
        private System.Windows.Forms.TextBox idPassportTextBox;
        private System.Windows.Forms.TextBox telephoneTextBox;
        private System.Windows.Forms.ComboBox positioncomboBox;
        private System.Windows.Forms.ComboBox searchByNameComboBox;
        private System.Windows.Forms.TextBox idNumberTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox idPersonnelNumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button photoButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}