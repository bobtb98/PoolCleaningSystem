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
    public partial class forgotPassword : Form
    {
        public forgotPassword()
        {
            InitializeComponent();

        }

        private void forgotPassword_Load(object sender, EventArgs e)
        {

            //To connect to MySQL database
            string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MyConn.Open();

            // Set up a SQL query to execute against a database that is tracked by database reader.
            string Query = "SELECT * from ACCOUNT where Username = '" + loginUsername.usernameGlobal + "';";
            MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
            MySqlDataReader MyReader = MyComd.ExecuteReader();
            MyReader.Read();

            textBoxUsername.ReadOnly = true;
            textBoxUsername.Enabled = false;
            textBoxUsername.Text = loginUsername.usernameGlobal;

            comboBoxSecretQuestion.Enabled = false;
            comboBoxSecretQuestion.Text = MyReader.GetString("SecretQuestion");
           
            MyReader.Close();
            MyConn.Close();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            try
            {
                // If Answer textbox is empty.
                if (String.IsNullOrWhiteSpace(richTextBoxAnswer.Text))
                {
                    MessageBox.Show("Answer is a required field.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // If Answer textbox is not empty.
                else
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query = "SELECT * from ACCOUNT where SecretQuestion = '" + this.comboBoxSecretQuestion.Text + "' and Answer = '" + this.richTextBoxAnswer.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    //if query matches
                    if (MyReader.Read())
                    {
                        this.Hide();
                        forgotPasword2 windowForm = new forgotPasword2();
                        windowForm.ShowDialog();
                    }
                    //if query do not match
                    else
                    {
                        MessageBox.Show("Answer is incorrect.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                }
            } catch (MySqlException ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
