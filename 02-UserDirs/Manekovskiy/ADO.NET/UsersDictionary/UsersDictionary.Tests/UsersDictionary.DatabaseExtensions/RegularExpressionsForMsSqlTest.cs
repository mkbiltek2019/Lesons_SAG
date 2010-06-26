using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using RegularExpressions = global::RegularExpressionsForMsSql;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UsersDictionary.Tests
{
    /// <summary>
    /// Summary description for RegularExressionsTest
    /// </summary>
    [TestClass]
    public class RegularExpressionsForMsSqlTest
    {
        public RegularExpressionsForMsSqlTest()
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
        public void MustMatchCorrectNames()
        {
            string pattern = @"^[A-Z][a-zA-Z]+$";
            string testName = "Vasiliy";

            bool result = RegularExpressions.Match(testName, pattern);
            Assert.IsTrue(result, "Name does not match pattern");
        }

        [TestMethod]
        public void MustFailForIncorrectNames()
        {
            string pattern = @"^[A-Z][a-zA-Z]+$";
            string testName = "Vasiliy123";

            bool result = RegularExpressions.Match(testName, pattern);
            Assert.IsFalse(result, "Incorreect name matches pattern");
        }

        [TestMethod]
        public void MustMatchCorrectPhoneNumber()
        {
            string pattern = @"^(\(?\d\d\d\)?)?( |-|\.)?\d\d\d( |-|\.)?\d{4,4}(( |-|\.)?[ext\.]+ ?\d+)?$";
            string testName = "(098)666-4444";

            bool result = RegularExpressions.Match(testName, pattern);
            Assert.IsTrue(result, "Correct number match failed");
        }

        [TestMethod]
        public void MustFailForIncorrectPhoneNumber()
        {
            string pattern = @"^(\(?\d\d\d\)?)?( |-|\.)?\d\d\d( |-|\.)?\d{4,4}(( |-|\.)?[ext\.]+ ?\d+)?$";
            string testName = "Vasiliy123";

            bool result = RegularExpressions.Match(testName, pattern);
            Assert.IsFalse(result, "Incorrect number matches pattern");
        }
    }
}
