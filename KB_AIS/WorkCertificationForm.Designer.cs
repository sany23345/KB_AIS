
namespace KB_AIS
{
    partial class WorkCertificationForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.redactPositionButton = new System.Windows.Forms.Button();
            this.positioncomboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dateOfIssueTimePicker = new System.Windows.Forms.DateTimePicker();
            this.expirationDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(638, 297);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // numberTextBox
            // 
            this.numberTextBox.Location = new System.Drawing.Point(813, 44);
            this.numberTextBox.Name = "numberTextBox";
            this.numberTextBox.ReadOnly = true;
            this.numberTextBox.Size = new System.Drawing.Size(322, 26);
            this.numberTextBox.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(645, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "Табельный номер";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(813, 16);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ReadOnly = true;
            this.nameTextBox.Size = new System.Drawing.Size(322, 26);
            this.nameTextBox.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 19);
            this.label1.TabIndex = 24;
            this.label1.Text = "ФИО";
            // 
            // backButton
            // 
            this.backButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.backButton.Location = new System.Drawing.Point(646, 248);
            this.backButton.Margin = new System.Windows.Forms.Padding(4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(215, 36);
            this.backButton.TabIndex = 28;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // redactPositionButton
            // 
            this.redactPositionButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.redactPositionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.redactPositionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.redactPositionButton.Location = new System.Drawing.Point(920, 248);
            this.redactPositionButton.Margin = new System.Windows.Forms.Padding(4);
            this.redactPositionButton.Name = "redactPositionButton";
            this.redactPositionButton.Size = new System.Drawing.Size(215, 36);
            this.redactPositionButton.TabIndex = 29;
            this.redactPositionButton.Text = "Изменить должность";
            this.redactPositionButton.UseVisualStyleBackColor = true;
            this.redactPositionButton.Click += new System.EventHandler(this.redactPositionButton_Click);
            // 
            // positioncomboBox
            // 
            this.positioncomboBox.DisplayMember = "ID";
            this.positioncomboBox.FormattingEnabled = true;
            this.positioncomboBox.Location = new System.Drawing.Point(813, 88);
            this.positioncomboBox.Margin = new System.Windows.Forms.Padding(4);
            this.positioncomboBox.Name = "positioncomboBox";
            this.positioncomboBox.Size = new System.Drawing.Size(322, 27);
            this.positioncomboBox.TabIndex = 80;
            this.positioncomboBox.ValueMember = "ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(646, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 19);
            this.label5.TabIndex = 79;
            this.label5.Text = "Название должности";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(645, 138);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 19);
            this.label16.TabIndex = 88;
            this.label16.Text = "Дата выдачи";
            // 
            // dateOfIssueTimePicker
            // 
            this.dateOfIssueTimePicker.Location = new System.Drawing.Point(813, 132);
            this.dateOfIssueTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.dateOfIssueTimePicker.Name = "dateOfIssueTimePicker";
            this.dateOfIssueTimePicker.Size = new System.Drawing.Size(322, 26);
            this.dateOfIssueTimePicker.TabIndex = 86;
            // 
            // expirationDateTimePicker
            // 
            this.expirationDateTimePicker.Location = new System.Drawing.Point(813, 166);
            this.expirationDateTimePicker.Margin = new System.Windows.Forms.Padding(4);
            this.expirationDateTimePicker.Name = "expirationDateTimePicker";
            this.expirationDateTimePicker.Size = new System.Drawing.Size(322, 26);
            this.expirationDateTimePicker.TabIndex = 85;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(645, 172);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(116, 19);
            this.label15.TabIndex = 87;
            this.label15.Text = "Дата окончания";
            // 
            // WorkCertificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1148, 297);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dateOfIssueTimePicker);
            this.Controls.Add(this.expirationDateTimePicker);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.positioncomboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.redactPositionButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.numberTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "WorkCertificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WorkCertificationForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkCertificationForm_FormClosed);
            this.Load += new System.EventHandler(this.WorkCertificationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button redactPositionButton;
        private System.Windows.Forms.ComboBox positioncomboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateOfIssueTimePicker;
        private System.Windows.Forms.DateTimePicker expirationDateTimePicker;
        private System.Windows.Forms.Label label15;
    }
}