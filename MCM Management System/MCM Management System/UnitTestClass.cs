using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCM_Management_System
{
        //Select Client Records form Database
        public class Client
        {
            //Constructor
            public Client()
            {
            }

            public bool runQueryToDB(string conn, string query)
            {
                bool hasRow = false;
                try
                {
                    MySqlConnection MyConn = new MySqlConnection(conn);
                    MyConn.Open();

                    MySqlCommand MyComd = new MySqlCommand(query, MyConn);
                    MySqlDataReader MyReader = MyComd.ExecuteReader();
                    //if query return rows of record , return true
                    hasRow = true;
                    MyReader.Close();
                    MyConn.Close();
                    return hasRow;
                }
                catch (Exception ex)
                {
                    //if query has error , return false
                    hasRow = false;
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source);
                    return hasRow;
                }
            }
        }

        public class Inventory
        {
            private int itemCode;
            private string itemCategory;
            private string itemName;
            private string description;
            private int quantity;

            //Constructor
            public Inventory(int a, string b, string c, string d, int e)
            {
                itemCode = a;
                itemCategory = b;
                itemName = c;
                description = d;
                quantity = e;
            }

            public int insertInventoryRecord()
            {
                int affectedRow;

                try
                {
                    MySqlConnection MyConn = new MySqlConnection("datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none;");
                    MyConn.Open();
                    // Set up a SQL query to execute against a database
                    string query = "INSERT INTO INVENTORY (ItemCode, ItemCategory, ItemName, Description, Quantity ) " +
                                   "VALUES ('" + itemCode + "','" + itemCategory + "','" + itemName + "','" + description + "','" + quantity + "');";
                    MySqlCommand MyComd = new MySqlCommand(query, MyConn);
                    //if query return rows of record , return true
                    affectedRow = MyComd.ExecuteNonQuery();
                    MyConn.Close();
                    return affectedRow;
                }
                catch (Exception ex)
                {
                    //if query has error , return false
                    affectedRow = 0;
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source);
                    return affectedRow;
                }

            }
        }

        public class Employee
        {
            private int EmpID;
            private string Address;

            //Constructor
            public Employee(int a, string b)
            {
                EmpID = a;
                Address = b;
            }

            public int updateEmployeeRecord()
            {
                int affectedRow = 0;
                try
                {
                    MySqlConnection MyConn = new MySqlConnection("datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none;");
                    MyConn.Open();
                    // Set up a SQL query to execute against a database
                    string query = "UPDATE employee set Address='" + Address + "'where EmpID='" + EmpID + "';";
                    MySqlCommand MyComd = new MySqlCommand(query, MyConn);

                    //if query update sucessful , return number of affected rows
                    affectedRow = MyComd.ExecuteNonQuery();
                    MyConn.Close();
                    return affectedRow;
                }
                catch (Exception ex)
                {
                    //if query has error , return zero
                    affectedRow = 0;
                    MessageBox.Show("Some error occured: " + ex.Message + " - " + ex.Source);
                    return affectedRow;
                }
            }
        }

}
