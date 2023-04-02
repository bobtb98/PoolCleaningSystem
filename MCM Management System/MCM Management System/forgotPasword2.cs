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
    public partial class forgotPasword2 : Form
    {
        public forgotPasword2()
        {
            InitializeComponent();
        }

        private void forgotPasword2_Load(object sender, EventArgs e)
        {
            this.textBoxUsername.Text = loginUsername.usernameGlobal;
            this.textBoxUsername.ReadOnly = true;
            this.textBoxUsername.Enabled = false;
        }

        private void btnResetPassword2_Click(object sender, EventArgs e)
        {
            try
            {
                // If password textbox is empty.
                if (String.IsNullOrWhiteSpace(textBoxNewPassword.Text) || String.IsNullOrWhiteSpace(textBoxNewPassword2.Text))
                {
                    MessageBox.Show("Password is a required field.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                // If password textbox is not empty.
                else
                {
                    //If both password textboxes have the same value
                    if (this.textBoxNewPassword.Text == this.textBoxNewPassword2.Text)
                    {
                        //To connect to MySQL database
                        string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                        MySqlConnection MyConn = new MySqlConnection(Conn);
                        MyConn.Open();

                        // Set up a SQL query to execute against a database that is tracked by database reader.
                        string Query = "UPDATE ACCOUNT set Password = '" + this.textBoxNewPassword2.Text + "' where Username = '" + loginUsername.usernameGlobal + "';";
                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);

                        //if one row is affected by update
                        if (MyComd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Password sucessfully changed!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                            loginUsername windowForm = new loginUsername();
                            windowForm.ShowDialog();
                        }
                    }
                    //If both password textboxes have different value
                    else
                    {
                        MessageBox.Show("Please reenter new password correctly.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
