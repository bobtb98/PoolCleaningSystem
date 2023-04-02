using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MCM_Management_System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestViewClientRecord()
        {
                bool expectedRows = true;
                string conn = "datasource=localhost; port=3306;username=root;password=;database=sdm; sslMode=none;";
                string query = "SELECT * from CLIENT;";

                Client testmethod1 = new Client();
                bool hasRows = testmethod1.runQueryToDB(conn, query);

                Assert.AreEqual(expectedRows, hasRows, "Read Client Record Failed!");
        }

        [TestMethod]
        public void TestInsertInventoryRecord()
        {
            int[] ItemCode = new int[]           { 900091, 900092, 900093, 900094, 900095 };
            string[] ItemCategory = new string[] { "Pool Light", "Pool Filter", "Pool Heat Pump", 
                                                   "Pool Cleaner", "Pool Accessories" };
            string[] ItemName = new string[]     { "DN-6017V Linear Pool Light", "Side-Mount Filter", 
                                                   "DGL-100C Degaulle Air", "Cordless Pool Vacuum", 
                                                   "Pool Gutter Grating" };
            string[] Description = new string[]  { "DN-6017V is ...", "Side-Mount Filter is ...", "DGL-100C Degaulle is ...", 
                                                   "Cordless Pool Vacuum is ...", "Pool Gutter Grating is ..." };
            int[] Quantity = new int[] { 5, 5, 3, 3, 54 };
            int affectedRows = 0;
            int totalAffectedRows = 0;
            int totalExpectedAffectedRows = 5;
            for (int i=0; i< 5; i++)
            {
                Inventory testmethod2 = new Inventory(ItemCode[i], ItemCategory[i], ItemName[i], Description[i], Quantity[i]);
                affectedRows = testmethod2.insertInventoryRecord();
                totalAffectedRows += affectedRows;
            }
            Assert.AreEqual(totalExpectedAffectedRows, totalAffectedRows, "Not all inventory records inserted. " 
                            + totalAffectedRows + " inventory records inserted!");

        }

        [TestMethod]
        public void TestUpdateEmployeeRecord()
        {
            int[] EmpID = new int[] { 400001, 400002, 400003 };
            string[] Address = new string[] { "Oakland Commerce Square 60-1 Jln Haruan Address", 
                                              "Blok A Diamond Square Jln 3/52", 
                                              "12 Jln 3/3A Sri Hartamas"};
            int affectedRow;
            int expectedRow = 1;

            for (int i = 0; i < 3; i++)
            {
                Employee testmethod3 = new Employee(EmpID[i], Address[i]);
                affectedRow = testmethod3.updateEmployeeRecord();
                Assert.AreEqual(expectedRow, affectedRow, "Update employee record failed!");
            }
        }





    }
}
