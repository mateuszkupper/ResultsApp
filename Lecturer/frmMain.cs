using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Lecturer
{
    public partial class frmMain : Form
    {
        static private User user = new User();
        private Connection connection = new Connection();
        private int moduleID;
        private List<int> MCQMarks = new List<int>();
        private List<int> otherMarks = new List<int>();
        private int totalMarksAvailable;

        internal static User User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            int x = 0;
            if (int.TryParse(node.Name, out x) && node.Parent.Name=="Result")
            { 
                DataSet dataResults = getData("SELECT Students.Name, Stud_Mod.Result " +
                                        "FROM Other_Assessments, Modules, Stud_Mod, Students " +
                                        "WHERE Other_Assessments.ModuleID = Modules.ModuleID " +
                                        "AND Modules.ModuleID = Stud_Mod.ModuleID " +
                                        "AND Stud_Mod.StudentID = Students.StudentID " +
                                        "AND Other_Assessments.AssessmentID = " + node.Name);

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = dataResults.Tables[0];
                makeAssignementsInvisible();
            } else if(node.Parent!=null && node.Parent.Name=="tnoModules")
            {
                moduleID = Int32.Parse(node.Name);
                DataSet dataResults = getData("SELECT * " +
                                        "FROM Modules " +
                                        "WHERE ModuleID = " + node.Name);

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = dataResults.Tables[0];

                DataSet dataResultsMCQ = getData("SELECT MCQs.NoOfQs, MCQs.MarksPerQ, " +
                                                "MCQs.NegativeMarking, MCQs.MarksAvailable " +
                                                "FROM MCQs, Modules " +
                                                "WHERE MCQs.ModuleID = Modules.ModuleID " +
                                                "AND Modules.ModuleID =" + node.Name);
                dgvMCQ.AutoGenerateColumns = true;
                dgvMCQ.DataSource = dataResultsMCQ.Tables[0];

                DataSet dataResultsOther = getData("SELECT Other_Assessments.MarksAvailable, Other_Assessments.Type " +
                                    "FROM Other_Assessments, Modules " +
                                    "WHERE Other_Assessments.ModuleID = Modules.ModuleID " +
                                    "AND Modules.ModuleID =" + node.Name);
                dgvOther.AutoGenerateColumns = true;
                dgvOther.DataSource = dataResultsOther.Tables[0];
                makeAssignementsVisible();

                for(int i = 0; i < dataResultsMCQ.Tables[0].Rows.Count; i++)
                {
                    MCQMarks.Add(Int32.Parse(dataResultsMCQ.Tables[0].Rows[i]["MarksAvailable"].ToString()));
                }
                for (int i = 0; i < dataResultsOther.Tables[0].Rows.Count; i++)
                {
                    otherMarks.Add(Int32.Parse(dataResultsOther.Tables[0].Rows[i]["MarksAvailable"].ToString()));
                }
                totalMarksAvailable = otherMarks.Sum() + MCQMarks.Sum();

                if(totalMarksAvailable > 100)
                {
                    lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are greater than 100 - modify one of the assignements or MCQs";
                }
                else if (totalMarksAvailable < 100)
                {
                    lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are less than 100 - modify one of the assignements or MCQs";
                }
            }
        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            makeAssignementsInvisible();
            if(node.Name == "tnoStudents")
            {
                DataSet dataResults = getData("SELECT * " +
                                        "FROM Students");

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = dataResults.Tables[0];
            }
            else if(node.Parent != null && node.Parent.Name == "tnoModules")
            {
                DataSet dataResults = getData("SELECT * " +
                                        "FROM Modules " +
                                        "WHERE ModuleID=" + node.Name);

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = dataResults.Tables[0];
            }
            else if(node.Parent != null && node.Parent.Name =="tnoLecturers")
            {
                DataSet dataResults = getData("SELECT * " +
                                        "FROM Lecturers " +
                                        "WHERE LecturerID=" + node.Name);

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = dataResults.Tables[0];
            }
        }

        private void btnStripSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Server=sql8.freemysqlhosting.net;Database=sql8112145;Uid=sql8112145;" +
                "Password=yhuyly8Gyn;");

            MySqlDataAdapter a = new MySqlDataAdapter("Select * from Students", conn);
            DataSet t = new DataSet();
            a.Fill(t);

            dgvMain.AutoGenerateColumns = true;
            dgvMain.DataSource = t.Tables[0];
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin LoginForm = new frmLogin();
            LoginForm.ShowDialog();
            if (user.UserID != 0)
            {
                splitContainer2.Panel1.Enabled = true;
                splitContainer1.Panel2.Enabled = true;
                logInToolStripMenuItem.Enabled = false;
                logOutToolStripMenuItem.Enabled = true;
                if (user.IsAdmin)
                {
                    splitContainer2.Panel2.Enabled = true;
                    populateAdminTree();
                }
                populateLecturerTree();
            }                     
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logOutToolStripMenuItem.Enabled = false;
            logInToolStripMenuItem.Enabled = true;
            user.Dispose();
            splitContainer2.Panel1.Enabled = false;
            splitContainer1.Panel2.Enabled = false;
            splitContainer2.Panel2.Enabled = false;
            treeLecturer.Nodes["tnoResults"].Nodes["tnoModulesResults"].Nodes.Clear();
            treeLecturer.Nodes["tnoModules"].Nodes.Clear();
            treeAdmin.Nodes["tnoModules"].Nodes.Clear();
            treeAdmin.Nodes["tnoLecturers"].Nodes.Clear();
            makeAssignementsInvisible();
            MCQMarks.Clear();
            otherMarks.Clear();
        }

        private void populateLecturerTree()
        {
            DataSet treeConnDataModules = getData("SELECT Modules.Code, Modules.Name, Modules.ModuleID " +
                                    "FROM Lecturers, Lec_Mod, Modules " +
                                    "WHERE Modules.ModuleID = Lec_Mod.ModuleID " +
                                    "AND Lec_Mod.LecturerID = Lecturers.LecturerID " +
                                    "AND Lecturers.LecturerID =" + user.UserID);
            DataSet treeConnDataExams = getData("SELECT Other_Assessments.Type, Other_Assessments.AssessmentID, Modules.Code " +
                                "FROM Lecturers, Lec_Mod, Modules, Other_Assessments " +
                                "WHERE Lecturers.LecturerID = Lec_Mod.LecturerID " +
                                "AND Lec_Mod.ModuleID = Modules.ModuleID " +
                                "AND Modules.ModuleID = Other_Assessments.ModuleID " +
                                "AND Lecturers.LecturerID = " + user.UserID);

            foreach (DataTable tableModules in treeConnDataModules.Tables)
            {
                foreach (DataRow rowModules in tableModules.Rows)
                {
                    TreeNode nodeLecturer;
                    nodeLecturer = treeLecturer.Nodes["tnoResults"].Nodes["tnoModulesResults"].Nodes.
                        Add(rowModules["Code"].ToString() + " - " + rowModules["Name"].ToString());
                    nodeLecturer.Name = "Result";
                    foreach (DataTable tableResults in treeConnDataExams.Tables)
                    {
                        foreach (DataRow rowResults in tableResults.Rows)
                        {
                            if (rowModules["Code"].ToString() == rowResults["Code"].ToString())
                            {
                                TreeNode nodeResults = nodeLecturer.Nodes.Add(rowResults["Type"].ToString());
                                nodeResults.Name = rowResults["AssessmentID"].ToString();
                            }
                        }
                    }
                }
            }

            foreach (DataTable tableModules in treeConnDataModules.Tables)
            {
                foreach (DataRow rowModules in tableModules.Rows)
                {
                    TreeNode nodeEditModules = treeLecturer.Nodes["tnoModules"].Nodes.Add(rowModules["Code"].ToString() + 
                        " - " + rowModules["Name"].ToString());
                    nodeEditModules.Name = rowModules["ModuleID"].ToString();
                }
            }
        }

        private void populateAdminTree()
        {
            DataSet treeConnDataModules = getData("SELECT Code, Name, ModuleID " +
                                    "FROM Modules");
            DataSet treeConnDataLecturers = getData("SELECT Name, LecturerID " +
                                    "FROM Lecturers");

            foreach (DataTable tableModules in treeConnDataModules.Tables)
            {
                foreach (DataRow rowModules in tableModules.Rows)
                {
                   TreeNode nodeAdminModules = treeAdmin.Nodes["tnoModules"].Nodes.Add(rowModules["Code"].ToString() +
                        " - " + rowModules["Name"].ToString());
                    nodeAdminModules.Name = rowModules["ModuleID"].ToString();
                }
            }

            foreach (DataTable tableLecturers in treeConnDataLecturers.Tables)
            {
                foreach (DataRow rowLecturers in tableLecturers.Rows)
                {
                    TreeNode nodeAdminLecturers = treeAdmin.Nodes["tnoLecturers"].Nodes.Add(rowLecturers["Name"].ToString());
                    nodeAdminLecturers.Name = rowLecturers["LecturerID"].ToString();
                }
            }
        }

        private DataSet getData(String query)
        {
            MySqlConnection treeConn = new MySqlConnection("Server=" + connection.Server +
                                                        ";Database=" + connection.DB +
                                                        ";Uid=" + connection.UID + ";" +
                                                        "Password=" + connection.Password + ";");
;
            MySqlDataAdapter treeConnectionAdapter = new MySqlDataAdapter(query, treeConn);
            DataSet treeConnData = new DataSet();
            treeConnectionAdapter.Fill(treeConnData);
            treeConnectionAdapter.Dispose();
            return treeConnData;
        }

        private void makeAssignementsVisible()
        {
            lblMCQ.Visible = true;
            lblOther.Visible = true;
            dgvMCQ.Visible = true;
            dgvOther.Visible = true;
            btnAddMCQ.Visible = true;
            btnAddOther.Visible = true;
            lblWarning.Visible = true;
        }

        private void makeAssignementsInvisible()
        {
            lblMCQ.Visible = false;
            lblOther.Visible = false;
            dgvMCQ.Visible = false;
            dgvOther.Visible = false;
            btnAddMCQ.Visible = false;
            btnAddOther.Visible = false;
            lblWarning.Visible = false;
        }

        private void calculateResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAddMCQ_Click(object sender, EventArgs e)
        {
            frmAddMCQ MCQForm = new frmAddMCQ();
            MCQForm.ModuleID = moduleID;
            MCQForm.ShowDialog();
            DataSet dataResultsMCQ = getData("SELECT MCQs.NoOfQs, MCQs.MarksPerQ, " +
                                "MCQs.NegativeMarking, MCQs.MarksAvailable " +
                                "FROM MCQs, Modules " +
                                "WHERE MCQs.ModuleID = Modules.ModuleID " +
                                "AND Modules.ModuleID =" + moduleID);
            dgvMCQ.AutoGenerateColumns = true;
            dgvMCQ.DataSource = dataResultsMCQ.Tables[0];

            for (int i = 0; i < dataResultsMCQ.Tables[0].Rows.Count; i++)
            {
                MCQMarks.Add(Int32.Parse(dataResultsMCQ.Tables[0].Rows[i]["MarksAvailable"].ToString()));
            }
            totalMarksAvailable = otherMarks.Sum() + MCQMarks.Sum();

            MCQMarks.Clear();
            if (totalMarksAvailable > 100)
            {
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are greater than 100 - modify one of the assignements or MCQs";
            }
            else if (totalMarksAvailable < 100)
            {
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are less than 100 - modify one of the assignements or MCQs";
            }
        }

        private void btnAddOther_Click(object sender, EventArgs e)
        {
            frmAddOther OtherForm = new frmAddOther();
            OtherForm.ModuleID = moduleID;
            OtherForm.ShowDialog();
            DataSet dataResultsOther = getData("SELECT Other_Assessments.MarksAvailable, Other_Assessments.Type " +
                                "FROM Other_Assessments, Modules " +
                                "WHERE Other_Assessments.ModuleID = Modules.ModuleID " +
                                "AND Modules.ModuleID =" + moduleID);
            dgvOther.AutoGenerateColumns = true;
            dgvOther.DataSource = dataResultsOther.Tables[0];

            otherMarks.Clear();
            for (int i = 0; i < dataResultsOther.Tables[0].Rows.Count; i++)
            {
                otherMarks.Add(Int32.Parse(dataResultsOther.Tables[0].Rows[i]["MarksAvailable"].ToString()));
            }
            totalMarksAvailable = otherMarks.Sum() + MCQMarks.Sum();

            if (totalMarksAvailable > 100)
            {
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are greater than 100 - modify one of the assignements or MCQs";
            }
            else if (totalMarksAvailable < 100)
            {
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are less than 100 - modify one of the assignements or MCQs";
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
