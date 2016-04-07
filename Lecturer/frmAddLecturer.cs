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
    public partial class frmAddLecturer : Form
    {
        String check = "qqq";
        public frmAddLecturer()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFilled() && isValid())
            {
                String Name = txtName.Text;
                String Department = txtDept.Text;
                String Username = txtUsername.Text;
                String Password = txtPassword.Text;
                Boolean isAdmin = chbAdmin.Checked;

                frmMain.AdminLecturerRow["Name"] = Name;
                frmMain.AdminLecturerRow["Department"] = Department;
                frmMain.AdminLecturerRow["UserName"] = Username;
                frmMain.AdminLecturerRow["Password"] = Password;
                frmMain.AdminLecturerRow["Admin?"] = isAdmin;
                check = Name;
                this.Close();
            }
            else if (!isFilled())
            {
                MessageBox.Show("Fill in all fields!", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else if (!isValid())
            {
                MessageBox.Show("Passwords must match!", "Validation",
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
            return (txtDept.Text != "" &&
                txtUsername.Text != "" &&
                txtPassword.Text != "" &&
                txtConfirmPassword.Text != "" &&
                txtName.Text != "") ? true : false;
        }

        private bool isValid()
        {
            return (txtPassword.Text == txtConfirmPassword.Text) ? true : false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmMain.AdminLecturerRow["Name"] = check;
            this.Close();
        }

        private void frmAddLecturer_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMain.AdminLecturerRow["Name"] = check;
        }
    }
}
