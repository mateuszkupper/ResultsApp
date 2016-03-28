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

        }

        private void treeAdmin_AfterSelect(object sender, TreeViewEventArgs e)
        {

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
                if (user.IsAdmin)
                {
                    splitContainer2.Panel2.Enabled = true;
                }
            }
                       
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user.Dispose();
            splitContainer2.Panel1.Enabled = false;
            splitContainer1.Panel2.Enabled = false;
            splitContainer2.Panel2.Enabled = false;
        }
    }
}
