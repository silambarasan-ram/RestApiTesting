using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace RestApiTesting
{
    public class BaseClass
    {
        [OneTimeSetUp]
        public static void Setup()
        {
            var dir = TestContext.CurrentContext.TestDirectory;

            Reporter.SetupExtentReport("Rest API Testing", "Rest API Testing Report", dir);
        }

        [SetUp]
        public static void SetupTest()
        {
            Reporter.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public static void TearDownTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            switch (testStatus)
            {
                case TestStatus.Passed:
                    Reporter.TestStatus(Status.Pass);
                    break;
                case TestStatus.Failed:
                    Reporter.TestStatus(Status.Fail, TestContext.CurrentContext.Result.StackTrace);
                    break;
            }
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            Reporter.FlushReport();
        }
    }
}