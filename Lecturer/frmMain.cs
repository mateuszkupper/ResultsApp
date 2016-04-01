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
            int i = 0;
            if (int.TryParse(node.Name, out i) && node.Parent.Name=="Result")
            { 
                DataSet dataResults = getData("SELECT Students.Name, Stud_Mod.Result " +
                                        "FROM Other_Assessments, Modules, Stud_Mod, Students " +
                                        "WHERE Other_Assessments.ModuleID = Modules.ModuleID " +
                                        "AND Modules.ModuleID = Stud_Mod.ModuleID " +
                                        "AND Stud_Mod.StudentID = Students.StudentID " +
                                        "AND Other_Assessments.AssessmentID = " + node.Name);

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = dataResults.Tables[0];
            } else if(node.Parent!=null && node.Parent.Name=="tnoModules")
            {
                DataSet dataResults = getData("SELECT * " +
                                        "FROM Modules " +
                                        "WHERE ModuleID = " + node.Name);

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = dataResults.Tables[0];

            }
        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
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

        private void calculateResultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAddMCQ_Click(object sender, EventArgs e)
        {
            frmAddMCQ MCQForm = new frmAddMCQ();
            MCQForm.ShowDialog();
        }

        private void btnAddOther_Click(object sender, EventArgs e)
        {
            frmAddOther OtherForm = new frmAddOther();
            OtherForm.ShowDialog();
        }
    }
}
