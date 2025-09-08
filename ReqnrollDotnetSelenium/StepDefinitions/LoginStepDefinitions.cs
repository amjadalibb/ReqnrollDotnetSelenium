using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using Reqnroll;
using ReqnrollDotnetSelenium.Helpers;
using ReqnrollDotnetSelenium.Pages;
using System;

namespace ReqnrollDotnetSelenium.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions(IWebDriver driver)
    {
        readonly string? userName = appSettings.GetAppSettings("applicationDetails:userName");
        readonly string? password = appSettings.GetAppSettings("applicationDetails:password");

        private readonly LoginPage loginPage = new(driver);

        [Given("I navigate to Advantage Shopping site")]
        public void GivenINavigateToAdvantageShoppingSite()
        {
            loginPage.BrowsePage();
            Console.WriteLine("Navigated to Advantage Shopping site");
        }

        [When("I click on the login link")]
        public void WhenIClickOnTheLoginLink()
        {
            loginPage.ClickUserIcon();
            Console.WriteLine("Clicked on the login link");
        }

        [When("I click Sign In")]
        public void WhenIClickSignIn()
        {
            loginPage.ClickSignIn();
            Console.WriteLine("Clicked on the Signin Button");
        }

        [Then("I should login successfully with valid username and password")]
        public void ThenIShouldLoginSuccessfullyWithValidUsernameAndPassword()
        {
            loginPage.VerifySignInUser(userName);
            Console.WriteLine("Login successful");
        }


        [When("I enter valid username and password")]
        public void WhenIEnterValidUsernameAndPassword()
        {
            if (userName is null)
                throw new ArgumentNullException(nameof(userName), "Username cannot be null.");
            if (password is null)
                throw new ArgumentNullException(nameof(password), "Password cannot be null.");
            loginPage.EnterUsername(userName);
            loginPage.EnterPassword(password);
            Console.WriteLine($"Entered username: {userName} and password: {password}");
        }
    }
}
