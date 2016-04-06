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
    public partial class frmAddOther : Form
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

        public frmAddOther()
        {
            InitializeComponent();
        }

        private void frmAddOther_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFilled() && isValid())
            {
                String Type = cmbType.Text;
                int MarksAvailable = Int32.Parse(txtMarksAvailable.Text);

                if (Type == "End of semester exam")
                {
                    Type = "EndOfSemester";
                }

                frmMain.OtherRow["ModuleID"] = ModuleID;
                frmMain.OtherRow["Type"] = Type;
                frmMain.OtherRow["Marks Available (0%-100%)"] = MarksAvailable;
                this.Close();
            }
            else if (!isFilled())
            {
                MessageBox.Show("Fill in all fields!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!isValid())
            {
                MessageBox.Show("Marks available needs to be a number!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Marks available need to be a number! \n Fill in all fields!", "Validation",
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain.OtherRow["ModuleID"] = 0;
            this.Close();
        }

        private bool isFilled()
        {
            return (cmbType.Text != "" && txtMarksAvailable.Text != "") ? true : false;
        }

        private bool isValid()
        {
            int x = 0;
            return (Int32.TryParse(txtMarksAvailable.Text, out x)) ? true : false;
        }
    }
}
