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
            String Type = cmbType.Text;
            int MarksAvailable = Int32.Parse(txtMarksAvailable.Text);

            if(Type == "End of semester exam")
            {
                Type = "EndOfSemester";
            }

            frmMain.OtherRow["ModuleID"] = ModuleID;
            frmMain.OtherRow["Type"] = Type;
            frmMain.OtherRow["MarksAvailable"] = MarksAvailable;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
