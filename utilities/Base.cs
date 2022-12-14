using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using AngleSharp;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace AHTG_QA_Automation_Assignment.utilities
{
    public class Base
{
        public ExtentReports extentR;
        public  ExtentTest test;

        [OneTimeSetUp]
        public void SetUp()
        {
            var workingDirectory = Environment.CurrentDirectory;
            var projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var reportPath = projectDirectory + "//index.html";
            var htmlRepoeter = new ExtentHtmlReporter(reportPath);
            extentR = new ExtentReports();
            extentR.AttachReporter(htmlRepoeter);
            extentR.AddSystemInfo("Host Name", "Local host");
            extentR.AddSystemInfo("Enviroment", "DemoTest");
            extentR.AddSystemInfo("Username", "Naz");



        }
    
        public IWebDriver driver;

        [SetUp]

        public void BrowserStart()
        {
           test = extentR.CreateTest(TestContext.CurrentContext.Test.Name);
            var browserName = ConfigurationManager.AppSettings["browser"];
            InitBrowser(browserName);
            var Testurl = ConfigurationManager.AppSettings["url"];
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Testurl);

        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {

                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":

                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":


                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;




            }

        }




        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime time = DateTime.Now;
            var fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if(status == TestStatus.Failed)
            {
                test.Fail("Test failed", captureScreenShot(driver,fileName));
                test.Log(Status.Fail,"test failed with logtrace" + stackTrace);
            }
            else if(status == TestStatus.Passed)
            {

            }
            extentR.Flush();
            driver.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            var TS = screenshot.GetScreenshot().AsBase64EncodedString;
           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(TS, screenShotName).Build();
        }




    }
}
