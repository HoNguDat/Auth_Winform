using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Winform_User.Libs;

namespace UserApp_UnitTest
{
    /// <summary>
    /// Summary description for FileHelperTest
    /// </summary>
    [TestClass]
    public class FileHelperTest
    {
       FileHelper fileHelper = new FileHelper();
        public FileHelperTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestWriteUser()
        {
            this.fileHelper.emptyFile();

            //Sample data
            string[] arrUserInfo = new string[] { "user1", "pass1"};
            this.fileHelper.writeUser(this.fileHelper.parseToString(arrUserInfo));

            //Expected
            int expected = 1;

            //Count of users in text file
            int actual = this.fileHelper.countLines();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseToString()
        {
            this.fileHelper.emptyFile();

            //Sample data
            string[] arrUserInfo = new string[] { "user1", "pass1" };

            //Expected
            string expected = "user1,pass1";

            //Count of users in text file
            string actual = this.fileHelper.parseToString(arrUserInfo);

            Assert.AreEqual(expected, actual);
        }
    }
}
