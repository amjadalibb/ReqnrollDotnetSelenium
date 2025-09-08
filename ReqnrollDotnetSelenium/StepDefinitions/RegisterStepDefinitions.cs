using OpenQA.Selenium;
using Reqnroll;
using ReqnrollDotnetSelenium.Pages;
using System;

namespace ReqnrollDotnetSelenium.StepDefinitions
{
    [Binding]
    public class RegisterStepDefinitions(IWebDriver driver)
    {
        private readonly LoginPage loginPage = new(driver);
        private readonly RegisterPage registerPage = new(driver);

        [Given("I am on Register page")]
        public void GivenIAmOnRegisterPage()
        {
            if (!registerPage.CheckRegisterPageRunning())
            {
                loginPage.BrowsePage();
                loginPage.ClickUserIcon();
                loginPage.WaitForLoginPageLoad();
                int retries = 3;
                do
                {
                    loginPage.ClickCreateNewAccount();
                    retries--;
                } while (!registerPage.CheckRegisterPageRunning() && retries > 0);
                registerPage.VerifyRegisterPageLoad();
            }
        }

        [When("I enter username {string} and email {string} and password {string} and confirm password {string}")]
        public void WhenIEnterUsernameAndEmailAndPasswordAndConfirmPassword(string username, string email, string password, string confirmpassword)
        {
            registerPage.EnterUsername(username);
            registerPage.EnterEmail(email);
            registerPage.EnterPassword(password);
            registerPage.EnterConfirmPassword(confirmpassword);
            Console.WriteLine($"Entered username: {username}, email: {email}, password: {password}, confirm password: {confirmpassword}");
        }

        [When("I Agree to the conditions of Use and Privacy Notice")]
        public void WhenIAgreeToTheConditionsOfUseAndPrivacyNotice()
        {
            registerPage.ClickIAgreeInput();
            Console.WriteLine("Clicked on I Agree to the conditions of Use and Privacy Notice");
        }

        [Then("I should see error message {string} for username field")]
        public void ThenIShouldSeeErrorMessageForUsernameField(string message)
        {
            registerPage.ValidateUsernameErrorMessage(message);
            Console.WriteLine($"Error message for username field: {message}");
        }

        [Then("I should see error message {string} for email field")]
        public void ThenIShouldSeeErrorMessageForEmailField(string message)
        {
            registerPage.ValidateEmailErrorMessage(message);
            Console.WriteLine($"Error message for email field: {message}");
        }

        [Then("I should see error message {string} for password field")]
        public void ThenIShouldSeeErrorMessageForPasswordField(string message)
        {
            registerPage.ValidatePasswordErrorMessage(message);
            Console.WriteLine($"Error message for password field: {message}");
        }

        [Then("I should see error message {string} for confirm password field")]
        public void ThenIShouldSeeErrorMessageForConfirmPasswordField(string message)
        {
            registerPage.ValidateConfirmPasswordErrorMessage(message);
            Console.WriteLine($"Error message for confirm password field: {message}");
        }
    }
}
