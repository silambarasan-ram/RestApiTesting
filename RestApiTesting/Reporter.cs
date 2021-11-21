using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace RestApiTesting
{
    public static class Reporter
    {
        public static ExtentReports extentReports;
        public static ExtentHtmlReporter extentHtmlReporter;
        public static ExtentTest extentTestCase;

        public static void SetupExtentReport(string reportName, string documentTitle, dynamic path)
        {
            extentHtmlReporter = new ExtentHtmlReporter(path);
            extentHtmlReporter.Config.Theme = Theme.Standard;
            extentHtmlReporter.Config.ReportName = reportName;
            extentHtmlReporter.Config.DocumentTitle = documentTitle;

            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
        }

        public static void CreateTest(string testName)
        {
            extentTestCase = extentReports.CreateTest(testName);
        }

        public static void LogToReport(Status status, string logMessage)
        {
            extentTestCase.Log(status, logMessage);
        }

        public static void FlushReport()
        {
            extentReports.Flush();
        }

        public static void TestStatus(Status status, string message = null)
        {
            if (status.Equals(Status.Pass))
                extentTestCase.Pass("Test is Passed");
            else
                extentTestCase.Fail($"Test is Failed : {message}");
        }
    }
}