using System;
using System.Windows.Forms;

namespace KB_AIS
{
    public partial class PeriodForm : Form
    {
        public Form humanRDForm;
        public string mark;
        public PeriodForm()
        {
            InitializeComponent();
        }

        private void PeriodForm_Load(object sender, EventArgs e)
        {
            dateTimePicker2.MaxDate = DateTime.Now;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            humanRDForm.Visible = true;
        }

        private void proceedButton_Click(object sender, EventArgs e)
        {
            if (mark=="1")
            {
                ReportForm reportForm = new ReportForm();
                reportForm.humanRDForm = this;
                reportForm.stDate = dateTimePicker1.Value;
                reportForm.enDate = dateTimePicker2.Value;
                reportForm.markreport = "3";
                reportForm.Visible = true;
                this.Visible = false;
            }
            else if (mark == "2")
            {
                ReportForm reportForm = new ReportForm();
                reportForm.humanRDForm = this;
                reportForm.stDate = dateTimePicker1.Value;
                reportForm.enDate = dateTimePicker2.Value;
                reportForm.markreport = "6";
                reportForm.Visible = true;
                this.Visible = false;
            }
            else if (mark == "3")
            {
                ReportDutyForm reportForm = new ReportDutyForm();
                reportForm.dutyForm = this;
                reportForm.stDate = dateTimePicker1.Value;
                reportForm.enDate = dateTimePicker2.Value;
                reportForm.markreport = "3";
                reportForm.Visible = true;
                this.Visible = false;
            }
        }

        private void PeriodForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            humanRDForm.Visible = true;
        }
    }
}
