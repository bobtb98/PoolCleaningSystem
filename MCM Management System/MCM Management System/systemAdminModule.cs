using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient; // Add this statement to include MySQL extension.
                              // You are connecting your Windows App as MySQLClient

namespace MCM_Management_System
{
    public partial class systemAdminModule : Form
    {
        public systemAdminModule()
        {
            InitializeComponent();
        }

        //  When the form systemAdminModule is loaded for the first time, run all statements inside this function
        private void systemAdminModule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sdmDataSet.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.sdmDataSet.employee);
            this.reportViewer1.RefreshReport();

            try
            {
                // To fill up table in Unlock/Lock Account Tabpage with account records.
                // Connect to MySQL Database
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();
                // Run SQL Query against database
                string Query = "select Username, Role, AccountStatus from account;";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                // For offline connection we will use MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyComd;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);
                // Here i have assign dTable object to the dataGridViewAccountStatus object to display data.               
                dataGridViewAccountStatus.DataSource = dTable;
                MyConn.Close(); //Close Connection

                //Set textboxes/comboBoxes read only and uninteractable by the user.
                txtUsername.ReadOnly = true;
                txtUsername.Enabled = false;
                txtRole.ReadOnly = true;
                txtRole.Enabled = false;
                txtStatus.ReadOnly = true;
                txtStatus.Enabled = false;
                textBoxOldPassword2.ReadOnly = true;
                textBoxOldPassword2.Enabled = false;
                comboBoxEmpPosition.Enabled = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //  When the form systemAdminModule top right x button is clicked, run all statements inside this function
        private void systemAdminModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Redirect to loginUsername.cs windows form
            MessageBox.Show("Logging Out...", "Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Hide();
            loginUsername windowForm = new loginUsername();
            windowForm.ShowDialog();
        }

        // Function to clear all textboxes, rich textboxes and comboboxes in Manage Account tabpages
        private void accountClearAll()
        {
            // Clears all texts and combobox in Create Account tab page.
            comboBoxEmployeeID.Text = "";
            comboBoxEmployeeID.SelectedIndex = -1;
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
            textBoxUsername.Text = "";
            richTextBoxAnswer.Text = "";
            comboBoxSecretQuestion.SelectedIndex = -1;
            comboBoxStatus.SelectedIndex = -1;
            comboBoxUserRole.SelectedIndex = -1;

            //Clear all textboxes, rich textboxes and comboboxes in the tabpage
            comboBoxEmployeeID2.Text = "";
            comboBoxEmployeeID2.SelectedIndex = -1;
            this.comboBoxUsername2.Text = "";
            this.comboBoxUsername2.SelectedIndex = -1;
            this.textBoxEmail2.Text = "";
            this.comboBoxStatus2.Text = "";
            this.comboBoxUsername2.SelectedIndex = -1;
            this.textBoxOldPassword2.Text = "";
            this.textBoxNewPassword2.Text = "";
            this.comboBoxSecretQuestion2.SelectedIndex = -1;
            this.richTextBoxAnswer2.Text = "";
            this.comboBoxUserRole2.SelectedIndex = -1;
        }

        // Function to clear all textboxes, rich textboxes and comboboxes in Manage Employee tabpages
        private void employeeClearAll()
        {
            // Control UI Elements in Add Staff page
            textBoxEmpID.Text = "";
            textBoxEmpName.Text = "";
            textBoxEmpAddress.Text = "";
            textBoxEmpPhoneNo.Text = "";
            textBoxEmpAltPhoneNo.Text = "";
            dateTimePickerEmpDOB.Text = "";
            comboBoxEmpMaritalStatus.Text = "";
            comboBoxEmpTitle.Text = "";
            comboBoxEmpPosition.Text = "";
            comboBoxEmpStatus.Text = "";
            dateTimePickerEmpStartDate.Text = "";
            comboBoxEmpSalaryType.Text = "";
            textBoxEmpSalary.Text = "";
            comboBoxEmpSalaryType.SelectedIndex = -1;
            comboBoxEmpTitle.SelectedIndex = -1;
            comboBoxEmpPosition.SelectedIndex = -1;
            comboBoxEmpStatus.SelectedIndex = -1;
            comboBoxEmpMaritalStatus.SelectedIndex = -1;

            // Control UI Elements in Update/Delete Staff page
            comboBoxEmpID.SelectedIndex = -1;
            textBoxEmpName2.Text = "";
            textBoxEmpAddress2.Text = "";
            textBoxEmpPhoneNo2.Text = "";
            textBoxEmpAltPhoneNo2.Text = "";
            dateTimePickerEmpDOB2.Text = "";
            comboBoxEmpMaritalStatus2.Text = "";
            comboBoxEmpTitle2.Text = "";
            comboBoxEmpPosition2.Text = "";
            comboBoxEmpStatus2.Text = "";
            dateTimePickerEmpStartDate2.Text = "";
            comboBoxEmpSalaryType2.Text = "";
            textBoxEmpSalary2.Text = "";
            comboBoxEmpTitle2.SelectedIndex = -1;
            comboBoxEmpPosition2.SelectedIndex = -1;
            comboBoxEmpStatus2.SelectedIndex = -1;
            comboBoxEmpSalaryType2.SelectedIndex = -1;
            comboBoxEmpMaritalStatus2.SelectedIndex = -1;
        }

        // Function to clear all textboxes, rich textboxes and comboboxes in Manage Client tabpages
        private void clientClearAll()
        {
            textBox_Client_Id.Text = "";
            textBox_Client_Name.Text = "";
            textBox_Client_Email.Text = "";
            textBox_Contact_Person.Text = "";
            textBox_Phone_Number.Text = "";
            textBox_Alt_Contact_Person.Text = "";
            textBox_Alt_Phone_Number.Text = "";
            comboBox_Client_Property.SelectedIndex = -1;
            comboBox_Client_Property.Text = "";
            textBox_Address.Text = "";
            comboBox_Client_Pool_Size.SelectedIndex = -1;
            comboBox_Client_Pool_Size.Text = "";
            textBox_Charge_Rate.Text = "";
            textBox_Pool_Remark.Text = "";
            comboBox_Client_Schedule_Type.SelectedIndex = -1;
            textBox_Schedule_Remark.Text = "";
            comboBox_Client_Outdoor_Pool.Text = "";
            comboBox_Client_Outdoor_Pool.SelectedIndex = -1;
            comboBox_Client_Pool_Bar.Text = "";
            comboBox_Client_Pool_Bar.SelectedIndex = -1;
            numericUpDown_Pool_Waterfall.Text = "0";
            numericUpDown_Pool_Waterfall.Text = "";
            numericUpDown_Pool_Slide.Text = "0";
            numericUpDown_Pool_Slide.Text = "";

            comboBox_Client_Id.SelectedIndex = -1;
            textBox_Client_Name2.Text = "";
            textBox_Client_Email2.Text = "";
            textBox_Contact_Person2.Text = "";
            textBox_Phone_Number2.Text = "";
            textBox_Alt_Contact_Person2.Text = "";
            textBox_Alt_Phone_Number2.Text = "";
            comboBox_Client_Property2.SelectedIndex = -1;
            comboBox_Client_Property2.Text = "";
            textBox_Address2.Text = "";
            comboBox_Client_Pool_Size2.SelectedIndex = -1;
            comboBox_Client_Pool_Size2.Text = "";
            textBox_Charge_Rate2.Text = "";
            textBox_Pool_Remark2.Text = "";
            comboBox_Client_Schedule_Type2.SelectedIndex = -1;
            textBox_Schedule_Remark2.Text = "";
            comboBox_Client_Outdoor_Pool2.Text = "";
            comboBox_Client_Outdoor_Pool2.SelectedIndex = -1;
            comboBox_Client_Pool_Bar2.Text = "";
            comboBox_Client_Pool_Bar2.SelectedIndex = -1;
            numericUpDown_Pool_Waterfall2.Text = "0";
            numericUpDown_Pool_Waterfall2.Text = "";
            numericUpDown_Pool_Slide2.Text = "0";
            numericUpDown_Pool_Slide2.Text = "";
        }

        // Function to clear all textboxes, rich textboxes and comboboxes in Manage Job tabpages
        private void jobClearAll()
        {
            textBox_Job_Id.Text = "";
            comboBox_Job_Client_Id.Text = "";
            comboBox_Job_Client_Id.SelectedIndex = -1;
            comboBox_Job_Type.Text = "";
            comboBox_Job_Type.SelectedIndex = -1;
            comboBox_Job_Status.Text = "";
            comboBox_Job_Status.SelectedIndex = -1;
            textBox_Job_Remarks.Text = "";
            comboBox_Job_Emp_Id.Text = "";
            comboBox_Job_Emp_Id.SelectedIndex = -1;
            comboBox_Job_Sup_Emp1_Id.Text = "";
            comboBox_Job_Sup_Emp1_Id.SelectedIndex = -1;
            comboBox_Job_Sup_Emp2_Id.Text = "";
            comboBox_Job_Sup_Emp2_Id.SelectedIndex = -1;
            comboBox_Job_Item_Code.Text = "";
            comboBox_Job_Item_Code.SelectedIndex = -1;
            textBox_Job_Maintenance_Charge.Text = "";
            dateTimePicker_Job_Date.Text = "";

            comboBox_Job_Id.Text = "";
            comboBox_Job_Id.SelectedIndex = -1;
            comboBox_Job_Client_Id2.Text = "";
            comboBox_Job_Client_Id2.SelectedIndex = -1;
            comboBox_Job_Type2.Text = "";
            comboBox_Job_Type2.SelectedIndex = -1;
            comboBox_Job_Status2.Text = "";
            comboBox_Job_Status2.SelectedIndex = -1;
            textBox_Job_Remarks2.Text = "";
            comboBox_Job_Emp_Id2.Text = "";
            comboBox_Job_Emp_Id2.SelectedIndex = -1;
            comboBox_Job_Sup_Emp1_Id2.Text = "";
            comboBox_Job_Sup_Emp1_Id2.SelectedIndex = -1;
            comboBox_Job_Sup_Emp2_Id2.Text = "";
            comboBox_Job_Sup_Emp2_Id2.SelectedIndex = -1;
            comboBox_Job_Item_Code2.Text = "";
            comboBox_Job_Item_Code2.SelectedIndex = -1;
            textBox_Job_Maintenance_Charge2.Text = "";
            dateTimePicker_Job_Date2.Text = "";
        }

        // Function to clear all textboxes, rich textboxes and comboboxes in the Manage Inventory tabpage 
        private void itemClearAll()
        {
            textBox_Item_Code.Text = "";
            comboBox_Item_Category.Text = "";
            comboBox_Item_Category.SelectedIndex = -1;
            textBox_Item_Name.Text = "";
            richTextBox_Item_Description.Text = "";
            numericUpDown_Item_Quantity.Text = "0";

            comboBox_Item_Code.Text = "";
            comboBox_Item_Code.SelectedIndex = -1;
            comboBox_Item_Category2.Text = "";
            comboBox_Item_Category2.SelectedIndex = -1;
            textBox_Item_Name2.Text = "";
            richTextBox_Item_Description2.Text = "";
            numericUpDown_Item_Quantity2.Text = "0";
        }

        // Function to populate combobox controlbox specified by user
        private void populateComboBox(ComboBox comboBox, string query, string column)
        {
            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost ;port=3306 ;username=root ;password= ;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Execute MySQL query against a database that is tracked by database reader.
                MySqlCommand MyComd = new MySqlCommand(query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // Clear combobox 
                comboBox.Items.Clear();

                // While query returns a record.
                // Populate combobox with column specified from arguement
                while (MyReader.Read())
                {
                    string combobox_Client_Pool_Code2 = MyReader.GetString(column);
                    comboBox.Items.Add(combobox_Client_Pool_Code2);
                }
                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /******************************************  TABPAGE MANAGE ACCOUNTS > TABPAGE CREATE ACCOUNTS ******************************************/

        private void comboBoxEmployeeID_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * FROM EMPLOYEE";
            string ColumnName = "EmpID";
            populateComboBox(comboBoxEmployeeID, Query, ColumnName);
        }

        private void btnCreateAcc_Click(object sender, EventArgs e)
        {
            try
            {   //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                if (this.textBoxUsername.Text == "" || this.comboBoxEmployeeID.Text == "" || this.textBoxEmail.Text == "" || this.comboBoxStatus.Text == "" || this.textBoxPassword.Text == "" || this.comboBoxSecretQuestion.Text == "" || this.richTextBoxAnswer.Text == "" || this.comboBoxUserRole.Text == "")
                {
                    MessageBox.Show("All fields are required", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query = "INSERT INTO account (Username, EmpID, Password, Role, Email, AccountStatus, SecretQuestion, Answer) VALUES ('" + this.textBoxUsername.Text + "','" + this.comboBoxEmployeeID.Text + "','" + this.textBoxPassword.Text + "','" + this.comboBoxUserRole.Text + "','" + this.textBoxEmail.Text + "','" + this.comboBoxStatus.Text + "','" + this.comboBoxSecretQuestion.Text + "','" + this.richTextBoxAnswer.Text + "');";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    //ADD IF () ... Else()
                    MessageBox.Show("New Account " + this.textBoxUsername.Text + " created.", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    accountClearAll();
                    MyConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            accountClearAll();
        }


        /******************************************  TABPAGE MANAGE ACCOUNTS > TABPAGE UPDATE/DELETE ACCOUNTS ******************************************/

        private void comboBoxUsername2_Click(object sender, EventArgs e)
        {
            try
            {   //To connect to MySQL database
                string Conn = "datasource=localhost ;port=3306 ;username=root ;password= ;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * from ACCOUNT ;";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyReader = MyComd.ExecuteReader();

                // Clear combobox for Employee ID
                comboBoxUsername2.Items.Clear();

                // While query returns a record.
                // Populate combobox  with employee ID date from database
                while (MyReader.Read())
                {
                    string combobox_Username = MyReader.GetString("Username");
                    comboBoxUsername2.Items.Add(combobox_Username);
                }
                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxEmployeeID2_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * FROM EMPLOYEE";
            string ColumnName = "EmpID";
            populateComboBox(this.comboBoxEmployeeID2, Query, ColumnName);
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            try
            {
                //Populate employee ID comboBox
                populateComboBox(comboBoxEmployeeID2, "SELECT * FROM EMPLOYEE", "EmpID");

                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * FROM ACCOUNT WHERE Username = '" + this.comboBoxUsername2.Text + "';";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // Fill up the textboxes, rich textboxes and comboboxes from records retrieved from query
                if (MyReader.Read())
                {
                    this.textBoxEmail2.Text = MyReader.GetString("Email");
                    this.comboBoxStatus2.Text = MyReader.GetString("AccountStatus");
                    this.textBoxOldPassword2.Text = MyReader.GetString("Password");
                    this.comboBoxSecretQuestion2.Text = MyReader.GetString("SecretQuestion");
                    this.comboBoxEmployeeID2.Text = MyReader.GetString("EmpID");
                    this.richTextBoxAnswer2.Text = MyReader.GetString("Answer");
                    this.comboBoxUserRole2.Text = MyReader.GetString("Role");
                }
                else
                {
                    MessageBox.Show("No records found", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {

            if (this.comboBoxUsername2.Text == "")
            {
                MessageBox.Show("Plesae select a username", "Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query1 = "SELECT * from ACCOUNT WHERE Username = '" + this.comboBoxUsername2.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query1, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    if (MyReader.Read())
                    {
                        // Popout dialog window asking user for yes/no confirmation
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete account " + MyReader.GetString("Username") + "(" + MyReader.GetString("Role") + ") ?", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MyReader.Close();
                            // Set up a SQL query to execute against a database that is tracked by database reader.
                            string Query = "DELETE from ACCOUNT WHERE Username = '" + this.comboBoxUsername2.Text + "';";
                            MyComd = new MySqlCommand(Query, MyConn);
                            MyReader = MyComd.ExecuteReader();
                            MyReader.Close();
                            MessageBox.Show("Record account " + this.comboBoxUsername2.Text + " deleted", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                            accountClearAll();
                            MyReader.Close();
                            MyConn.Close();
                        }

                        else if (dialogResult == DialogResult.No)
                        {
                            MyReader.Close();
                            MyConn.Close();
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

        private void btnUpdate2_Click(object sender, EventArgs e)
        {
            if (this.comboBoxUsername2.Text == "" || this.comboBoxEmployeeID2.Text == "" || this.textBoxEmail2.Text == "" || this.comboBoxStatus2.Text == "" || this.textBoxOldPassword2.Text == "" || this.comboBoxSecretQuestion2.Text == "" || this.richTextBoxAnswer2.Text == "" || this.comboBoxUserRole2.Text == "")
            {
                MessageBox.Show("All fields are required except new password field. Please fill up required fields", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    //if user did not enter a new password for user account
                    if (String.IsNullOrWhiteSpace(this.textBoxNewPassword2.Text))
                    {
                        string Query = "UPDATE account set Username='" + this.comboBoxUsername2.Text + "',EmpID='" + this.comboBoxEmployeeID2.Text + "',Role='" + this.comboBoxUserRole2.Text + "',Email='" + this.textBoxEmail2.Text + "',AccountStatus='" + this.comboBoxStatus2.Text + "',SecretQuestion='" + this.comboBoxSecretQuestion2.Text + "',Answer='" + this.richTextBoxAnswer2.Text + "' where Username='" + this.comboBoxUsername2.Text + "';";
                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader;
                        MyReader = MyComd.ExecuteReader();
                        MessageBox.Show("Record account" + this.comboBoxUsername2.Text + " updated", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyReader.Close();
                    }
                    //if user has entered new password for user account
                    else
                    {
                        //if new password box is left empty
                        string Query = "UPDATE account set Username='" + this.comboBoxUsername2.Text + "',EmpID='" + this.comboBoxEmployeeID2.Text + "',Password='" + this.textBoxNewPassword2.Text + "',Role='" + this.comboBoxUserRole2.Text + "',Email='" + this.textBoxEmail2.Text + "',AccountStatus='" + this.comboBoxStatus2.Text + "',SecretQuestion='" + this.comboBoxSecretQuestion2.Text + "',Answer='" + this.richTextBoxAnswer2.Text + "' where Username='" + this.comboBoxUsername2.Text + "';";
                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader;
                        MyReader = MyComd.ExecuteReader();
                        MessageBox.Show("Record account" + this.comboBoxUsername2.Text + " updated", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MyReader.Close();
                    }
                    //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                    accountClearAll();
                    MyConn.Close();//Connection closed here  
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnClear2_Click(object sender, EventArgs e)
        {
            accountClearAll();
        }


        /******************************************  TABPAGE MANAGE ACCOUNTS > TABPAGE UNLOCK/LOCK ACCOUNTS ******************************************/
        private void dataGridViewAccountStatus_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //DataGridViewAccountStatus(datagridViewRow) has dataset already extracted from MySQL database.
                //Double click on a row data will populate data on the textboxes.
                DataGridViewRow rowIndex = dataGridViewAccountStatus.Rows[e.RowIndex];
                txtUsername.Text = rowIndex.Cells[0].Value.ToString();
                txtRole.Text = rowIndex.Cells[1].Value.ToString();
                txtStatus.Text = rowIndex.Cells[2].Value.ToString();

                //Change button name according to user account status
                if (txtStatus.Text == "Active")
                {
                    btnAccLockUnlock.Text = "Lock Account";
                }
                else if (txtStatus.Text == "Locked")
                {
                    btnAccLockUnlock.Text = "Unlock Account";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccLockUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to MySQL Database
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                //if button lock account is clicked
                if (btnAccLockUnlock.Text == "Lock Account")
                {
                    string Query = "UPDATE account set AccountStatus = 'Locked' where Username='" + this.txtUsername.Text + "' and AccountStatus ='" + this.txtStatus.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    int noRowsAffected = MyComd.ExecuteNonQuery();
                    if (noRowsAffected == 1)
                    {
                        MessageBox.Show("Account " + this.txtUsername.Text + " is locked.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //if button unlock account is clicked
                else if (btnAccLockUnlock.Text == "Unlock Account")
                {
                    string Query2 = "UPDATE account set AccountStatus = 'Active' where Username='" + this.txtUsername.Text + "' and AccountStatus ='" + this.txtStatus.Text + "';";
                    MySqlCommand MyComd2 = new MySqlCommand(Query2, MyConn);
                    int noRowsAffected = MyComd2.ExecuteNonQuery();
                    if (noRowsAffected == 1)
                    {
                        MessageBox.Show("Account " + this.txtUsername.Text + " is unlocked.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                MyConn.Close();//Connection closed here  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to MySQL Database and run query
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                string Query = "select Username, Role, AccountStatus from account;";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);

                //For offline connection we will use MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyComd;
                DataTable dTable = new DataTable();
                MyAdapter.Fill(dTable);

                // Here i have assign dTable object to the dataGridViewAccountStatus object to display data.               
                dataGridViewAccountStatus.DataSource = dTable;

                MyConn.Close(); //Close Connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /******************************************** MANAGE EMPLOYEE > ADD EMPLOYEE ******************************************/
        private void btnStaffClear_Click(object sender, EventArgs e)
        {
            employeeClearAll();
        }

        private void comboBoxEmpTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] array = new string[] { "Owner", "Assistant Manager", "System Administrator", "Operational Manager" };
            string[] array2 = new string[] { "Pool Maintenance Staff" };
            comboBoxEmpPosition.Items.Clear();
            comboBoxEmpPosition.Enabled = true;

            if (comboBoxEmpTitle.Text == "Manager")
            {
                for (int i = 0; i < array.Count(); i++)
                {
                    this.comboBoxEmpPosition.Items.Add(array[i]);
                }
            }
            else if (comboBoxEmpTitle.Text == "Staff")
            {
                for (int i = 0; i < array2.Count(); i++)
                {
                    this.comboBoxEmpPosition.Items.Add(array2[i]);
                }
            }
        }

        private void btnStaffAdd_Click(object sender, EventArgs e)
        {
            try
            {   //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                if (this.textBoxEmpID.Text == "" || this.textBoxEmpName.Text == "" || this.textBoxEmpAddress.Text == "" || this.textBoxEmpPhoneNo.Text == "" ||
                    this.dateTimePickerEmpDOB.Text == null || this.comboBoxEmpMaritalStatus.Text == "" || this.comboBoxEmpTitle.Text == "" || this.comboBoxEmpPosition.Text == "" ||
                    this.comboBoxEmpStatus.Text == "" || this.dateTimePickerEmpStartDate.Text == "" || this.comboBoxEmpSalaryType.Text == "" || this.textBoxEmpSalary.Text == "")
                {
                    MessageBox.Show("Please enter all required fields.\nAlternate Phone Number is optional", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query = "INSERT into EMPLOYEE (EmpID, FName, Address, PhoneNo, AltPhoneNo, DOB, MaritalStatus, Title, Position, Status, StartDate, SalaryType, Salary) VALUES ('" +
                        this.textBoxEmpID.Text + "','" + this.textBoxEmpName.Text + "','" + this.textBoxEmpAddress.Text + "','" + this.textBoxEmpPhoneNo.Text + "','" + this.textBoxEmpAltPhoneNo.Text + "','" +
                        this.dateTimePickerEmpDOB.Text + "','" + this.comboBoxEmpMaritalStatus.Text + "','" + this.comboBoxEmpTitle.Text + "','" + this.comboBoxEmpPosition.Text + "','" +
                        this.comboBoxEmpStatus.Text + "','" + this.dateTimePickerEmpStartDate.Text + "','" + this.comboBoxEmpSalaryType.Text + "','" + decimal.Parse(this.textBoxEmpSalary.Text) + "');";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    //ADD IF () ... Else()
                    MessageBox.Show("New Staff " + this.textBoxEmpName.Text + " added.", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    employeeClearAll();
                    MyConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /******************************************** MANAGE EMPLOYEE > UPDATE/DELETE EMPLOYEE ******************************************/
        private void comboBoxEmpID_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from EMPLOYEE;";
            string ColumnName = "EmpID";
            populateComboBox(comboBoxEmpID, Query, ColumnName);
        }

        private void btnStaffSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * from EMPLOYEE WHERE EmpID = '" + this.comboBoxEmpID.Text + "';";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // Fill up the textboxes, rich textboxes and comboboxes from records retrieved from query
                if (MyReader.Read())
                {
                    textBoxEmpName2.Text = MyReader.GetString("FName");
                    textBoxEmpAddress2.Text = MyReader.GetString("Address");
                    textBoxEmpPhoneNo2.Text = MyReader.GetString("PhoneNo");
                    textBoxEmpAltPhoneNo2.Text = MyReader.GetString("AltPhoneNo");
                    dateTimePickerEmpDOB2.Text = MyReader.GetString("DOB");
                    comboBoxEmpMaritalStatus2.Text = MyReader.GetString("MaritalStatus");
                    comboBoxEmpTitle2.Text = MyReader.GetString("Title");
                    comboBoxEmpStatus2.Text = MyReader.GetString("Status");
                    dateTimePickerEmpStartDate2.Text = MyReader.GetString("StartDate");
                    comboBoxEmpSalaryType2.Text = MyReader.GetString("SalaryType");
                    textBoxEmpSalary2.Text = MyReader.GetString("Salary");
                    comboBoxEmpPosition2.Text = MyReader.GetString("Position");

                }
                else
                {
                    MessageBox.Show("No records found", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxEmpTitle2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] array = new string[] { "Owner", "Assistant Manager", "System Administrator", "Operational Manager" };
            string[] array2 = new string[] { "Pool Maintenance Staff" };
            comboBoxEmpPosition2.Items.Clear();
            comboBoxEmpPosition2.Enabled = true;

            if (comboBoxEmpTitle2.Text == "Manager")
            {
                for (int i = 0; i < array.Count(); i++)
                {
                    this.comboBoxEmpPosition2.Items.Add(array[i]);
                }
            }
            else if (comboBoxEmpTitle2.Text == "Staff")
            {
                for (int i = 0; i < array2.Count(); i++)
                {
                    this.comboBoxEmpPosition2.Items.Add(array2[i]);
                }
            }
        }

        private void btnStaffUpdate_Click(object sender, EventArgs e)
        {
            if (this.textBoxEmpName2.Text == "" || this.textBoxEmpAddress2.Text == "" || this.textBoxEmpPhoneNo2.Text == "" || this.comboBoxEmpMaritalStatus2.Text == "" ||
                 this.comboBoxEmpTitle2.Text == "" || this.comboBoxEmpPosition2.Text == "" || this.comboBoxEmpStatus2.Text == "" || this.comboBoxEmpSalaryType2.Text == "" ||
                 this.textBoxEmpSalary2.Text == "")
            {
                MessageBox.Show("Please fill up all required fields. \nAlternate Phone Number is optional.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    //Set and execute query to database.
                    string Query = "UPDATE employee set EmpID='" + int.Parse(this.comboBoxEmpID.Text) + "',FName='" + this.textBoxEmpName2.Text + "',Address='" + this.textBoxEmpAddress2.Text +
                                   "',PhoneNo='" + this.textBoxEmpPhoneNo2.Text + "',AltPhoneNo='" + this.textBoxEmpAltPhoneNo2.Text + "',DOB='" + this.dateTimePickerEmpDOB2.Text + "',MaritalStatus='" + this.comboBoxEmpMaritalStatus2.Text +
                                   "',Title='" + this.comboBoxEmpTitle2.Text + "',Position='" + this.comboBoxEmpPosition2.Text + "',Status='" + this.comboBoxEmpStatus2.Text + "',StartDate='" + this.dateTimePickerEmpStartDate2.Text +
                                   "',SalaryType='" + this.comboBoxEmpSalaryType2.Text + "',Salary='" + decimal.Parse(this.textBoxEmpSalary2.Text) + "' where EmpID='" + int.Parse(this.comboBoxEmpID.Text) + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyReader = MyComd.ExecuteReader();
                    MessageBox.Show("Record employee " + this.textBoxEmpName2.Text + "( Employee ID: " + this.comboBoxEmpID.Text + " ) updated", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyReader.Close();


                    //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                    employeeClearAll();
                    MyConn.Close();//Connection closed here  
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnStaffDelete_Click(object sender, EventArgs e)
        {
            if (this.comboBoxEmpID.Text == "")
            {
                MessageBox.Show("Plesae select an Employee ID", "Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query1 = "SELECT * from Employee WHERE EmpID = '" + this.comboBoxEmpID.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query1, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    if (MyReader.Read())
                    {
                        // Popout dialog window asking user for yes/no confirmation
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete employee " + MyReader.GetString("FName") + "(Employee ID: " + MyReader.GetString("EmpID") + ") record?", "Delete Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MyReader.Close();
                            // Set up a SQL query to execute against a database that is tracked by database reader.
                            string Query = "DELETE from Employee WHERE EmpID = '" + this.comboBoxEmpID.Text + "';";
                            MyComd = new MySqlCommand(Query, MyConn);
                            MyReader = MyComd.ExecuteReader();
                            MyReader.Close();
                            MessageBox.Show("Record employee " + this.textBoxEmpName2.Text + "(Employee ID: " + this.comboBoxEmpID.Text + ")" + " deleted", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                            employeeClearAll();
                            MyReader.Close();
                            MyConn.Close();
                        }

                        else if (dialogResult == DialogResult.No)
                        {
                            MyReader.Close();
                            MyConn.Close();
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

        private void btnStaffClear2_Click(object sender, EventArgs e)
        {
            employeeClearAll();
        }


        //************************************************** MANAGE CLIENT > ADD CLIENT TABPAGE *******************************************//
        private void comboBox_Client_Pool_Size_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.comboBox_Client_Pool_Size.Text == "Small")
            {
                this.textBox_Charge_Rate.Text = "200";
            }
            else if (this.comboBox_Client_Pool_Size.Text == "Medium")
            {
                this.textBox_Charge_Rate.Text = "300";

            }
            else if (this.comboBox_Client_Pool_Size.Text == "Large")
            {
                this.textBox_Charge_Rate.Text = "400";

            }
            else if (this.comboBox_Client_Pool_Size.Text == "Complex")
            {
                this.textBox_Charge_Rate.Text = "600";
            }
        }

        private void button_Client_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                decimal addChargeTotal = 0;
                decimal waterfallCharge = 500;
                decimal slideCharge = 100;
                decimal poolBarCharge = 700;
                decimal outdoorPoolCharge = 200;
                int numOfPoolBar = 0;
                int numOfOutdoorPool = 0;

                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                //If any required fields are left blank 
                if (this.textBox_Client_Id.Text == "" || this.textBox_Client_Name.Text == "" || this.textBox_Client_Email.Text == "" || this.textBox_Contact_Person.Text == "" ||
                    this.textBox_Phone_Number.Text == null || this.comboBox_Client_Property.Text == "" || this.textBox_Address.Text == "" || this.comboBox_Client_Pool_Size.Text == "" || this.textBox_Charge_Rate.Text == "" ||
                    this.comboBox_Client_Schedule_Type.Text == "")
                {
                    MessageBox.Show("Please enter all required fields.\nAlternate contact person, phone number, pool bar, outdoor pool, waterfall, slides, pool remarks and schedule remarks are optional.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //If all required fields are filled.
                else
                {
                    if (this.comboBox_Client_Pool_Bar.Text == "Yes")
                    {
                        addChargeTotal += poolBarCharge;
                        numOfPoolBar = 1;
                    }
                    if (this.comboBox_Client_Outdoor_Pool.Text == "Yes")
                    {
                        addChargeTotal += outdoorPoolCharge;
                        numOfOutdoorPool = 1;
                    }
                    if (this.numericUpDown_Pool_Slide.Text != "")
                    {
                        addChargeTotal += slideCharge * int.Parse(this.numericUpDown_Pool_Slide.Text);
                    }
                    if (this.numericUpDown_Pool_Waterfall.Text != "")
                    {
                        addChargeTotal += waterfallCharge * int.Parse(this.numericUpDown_Pool_Waterfall.Text);
                    }

                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query = "INSERT INTO CLIENT (ClientID, ClientName, ClientEmail, ContactPerson, PhoneNo, AltContactPerson, AltPhoneNo ,Property ,Address ,PoolSize ,ChargeRate ,NumOfPoolBar, NumOfOutdoorPool, NumOfWaterfall, NumOfSlide, AddCharge ,PoolRemarks, ScheduleType, ScheduleRemarks) " +
                        "VALUES ('" + int.Parse(this.textBox_Client_Id.Text) + "','" + this.textBox_Client_Name.Text + "','" + this.textBox_Client_Email.Text + "','" + this.textBox_Contact_Person.Text + "','"
                                    + this.textBox_Phone_Number.Text + "','" + this.textBox_Alt_Contact_Person.Text + "','" + textBox_Alt_Phone_Number.Text + "','" + this.comboBox_Client_Property.Text + "','" + this.textBox_Address.Text + "','"
                                    + this.comboBox_Client_Pool_Size.Text + "','" + decimal.Parse(this.textBox_Charge_Rate.Text) + "','" + numOfPoolBar + "','" + numOfOutdoorPool + "','" + int.Parse(this.numericUpDown_Pool_Waterfall.Text) + "','" + int.Parse(this.numericUpDown_Pool_Slide.Text) + "','" + addChargeTotal + "','" + this.textBox_Pool_Remark.Text + "','" + this.comboBox_Client_Schedule_Type.Text + "','" + this.textBox_Schedule_Remark.Text + "');";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    MessageBox.Show("Record client " + this.textBox_Client_Name.Text + "(Client ID: " + this.textBox_Client_Id.Text + ") added", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clientClearAll();
                    MyConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Client_CLEAR_Click(object sender, EventArgs e)
        {
            clientClearAll();

        }


        //************************************************** MANAGE CLIENT > UPDATE/UPDATE CLIENT TABPAGE *******************************************//
        private void comboBox_Client_Id_Click(object sender, EventArgs e)
        {
            // Populate comboBox ClientID
            string Query = "SELECT* from CLIENT; ";
            string ColumnName = "ClientID";
            populateComboBox(comboBox_Client_Id, Query, ColumnName);
        }

        private void button_SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * FROM CLIENT WHERE ClientID = '" + this.comboBox_Client_Id.Text + "';";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // Fill up the textboxes, rich textboxes and comboboxes from records retrieved from query
                if (MyReader.Read())
                {
                    this.textBox_Client_Name2.Text = MyReader.GetString("ClientName");
                    this.textBox_Client_Email2.Text = MyReader.GetString("ClientEmail");
                    this.textBox_Contact_Person2.Text = MyReader.GetString("ContactPerson");
                    this.textBox_Phone_Number2.Text = MyReader.GetString("PhoneNo");
                    this.textBox_Alt_Contact_Person2.Text = MyReader.GetString("AltContactPerson");
                    this.textBox_Alt_Phone_Number2.Text = MyReader.GetString("AltPhoneNo");
                    this.comboBox_Client_Property2.Text = MyReader.GetString("Property");
                    this.textBox_Address2.Text = MyReader.GetString("Address");
                    this.comboBox_Client_Pool_Size2.Text = MyReader.GetString("PoolSize");
                    this.textBox_Charge_Rate2.Text = MyReader.GetString("ChargeRate");
                    if (MyReader.GetInt32("NumOfOutdoorPool") == 1)
                    {
                        this.comboBox_Client_Outdoor_Pool2.Text = "Yes";
                    }
                    else
                    {
                        this.comboBox_Client_Outdoor_Pool2.Text = "No";
                    }
                    if (MyReader.GetInt32("NumOfPoolBar") == 1)
                    {
                        this.comboBox_Client_Pool_Bar2.Text = "Yes";
                    }
                    else
                    {
                        this.comboBox_Client_Pool_Bar2.Text = "No";
                    }
                    this.numericUpDown_Pool_Waterfall2.Text = MyReader.GetString("NumOfWaterfall");
                    this.numericUpDown_Pool_Slide2.Text = MyReader.GetString("NumOfSlide");
                    this.textBox_Pool_Remark2.Text = MyReader.GetString("PoolRemarks");
                    this.comboBox_Client_Schedule_Type2.Text = MyReader.GetString("ScheduleType");
                    this.textBox_Schedule_Remark2.Text = MyReader.GetString("ScheduleRemarks");

                }
                else
                {
                    MessageBox.Show("No records found", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_Client_Pool_Size2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.comboBox_Client_Pool_Size2.Text == "Small")
            {
                this.textBox_Charge_Rate2.Text = "200";
            }
            else if (this.comboBox_Client_Pool_Size2.Text == "Medium")
            {
                this.textBox_Charge_Rate2.Text = "300";

            }
            else if (this.comboBox_Client_Pool_Size2.Text == "Large")
            {
                this.textBox_Charge_Rate2.Text = "400";

            }
            else if (this.comboBox_Client_Pool_Size2.Text == "Complex")
            {
                this.textBox_Charge_Rate2.Text = "600";
            }
        }

        private void button_UPDATE_Click(object sender, EventArgs e)
        {
            decimal addChargeTotal = 0;
            decimal waterfallCharge = 500;
            decimal slideCharge = 100;
            decimal poolBarCharge = 700;
            decimal outdoorPoolCharge = 200;
            int numOfPoolBar = 0;
            int numOfOutdoorPool = 0;

            if (this.comboBox_Client_Id.Text == "" || this.textBox_Client_Name2.Text == "" || this.textBox_Client_Email2.Text == "" || this.textBox_Contact_Person2.Text == "" ||
                this.textBox_Phone_Number2.Text == "" || this.comboBox_Client_Property2.Text == "" || this.textBox_Address2.Text == "" || this.comboBox_Client_Pool_Size2.Text == "" || this.textBox_Charge_Rate2.Text == "" ||
                this.comboBox_Client_Schedule_Type2.Text == "")
            {
                MessageBox.Show("Please fill up all required fields. \nAlternate contact person, alternate phone number,pool bar, outdoor pool, waterfall, slide, pool remarks and schedule remarks are optional.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    if (this.comboBox_Client_Pool_Bar2.Text == "Yes")
                    {
                        addChargeTotal += poolBarCharge;
                        numOfPoolBar = 1;
                    }
                    if (this.comboBox_Client_Outdoor_Pool2.Text == "Yes")
                    {
                        addChargeTotal += outdoorPoolCharge;
                        numOfOutdoorPool = 1;
                    }
                    if (this.numericUpDown_Pool_Slide2.Text != "")
                    {
                        addChargeTotal += slideCharge * int.Parse(this.numericUpDown_Pool_Slide2.Text);
                    }
                    if (this.numericUpDown_Pool_Waterfall2.Text != "")
                    {
                        addChargeTotal += waterfallCharge * int.Parse(this.numericUpDown_Pool_Waterfall2.Text);
                    }

                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    //Prepare update MySQL query and run it against the database
                    string Query = "UPDATE CLIENT set ClientID='" + int.Parse(this.comboBox_Client_Id.Text) + "',ClientName='" + this.textBox_Client_Name2.Text + "',ClientEmail='"
                                                                  + this.textBox_Client_Email2.Text + "',ContactPerson='" + this.textBox_Contact_Person2.Text + "',PhoneNo='" + this.textBox_Phone_Number2.Text
                                                                  + "',AltContactPerson='" + this.textBox_Alt_Contact_Person2.Text + "',AltPhoneNo='" + this.textBox_Alt_Phone_Number2.Text + "',Property='" + this.comboBox_Client_Property2.Text + 
                                                                  "',Address='" + this.textBox_Address2.Text + "', PoolSize='" + this.comboBox_Client_Pool_Size2.Text + "', ChargeRate='" + decimal.Parse(this.textBox_Charge_Rate2.Text)
                                                                  + "', NumOfPoolBar='" + numOfPoolBar + "', NumOfOutdoorPool='" + numOfOutdoorPool + "', NumOfWaterfall='" + int.Parse(this.numericUpDown_Pool_Waterfall2.Text)
                                                                  + "', NumOfSlide='" + int.Parse(this.numericUpDown_Pool_Slide2.Text) + "', AddCharge='" + addChargeTotal + "', PoolRemarks='" + this.textBox_Pool_Remark2.Text + "', ScheduleType='"
                                                                  + this.comboBox_Client_Schedule_Type2.Text + "', ScheduleRemarks='" + this.textBox_Schedule_Remark2.Text + "' where ClientID='" + int.Parse(this.comboBox_Client_Id.Text) + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyReader = MyComd.ExecuteReader();
                    MessageBox.Show("Record client " + this.textBox_Client_Name2.Text + "(ClientID: " + this.comboBox_Client_Id.Text + ") updated", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyReader.Close();

                    //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                    clientClearAll();
                    MyConn.Close();//Connection closed here  
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_DELETE_Click(object sender, EventArgs e)
        {
            if (this.comboBox_Client_Id.Text == "")
            {
                MessageBox.Show("Plesae select a Client ID", "Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query1 = "SELECT * from CLIENT WHERE ClientID = '" + this.comboBox_Client_Id.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query1, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    if (MyReader.Read())
                    {
                        // Popout dialog window asking user for yes/no confirmation
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete client " + MyReader.GetString("ClientName") + "(Client ID: " + MyReader.GetString("ClientID") + ") record?", "Delete Client", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MyReader.Close();
                            // Set up a SQL query to execute against a database that is tracked by database reader.
                            string Query = "DELETE from CLIENT WHERE ClientID = '" + this.comboBox_Client_Id.Text + "';";
                            MyComd = new MySqlCommand(Query, MyConn);
                            MyReader = MyComd.ExecuteReader();
                            MyReader.Close();
                            MessageBox.Show("Record client " + this.textBox_Client_Name2.Text + " deleted", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                            clientClearAll();
                            MyReader.Close();
                            MyConn.Close();
                        }

                        else if (dialogResult == DialogResult.No)
                        {
                            MyReader.Close();
                            MyConn.Close();
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

        private void button_CLEAR2_Click(object sender, EventArgs e)
        {
            clientClearAll();
        }


        /********************************************* MANAGE JOB > ADD JOB ********************************************************/
        private void comboBox_Job_Client_Id_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from CLIENT";
            string ColumnName = "ClientID";
            populateComboBox(comboBox_Job_Client_Id, Query, ColumnName);
        }

        private void comboBox_Job_Client_Id_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * FROM CLIENT WHERE ClientID = '" + this.comboBox_Job_Client_Id.Text + "';";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // To enable/disable the number of employees assigned to job
                if (MyReader.Read())
                {

                    if (MyReader.GetString("PoolSize") == "Small")
                    {
                        this.comboBox_Job_Sup_Emp1_Id.Enabled = false;
                        this.comboBox_Job_Sup_Emp2_Id.Enabled = false;
                    }
                    else if (MyReader.GetString("PoolSize") == "Medium" || MyReader.GetString("PoolSize") == "Large")
                    {
                        this.comboBox_Job_Sup_Emp1_Id.Enabled = true;
                        this.comboBox_Job_Sup_Emp2_Id.Enabled = false;
                    }
                    else if (MyReader.GetString("PoolSize") == "Complex")
                    {
                        this.comboBox_Job_Sup_Emp1_Id.Enabled = true;
                        this.comboBox_Job_Sup_Emp2_Id.Enabled = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_Job_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Job_Type.Text == "Cleaning")
            {
                this.textBox_Job_Maintenance_Charge.Enabled = false;
                this.textBox_Job_Maintenance_Charge.ReadOnly = true;

            }
            else if (this.comboBox_Job_Type.Text == "Maintenance")
            {
                this.textBox_Job_Maintenance_Charge.Enabled = true;
                this.textBox_Job_Maintenance_Charge.ReadOnly = false;
            }
        }

        private void comboBox_Job_Emp_Id_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from EMPLOYEE WHERE Title= 'Staff'";
            string ColumnName = "EmpID";
            populateComboBox(comboBox_Job_Emp_Id, Query, ColumnName);
        }

        private void comboBox_Job_Sup_Emp1_Id_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from EMPLOYEE WHERE Title= 'Staff'";
            string ColumnName = "EmpID";
            populateComboBox(comboBox_Job_Sup_Emp1_Id, Query, ColumnName);
        }

        private void comboBox_Job_Sup_Emp2_Id_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from EMPLOYEE WHERE Title= 'Staff'";
            string ColumnName = "EmpID";
            populateComboBox(comboBox_Job_Sup_Emp2_Id, Query, ColumnName);
        }

        private void comboBox_Job_Item_Code_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from INVENTORY";
            string ColumnName = "ItemCode";
            populateComboBox(comboBox_Job_Item_Code, Query, ColumnName);
        }

        private void button_Job_ADD_Click(object sender, EventArgs e)
        {
            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                //If any required fields are left blank 
                if (this.textBox_Job_Id.Text == "" || this.comboBox_Job_Client_Id.Text == "" || this.comboBox_Job_Type.Text == "" || this.comboBox_Job_Status.Text == "" ||
                    this.comboBox_Job_Emp_Id.Text == null || this.comboBox_Job_Item_Code.Text == "" || this.dateTimePicker_Job_Date.Text == "")
                {
                    MessageBox.Show("Please enter all required fields.\nJob remarks and maintenance charge are optional.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //If all required fields are filled.
                else
                {
                    if (this.comboBox_Job_Type.Text == "Maintenance")
                    {
                        if (this.textBox_Job_Maintenance_Charge.Text == "" || this.textBox_Job_Remarks.Text == "")
                        {
                            MessageBox.Show("Please fill up job remarks and maintenance charge.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    if (string.IsNullOrEmpty(this.textBox_Job_Maintenance_Charge.Text))
                    {
                        this.textBox_Job_Maintenance_Charge.Text = "0";
                    }

                    string Query;
                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    // If 3 employees are assigned to job
                    if (comboBox_Job_Emp_Id.Enabled == true && comboBox_Job_Sup_Emp1_Id.Enabled == true && comboBox_Job_Sup_Emp2_Id.Enabled == true)
                    {
                        Query = "INSERT INTO JOBS (JobID, ClientID, JobType, JobStatus, JobRemarks, EmpID, SupEmpID, SupEmpID2, ItemCode , MaintenanceCharge , date) " +
                           "VALUES ('" + int.Parse(this.textBox_Job_Id.Text) + "','" + int.Parse(this.comboBox_Job_Client_Id.Text) + "','" + this.comboBox_Job_Type.Text + "','" + this.comboBox_Job_Status.Text + "','"
                                       + this.textBox_Job_Remarks.Text + "','" + int.Parse(this.comboBox_Job_Emp_Id.Text) + "','" + int.Parse(this.comboBox_Job_Sup_Emp1_Id.Text) + "','" + int.Parse(this.comboBox_Job_Sup_Emp2_Id.Text)
                                       + "','" + int.Parse(comboBox_Job_Item_Code.Text) + "','" + decimal.Parse(textBox_Job_Maintenance_Charge.Text) + "','" + this.dateTimePicker_Job_Date.Text + "');";
                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyComd.ExecuteReader();
                    }
                    // If 2 employees are assigned to job
                    else if (comboBox_Job_Emp_Id.Enabled == true && comboBox_Job_Sup_Emp1_Id.Enabled == true && comboBox_Job_Sup_Emp2_Id.Enabled == false)
                    {
                        Query = "INSERT INTO JOBS (JobID, ClientID, JobType, JobStatus, JobRemarks, EmpID, SupEmpID, ItemCode , MaintenanceCharge , date) " +
                          "VALUES ('" + int.Parse(this.textBox_Job_Id.Text) + "','" + int.Parse(this.comboBox_Job_Client_Id.Text) + "','" + this.comboBox_Job_Type.Text + "','" + this.comboBox_Job_Status.Text + "','"
                                      + this.textBox_Job_Remarks.Text + "','" + int.Parse(this.comboBox_Job_Emp_Id.Text) + "','" + int.Parse(this.comboBox_Job_Sup_Emp1_Id.Text) + "','" +
                                      +int.Parse(comboBox_Job_Item_Code.Text) + "','" + decimal.Parse(textBox_Job_Maintenance_Charge.Text) + "','" + this.dateTimePicker_Job_Date.Text + "');";
                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyComd.ExecuteReader();
                    }
                    // If 1 employees are assigned to job
                    else if (comboBox_Job_Emp_Id.Enabled == true && comboBox_Job_Sup_Emp1_Id.Enabled == false && comboBox_Job_Sup_Emp2_Id.Enabled == false)
                    {
                        Query = "INSERT INTO JOBS (JobID, ClientID, JobType, JobStatus, JobRemarks, EmpID, ItemCode , MaintenanceCharge , date) " +
                           "VALUES ('" + int.Parse(this.textBox_Job_Id.Text) + "','" + int.Parse(this.comboBox_Job_Client_Id.Text) + "','" + this.comboBox_Job_Type.Text + "','" + this.comboBox_Job_Status.Text + "','"
                                       + this.textBox_Job_Remarks.Text + "','" + int.Parse(this.comboBox_Job_Emp_Id.Text) + "','" +
                                       +int.Parse(comboBox_Job_Item_Code.Text) + "','" + decimal.Parse(textBox_Job_Maintenance_Charge.Text) + "','" + this.dateTimePicker_Job_Date.Text + "');";
                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyComd.ExecuteReader();
                    }

                    MessageBox.Show("Record Job ID " + this.textBox_Job_Id.Text + "(" + this.comboBox_Job_Type.Text + ") added", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    jobClearAll();
                    MyConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Job_CLEAR_Click(object sender, EventArgs e)
        {
            jobClearAll();
        }


        /********************************************* MANAGE JOB > UDPATE/DELETE JOB ********************************************************/
        private void comboBox_Job_Id_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from JOBS";
            string ColumnName = "JobID";
            populateComboBox(comboBox_Job_Id, Query, ColumnName);
        }

        private void button_Job_SEARCH_Click(object sender, EventArgs e)
        {
            // Populate all comboboxes
            string Query1 = "SELECT * from CLIENT";
            string ColumnName1 = "ClientID";
            populateComboBox(comboBox_Job_Client_Id2, Query1, ColumnName1);

            string Query2 = "SELECT * from EMPLOYEE WHERE Title= 'Staff';";
            string ColumnName2 = "EmpID";
            populateComboBox(comboBox_Job_Emp_Id2, Query2, ColumnName2);

            string Query3 = "SELECT * from EMPLOYEE WHERE Title= 'Staff';";
            string ColumnName3 = "EmpID";
            populateComboBox(comboBox_Job_Sup_Emp1_Id2, Query3, ColumnName3);

            string Query4 = "SELECT * from EMPLOYEE WHERE Title= 'Staff';";
            string ColumnName4 = "EmpID";
            populateComboBox(comboBox_Job_Sup_Emp2_Id2, Query4, ColumnName4);

            string Query5 = "SELECT * from INVENTORY";
            string ColumnName5 = "ItemCode";
            populateComboBox(comboBox_Job_Item_Code2, Query5, ColumnName5);

            //Disable comboBox Client Id
            this.comboBox_Job_Client_Id2.Enabled = false;


            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * FROM JOBS WHERE JobID = '" + this.comboBox_Job_Id.Text + "';";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // Fill up the textboxes, rich textboxes and comboboxes from records retrieved from query
                if (MyReader.Read())
                {

                    //Populate if textbox/combobox/datepicker is not null, else set all to empty;
                    if (MyReader.IsDBNull(MyReader.GetOrdinal("ClientID")))
                    {
                        this.comboBox_Job_Client_Id2.Text = "";
                    }
                    else
                    {
                        this.comboBox_Job_Client_Id2.Text = MyReader.GetString("ClientID");
                    }
                    this.comboBox_Job_Type2.Text = MyReader.GetString("JobType");
                    this.comboBox_Job_Status2.Text = MyReader.GetString("JobStatus");

                    if (MyReader.IsDBNull(MyReader.GetOrdinal("JobRemarks")))
                    {
                        this.textBox_Job_Remarks2.Text = "";
                    }
                    else
                    {
                        this.textBox_Job_Remarks2.Text = MyReader.GetString("JobRemarks");
                    }

                    if (MyReader.IsDBNull(MyReader.GetOrdinal("EmpID")))
                    {
                        this.comboBox_Job_Emp_Id2.Text = "";
                    }
                    else
                    {
                        this.comboBox_Job_Emp_Id2.Text = MyReader.GetString("EmpID");
                    }

                    if (MyReader.IsDBNull(MyReader.GetOrdinal("SupEmpID")))
                    {
                        this.comboBox_Job_Sup_Emp1_Id2.Text = "";
                    }
                    else
                    {
                        this.comboBox_Job_Sup_Emp1_Id2.Text = MyReader.GetString("SupEmpID");
                    }
                    if (MyReader.IsDBNull(MyReader.GetOrdinal("SupEmpID2")))
                    {
                        this.comboBox_Job_Sup_Emp2_Id2.Text = "";
                    }
                    else
                    {
                        this.comboBox_Job_Sup_Emp2_Id2.Text = MyReader.GetString("SupEmpID2");
                    }
                    if (MyReader.IsDBNull(MyReader.GetOrdinal("ItemCode")))
                    {
                        this.comboBox_Job_Item_Code2.Text = "";
                    }
                    else
                    {
                        this.comboBox_Job_Item_Code2.Text = MyReader.GetString("ItemCode");
                    }

                    this.textBox_Job_Maintenance_Charge2.Text = MyReader.GetString("MaintenanceCharge");
                    this.dateTimePicker_Job_Date2.Text = MyReader.GetString("date");

                }
                else
                {
                    MessageBox.Show("No records found", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_Job_Client_Id2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * FROM CLIENT WHERE ClientID = '" + this.comboBox_Job_Client_Id2.Text + "';";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // To enable/disable the number of employees assigned to job
                if (MyReader.Read())
                {

                    if (MyReader.GetString("PoolSize") == "Small")
                    {
                        this.comboBox_Job_Sup_Emp1_Id2.Enabled = false;
                        this.comboBox_Job_Sup_Emp1_Id2.Text = "";
                        this.comboBox_Job_Sup_Emp1_Id2.SelectedIndex = -1;
                        this.comboBox_Job_Sup_Emp2_Id2.Enabled = false;
                        this.comboBox_Job_Sup_Emp2_Id2.Text = "";
                        this.comboBox_Job_Sup_Emp2_Id2.SelectedIndex = -1;
                    }
                    else if (MyReader.GetString("PoolSize") == "Medium" || MyReader.GetString("PoolSize") == "Large")
                    {
                        this.comboBox_Job_Sup_Emp1_Id2.Enabled = true;
                        this.comboBox_Job_Sup_Emp2_Id2.Enabled = false;
                        this.comboBox_Job_Sup_Emp2_Id2.Text = "";
                        this.comboBox_Job_Sup_Emp2_Id2.SelectedIndex = -1;
                    }
                    else if (MyReader.GetString("PoolSize") == "Complex")
                    {
                        this.comboBox_Job_Sup_Emp1_Id2.Enabled = true;
                        this.comboBox_Job_Sup_Emp2_Id2.Enabled = true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox_Job_Type2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_Job_Type2.Text == "Cleaning")
            {
                this.textBox_Job_Maintenance_Charge2.Enabled = false;
                this.textBox_Job_Maintenance_Charge2.ReadOnly = true;

            }
            else if (this.comboBox_Job_Type2.Text == "Maintenance")
            {
                this.textBox_Job_Maintenance_Charge2.Enabled = true;
                this.textBox_Job_Maintenance_Charge2.ReadOnly = false;
            }
        }

        private void button_Job_UPDATE_Click(object sender, EventArgs e)
        {
            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                //If any required fields are left blank 
                if (this.comboBox_Job_Id.Text == "" || this.comboBox_Job_Client_Id2.Text == "" || this.comboBox_Job_Type2.Text == "" || this.comboBox_Job_Status2.Text == "" ||
                    this.comboBox_Job_Emp_Id2.Text == "" || this.comboBox_Job_Item_Code2.Text == "" || this.dateTimePicker_Job_Date2.Text == "")
                {
                    MessageBox.Show("Please enter all required fields.\nJob remarks and maintenance charge are optional.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //If all required fields are filled.
                else
                {
                    if (this.comboBox_Job_Type2.Text == "Maintenance")
                    {
                        if (this.textBox_Job_Maintenance_Charge2.Text == "" || this.textBox_Job_Remarks2.Text == "")
                        {
                            MessageBox.Show("Please fill up job remarks and maintenance charge.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    if (string.IsNullOrEmpty(this.textBox_Job_Maintenance_Charge2.Text))
                    {
                        this.textBox_Job_Maintenance_Charge2.Text = "0";
                    }

                    string Query;
                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    // If 3 employees are assigned to job
                    if (comboBox_Job_Emp_Id2.Enabled == true && comboBox_Job_Sup_Emp1_Id2.Enabled == true && comboBox_Job_Sup_Emp2_Id2.Enabled == true)
                    {

                        Query = "UPDATE JOBS set JobID='" + int.Parse(this.comboBox_Job_Id.Text) + "',ClientID='" + this.comboBox_Job_Client_Id2.Text + "',JobType='"
                                              + this.comboBox_Job_Type2.Text + "',JobStatus='" + this.comboBox_Job_Status2.Text + "',JobRemarks='" + this.textBox_Job_Remarks2.Text
                                              + "',EmpID='" + this.comboBox_Job_Emp_Id2.Text + "',SupEmpID='" + this.comboBox_Job_Sup_Emp1_Id2.Text + "',SupEmpID2='"
                                              + this.comboBox_Job_Sup_Emp2_Id2.Text + "', ItemCode='" + this.comboBox_Job_Item_Code2.Text + "', MaintenanceCharge='" + decimal.Parse(this.textBox_Job_Maintenance_Charge2.Text)
                                              + "', date='" + this.dateTimePicker_Job_Date2.Text + "' WHERE JobID = '" + int.Parse(this.comboBox_Job_Id.Text) + " ';";

                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyComd.ExecuteReader();
                    }
                    // If 2 employees are assigned to job
                    else if (comboBox_Job_Emp_Id2.Enabled == true && comboBox_Job_Sup_Emp1_Id2.Enabled == true && comboBox_Job_Sup_Emp2_Id2.Enabled == false)
                    {
                        Query = "UPDATE JOBS set JobID='" + int.Parse(this.comboBox_Job_Id.Text) + "',ClientID='" + this.comboBox_Job_Client_Id2.Text + "',JobType='"
                                            + this.comboBox_Job_Type2.Text + "',JobStatus='" + this.comboBox_Job_Status2.Text + "',JobRemarks='" + this.textBox_Job_Remarks2.Text
                                            + "',EmpID='" + this.comboBox_Job_Emp_Id2.Text + "',SupEmpID='" + this.comboBox_Job_Sup_Emp1_Id2.Text
                                            + "', ItemCode='" + this.comboBox_Job_Item_Code2.Text + "', MaintenanceCharge='" + decimal.Parse(this.textBox_Job_Maintenance_Charge2.Text)
                                            + "', date='" + this.dateTimePicker_Job_Date2.Text + "' WHERE JobID = '" + int.Parse(this.comboBox_Job_Id.Text) + " ';";

                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyComd.ExecuteReader();
                    }
                    // If 1 employees are assigned to job
                    else if (comboBox_Job_Emp_Id2.Enabled == true && comboBox_Job_Sup_Emp1_Id2.Enabled == false && comboBox_Job_Sup_Emp2_Id2.Enabled == false)
                    {
                        Query = "UPDATE JOBS set JobID='" + int.Parse(this.comboBox_Job_Id.Text) + "',ClientID='" + this.comboBox_Job_Client_Id2.Text + "',JobType='"
                                           + this.comboBox_Job_Type2.Text + "',JobStatus='" + this.comboBox_Job_Status2.Text + "',JobRemarks='" + this.textBox_Job_Remarks2.Text
                                           + "',EmpID='" + this.comboBox_Job_Emp_Id2.Text
                                           + "', ItemCode='" + this.comboBox_Job_Item_Code2.Text + "', MaintenanceCharge='" + decimal.Parse(this.textBox_Job_Maintenance_Charge2.Text)
                                           + "', date='" + this.dateTimePicker_Job_Date2.Text + "' WHERE JobID = '" + int.Parse(this.comboBox_Job_Id.Text) + " ';";

                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyComd.ExecuteReader();
                    }

                    MessageBox.Show("Record Job ID " + this.comboBox_Job_Id.Text + "(" + this.comboBox_Job_Type2.Text + ") added", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    jobClearAll();
                    MyConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Job_DELETE_Click(object sender, EventArgs e)
        {

            if (this.comboBox_Job_Id.Text == "")
            {
                MessageBox.Show("Plesae select a Job ID", "Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query1 = "SELECT * from JOBS WHERE JobID = '" + this.comboBox_Job_Id.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query1, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    if (MyReader.Read())
                    {
                        // Popout dialog window asking user for yes/no confirmation
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete job " + MyReader.GetString("JobType") + "(Job ID: " + MyReader.GetString("JobID") + ") record?", "Delete Job", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MyReader.Close();
                            // Set up a SQL query to execute against a database that is tracked by database reader.
                            string Query = "DELETE from JOBS WHERE JobID = '" + this.comboBox_Job_Id.Text + "';";
                            MyComd = new MySqlCommand(Query, MyConn);
                            MyReader = MyComd.ExecuteReader();
                            MyReader.Close();
                            MessageBox.Show("Record Job ID " + this.comboBox_Job_Id.Text + " deleted", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                            jobClearAll();
                            MyReader.Close();
                            MyConn.Close();
                        }

                        else if (dialogResult == DialogResult.No)
                        {
                            MyReader.Close();
                            MyConn.Close();
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

        private void button_Job_CLEAR2_Click(object sender, EventArgs e)
        {
            jobClearAll();
        }

        /********************************************* MANAGE JOB > VIEW JOBS ********************************************************/

        private void button_Job_REFRESH_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to MySQL Database and run query
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                string Query = "select date, JobID, ClientID, JobStatus, JobRemarks, EmpID, SupEmpID, SupEmpID2, Picture from jobs;";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);

                //For offline connection we will use MySqlDataAdapter class.  
                MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
                MyAdapter.SelectCommand = MyComd;
                DataTable dTable1 = new DataTable();

                //MyAdapter.Fill(dTable1);

                // Here i have assign dTable object to the dataGridViewAccountStatus object to display data.               
                //dataGridView1.DataSource = dTable1;

                //Size is auto
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //Height of the grid
                dataGridView1.RowTemplate.Height = 120;
                dataGridView1.AllowUserToAddRows = false;
                MyAdapter.Fill(dTable1);
                dataGridView1.DataSource = dTable1;

                DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
                //Pick Column for resize the item.
                imageColumn = (DataGridViewImageColumn)dataGridView1.Columns[8];
                //The column that we want to resize the image.
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

                MyAdapter.Dispose();

                MyConn.Close(); //Close Connection
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /********************************************* MANAGE INVENTORY > ADD ITEM ********************************************************/
        private void button_Item_CLEAR_Click(object sender, EventArgs e)
        {
            itemClearAll();
        }

        private void button_Item_ADD_Click(object sender, EventArgs e)
        {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    //If any required fields are left blank 
                    if (this.textBox_Item_Code.Text == "" || this.textBox_Item_Name.Text == "" || this.richTextBox_Item_Description.Text == "" || this.comboBox_Item_Category.Text == "")
                    {
                        MessageBox.Show("Please enter all required fields.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    //If all required fields are filled.
                    else
                    {
                        // Set up a SQL query to execute against a database that is tracked by database reader.
                        string Query = "INSERT INTO INVENTORY (ItemCode, ItemCategory, ItemName, Description, Quantity ) " +
                            "VALUES ('" + int.Parse(this.textBox_Item_Code.Text) + "','" + this.comboBox_Item_Category.Text + "','" + this.textBox_Item_Name.Text
                                        + "','" + this.richTextBox_Item_Description.Text + "','" + int.Parse(this.numericUpDown_Item_Quantity.Text) + "');";
                        MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                        MySqlDataReader MyReader = MyComd.ExecuteReader();

                        MessageBox.Show("Item added to inventory!", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        itemClearAll();
                        MyConn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }


        /********************************************* MANAGE INVENTORY > UDPATE/REMOVE ITEM ********************************************************/
        private void button_Item_CLEAR2_Click(object sender, EventArgs e)
        {
                itemClearAll();          
        }

        private void comboBox_Item_Code_Click(object sender, EventArgs e)
        {
            string Query = "SELECT * from INVENTORY";
            string ColumnName = "ItemCode";
            populateComboBox(comboBox_Item_Code, Query, ColumnName);
        }

        private void button_Item_SEARCH_Click(object sender, EventArgs e)
        {
            try
            {
                //To connect to MySQL database
                string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MyConn.Open();

                // Set up a SQL query to execute against a database that is tracked by database reader.
                string Query = "SELECT * FROM INVENTORY WHERE ItemCode = '" + this.comboBox_Item_Code.Text + "';";
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader = MyComd.ExecuteReader();

                // Fill up the textboxes, rich textboxes and comboboxes from records retrieved from query
                if (MyReader.Read())
                {
                    this.comboBox_Item_Category2.Text = MyReader.GetString("ItemCategory");
                    this.textBox_Item_Name2.Text = MyReader.GetString("ItemName");
                    this.richTextBox_Item_Description2.Text = MyReader.GetString("Description");
                    this.numericUpDown_Item_Quantity2.Text = MyReader.GetString("Quantity");
                }
                else
                {
                    MessageBox.Show("No records found", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Item_UPDATE_Click(object sender, EventArgs e)
        {
            if (this.comboBox_Item_Code.Text == "" || this.comboBox_Item_Category2.Text == "" || this.textBox_Item_Name2.Text == "" || this.numericUpDown_Item_Quantity2.Text == "")
            {
                MessageBox.Show("Please fill up all required fields", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();


                    //if new password box is left empty
                    string Query = "UPDATE INVENTORY set ItemCode='" + this.comboBox_Item_Code.Text + "',ItemCategory='" + this.comboBox_Item_Category2.Text + "',ItemName='" + this.textBox_Item_Name2.Text +
                                   "',Description='" + this.richTextBox_Item_Description2.Text + "',Quantity='" + int.Parse(this.numericUpDown_Item_Quantity2.Text) + "' WHERE ItemCode= '" + this.comboBox_Item_Code.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyReader = MyComd.ExecuteReader();
                    MessageBox.Show("Record item" + this.comboBox_Item_Code.Text + " updated", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MyReader.Close();

                    //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                    itemClearAll();
                    MyConn.Close();//Connection closed here  
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button_Item_DELETE_Click(object sender, EventArgs e)
        {
            if (this.comboBox_Item_Code.Text == "")
            {
                MessageBox.Show("Plesae select an Item Code", "Records", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    //To connect to MySQL database
                    string Conn = "datasource=localhost; port=3306; username=root; password=; database=sdm; sslMode=none";
                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MyConn.Open();

                    // Set up a SQL query to execute against a database that is tracked by database reader.
                    string Query1 = "SELECT * from INVENTORY WHERE ItemCode = '" + this.comboBox_Item_Code.Text + "';";
                    MySqlCommand MyComd = new MySqlCommand(Query1, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();

                    if (MyReader.Read())
                    {
                        // Popout dialog window asking user for yes/no confirmation
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete Item " + MyReader.GetString("ItemName") + "(Item Code: " + MyReader.GetString("ItemCode") + ") record?", "Delete Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MyReader.Close();
                            // Set up a SQL query to execute against a database that is tracked by database reader.
                            string Query = "DELETE from INVENTORY WHERE ItemCode = '" + this.comboBox_Item_Code.Text + "';";
                            MyComd = new MySqlCommand(Query, MyConn);
                            MyReader = MyComd.ExecuteReader();
                            MyReader.Close();
                            MessageBox.Show("Record item " + this.comboBox_Item_Code.Text + " deleted", "Records", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Clear all textboxes, rich textboxes and comboboxes in the tabpage
                            itemClearAll();
                            MyReader.Close();
                            MyConn.Close();
                        }

                        else if (dialogResult == DialogResult.No)
                        {
                            MyReader.Close();
                            MyConn.Close();
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

        /********************************************* PT STAFF MONTHLY SALARY REPORT ********************************************************/
        // automatic add Part-time EmpID into the combobox
        public void getemployeeID()
        {
            try
            {
                this.comboBox1.Items.Clear();
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm;sslMode=none";
                string Query = "SELECT * FROM employee WHERE Status = 'Part-Time';";
                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader;
                MyConn.Open();
                MyReader = MyComd.ExecuteReader();

                while (MyReader.Read())
                {
                    string EmployeeID = MyReader.GetString("EmpID");
                    this.comboBox1.Items.Add(EmployeeID);
                }
                MyConn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            getemployeeID();
        }

        private void buttonAdminPT_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text != "")
            {
                try
                {
                    string parameterName;
                    string parameterEmpID;
                    string parameterEmpPhone;
                    string parameterJobTitle;
                    string parameterEmpStatus;

                    string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                    string Query = "SELECT * from employee WHERE EmpID = '" + comboBox1.Text + "';";

                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MySqlCommand MyComd = new MySqlCommand(Query, MyConn);
                    MySqlDataReader MyReader;
                    MyConn.Open();
                    MyReader = MyComd.ExecuteReader();

                    MyReader.Read();

                    parameterName = MyReader.GetString("FName");
                    parameterEmpID = MyReader.GetString("EmpID");
                    parameterJobTitle = MyReader.GetString("Title");
                    parameterEmpStatus = MyReader.GetString("Status");
                    parameterEmpPhone = "0" + MyReader.GetString("PhoneNo");

                    MyConn.Close();

                    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
                       {
                    new Microsoft.Reporting.WinForms.ReportParameter("PTEmployeeName", parameterName),
                    new Microsoft.Reporting.WinForms.ReportParameter("PTEmployeeID", parameterEmpID),
                    new Microsoft.Reporting.WinForms.ReportParameter("PTEmployeePhone", parameterEmpPhone),
                    new Microsoft.Reporting.WinForms.ReportParameter("PTJobTitle", parameterJobTitle),
                     new Microsoft.Reporting.WinForms.ReportParameter("PTEmpStatus", parameterEmpStatus),

                       };
                    reportViewer2.LocalReport.SetParameters(rParams);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

                try
                {
                    string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                    string Query = "SELECT employee.EmpID, employee.FName, employee.Address, employee.PhoneNo, employee.Position, employee.Salary, jobs.JobStatus, jobs.JobID, jobs.`date` " +
                        " FROM employee INNER JOIN jobs ON employee.EmpID = jobs.EmpID OR employee.EmpID = jobs.SupEmpID OR employee.EmpID = jobs.SupEmpID2 " +
                        " WHERE(employee.Status = 'Part-Time') AND (jobs.JobStatus = 'Completed') AND employee.EmpID = '" + comboBox1.Text + "'";

                    MySqlConnection MyConn = new MySqlConnection(Conn);
                    MySqlCommand Mycomm = new MySqlCommand(Query, MyConn);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                    myAdapter.SelectCommand = Mycomm;
                    DataTable dtable = new DataTable();
                    myAdapter.Fill(dtable);
                    int rowcount = dtable.Rows.Count;

                    ReportDataSource rds = new ReportDataSource("DataSetEmployeePTSalary", dtable);
                    this.reportViewer2.LocalReport.DataSources.Clear();
                    this.reportViewer2.LocalReport.DataSources.Add(rds);
                    this.reportViewer2.LocalReport.Refresh();

                    this.reportViewer2.RefreshReport();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else {
                MessageBox.Show("Please select a Job ID.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
