using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.BoDi;
using ReqnrollDotnetSelenium.Config;
using ReqnrollDotnetSelenium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollDotnetSelenium.Hooks
{
    [Binding]
    public sealed class Hook
    {
        private readonly IObjectContainer objectContainer;
        private static IWebDriver driver;
        private static DriverConfig driverConfig;

        private static ExtentSparkReporter extentSparkReporter;
        private static ExtentReports extentReports;
        private static FeatureContext featureContext;
        private static ScenarioContext scenarioContext;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentTest step;

        readonly static string curDir = Directory.GetCurrentDirectory();
        readonly static string prjReportFolder = Path.Combine(Directory.GetParent(curDir).Parent.Parent.FullName, "Reports");
        readonly static string curTime = System.DateTime.Now.ToString("ddMMyyyy_HHmmss");
        readonly static string curReportFolder = prjReportFolder + @"\HtmlReport\TestReport_" + curTime + @"\";

        public Hook(IObjectContainer iObjectContainer)
        {
            objectContainer = iObjectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            extentSparkReporter = new ExtentSparkReporter(curReportFolder + "Spark.html");
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentSparkReporter);

            extentReports.AddSystemInfo("Host Name", System.Environment.MachineName);
            extentReports.AddSystemInfo("Environment", System.Environment.OSVersion.VersionString);
            extentReports.AddSystemInfo("User Name", System.Environment.UserName);

            driverConfig = new DriverConfig();

            // With the following null-checked version:
            string? browser = appSettings.GetAppSettings("browserDetails:name");
            if (string.IsNullOrEmpty(browser))
            {
                throw new InvalidOperationException("Browser name is not configured in app settings.");
            }
            // Initialize WebDriver based on the specified browser
            driver = driverConfig.InitializeDriver((DriverConfig.BrowserType)Enum.Parse(typeof(DriverConfig.BrowserType), browser));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext runFeatureContext)
        {
            featureContext = runFeatureContext;
            feature = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);
        }


        [BeforeScenario]
        public void BeforeScenario(ScenarioContext runScenarioContext)
        {
            scenarioContext = runScenarioContext;
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterStep]
        public static void AfterEachStep(ScenarioContext runScenarioContext)
        {
            scenarioContext = runScenarioContext;
            switch (runScenarioContext.CurrentScenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNode<Given>();
                    break;

                case ScenarioBlock.When:
                    CreateNode<When>();
                    break;

                case ScenarioBlock.Then:
                    CreateNode<Then>();
                    break;

                default:
                    CreateNode<And>();
                    break;
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extentReports.Flush();
            CloseDriver();
        }

        private static void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (scenarioContext.TestError != null)
            {
                // Create Screenshots folder if it doesn't exist
                string screenshotPath = curReportFolder + @"Screenshots\";

                if (!Directory.Exists(screenshotPath))
                {
                    Directory.CreateDirectory(screenshotPath);
                }
                // Take screenshot
                string pathName = screenshotPath + scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".png";
                TakeScreenshot(pathName);

                scenario.CreateNode<T>(scenarioContext.StepContext.StepInfo.Text)
                    .Fail(scenarioContext.TestError.Message + "\n" + scenarioContext.TestError.StackTrace, MediaEntityBuilder.CreateScreenCaptureFromPath(pathName).Build());
            }
            else
            {
                scenario.CreateNode<T>(scenarioContext.StepContext.StepInfo.Text);
            }
        }

        private static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Close();
                driver.Quit();
            }

        }

        private static void TakeScreenshot(string filePath)
        {
            // Take screenshot and save to the specified path
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(filePath);
        }
    }
}
