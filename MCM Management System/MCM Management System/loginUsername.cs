using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Add this statement to include MySQL extension.
                              //You are connecting your Windows App as MySQLClient

namespace MCM_Management_System
{
    public partial class loginUsername : Form
    {
        public static string usernameGlobal;

        public loginUsername()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Connect to mySQL phpmyadmin database
            string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
            string Query = "SELECT * from account where username = '" + this.txtUsername.Text + "';";
            usernameGlobal = this.txtUsername.Text;
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader; 
            MyConn.Open();
            MyReader = MyComd.ExecuteReader();

            // If username match with database
            if (MyReader.Read())
            {
                if (MyReader.GetString("Role") == "Full-Time Staff" || MyReader.GetString("Role") == "Part-Time Staff")
                {
                    MessageBox.Show("Username entered is incorrect.", "Alert");
                    return;
                }
                else
                {
                    //To hide window with username and direct to window with password.
                    this.Hide();
                    loginPassword windowForm = new loginPassword();
                    windowForm.Size = new Size(339, 274);
                    windowForm.ShowDialog();
                }
            }
            // If username do not match with database
            else
            {
                //If username input is empty
                if (string.IsNullOrEmpty(txtUsername.Text)) { return; }

                //If username input is not empty
                else { MessageBox.Show("Username is incorrect", "Alert"); }
            }
            MyReader.Close();
            MyConn.Close();
        }

        private void loginUsername_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
