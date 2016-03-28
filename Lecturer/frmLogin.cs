using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Lecturer
{
    public partial class frmLogin : Form
    {
        private User user = new User();
        private Connection connection = new Connection();

        internal User User
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

        public frmLogin()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("Server="+connection.Server+
                                                                ";Database="+connection.DB+
                                                                ";Uid="+connection.UID+";" +
                                                                "Password="+connection.Password+";"))
            { 
                try
                {
                    conn.Open();
                    MessageBox.Show("Connection OK", "Connection",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    conn.Dispose();
                }
                catch (MySqlException)
                {
                    MessageBox.Show("Connection error", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                String username = txtName.Text;
                String password = txtPassword.Text;
                MySqlConnection loginConn = new MySqlConnection("Server=" + connection.Server +
                                                            ";Database=" + connection.DB +
                                                            ";Uid=" + connection.UID + ";" +
                                                            "Password=" + connection.Password + ";");
                String loginConnString = "Select * from Lecturers where UserName='" + username +
                                            "' and Password='" + password + "'";
                MySqlDataAdapter loginConnectionAdapter = new MySqlDataAdapter(loginConnString, loginConn);
                DataSet loginConnData = new DataSet();
                loginConnectionAdapter.Fill(loginConnData);
                loginConnectionAdapter.Dispose();

                user.UserID = Convert.ToInt32(loginConnData.Tables[0].Rows[0]["LecturerID"]);
                user.IsAdmin = Convert.ToBoolean(loginConnData.Tables[0].Rows[0]["Admin?"]);
                user.Name = Convert.ToString(loginConnData.Tables[0].Rows[0]["Name"]);
                user.Password = Convert.ToString(loginConnData.Tables[0].Rows[0]["Password"]);
                user.UserName = Convert.ToString(loginConnData.Tables[0].Rows[0]["UserName"]);
                user.Dept = Convert.ToString(loginConnData.Tables[0].Rows[0]["Department"]);

                frmMain.User = this.user;
                this.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Connection error" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Incorrect password or username", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
