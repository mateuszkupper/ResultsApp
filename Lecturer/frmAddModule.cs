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
    public partial class frmAddModule : Form
    {
        int check = -1;
        public frmAddModule()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFilled() && isValid())
            {
                int Semester = Int32.Parse(txtSemester.Text);
                int Credits = Int32.Parse(txtCredits.Text);
                String Description = rtxtDescription.Text;
                String Code = txtCode.Text;
                String Name = txtName.Text;

                frmMain.AdminModuleRow["Name"] = Name;
                frmMain.AdminModuleRow["Code"] = Code;
                frmMain.AdminModuleRow["Semester"] = Semester;
                frmMain.AdminModuleRow["Description"] = Description;
                frmMain.AdminModuleRow["Credit"] = Credits;
                check = Semester;
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
            return (txtSemester.Text != "" &&
                txtCredits.Text != "" &&
                txtCode.Text != "" &&
                txtName.Text != "" &&
                rtxtDescription.Text != "") ? true : false;
        }

        private bool isValid()
        {
            int x = 0;
            return (Int32.TryParse(txtSemester.Text, out x) &&
                Int32.TryParse(txtCredits.Text, out x)) ? true : false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain.AdminModuleRow["Semester"] = check;
            this.Close();
        }

        private void frmAddModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.AdminModuleRow["Semester"] = check;
        }
    }
}
