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
        private int MCQID = 0;
        private int otherID = 0;
        private int MCQNoOfQs = 0;
        private Dictionary<String, MySqlDataAdapter> dataAdapters = new Dictionary<String, MySqlDataAdapter>();
        private Dictionary<String, BindingSource> bindingSources = new Dictionary<string, BindingSource>();
        private Dictionary<String, MySqlCommandBuilder> cmdBuilders = new Dictionary<string, MySqlCommandBuilder>();
        private int totalMarksAvailable;
        private String nodeSelected;

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


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (dgvMain.Columns.Contains("Result"))
            {
                dgvMain.Columns.Remove("Result");
            }
            TreeNode node = e.Node;
            TreeNode parent = node.Parent;
            int x = 0;
            if (node.Parent != null && parent.Parent != null)
            {
                dgvMain.AllowUserToDeleteRows = false;
                if (int.TryParse(node.Name, out x) && parent.Parent.Name == "tnoModulesResults" && node.Text != "MCQ")
                {
                    dataResultsAssessments = getData("SELECT x.Name, x.StudentID, t.Result AS 'Result (%)' " +
                                "FROM (SELECT Other_Assessments_Results.Result, Other_Assessments_Results.StudentID " +
                                "FROM Other_Assessments_Results " +
                                "WHERE Other_Assessments_Results.AssessmentID = " + node.Name + ") t " +
                                "RIGHT JOIN (SELECT Stud_Mod.StudentID, Students.Name, Stud_Mod.ModuleID " +
                                                    "FROM Students, Stud_Mod " +
                                                    "WHERE Students.StudentID = Stud_Mod.StudentID) AS x " + 
                                "ON x.StudentID = t.StudentID " +
                                "WHERE x.ModuleID = " + node.Parent.Name,
                                "dataResultsAssessments");

                    otherID = Int32.Parse(node.Name);
                    dgvMain.AutoGenerateColumns = true;
                    btnAddData.Enabled = false;
                    dgvMain.DataSource = dataResultsAssessments;
                    dgvMain.Columns["StudentID"].ReadOnly = true;
                    dgvMain.Columns["Name"].ReadOnly = true;
                    makeAssignementsInvisible();
                    nodeSelected = "LecturerResultsOther";
                    lblWarning.Text = "";
                }
                else if (int.TryParse(node.Name, out x) && parent.Parent.Name == "tnoModulesResults" && node.Text == "MCQ")
                {
                    dataResultsAssessments = getData("SELECT x.Name, x.StudentID, t.NoOfCorrectQs AS 'Number Of Correct Answers', " +
                                                    "t.NoOfIncorrectQs AS 'Number Of Incorrect Answers', " +
                                                    "t.NoOfNotAnsweredQs AS 'Number Of Not Answered Questions' " +
                                                    "FROM (SELECT MCQs_Results.NoOfCorrectQs, MCQs_Results.StudentID, " +
                                                    "MCQs_Results.NoOfIncorrectQs, MCQs_Results.NoOfNotAnsweredQs " +
                                                    "FROM MCQs_Results " +
                                                    "WHERE MCQs_Results.MCQID = " + node.Name + ") t " +
                                                    "RIGHT JOIN (SELECT Stud_Mod.StudentID, Students.Name, Stud_Mod.ModuleID " +
                                                            "FROM Students, Stud_Mod " +
                                                            "WHERE Students.StudentID = Stud_Mod.StudentID) AS x " +
                                                    "ON x.StudentID = t.StudentID " +
                                                    "WHERE x.ModuleID = " + node.Parent.Name,
                                                    "dataResultsAssessments");
                    MCQID = Int32.Parse(node.Name);
                    
                    dgvMain.AutoGenerateColumns = true;
                    dgvMain.DataSource = dataResultsAssessments;
                    dgvMain.Columns["StudentID"].ReadOnly = true;
                    dgvMain.Columns["Name"].ReadOnly = true;
                    btnAddData.Enabled = false;
                    makeAssignementsInvisible();
                    nodeSelected = "LecturerResultsMCQ";


                    if (!dgvMain.Columns.Contains("Result"))
                    {
                        dgvMain.Columns.Add("Result", "Result (%)");
                        dgvMain.Columns["Result"].ReadOnly = true;
                    }

                    checkNumberOfQs();
                }
            }
            if (node.Parent != null && node.Parent.Name == "tnoModules")
            {
                dgvMain.AllowUserToDeleteRows = false;
                moduleID = Int32.Parse(node.Name);
                refreshModuleDetails();
                nodeSelected = "LecturerModule";
                btnAddData.Enabled = false;
            }

        }



        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (dgvMain.Columns.Contains("Result"))
            {
                dgvMain.Columns.Remove("Result");
            }
            TreeNode node = e.Node;
            makeAssignementsInvisible();
            if (node.Name == "tnoStudents")
            {
                dataStudents = getData("SELECT * " +
                                        "FROM Students", "dataStudents");

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = bindingSources["dataStudents"];
                nodeSelected = "AdminStudents";
                btnAddData.Enabled = true;
                dgvMain.AllowUserToDeleteRows = true;
                lblWarning.Text = "";
            }
            else if (node.Name == "tnoModules")
            {
                dataModules = getData("SELECT * " +
                                        "FROM Modules ", "dataModules");

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = bindingSources["dataModules"];
                nodeSelected = "AdminModules";
                btnAddData.Enabled = true;
                dgvMain.AllowUserToDeleteRows = true;
                lblWarning.Text = "";
            }
            else if (node.Name == "tnoLecturers")
            {
                dataLecturers = getData("SELECT * " +
                                        "FROM Lecturers ", "dataLecturers");

                dgvMain.AutoGenerateColumns = true;
                dgvMain.DataSource = bindingSources["dataLecturers"];
                nodeSelected = "AdminLecturers";
                btnAddData.Enabled = true;
                dgvMain.AllowUserToDeleteRows = true;
                lblWarning.Text = "";
            }
            else if (node.Name == "tnoLecturersModules")
            {
                nodeSelected = "AdminLecturersModules";
                lblWarning.Text = "";
            }
            else if (node.Name == "tnoStudentsModules")
            {
                nodeSelected = "tnoStudentsModules";
                lblWarning.Text = "";
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
                makeAssignementsInvisible();
                if (user.IsAdmin)
                {
                    splitContainer2.Panel2.Enabled = true;
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
                    if (rowMCQs["Code"].ToString() == rowModules["Code"].ToString())
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
            splitContainer5.Visible = true;
        }



        private void makeAssignementsInvisible()
        {
            splitContainer5.Visible = false;
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

            if (Int32.Parse(OtherRow["ModuleID"].ToString()) != 0)
            {
                dataModuleMCQ.Rows.Add(MCQRow);

                dgvMCQ.DataSource = dataModuleMCQ;
                checkTotalMarksAvailable();
                hideColumns();
            }
        }



        private void btnAddOther_Click(object sender, EventArgs e)
        {
            OtherRow = dataModuleOther.NewRow();
            frmAddOther OtherForm = new frmAddOther();
            OtherForm.ModuleID = moduleID;
            OtherForm.ShowDialog();

            if (Int32.Parse(OtherRow["ModuleID"].ToString()) != 0)
            {
                dataModuleOther.Rows.Add(OtherRow);

                dgvOther.DataSource = dataModuleOther;
                checkTotalMarksAvailable();
                hideColumns();
            }
        }

        private void dgvMCQ_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkTotalMarksAvailable();
            hideColumns();
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
            hideColumns();
        }

        private void dgvOther_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkTotalMarksAvailable();
            hideColumns();
        }


        private void checkTotalMarksAvailable()
        {
            totalMarksAvailable = 0;
            for (int i = 0; i < dgvMCQ.RowCount; i++)
            {
                totalMarksAvailable += Int32.Parse(dgvMCQ.Rows[i].Cells["Marks Available (0%-100%)"].Value.ToString());
            }
            for (int i = 0; i < dgvOther.RowCount; i++)
            {
                totalMarksAvailable += Int32.Parse(dgvOther.Rows[i].Cells["Marks Available (0%-100%)"].Value.ToString());
            }
            if (totalMarksAvailable > 100)
            {
                //btnSaveMCQ.Enabled = false;
                //btnSaveOthers.Enabled = false;
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are greater than 100 - modify one of the assignements or MCQs";
            }
            else if (totalMarksAvailable < 100)
            {
                //btnSaveMCQ.Enabled = false;
                //btnSaveOthers.Enabled = false;
                lblWarning.Text = "Total marks available (" + totalMarksAvailable + ") are less than 100 - modify one of the assignements or MCQs";
            }
            else
            {
                //btnSaveMCQ.Enabled = true;
                //btnSaveOthers.Enabled = true;
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

            dataModuleMCQ = getData("SELECT MCQs.ModuleID, MCQs.MCQID, " +
                                            "MCQs.NoOfQs AS 'Number Of Questions', " +
                                            "MCQs.MarksPerQ AS 'Marks Per Question', " +
                                            "MCQs.NegativeMarking AS 'Negative Marking?', " +
                                            "MCQs.MarksAvailable AS 'Marks Available (0%-100%)' " +
                                            "FROM MCQs, Modules " +
                                            "WHERE MCQs.ModuleID = Modules.ModuleID " +
                                            "AND Modules.ModuleID =" + moduleID, "dataModuleMCQ");
            dgvMCQ.AutoGenerateColumns = true;
            dgvMCQ.DataSource = bindingSources["dataModuleMCQ"];
            /*dgvMCQ.Columns[2].HeaderText = "Number Of Questions";
            dgvMCQ.Columns[3].HeaderText = "Marks Per Question";
            dgvMCQ.Columns[4].HeaderText = "Negative Marking?";
            dgvMCQ.Columns[5].HeaderText = "Marks Available (0%-100%)";*/

            dataModuleOther = getData("SELECT Other_Assessments.ModuleID, Other_Assessments.AssessmentID, " +
                                "Other_Assessments.MarksAvailable AS 'Marks Available (0%-100%)', Other_Assessments.Type " +
                                "FROM Other_Assessments, Modules " +
                                "WHERE Other_Assessments.ModuleID = Modules.ModuleID " +
                                "AND Modules.ModuleID =" + moduleID, "dataModuleOther");
            dgvOther.AutoGenerateColumns = true;
            dgvOther.DataSource = bindingSources["dataModuleOther"];
            makeAssignementsVisible();

            checkTotalMarksAvailable();
            hideColumns();
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
            hideColumns();
        }

        private void dgvOther_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            checkTotalMarksAvailable();
            hideColumns();
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            refreshModuleDetails();
            hideColumns();
        }

        private void hideColumns()
        {
            dgvMCQ.Columns[0].Visible = false;
            dgvOther.Columns[0].Visible = false;
            dgvOther.Columns[1].Visible = false;
            dgvMCQ.Columns[1].Visible = false;
        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to overwrite data?", "Save?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                switch (nodeSelected)
                {
                    case "LecturerResultsMCQ":
                        dgvMain.EndEdit();
                        if (checkMCQMarks(MCQNoOfQs))
                        {
                            DataTable dataMCQ = (DataTable)(dgvMain.DataSource);
                            MySqlConnection connMCQ = new MySqlConnection("Server=" + connection.Server +
                                                            ";Database=" + connection.DB +
                                                            ";Uid=" + connection.UID + ";" +
                                                            "Password=" + connection.Password + ";");
                            MySqlCommand commandMCQ = connMCQ.CreateCommand();
                            foreach (DataGridViewRow row in dgvMain.Rows)
                            {
                                if (row.Cells["StudentID"].Value.ToString() == String.Empty)
                                {
                                    row.Cells["StudentID"].Value = "0";
                                }
                                if (row.Cells["Number Of Correct Answers"].Value.ToString() == String.Empty)
                                {
                                    row.Cells["Number Of Correct Answers"].Value = "0";
                                }
                                if (row.Cells["Number Of Incorrect Answers"].Value.ToString() == String.Empty)
                                {
                                    row.Cells["Number Of Incorrect Answers"].Value = "0";
                                }
                                if (row.Cells["Number Of Not Answered Questions"].Value.ToString() == String.Empty)
                                {
                                    row.Cells["Number Of Not Answered Questions"].Value = "0";
                                }

                                commandMCQ.CommandText = "INSERT INTO MCQs_Results (MCQID, StudentID, NoOfCorrectQs, " +
                                                         "NoOfIncorrectQs, NoOfNotAnsweredQs) " +
                                                         "VALUES (" + MCQID + ", " +
                                                         row.Cells["StudentID"].Value + ", " +
                                                         row.Cells["Number Of Correct Answers"].Value + ", " +
                                                         row.Cells["Number Of Incorrect Answers"].Value + ", " +
                                                         row.Cells["Number Of Not Answered Questions"].Value + ") " +
                                                         "ON DUPLICATE KEY UPDATE " +
                                                         "NoOfCorrectQs = VALUES(NoOfCorrectQs), " +
                                                         "NoOfIncorrectQs = VALUES(NoOfIncorrectQs), " +
                                                         "NoOfNotAnsweredQs = VALUES(NoOfNotAnsweredQs); ";

                                connMCQ.Open();
                                commandMCQ.ExecuteNonQuery();
                                connMCQ.Close();
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Check total number of questions!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "LecturerResultsOther":
                        dgvMain.EndEdit();
                        DataTable dataOther = (DataTable)(dgvMain.DataSource);
                        MySqlConnection connOther = new MySqlConnection("Server=" + connection.Server +
                                                        ";Database=" + connection.DB +
                                                        ";Uid=" + connection.UID + ";" +
                                                        "Password=" + connection.Password + ";");
                        MySqlCommand commandOther = connOther.CreateCommand();

                        Boolean isDataOk = true;
                        foreach (DataGridViewRow row in dgvMain.Rows)
                        {
                            if (Int32.Parse(row.Cells["Result (%)"].Value.ToString()) > 100 ||
                                (Int32.Parse(row.Cells["Result (%)"].Value.ToString()) < 0))
                            {
                                MessageBox.Show("Incorrect result value!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                isDataOk = false;
                                break;
                            }
                        }

                        if (isDataOk)
                        {
                            foreach (DataGridViewRow row in dgvMain.Rows)
                            {
                                commandOther.CommandText = "INSERT INTO Other_Assessments_Results (AssessmentID, StudentID, Result) " +
                                                         "VALUES (" + otherID + ", " +
                                                         row.Cells["StudentID"].Value + ", " +
                                                         row.Cells["Result (%)"].Value + ") " +
                                                         "ON DUPLICATE KEY UPDATE " +
                                                         "AssessmentID = VALUES(AssessmentID), " +
                                                         "StudentID = VALUES(StudentID), " +
                                                         "Result = VALUES(Result); ";

                                connOther.Open();
                                commandOther.ExecuteNonQuery();
                                connOther.Close();
                            }
                        }
                        break;
                    case "LecturerModule":
                        dgvMain.EndEdit();
                        bindingSources["dataModule"].EndEdit();
                        dataAdapters["dataModule"].Update((DataTable)bindingSources["dataModule"].DataSource);
                        clearLecturerTree();
                        populateLecturerTree();
                        refreshModuleDetails();
                        break;
                    case "AdminStudents":
                        dgvMain.EndEdit();
                        bindingSources["dataStudents"].EndEdit();
                        dataAdapters["dataStudents"].Update((DataTable)bindingSources["dataStudents"].DataSource);
                        break;
                    case "AdminModules":
                        dgvMain.EndEdit();
                        bindingSources["dataModules"].EndEdit();
                        dataAdapters["dataModules"].Update((DataTable)bindingSources["dataModules"].DataSource);
                        clearLecturerTree();
                        populateLecturerTree();
                        break;
                    case "AdminLecturers":
                        dgvMain.EndEdit();
                        bindingSources["dataLecturers"].EndEdit();
                        dataAdapters["dataLecturers"].Update((DataTable)bindingSources["dataLecturers"].DataSource);
                        clearLecturerTree();
                        populateLecturerTree();
                        break;
                    case "AdminLecturersModules":
                        break;
                    case "AdminStudentsModules":
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnSaveMCQ_Click(object sender, EventArgs e)
        {
            if (totalMarksAvailable == 100)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to overwrite data?", "Save?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dgvMCQ.EndEdit();
                    bindingSources["dataModuleMCQ"].EndEdit();
                    dataAdapters["dataModuleMCQ"].Update((DataTable)bindingSources["dataModuleMCQ"].DataSource);
                    dgvOther.EndEdit();
                    bindingSources["dataModuleOther"].EndEdit();
                    dataAdapters["dataModuleOther"].Update((DataTable)bindingSources["dataModuleOther"].DataSource);
                    clearLecturerTree();
                    populateLecturerTree();
                }
            }
            else 
            {
                MessageBox.Show("Check total marks available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveOthers_Click(object sender, EventArgs e)
        {
            if (totalMarksAvailable == 100)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to overwrite data?", "Save?", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    dgvMCQ.EndEdit();
                    bindingSources["dataModuleMCQ"].EndEdit();
                    dataAdapters["dataModuleMCQ"].Update((DataTable)bindingSources["dataModuleMCQ"].DataSource);
                    dgvOther.EndEdit();
                    bindingSources["dataModuleOther"].EndEdit();
                    dataAdapters["dataModuleOther"].Update((DataTable)bindingSources["dataModuleOther"].DataSource);
                    clearLecturerTree();
                    populateLecturerTree();
                }
            }
            else
            {
                MessageBox.Show("Check total marks available!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("This value must be a number!", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool checkMCQMarks(int NoOfQs)
        {
            Boolean isValid = true;
            int rowNum = 0;
            int total = 0;
            for (int i = 0; i < dgvMain.RowCount; i++)
            {
                if (!String.IsNullOrEmpty(dgvMain.Rows[i].Cells["Number Of Correct Answers"].Value.ToString()) &&
                    !String.IsNullOrEmpty(dgvMain.Rows[i].Cells["Number Of Incorrect Answers"].Value.ToString()) &&
                    !String.IsNullOrEmpty(dgvMain.Rows[i].Cells["Number Of Not Answered Questions"].Value.ToString()))
                {
                    int totalQuestions = Int32.Parse(dgvMain.Rows[i].Cells["Number Of Correct Answers"].Value.ToString()) +
                                            Int32.Parse(dgvMain.Rows[i].Cells["Number Of Incorrect Answers"].Value.ToString()) +
                                            Int32.Parse(dgvMain.Rows[i].Cells["Number Of Not Answered Questions"].Value.ToString());
                    if(totalQuestions>NoOfQs)
                    {
                        isValid = false;
                        total = totalQuestions;
                        rowNum = i;
                    }
                    else if(totalQuestions<NoOfQs)
                    {
                        isValid = false;
                        rowNum = i;
                        total = totalQuestions;
                    }

                    if (totalQuestions == 0)
                    {
                        isValid = true;
                    }
                }
            }

            if (isValid)
            {
                lblWarning.Text = "TOTAL NUMBER OF QUESTIONS: " + NoOfQs;
            } else
            {
                rowNum += 1;
                lblWarning.Text = "TOTAL NUMBER OF QUESTIONS: " + NoOfQs + ". Total number of questions is incorrect - row: " + 
                    rowNum + ", number of questions: " + total;
            }
            return isValid;
        }

        private void checkNumberOfQs() 
        {
            MySqlConnection conn = new MySqlConnection("Server=" + connection.Server +
            ";Database=" + connection.DB +
            ";Uid=" + connection.UID + ";" +
            "Password=" + connection.Password + ";");
            MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT NoOfQs, MarksPerQ, NegativeMarking " +
                "FROM MCQs " +
                "WHERE MCQID = " + MCQID;

            conn.Open();
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                MySqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        int NoOfQs = Int32.Parse(reader["NoOfQs"].ToString());
                        int MarksPerQ = Int32.Parse(reader["MarksPerQ"].ToString());
                        Boolean NegativeMarking = Boolean.Parse(reader["NegativeMarking"].ToString());
                        MCQNoOfQs = NoOfQs;
                        if (checkMCQMarks(NoOfQs) && 
                            !String.IsNullOrEmpty(row.Cells["Number Of Correct Answers"].Value.ToString()) &&
                            !String.IsNullOrEmpty(row.Cells["Number Of Incorrect Answers"].Value.ToString()))
                        {
                            int correct = Int32.Parse(row.Cells["Number Of Correct Answers"].Value.ToString());
                            int incorrect = Int32.Parse(row.Cells["Number Of Incorrect Answers"].Value.ToString());
                            double result = 0;
                            if (NegativeMarking)
                            {
                                result = ((((double)correct * (double)MarksPerQ - (double)incorrect) / ((double)NoOfQs * (double)MarksPerQ))) * 100;
                            }
                            else
                            {
                                result = (((double)correct * (double)MarksPerQ) / ((double)NoOfQs * (double)MarksPerQ)) * 100;
                            }
                            if(result<0)
                            {
                                result = 0;
                            }
                            row.Cells["Result"].Value = Math.Round(result, 2);
                        }
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            conn.Close();
        }

        private void dgvMain_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (nodeSelected == "LecturerModuleMCQ")
            {
                checkNumberOfQs();
            }
        }
    }
}
