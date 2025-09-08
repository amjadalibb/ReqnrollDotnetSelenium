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
    public class RegisterPage(IWebDriver webDriver) : BasePage(webDriver)
    {
        // Locators by ID, Name, XPath
        private readonly By RegisterPageSection = By.Id("registerPage");

        private readonly By UsernameField = By.Name("usernameRegisterPage");
        private readonly By EmailField = By.Name("emailRegisterPage");
        private readonly By PasswordField = By.Name("passwordRegisterPage");
        private readonly By ConfirmPasswordField = By.Name("confirm_passwordRegisterPage");
        private readonly By IAgreeInput = By.Name("i_agree");

        // Dynamic XPaths for error messages
        private readonly string dynUsernameErrorMsgFieldXPath = "//*[@sec-name='userName']/div/label[contains(text(), \"{0}\")]";
        private readonly string dynEmailErrorMsgFieldXPath = "//*[@sec-name='userEmail']/div/label[contains(text(), \"{0}\")]";
        private readonly string dynPasswordErrorMsgFieldXPath = "//*[@sec-name='userPassword' and @a-hint='Password']/div/label[contains(text(), \"{0}\")]";
        private readonly string dynCnfrmPasswordErrorMsgFieldXPath = "//*[@sec-name='userPassword' and @a-hint='Confirm password']/div/label[contains(text(), \"{0}\")]";

        // Verify if register page is running
        public bool CheckRegisterPageRunning()
        {
            return IsElementPresent(RegisterPageSection);
        }

        // Verify if register page is running
        public void VerifyRegisterPageLoad()
        {
            Assert.That(CheckRegisterPageRunning(), Is.True, "Register Page is not loading.");
        }

        // Enter user details Username, Email, Password, Confirm Password
        public void EnterUsername(string username)
        {
            SendKeys(UsernameField, username);
        }

        public void EnterEmail(string email)
        {
            SendKeys(EmailField, email);
        }

        public void EnterPassword(string password)
        {
            SendKeys(PasswordField, password);
        }

        public void EnterConfirmPassword(string confirmPassword)
        {
            SendKeys(ConfirmPasswordField, confirmPassword);
        }

        // Click on I Agree to the conditions of Use and Privacy Notice
        public void ClickIAgreeInput()
        {
            ClickElement(IAgreeInput);
        }

        // Validate error messages for Username, Email, Password, Confirm Password fields
        public void ValidateUsernameErrorMessage(string message)
        {
            Assert.That(FindElement(By.XPath(string.Format(dynUsernameErrorMsgFieldXPath, message))).Text, Is.EqualTo(message.Replace("  ", " ")));
        }
        public void ValidateEmailErrorMessage(string message)
        {
            Assert.That(FindElement(By.XPath(string.Format(dynEmailErrorMsgFieldXPath, message))).Text, Is.EqualTo(message));
        }
        public void ValidatePasswordErrorMessage(string message)
        {
            Assert.That(FindElement(By.XPath(string.Format(dynPasswordErrorMsgFieldXPath, message))).Text, Is.EqualTo(message.Replace("  ", " ")));
        }
        public void ValidateConfirmPasswordErrorMessage(string message)
        {
            Assert.That(FindElement(By.XPath(string.Format(dynCnfrmPasswordErrorMsgFieldXPath, message))).Text, Is.EqualTo(message));
        }

        // Validate error messages cleared for Username, Email, Password, Confirm Password fields
        public void ValidateErrorUsernameMessageCleared(string message)
        {
            Assert.That(IsElementPresent(By.XPath(string.Format(dynUsernameErrorMsgFieldXPath, message))), Is.False, "Username error message did not clear");
        }
        public void ValidateErrorEmailMessageCleared(string message)
        {
            Assert.That(IsElementPresent(By.XPath(string.Format(dynEmailErrorMsgFieldXPath, message))), Is.False, "Email error message did not clear");
        }
        public void ValidateErrorPasswordMessageCleared(string message)
        {
            Assert.That(IsElementPresent(By.XPath(string.Format(dynPasswordErrorMsgFieldXPath, message))), Is.False, "Password error message did not clear");
        }
        public void ValidateErrorCnfrmPasswordMessageCleared(string message)
        {
            Assert.That(IsElementPresent(By.XPath(string.Format(dynCnfrmPasswordErrorMsgFieldXPath, message))), Is.False, "Confirm Password error message did not clear");
        }
    }
}
