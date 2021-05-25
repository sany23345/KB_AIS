
namespace KB_AIS
{
    partial class DutyForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DutyForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.searchByIdTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchByNameTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.completionMarkButton = new System.Windows.Forms.Button();
            this.goingWorkMarkButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.рабочееВремяЗаТекущийМесяцToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заТекущийГодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рабочееВремяЗаОпределенныйПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 19);
            this.label2.TabIndex = 17;
            this.label2.Text = "Поиск по номеру удостоверения";
            // 
            // searchByIdTextBox
            // 
            this.searchByIdTextBox.Location = new System.Drawing.Point(13, 106);
            this.searchByIdTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchByIdTextBox.Name = "searchByIdTextBox";
            this.searchByIdTextBox.Size = new System.Drawing.Size(352, 26);
            this.searchByIdTextBox.TabIndex = 16;
            this.searchByIdTextBox.TextChanged += new System.EventHandler(this.searchByIdTextBox_TextChanged);
            this.searchByIdTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsDigit_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Поиск по фамилии сотрудника";
            // 
            // searchByNameTextBox
            // 
            this.searchByNameTextBox.Location = new System.Drawing.Point(13, 48);
            this.searchByNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchByNameTextBox.Name = "searchByNameTextBox";
            this.searchByNameTextBox.Size = new System.Drawing.Size(352, 26);
            this.searchByNameTextBox.TabIndex = 14;
            this.searchByNameTextBox.TextChanged += new System.EventHandler(this.searchByNameTextBox_TextChanged);
            this.searchByNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxIsLetter_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 145);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1124, 464);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // completionMarkButton
            // 
            this.completionMarkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.completionMarkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completionMarkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.completionMarkButton.Location = new System.Drawing.Point(387, 101);
            this.completionMarkButton.Margin = new System.Windows.Forms.Padding(4);
            this.completionMarkButton.Name = "completionMarkButton";
            this.completionMarkButton.Size = new System.Drawing.Size(346, 36);
            this.completionMarkButton.TabIndex = 19;
            this.completionMarkButton.Text = "Поставить отметку о завершении работы\r\n";
            this.completionMarkButton.UseVisualStyleBackColor = true;
            this.completionMarkButton.Click += new System.EventHandler(this.completionMarkButton_Click);
            // 
            // goingWorkMarkButton
            // 
            this.goingWorkMarkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.goingWorkMarkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goingWorkMarkButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.goingWorkMarkButton.Location = new System.Drawing.Point(387, 43);
            this.goingWorkMarkButton.Margin = new System.Windows.Forms.Padding(4);
            this.goingWorkMarkButton.Name = "goingWorkMarkButton";
            this.goingWorkMarkButton.Size = new System.Drawing.Size(346, 36);
            this.goingWorkMarkButton.TabIndex = 18;
            this.goingWorkMarkButton.Text = "Поставить отметку о выходе на работу";
            this.goingWorkMarkButton.UseVisualStyleBackColor = true;
            this.goingWorkMarkButton.Click += new System.EventHandler(this.goingWorkMarkButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1124, 25);
            this.toolStrip1.TabIndex = 21;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рабочееВремяЗаТекущийМесяцToolStripMenuItem,
            this.заТекущийГодToolStripMenuItem,
            this.рабочееВремяЗаОпределенныйПериодToolStripMenuItem});
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(61, 22);
            this.toolStripButton1.Text = "Отчеты";
            // 
            // рабочееВремяЗаТекущийМесяцToolStripMenuItem
            // 
            this.рабочееВремяЗаТекущийМесяцToolStripMenuItem.Name = "рабочееВремяЗаТекущийМесяцToolStripMenuItem";
            this.рабочееВремяЗаТекущийМесяцToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.рабочееВремяЗаТекущийМесяцToolStripMenuItem.Text = "Рабочее время за текущий месяц";
            this.рабочееВремяЗаТекущийМесяцToolStripMenuItem.Click += new System.EventHandler(this.рабочееВремяЗаТекущийМесяцToolStripMenuItem_Click);
            // 
            // заТекущийГодToolStripMenuItem
            // 
            this.заТекущийГодToolStripMenuItem.Name = "заТекущийГодToolStripMenuItem";
            this.заТекущийГодToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.заТекущийГодToolStripMenuItem.Text = "Рабочее время за текущий год";
            this.заТекущийГодToolStripMenuItem.Click += new System.EventHandler(this.заТекущийГодToolStripMenuItem_Click);
            // 
            // рабочееВремяЗаОпределенныйПериодToolStripMenuItem
            // 
            this.рабочееВремяЗаОпределенныйПериодToolStripMenuItem.Name = "рабочееВремяЗаОпределенныйПериодToolStripMenuItem";
            this.рабочееВремяЗаОпределенныйПериодToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.рабочееВремяЗаОпределенныйПериодToolStripMenuItem.Text = "Рабочее время за определенный период";
            this.рабочееВремяЗаОпределенныйПериодToolStripMenuItem.Click += new System.EventHandler(this.рабочееВремяЗаОпределенныйПериодToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripButton2.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton2.Text = "Выход";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(203, 22);
            this.toolStripButton3.Text = "Просмотр личного удостоверения";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Column1
            // 
            this.Column1.FillWeight = 60.9137F;
            this.Column1.HeaderText = "Фото";
            this.Column1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.FillWeight = 119.5432F;
            this.Column2.HeaderText = "Номер удостоверения";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.FillWeight = 119.5432F;
            this.Column3.HeaderText = "ФИО";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // DutyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1124, 609);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.completionMarkButton);
            this.Controls.Add(this.goingWorkMarkButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchByIdTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchByNameTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DutyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DutyForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DutyForm_FormClosed);
            this.Load += new System.EventHandler(this.DutyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchByIdTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchByNameTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button completionMarkButton;
        private System.Windows.Forms.Button goingWorkMarkButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem рабочееВремяЗаТекущийМесяцToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рабочееВремяЗаОпределенныйПериодToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem заТекущийГодToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}