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
        // Locators
        private readonly By RegisterButton = By.Id("register_btn");
        private readonly By RegisterPageSection = By.Id("registerPage");

        private readonly By UsernameField = By.Name("usernameRegisterPage");
        private readonly By EmailField = By.Name("emailRegisterPage");
        private readonly By PasswordField = By.Name("passwordRegisterPage");
        private readonly By ConfirmPasswordField = By.Name("confirm_passwordRegisterPage");
        private readonly By IAgreeInput = By.Name("i_agree");

        private readonly By UsernameErrorMessage = By.XPath("//*[@sec-name='userName']/div/label");
        private readonly By EmailErrorMessage = By.XPath("//*[@sec-name='userEmail']/div/label");
        private readonly By PasswordErrorMessage = By.XPath("//*[@sec-name='userPassword' and @a-hint='Password']/div/label");
        private readonly By ConfirmPasswordErrorMessage = By.XPath("//*[@sec-name='userPassword' and @a-hint='Confirm password']/div/label");

        public bool CheckRegisterPageRunning()
        {
            return IsElementPresent(RegisterPageSection);
        }

        // Verify if register page is running
        public void VerifyRegisterPageLoad()
        {
            Assert.That(CheckRegisterPageRunning(), Is.True, "Register Page is not loading.");
        }

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

        public void ClickRegisterButton()
        {
            ClickElement(RegisterButton);
        }

        public void ClickIAgreeInput()
        {
            ClickElement(IAgreeInput);
        }

        public void ValidateUsernameErrorMessage(string message)
        {
            Assert.That(FindElement(UsernameErrorMessage).Text, Is.EqualTo(message));
        }

        public bool IsErrorUsernameMessageDisplayed()
        {
            return IsElementPresent(UsernameErrorMessage);
        }

        public void ValidateEmailErrorMessage(string message)
        {
            Assert.That(FindElement(EmailErrorMessage).Text, Is.EqualTo(message));
        }

        public bool IsErrorEmailMessageDisplayed()
        {
            return IsElementPresent(EmailErrorMessage);
        }

        public void ValidatePasswordErrorMessage(string message)
        {
            Assert.That(FindElement(PasswordErrorMessage).Text, Is.EqualTo(message));
        }

        public bool IsErrorPasswordMessageDisplayed()
        {
            return IsElementPresent(PasswordErrorMessage);
        }

        public void ValidateConfirmPasswordErrorMessage(string message)
        {
            Assert.That(FindElement(ConfirmPasswordErrorMessage).Text, Is.EqualTo(message));
        }

        public bool IsErrorConfirmPasswordMessageDisplayed()
        {
            return IsElementPresent(ConfirmPasswordErrorMessage);
        }
    }
}
