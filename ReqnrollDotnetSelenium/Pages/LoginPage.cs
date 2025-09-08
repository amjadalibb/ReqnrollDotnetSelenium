using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using ReqnrollDotnetSelenium.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollDotnetSelenium.Pages
{
    public class LoginPage(IWebDriver webDriver) : BasePage(webDriver)
    {
        readonly IWebDriver driver = webDriver;

        // Read application details from appsettings.json
        readonly string? applicationURL = appSettings.GetAppSettings("applicationDetails:url");
        readonly string? appTitle = appSettings.GetAppSettings("applicationDetails:title");

        // Locators
        private readonly By UserIcon = By.Id("menuUserLink");

        private readonly By CreateNewAccount = By.XPath("//a[@translate='CREATE_NEW_ACCOUNT']");

        // Methods to interact with the page
        public void BrowsePage()
        {
            if (string.IsNullOrEmpty(applicationURL))
                throw new InvalidOperationException("Application URL is not configured.");
            driver.Navigate().GoToUrl(applicationURL);
            driver.Manage().Window.Maximize();
            IsElementPresent(UserIcon);
        }

        // Verify if application is running
        public void VerifyApplicationRunning()
        {
            if (driver.Title != null && driver.Title.Equals(appTitle))
                Assert.That(true, "Application is Running");
            else
                BrowsePage();
        }

        // Click on Create New Account
        public void ClickCreateNewAccount()
        {
            ClickElement(CreateNewAccount);
        }

        //  Click on User Icon
        public void ClickUserIcon()
        {
            FindElement(UserIcon).Click();
        }

        // Wait for Login page load
        public void WaitForLoginPageLoad()
        {
            WaitForWebElementClickable(CreateNewAccount);
        }
    }
}
