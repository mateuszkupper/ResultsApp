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
        private Dictionary<String, MySqlDataAdapter> dataAdapters = new Dictionary<String, MySqlDataAdapter>();
        private Dictionary<String, BindingSource> bindingSources = new Dictionary<string, BindingSource>();
        private Dictionary<String, MySqlCommandBuilder> cmdBuilders = new Dictionary<string, MySqlCommandBuilder>();
        private int totalMarksAvailable;

        #region "DataTables"
        static private DataTable dataResultsAssessments;
        static private DataTable dataModule;
        static private DataTable dataModuleMCQ;
        static private DataTable dataModuleOther;
        static private DataTable dataStudents;
        static private DataTable dataModules;
        static private DataTable dataLecturers;
        #endregion

        static private DataRow mCQRow;
        static private DataRow otherRow; 
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

        internal static DataRow MCQRow
        {
            get
            {
                return mCQRow;
            }

            set
            {
                mCQRow = value;
            }
        }

        internal static DataRow OtherRow
        {
            get
            {
                return otherRow;
            }

            set
            {
                otherRow = value;
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
            TreeNode parent = node.Parent;
            int x = 0;
            if (node.Parent != null && parent.Parent != null)
            {
                if (int.TryParse(node.Name, out x) && parent.Parent.Name == "tnoModulesResults" && node.Text != "MCQ")
                {
                    dataResultsAssessments = getData("SELECT Stud_Mod.StudentID, t.Result " +
                                "FROM (SELECT Other_Assessments_Results.Result, Other_Assessments_Results.StudentID " +
                                "FROM Other_Assessments_Results " +
                                "WHERE Other_Assessments_Results.AssessmentID = " + node.Name + ") t " +
                                "RIGHT JOIN Stud_Mod ON Stud_Mod.StudentID = t.StudentID " +
                                "WHERE Stud_Mod.ModuleID = " + node.Parent.Name,
                                "dataResultsAssessments");

                    dgvMain.AutoGenerateColumns = true;
                    dgvMain.DataSource = bindingSources["dataResultsAssessments"];
                    makeAssignementsInvisible();
                }
                else if (int.TryParse(node.Name, out x) && parent.Parent.Name == "tnoModulesResults" && node.Text == "MCQ")
                {
                    dataResultsAssessments = getData("SELECT Stud_Mod.StudentID, t.NoOfCorrectQs " +
                                                    "FROM (SELECT MCQs_Results.NoOfCorrectQs, MCQs_Results.StudentID " +
                                                    "FROM MCQs_Results " +
                                                    "WHERE MCQs_Results.MCQID = " + node.Name + ") t " +
                                                    "RIGHT JOIN Stud_Mod ON Stud_Mod.StudentID = t.StudentID " +
                                                    "WHERE Stud_Mod.ModuleID = " + node.Parent.Name,
                                                    "dataResultsAssessments");

                    dgvMain.AutoGenerateColumns = true;
                    dgvMain.DataSource = bindingSources["dataResultsAssessments"];
                    makeAssignementsInvisible();
                }
            }
                if (node.Parent != null && node.Parent.Name == "tnoModules")
                {
                    moduleID = Int32.Parse(node.Name);
                    refreshModuleDetails();
                }
            
        }



        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            makeAssignementsInvisible();
            if(node.Name == "tnoStudents")
            {
                dataStudents = getData("SELECT * " +
                                        "FROM Students", "dataStudents");

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = bindingSources["dataStudents"];
            }
            else if(node.Parent != null && node.Parent.Name == "tnoModules")
            {
                dataModules = getData("SELECT * " +
                                        "FROM Modules " +
                                        "WHERE ModuleID=" + node.Name, "dataModules");

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = bindingSources["dataModules"];
            }
            else if(node.Parent != null && node.Parent.Name =="tnoLecturers")
            {
                dataLecturers = getData("SELECT * " +
                                        "FROM Lecturers " +
                                        "WHERE LecturerID=" + node.Name, "dataLecturers");

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = bindingSources["dataLecturers"];
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
            totalMarksAvailable = 0;
        }



        private void populateLecturerTree()
        {
            DataTable treeConnDataModules = getData("SELECT Modules.Code, Modules.Name, Modules.ModuleID " +
                                    "FROM Lecturers, Lec_Mod, Modules " +
                                    "WHERE Modules.ModuleID = Lec_Mod.ModuleID " +
                                    "AND Lec_Mod.LecturerID = Lecturers.LecturerID " +
                                    "AND Lecturers.LecturerID =" + user.UserID, "treeLModules");
            DataTable treeConnDataExams = getData("SELECT Other_Assessments.Type, Other_Assessments.AssessmentID, Modules.Code " +
                                "FROM Lecturers, Lec_Mod, Modules, Other_Assessments " +
                                "WHERE Lecturers.LecturerID = Lec_Mod.LecturerID " +
                                "AND Lec_Mod.ModuleID = Modules.ModuleID " +
                                "AND Modules.ModuleID = Other_Assessments.ModuleID " +
                                "AND Lecturers.LecturerID = " + user.UserID, "treeLExams");
            DataTable treeConnDataMCQs = getData("SELECT MCQs.MCQID, Modules.Code " +
                                                "FROM Lecturers, Lec_Mod, Modules, MCQs " +
                                                "WHERE Lecturers.LecturerID = Lec_Mod.LecturerID " +
                                                "AND Lec_Mod.ModuleID = Modules.ModuleID " +
                                                "AND Modules.ModuleID = MCQs.ModuleID " +
                                                "AND Lecturers.LecturerID = " + user.UserID, "treeLMCQs");

                foreach (DataRow rowModules in treeConnDataModules.Rows)
                {
                    TreeNode nodeLecturer;
                    nodeLecturer = treeLecturer.Nodes["tnoResults"].Nodes["tnoModulesResults"].Nodes.
                        Add(rowModules["Code"].ToString() + " - " + rowModules["Name"].ToString());
                    nodeLecturer.Name = rowModules["ModuleID"].ToString();
                        foreach (DataRow rowResults in treeConnDataExams.Rows)
                        {
                            if (rowModules["Code"].ToString() == rowResults["Code"].ToString())
                            {
                                TreeNode nodeResults = nodeLecturer.Nodes.Add(rowResults["Type"].ToString());
                                nodeResults.Name = rowResults["AssessmentID"].ToString();
                            }
                        }

                        foreach (DataRow rowMCQs in treeConnDataMCQs.Rows)
                        {
                            if(rowMCQs["Code"].ToString() == rowModules["Code"].ToString())
                            {
                                TreeNode nodeResults = nodeLecturer.Nodes.Add("MCQ");
                                nodeResults.Name = rowMCQs["MCQID"].ToString();
                            }
                        }
                }

                foreach (DataRow rowModules in treeConnDataModules.Rows)
                {
                    TreeNode nodeEditModules = treeLecturer.Nodes["tnoModules"].Nodes.Add(rowModules["Code"].ToString() + 
                        " - " + rowModules["Name"].ToString());
                    nodeEditModules.Name = rowModules["ModuleID"].ToString();
                }
            
        }



        private void populateAdminTree()
        {
            DataTable treeConnDataModules = getData("SELECT Code, Name, ModuleID " +
                                    "FROM Modules", "treeAModules");
            DataTable treeConnDataLecturers = getData("SELECT Name, LecturerID " +
                                    "FROM Lecturers", "treeALecturers");

                foreach (DataRow rowModules in treeConnDataModules.Rows)
                {
                   TreeNode nodeAdminModules = treeAdmin.Nodes["tnoModules"].Nodes.Add(rowModules["Code"].ToString() +
                        " - " + rowModules["Name"].ToString());
                    nodeAdminModules.Name = rowModules["ModuleID"].ToString();
                }
            

                foreach (DataRow rowLecturers in treeConnDataLecturers.Rows)
                {
                    TreeNode nodeAdminLecturers = treeAdmin.Nodes["tnoLecturers"].Nodes.Add(rowLecturers["Name"].ToString());
                    nodeAdminLecturers.Name = rowLecturers["LecturerID"].ToString();
                }
            
        }



        private DataTable getData(String query, String name)
        {
            MySqlConnection treeConn = new MySqlConnection("Server=" + connection.Server +
                                                        ";Database=" + connection.DB +
                                                        ";Uid=" + connection.UID + ";" +
                                                        "Password=" + connection.Password + ";");

            DataTable treeConnData;
            if (dataAdapters.ContainsKey(name))
            {
                dataAdapters[name] = new MySqlDataAdapter(query, treeConn);
                treeConnData = new DataTable();
                dataAdapters[name].Fill(treeConnData);
                cmdBuilders[name] = new MySqlCommandBuilder(dataAdapters[name]);
                bindingSources[name].DataSource = treeConnData;
            }
            else
            {
                dataAdapters.Add(name, new MySqlDataAdapter(query, treeConn));
                treeConnData = new DataTable();
                dataAdapters[name].Fill(treeConnData);
                cmdBuilders.Add(name, new MySqlCommandBuilder(dataAdapters[name]));
                bindingSources.Add(name, new BindingSource());
                bindingSources[name].DataSource = treeConnData;
            }
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
            MCQRow = dataModuleMCQ.NewRow();
            frmAddMCQ MCQForm = new frmAddMCQ();
            MCQForm.ModuleID = moduleID;
            MCQForm.ShowDialog();

            dataModuleMCQ.Rows.Add(MCQRow);

            dgvMCQ.DataSource = dataModuleMCQ;
            checkTotalMarksAvailable();
        }



        private void btnAddOther_Click(object sender, EventArgs e)
        {
            OtherRow = dataModuleOther.NewRow();
            frmAddOther OtherForm = new frmAddOther();
            OtherForm.ModuleID = moduleID;
            OtherForm.ShowDialog();

            dataModuleOther.Rows.Add(OtherRow);

            dgvOther.DataSource = dataModuleOther;
            checkTotalMarksAvailable();
        }



        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvMCQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvMCQ_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkTotalMarksAvailable();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvMCQ.EndEdit();
            dataAdapters["dataModuleMCQ"].Update((DataTable)bindingSources["dataModuleMCQ"].DataSource);

            dgvOther.EndEdit();
            dataAdapters["dataModuleOther"].Update((DataTable)bindingSources["dataModuleOther"].DataSource);

            dgvMain.EndEdit();
            dataAdapters["dataModule"].Update((DataTable)bindingSources["dataModule"].DataSource);
            clearLecturerTree();
            populateLecturerTree();
            refreshModuleDetails();
        }

        private void dgvOther_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkTotalMarksAvailable();
        }


        private void checkTotalMarksAvailable()
        {
            totalMarksAvailable = 0;
            for (int i = 0; i < dgvMCQ.RowCount; i++)
            {
                totalMarksAvailable += Int32.Parse(dgvMCQ.Rows[i].Cells["MarksAvailable"].Value.ToString());
            }
            for (int i = 0; i < dgvOther.RowCount; i++)
            {
                totalMarksAvailable += Int32.Parse(dgvOther.Rows[i].Cells["MarksAvailable"].Value.ToString());
            }
            if (totalMarksAvailable > 100)
            {
                btnSave.Enabled = false; 
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are greater than 100 - modify one of the assignements or MCQs";
            }
            else if (totalMarksAvailable < 100)
            {
                btnSave.Enabled = false;
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are less than 100 - modify one of the assignements or MCQs";
            }
            else
            {
                btnSave.Enabled = true;
                lblWarning.Text = "";
            }
        }

        private void refreshModuleDetails()
        {
            dataModule = getData("SELECT * " +
                           "FROM Modules " +
                           "WHERE ModuleID = " + moduleID, "dataModule");

            dgvMain.AutoGenerateColumns = true;
            dgvMain.DataSource = bindingSources["dataModule"];

            dataModuleMCQ = getData("SELECT MCQs.ModuleID, MCQs.MCQID, MCQs.NoOfQs, MCQs.MarksPerQ, " +
                                            "MCQs.NegativeMarking, MCQs.MarksAvailable " +
                                            "FROM MCQs, Modules " +
                                            "WHERE MCQs.ModuleID = Modules.ModuleID " +
                                            "AND Modules.ModuleID =" + moduleID, "dataModuleMCQ");
            dgvMCQ.AutoGenerateColumns = true;
            dgvMCQ.DataSource = bindingSources["dataModuleMCQ"];

            dataModuleOther = getData("SELECT Other_Assessments.ModuleID, Other_Assessments.AssessmentID, Other_Assessments.MarksAvailable, Other_Assessments.Type " +
                                "FROM Other_Assessments, Modules " +
                                "WHERE Other_Assessments.ModuleID = Modules.ModuleID " +
                                "AND Modules.ModuleID =" + moduleID, "dataModuleOther");
            dgvOther.AutoGenerateColumns = true;
            dgvOther.DataSource = bindingSources["dataModuleOther"];
            makeAssignementsVisible();

            checkTotalMarksAvailable();
        }

        private void clearLecturerTree()
        {
            treeLecturer.Nodes.Clear();
            TreeNode results = treeLecturer.Nodes.Add("Results");
            results.Name = "tnoResults";
            TreeNode moduleResults = results.Nodes.Add("Modules");
            moduleResults.Name = "tnoModulesResults";
            TreeNode modules = treeLecturer.Nodes.Add("Modules");
            modules.Name = "tnoModules";
        }

        private void dgvMCQ_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            checkTotalMarksAvailable();
        }

        private void dgvOther_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvOther_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            checkTotalMarksAvailable();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            refreshModuleDetails();
        }
    }
}
