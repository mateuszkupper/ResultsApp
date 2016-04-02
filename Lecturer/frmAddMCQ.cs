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
            int NoOfQs = Int32.Parse(txtNoOfQs.Text);
            int MarksPerQ = Int32.Parse(txtMarksPerQuestion.Text);
            int MarksAvailable = Int32.Parse(txtMarksAvailable.Text);
            Boolean NegativeMarking = chbNegativeMarking.Checked;

            //frmMain.MCQRownull, ModuleID, NoOfQs, MarksPerQ, NegativeMarking, MarksAvailable;
            frmMain.MCQRow["ModuleID"] = ModuleID;
            frmMain.MCQRow["NoOfQs"] = NoOfQs;
            frmMain.MCQRow["MarksPerQ"] = MarksPerQ;
            frmMain.MCQRow["NegativeMarking"] = NegativeMarking;
            frmMain.MCQRow["MarksAvailable"] = MarksAvailable;
            /*MySqlConnection conn = new MySqlConnection("Server=" + connection.Server +
                                            ";Database=" + connection.DB +
                                            ";Uid=" + connection.UID + ";" +
                                            "Password=" + connection.Password + ";");

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "INSERT INTO MCQs (ModuleID, NoOfQs, MarksPerQ," +
                                    "NegativeMarking, MArksAvailable) VALUES (" + ModuleID +
                                    ", " + NoOfQs + ", " + MarksPerQ + ", " +
                                    NegativeMarking + ", " + MarksAvailable + ")";
            conn.Open();
            command.ExecuteNonQuery();*/

            //frmMain.dgv
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
