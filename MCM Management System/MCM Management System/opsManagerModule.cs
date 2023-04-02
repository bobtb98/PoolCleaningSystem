using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;

namespace MCM_Management_System
{
        public partial class opsManagerModule : Form
        {
        public opsManagerModule()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            notificationPopout();

            // TODO: This line of code loads data into the 'sdmDataSet.employee' table.
            this.employeeTableAdapter.Fill(this.sdmDataSet.employee);
            this.reportViewer1.RefreshReport();

            // TODO: This line of code loads data into the 'sdmDataSet.monthlyJobListing' table.
            this.monthlyJobListingTableAdapter.Fill(this.sdmDataSet.monthlyJobListing);
            this.reportViewerVML.RefreshReport();

            // TODO: This line of code loads data into the 'sdmDataSet.monthlyJobListing' table.
            this.jobsTableAdapter.Fill(this.sdmDataSet.jobs);
            this.reportViewer_cleaning.RefreshReport();
        }

        


        private void opsManagerModule_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Redirect to loginUsername.cs windows form
            MessageBox.Show("Logging Out...", "Account", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            this.Hide();
            loginUsername windowForm = new loginUsername();
            windowForm.ShowDialog();
        }

        //Function to popout notification
        private void notificationPopout()
        {
            //To connect to MySQL database
            string Conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none";
            MySqlConnection MyConn = new MySqlConnection(Conn);
            MyConn.Open();

            //get current date
            string currDate = DateTime.Now.ToString("yyyy-MM-dd");
            string futureDate = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            //var pastDate = currDate - 28;

            // Set up a SQL query to execute against a database .
            string Query = "SELECT COUNT(*) from JOBS WHERE JobStatus = 'Pending' and date >= '" + currDate + "' and date <='" + futureDate + "';";
            MySqlCommand MyComd = new MySqlCommand(Query, MyConn);

            // Get number of records selected
            int noOfReturnRecords = Convert.ToInt32(MyComd.ExecuteScalar());

            // Create notification
            PopupNotifier popout = new PopupNotifier();

            popout.ImagePadding = new Padding(10, 7, 0, 0);
            popout.Image = SystemIcons.Information.ToBitmap();

            //popup.BodyColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.BorderColor = System.Drawing.Color.FromArgb(0, 0, 0);
            //popup.ContentColor = System.Drawing.Color.FromArgb(255,255,255);
            //popup.ContentHoverColor = System.Drawing.Color.FromArgb(255, 255, 255);
            popout.ContentPadding = new Padding(0);

            popout.TitlePadding = new Padding(10, 10, 0, 0);
            popout.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12);
            popout.TitleColor = Color.Black;
            popout.HeaderColor = Color.CadetBlue;
            popout.BodyColor = Color.White;

            popout.ContentPadding = new Padding(10, 7, 0, 0);
            popout.ContentFont = new System.Drawing.Font("Microsoft Sans Serif", 10);
            popout.ContentColor = Color.Black;
            popout.ContentHoverColor = Color.Black;

            popout.TitleText = "Weekly Schedule Reminder";
            popout.ContentText = "There are " + noOfReturnRecords + " pending jobs to be completed this week!";
            popout.AnimationDuration = 1000;
            popout.AnimationInterval = 1;
            popout.Delay = 8000;
            popout.Popup();
        }

        // Function to clear all textboxes, rich textboxes and comboboxes in the Manage Client tabpage 
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

        // Function to clear all textboxes, rich textboxes and comboboxes in the Manage Job tabpage 
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
                    string comboboxValue = MyReader.GetString(column);
                    comboBox.Items.Add(comboboxValue);
                }
                MyConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //************************************************** MANAGE CLIENT > ADD CLIENT TABPAGE *******************************************//
        private void button_Client_CLEAR_Click(object sender, EventArgs e)
        {
            clientClearAll();
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


        //************************************************** MANAGE CLIENT > UPDATE/DELETE CLIENT TABPAGE *******************************************/
        private void comboBox1_Client_Id_Click_1(object sender, EventArgs e)
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

        private void button_CLEAR2_Click(object sender, EventArgs e)
        {
            clientClearAll();
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


        /********************************************* MANAGE JOB > ADD JOB ********************************************************/
        private void button_Job_CLEAR_Click(object sender, EventArgs e)
        {
            jobClearAll();
        }

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

        /********************************************* MANAGE JOB > UDPATE/DELETE JOB ********************************************************/
        private void button_Job_CLEAR2_Click(object sender, EventArgs e)
        {
            jobClearAll();
        }

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
                                              + "', date='" + this.dateTimePicker_Job_Date2.Text +"' WHERE JobID = '" + int.Parse(this.comboBox_Job_Id.Text) + " ';";

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

        private void comboBox_Job_Client_Id2_SelectedIndexChanged_1(object sender, EventArgs e)
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
            if (this.comboBox_Job_Type2.Text == "Cleaning" )
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
                // dataGridView1.DataSource = dTable1;

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


        /********************************************* SEARCH STAFF DETAILS TABPAGE ********************************************************/

        private void textBox_Staff_Details_Search_TextChanged_1(object sender, EventArgs e)
        {
            //To filter according to name
            //dataset sdmDataSet.employee is imported via reportviewer controls
            DataView dataView = new DataView(this.sdmDataSet.employee);

            //filter on name or id
            dataView.RowFilter = "FName LIKE '%" + textBox_Staff_Details_Search.Text + "%' or Convert(EmpID, 'System.String') LIKE '%" + textBox_Staff_Details_Search.Text + "%' ";

            //To clear and regenerate the filtered report
            ReportDataSource reportStaffDetails = new ReportDataSource("DataSetEmployee", dataView);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportStaffDetails);
            this.reportViewer1.RefreshReport();
        }

        /********************************************* MANAGE INVENTORY > ADD ITEM TABPAGE ********************************************************/
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


        /********************************************* MANAGE INVENTORY > UPDATE/REMOVE ITEM TABPAGE ********************************************************/
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

        /********************************************* MONTHLY JOB LIST REPORT ********************************************************/
        public string report_VLM()
        {
            string report_VLM="";

            if (comboBox_JL_S.SelectedIndex == 0)
            {
                report_VLM = "Completed";
            }
            else if (comboBox_JL_S.SelectedIndex == 1)
            {
                report_VLM = "Pending";
            }
            return report_VLM;
        }
        private void button_JL_S_Click(object sender, EventArgs e)

        {
            int months = 0;
            string conn_out;
            string Query_out;
            string report_vlm = report_VLM();

            try
            {
                if (this.comboBox_JL_M.Text != "" && this.comboBox_JL_S.Text != "")
                {
                    if (comboBox_JL_M.SelectedIndex == 0)
                    {
                        months = 1;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 1)
                    {
                        months = 2;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 2)
                    {
                        months = 3;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 3)
                    {
                        months = 4;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 4)
                    {
                        months = 5;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 5)
                    {
                        months = 6;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 6)
                    {
                        months = 7;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 7)
                    {
                        months = 8;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 8)
                    {
                        months = 9;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 9)
                    {
                        months = 10;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 10)
                    {
                        months = 11;

                    }
                    else if (comboBox_JL_M.SelectedIndex == 11)
                    {
                        months = 12;

                    }


                    string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";

                    string Query = "SELECT jobs.JobID, jobs.`date`, client.ClientName, client.PhoneNo" +
                                  " FROM client" +
                                  " INNER JOIN jobs ON client.ClientID = jobs.ClientID" +
                                  " WHERE (jobs.JobStatus ='" + report_vlm + "') AND (MONTH(jobs.date)) ='" + months + "' ORDER BY jobs.`date`;";

                    conn_out = Conn;
                    Query_out = Query;
                    MySqlConnection MyConn = new MySqlConnection(conn_out);
                    MySqlCommand Mycomm = new MySqlCommand(Query_out, MyConn);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                    myAdapter.SelectCommand = Mycomm;
                    DataTable dtable = new DataTable();
                    myAdapter.Fill(dtable);
                    int rowcount = dtable.Rows.Count;

                    ReportDataSource rds = new ReportDataSource("DataSetMonthlyJobListing", dtable);
                    this.reportViewerVML.LocalReport.DataSources.Clear();
                    this.reportViewerVML.LocalReport.DataSources.Add(rds);
                    this.reportViewerVML.LocalReport.Refresh();

                    this.reportViewerVML.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Please select month and job status.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_JL_view_all_Click(object sender, EventArgs e)

        {
            try
            {
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                string Query = "SELECT jobs.JobID, jobs.`date`, client.ClientName, client.PhoneNo" +
                              " FROM client" +
                              " INNER JOIN jobs ON client.ClientID = jobs.ClientID" +
                              " ORDER BY jobs.`date`;";

                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand Mycomm = new MySqlCommand(Query, MyConn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = Mycomm;
                DataTable dtable = new DataTable();
                myAdapter.Fill(dtable);
                int rowcount = dtable.Rows.Count;

                ReportDataSource rds = new ReportDataSource("DataSetMonthlyJobListing", dtable);
                this.reportViewerVML.LocalReport.DataSources.Clear();
                this.reportViewerVML.LocalReport.DataSources.Add(rds);
                this.reportViewerVML.LocalReport.Refresh();

                this.reportViewerVML.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /********************************************* MONTHLY JOB CLEANING/MAINTENANCE REPORT ********************************************************/
        public int cb_month()
        {
            int month = 0;

            if (comboBox_month.SelectedIndex == 0)
            {
                month = 1;

            }
            else if (comboBox_month.SelectedIndex == 1)
            {
                month = 2;

            }
            else if (comboBox_month.SelectedIndex == 2)
            {
                month = 3;

            }
            else if (comboBox_month.SelectedIndex == 3)
            {
                month = 4;

            }
            else if (comboBox_month.SelectedIndex == 4)
            {
                month = 5;

            }
            else if (comboBox_month.SelectedIndex == 5)
            {
                month = 6;

            }
            else if (comboBox_month.SelectedIndex == 6)
            {
                month = 7;

            }
            else if (comboBox_month.SelectedIndex == 7)
            {
                month = 8;

            }
            else if (comboBox_month.SelectedIndex == 8)
            {
                month = 9;

            }
            else if (comboBox_month.SelectedIndex == 9)
            {
                month = 10;

            }
            else if (comboBox_month.SelectedIndex == 10)
            {
                month = 11;

            }
            else if (comboBox_month.SelectedIndex == 11)
            {
                month = 12;

            }
            return month;
        }

        public string cb_status()
        {
            string status ="";
            if (comboBox_status.SelectedIndex == 0)
            {
                status = "Completed";
            }
            else if (comboBox_status.SelectedIndex == 1)
            {
                status = "Pending";
            }
            return status;
        }

        public string cb_JobType()
        {
            string JobType;
            if (comboBox_JobType.SelectedIndex == 0)
            {
                JobType = "Cleaning";
            }
            else
                JobType = "Maintenance";

            return JobType;
        }
        private void button_cleaning_search_Click(object sender, EventArgs e)
        {
            string conn_out = " ";
            string Query_out = " ";
            try
            {
                string status = cb_status();
                string JobType = cb_JobType();
                int month = cb_month();
                if (this.comboBox_month.Text !="" && this.comboBox_status.Text != "" && this.comboBox_JobType.Text != "")
                {
                    string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                    string Query = "SELECT `date`, JobID, ClientID, JobStatus, JobType, EmpID, SupEmpID, SupEmpID2" +
                                    " FROM jobs" +
                                    " WHERE (JobType ='" + JobType + "') AND (JobStatus ='" + status + "') AND (MONTH(jobs.date)) ='" + month + "' ORDER BY `date`;";
                    conn_out = Conn;
                    Query_out = Query;
                    MySqlConnection MyConn = new MySqlConnection(conn_out);
                    MySqlCommand Mycomm = new MySqlCommand(Query_out, MyConn);
                    MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                    myAdapter.SelectCommand = Mycomm;
                    DataTable dtable = new DataTable();
                    myAdapter.Fill(dtable);
                    int rowcount = dtable.Rows.Count;

                    ReportDataSource rds = new ReportDataSource("DataSetCleaningMaintenanceJob", dtable);
                    this.reportViewer_cleaning.LocalReport.DataSources.Clear();
                    this.reportViewer_cleaning.LocalReport.DataSources.Add(rds);
                    this.reportViewer_cleaning.LocalReport.Refresh();
                    this.reportViewer_cleaning.RefreshReport();
                }
                else
                {
                    MessageBox.Show("Please select a month, job status and job type.", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_cleaning_view_Click(object sender, EventArgs e)
        {
            try
            {
                string Conn = "datasource=localhost;port=3306;username=root;password=;database=sdm; sslMode=none";
                string Query = "SELECT `date`, JobID, ClientID, JobStatus, JobType, EmpID, SupEmpID, SupEmpID2" +
                                " FROM jobs" +
                                " ORDER BY `date`;";


                MySqlConnection MyConn = new MySqlConnection(Conn);
                MySqlCommand Mycomm = new MySqlCommand(Query, MyConn);
                MySqlDataAdapter myAdapter = new MySqlDataAdapter();
                myAdapter.SelectCommand = Mycomm;
                DataTable dtable = new DataTable();
                myAdapter.Fill(dtable);
                int rowcount = dtable.Rows.Count;

                ReportDataSource rds = new ReportDataSource("DataSetCleaningMaintenanceJob", dtable);
                this.reportViewer_cleaning.LocalReport.DataSources.Clear();
                this.reportViewer_cleaning.LocalReport.DataSources.Add(rds);
                this.reportViewer_cleaning.LocalReport.Refresh();
                this.reportViewer_cleaning.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


