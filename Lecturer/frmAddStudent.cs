using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lecturer
{
    public partial class frmAddStudent : Form
    {
        int check = -1;
        public frmAddStudent()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFilled() && isValid())
            {
                int Year = Int32.Parse(txtYear.Text);
                String Name = txtName.Text;
                String Course = txtCourse.Text;

                frmMain.AdminStudentRow["Name"] = Name;
                frmMain.AdminStudentRow["Year"] = Year;
                frmMain.AdminStudentRow["Course"] = Course;
                check = Year;
                this.Close();
            }
            else if (!isFilled())
            {
                MessageBox.Show("Fill in all fields!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!isValid())
            {
                MessageBox.Show("Invalid values!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("All values need to be numbers! \n Fill in all fields!", "Validation",
                     MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private bool isFilled()
        {
            return (txtName.Text != "" &&
                txtYear.Text != "" &&
                txtCourse.Text != "") ? true : false;
        }

        private bool isValid()
        {
            int x = 0;
            return (Int32.TryParse(txtYear.Text, out x)) ? true : false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain.AdminStudentRow["Year"] = check;
            this.Close();
        }

        private void frmAddModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.AdminStudentRow["Year"] = check;
        }
    }
}
