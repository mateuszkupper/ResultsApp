using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Lecturer
{
    public partial class frmAddMCQ : Form
    {
        private int moduleID;
        private Connection connection = new Connection();

        public int ModuleID
        {
            get
            {
                return moduleID;
            }

            set
            {
                moduleID = value;
            }
        }

        public frmAddMCQ()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFilled() && isValid())
            {
                int NoOfQs = Int32.Parse(txtNoOfQs.Text);
                int MarksPerQ = Int32.Parse(txtMarksPerQuestion.Text);
                int MarksAvailable = Int32.Parse(txtMarksAvailable.Text);
                Boolean NegativeMarking = chbNegativeMarking.Checked;

                frmMain.MCQRow["ModuleID"] = ModuleID;
                frmMain.MCQRow["NoOfQs"] = NoOfQs;
                frmMain.MCQRow["MarksPerQ"] = MarksPerQ;
                frmMain.MCQRow["NegativeMarking"] = NegativeMarking;
                frmMain.MCQRow["MarksAvailable"] = MarksAvailable;

                this.Close();
            }
            else if(!isFilled())
            {
                MessageBox.Show("Fill in all fields!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if(!isValid())
            {
                MessageBox.Show("All values need to be numbers!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("All values need to be numbers! \n Fill in all fields!", "Validation",
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isFilled()
        {
            return (txtNoOfQs.Text != "" &&
                txtMarksPerQuestion.Text != "" &&
                txtMarksAvailable.Text != "") ? true : false;
        }

        private bool isValid()
        {
            int x = 0;
            return (Int32.TryParse(txtNoOfQs.Text, out x) &&
                Int32.TryParse(txtMarksPerQuestion.Text, out x) &&
                Int32.TryParse(txtMarksAvailable.Text, out x)) ? true : false;
        }
    }
}
