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

            MySqlConnection conn = new MySqlConnection("Server=" + connection.Server +
                                            ";Database=" + connection.DB +
                                            ";Uid=" + connection.UID + ";" +
                                            "Password=" + connection.Password + ";");

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO Other_Assessments (ModuleID, MarksAvailable, Type) VALUES (" 
                                    + ModuleID + ", " + MarksAvailable + ", '" + Type + "')";
            conn.Open();
            command.ExecuteNonQuery();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
