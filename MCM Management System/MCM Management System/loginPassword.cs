using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // Add this statement to include MySQL extension.
                              // You are connecting your Windows App as MySQLClient

namespace MCM_Management_System
{
    public partial class loginPassword : Form
    {
        public int attempt = 4;         //attempt counts for login
        public string accountStatus;    //accountStatus
        public loginPassword()
        {
            InitializeComponent();
        }

        private void loginPassword_Load(object sender, EventArgs e)
        {
            //Fill up empty label to current username
            txtUsername.Text = loginUsername.usernameGlobal;

            //Disable and make the Back button invisible 
            //btnBack.Enabled = false;
            //btnBack.Visible = false;

            // Connect to mySQL phpadmin database
            string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
            string Query = "SELECT * from ACCOUNT where username = '" + loginUsername.usernameGlobal + "';";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
            MyConn.Open();
            MySqlDataReader MyReader = MyComd.ExecuteReader();

            // Check account status
            if (MyReader.Read())
            {
                accountStatus = MyReader.GetString("accountStatus");
                if (accountStatus == "Locked") {
                    //Set textbox uneditable and uninteractable by the user.
                    txtPassword.ReadOnly = true;
                    txtPassword.Enabled = false;

                    //Enable and make the Back button visible 
                    btnBack.Enabled = true;
                    btnBack.Visible = true;

                    //Show pop out message
                    MessageBox.Show("Your account is locked. Please contact the system administrator.", "Alert");
                }
            }
            MyReader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (accountStatus == "Active") {
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                string Query = "SELECT * from ACCOUNT where username = '" + loginUsername.usernameGlobal + "' and password = '" + this.txtPassword.Text + "';";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MyConn.Open();
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // If username and password match with database
                if (MyReader.Read()) {

                    if (MyReader.GetString("Role") == "Owner" || MyReader.GetString("Role") == "Assistant Manager")
                    {
                        this.Hide();
                        ownerAssManagerModule windowForm = new ownerAssManagerModule();
                        windowForm.ShowDialog();
                    }
                    else if (MyReader.GetString("Role") == "Operational Manager")
                    {

                        //MessageBox.Show("Operational Manager", "Role Type");
                        //Redirect to opsManagerModule.cs windows form
                        this.Hide();
                        opsManagerModule windowForm = new opsManagerModule();
                        windowForm.ShowDialog();
                    }
                    else if (MyReader.GetString("Role") == "System Administrator")
                    {
                        //MessageBox.Show("System Admin", "Role Type");
                        //Redirect to systemAdminModule.cs windows form
                        this.Hide();
                        systemAdminModule windowForm = new systemAdminModule();
                        windowForm.ShowDialog();
                    }
                }

                // If username and password do not match with database
                else {
                    //If password input is empty
                    if (string.IsNullOrEmpty(txtPassword.Text)) { return; }

                    //If password input is not empty
                    else {
                        attempt--;
                        MessageBox.Show("Password entered is incorrect. You have " + attempt + " attempt(s) left", "Alert");

                        // If user attempts password more than 3 times, lock user account.
                        if (attempt == 0) {
                            MyReader.Close();
                            string Query2 = "UPDATE ACCOUNT set accountstatus = 'Locked' WHERE username = '" + loginUsername.usernameGlobal + "';";
                            MySqlCommand MyComd2 = new MySqlCommand(Query2, MyConn);
                            MySqlDataReader MyReader2 = MyComd.ExecuteReader();
                            MessageBox.Show("Your account is locked. Please contact the system administrator.", "Alert");

                            //Enable and make the Back button visible 
                            btnBack.Enabled = true;
                            btnBack.Visible = true;
                            MyReader2.Close();
                        }
                    }
                }
                MyReader.Close();
                MyConn.Close();

            }
            else if (accountStatus == "Locked") {
                MessageBox.Show("Your account is locked. Please contact the system administrator.", "Alert");
                //Enable and make the Back button visible 
                btnBack.Enabled = true;
                btnBack.Visible = true;
            }
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            //Go back to loginUsername.cs windows form
            this.Hide();
            loginUsername windowForm = new loginUsername();
            windowForm.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Go back to loginUsername.cs windows form
            this.Hide();
            forgotPassword windowForm = new forgotPassword();
            windowForm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}



