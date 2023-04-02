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
    public partial class ownerAssManagerModule : Form
    {
        public ownerAssManagerModule()
        {
            InitializeComponent();
        }

        //  When the form systemAdminModule is loaded for the first time, run all statements inside this function
        private void ownerAssManagerModule_Load(object sender, EventArgs e)
        {
            this.sdmDataSet.EnforceConstraints = false;

            // TODO: This line of code loads data into the 'sdmDataSet1.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.sdmDataSet1.employee);

            // TODO: This line of code loads data into the 'sdmDataSet.cleaningSchedule' table. You can move, or remove it, as needed.
            this.cleaningScheduleTableAdapter.Fill(this.sdmDataSet.cleaningSchedule);

            // TODO: This line of code loads data into the 'sdmDataSet.employeePerformance' table. You can move, or remove it, as needed.
            this.employeePerformanceTableAdapter.Fill(this.sdmDataSet.employeePerformance);

            // TODO: This line of code loads data into the 'sdmDataSet.employee' table.
            this.employeeTableAdapter.Fill(this.sdmDataSet.employee);
            this.reportViewer5.RefreshReport();

            //Set textboxes/comboBoxes read only and uninteractable by the user.
            comboBoxEmpPosition.Enabled = false;
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
            this.reportViewer3.RefreshReport();
        }

        //  When the form systemAdminModule top right x button is clicked, run all statements inside this function
        private void ownerAssManagerModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Redirect to loginUsername.cs windows form
            MessageBox.Show("Logging Out...", "Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Hide();
            loginUsername windowForm = new loginUsername();
            windowForm.ShowDialog();
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


        /******************************************** MANAGE EMPLOYEE > UPDATE?DELETE EMPLOYEE ******************************************/
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

        /********************************************* STAFF JOB PERFORMANCE REPORT ********************************************************/
        private void button_Report_StaffWorkPerformance_FILTER_Click_1(object sender, EventArgs e)

        {
            if (this.comboBox_Report_StaffWorkPerformance_Month.Text == "" || this.comboBox_Report_StaffWorkPerformance_Year.Text == "")
            {
                MessageBox.Show("Please select a year and month.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                // set month in integer
                int month = 0;
                if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 0)
                {
                    month = 1;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 1)
                {
                    month = 2;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 2)
                {
                    month = 3;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 3)
                {
                    month = 4;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 4)
                {
                    month = 5;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 5)
                {
                    month = 6;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 6)
                {
                    month = 7;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 7)
                {
                    month = 8;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 8)
                {
                    month = 9;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 9)
                {
                    month = 10;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 10)
                {
                    month = 11;
                }
                else if (comboBox_Report_StaffWorkPerformance_Month.SelectedIndex == 11)
                {
                    month = 12;
                }

                //dataset sdmDataSet.employee is imported via reportviewer controls
                DataView dataView = new DataView(this.sdmDataSet.employeePerformance);

                //filter on year and month 
                int monthAdd1 = month + 1;
                dataView.RowFilter = "date >='" + this.comboBox_Report_StaffWorkPerformance_Year.Text + "-" + month.ToString() + "-1' AND date < '" + this.comboBox_Report_StaffWorkPerformance_Year.Text + "-" + monthAdd1.ToString() + "-1'";
                //Special case if month lies on december
                if (month == 12)
                {
                    month -= 1;
                    dataView.RowFilter = "date >='" + this.comboBox_Report_StaffWorkPerformance_Year.Text + "-" + month.ToString() + "-1' AND date < '" + this.comboBox_Report_StaffWorkPerformance_Year.Text + "-" + monthAdd1.ToString() + "-1'";
                }

                //To clear, add datasource into local reoport viewer controls and generate the filtered report
                ReportDataSource reportStaffWorkPerformance = new ReportDataSource("DataSet1", dataView);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportStaffWorkPerformance);
                this.reportViewer1.RefreshReport();
            }
        }

        private void button_Report_StaffWorkPerformance_VIEWALL_Click_1(object sender, EventArgs e)

        {
            // dataset sdmDataSet.employee is imported and set as data source for report.
            DataView dataView = new DataView(this.sdmDataSet.employeePerformance);
            dataView.RowFilter = "";
            ReportDataSource reportStaffWorkPerformance = new ReportDataSource("DataSet1", dataView);

            // To clear ,add datasource into local reoport viewer controls and generate the original result
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportStaffWorkPerformance);
            this.reportViewer1.RefreshReport();
        }

        /********************************************* CLIENT CLEANING SCHEDULE REPORT ********************************************************/
        private void button_Report_MonthlyCleaningSchedule_FILTER_Click(object sender, EventArgs e)
        {
            if (this.comboBox_Report_MonthlyCleaningSchedule_Month.Text == "" || this.comboBox_Report_MonthlyCleaningSchedule_Year.Text == "")
            {
                MessageBox.Show("Please select a year and month.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                // set month in integer
                int month = 0;
                if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 0)
                {
                    month = 1;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 1)
                {
                    month = 2;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 2)
                {
                    month = 3;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 3)
                {
                    month = 4;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 4)
                {
                    month = 5;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 5)
                {
                    month = 6;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 6)
                {
                    month = 7;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 7)
                {
                    month = 8;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 8)
                {
                    month = 9;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 9)
                {
                    month = 10;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 10)
                {
                    month = 11;
                }
                else if (comboBox_Report_MonthlyCleaningSchedule_Month.SelectedIndex == 11)
                {
                    month = 12;
                }

                //dataset sdmDataSet.employee is imported via reportviewer controls
                DataView dataView = new DataView(this.sdmDataSet.cleaningSchedule);

                //filter on year and month 
                int monthAdd1 = month + 1;
                dataView.RowFilter = "date >='" + this.comboBox_Report_MonthlyCleaningSchedule_Year.Text + "-" + month.ToString() + "-1' AND date < '" + this.comboBox_Report_MonthlyCleaningSchedule_Year.Text + "-" + monthAdd1.ToString() + "-1'";
                //Special case if month lies on december
                if (month == 12)
                {
                    month -= 1;
                    dataView.RowFilter = "date >='" + this.comboBox_Report_MonthlyCleaningSchedule_Year.Text + "-" + month.ToString() + "-1' AND date < '" + this.comboBox_Report_MonthlyCleaningSchedule_Year.Text + "-" + monthAdd1.ToString() + "-1'";
                }

                //To clear, add datasource into local reoport viewer controls and generate the filtered report
                ReportDataSource reportCustomerCleaningSchedule = new ReportDataSource("DataSetCleaningSchedule", dataView);
                this.reportViewer2.LocalReport.DataSources.Clear();
                this.reportViewer2.LocalReport.DataSources.Add(reportCustomerCleaningSchedule);
                this.reportViewer2.RefreshReport();
            }
        }

        private void button_Report_MonthlyCleaningSchedule_VIEWALL_Click(object sender, EventArgs e)
        {
            // dataset sdmDataSet.cleaningSchedule is imported and set as data source for report.
            DataView dataView = new DataView(this.sdmDataSet.cleaningSchedule);
            dataView.RowFilter = "";
            ReportDataSource reportCustomerCleaningSchedule = new ReportDataSource("DataSetCleaningSchedule", dataView);

            // To clear ,add datasource into local reoport viewer controls and generate the original result
            this.reportViewer2.LocalReport.DataSources.Clear();
            this.reportViewer2.LocalReport.DataSources.Add(reportCustomerCleaningSchedule);
            this.reportViewer2.RefreshReport();
        }


        /********************************************* CLIENT CONTACT DETAILS REPORT ********************************************************/
        private void textBox_Staff_Details_Search_TextChanged(object sender, EventArgs e)
        {
            //To filter according to name
            //dataset sdmDataSet.employee is imported via reportviewer controls
            DataView dataView = new DataView(this.sdmDataSet.employee);

            //filter on name or id
            dataView.RowFilter = "FName LIKE '%" + textBox_Staff_Details_Search.Text + "%' or Convert(EmpID, 'System.String') LIKE '%" + textBox_Staff_Details_Search.Text + "%' ";

            //To clear and regenerate the filtered report
            ReportDataSource reportStaffDetails = new ReportDataSource("DataSetEmployee", dataView);
            this.reportViewer3.LocalReport.DataSources.Clear();
            this.reportViewer3.LocalReport.DataSources.Add(reportStaffDetails);
            this.reportViewer3.RefreshReport();
        }

        /********************************************* MONTHLY PT STAFF SALARY REPORT ********************************************************/
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
                    reportViewer4.LocalReport.SetParameters(rParams);
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
                    this.reportViewer4.LocalReport.DataSources.Clear();
                    this.reportViewer4.LocalReport.DataSources.Add(rds);
                    this.reportViewer4.LocalReport.Refresh();

                    this.reportViewer4.RefreshReport();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Please select a Job ID.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

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
    }

}
