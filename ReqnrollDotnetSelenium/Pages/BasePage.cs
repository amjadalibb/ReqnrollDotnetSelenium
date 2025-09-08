using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using ReqnrollDotnetSelenium.Helpers;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReqnrollDotnetSelenium.Pages
{
    public abstract class BasePage(IWebDriver webDriver)
    {
        readonly ElementHelper elementHelper = new(webDriver);

        // Find an element using the ElementHelper
        protected IWebElement FindElement(By by)
        {
            return elementHelper.FindElement(by);
        }
        // Send keys to an input field
        protected void SendKeys(By by, string message)
        {
            try
            {
                IWebElement elem = FindElement(by);
                elem.Clear();
                elem.SendKeys(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Element exception: {ex.Message}");
            }
        }
        //  Click an element
        protected void ClickElement(By by)
        {
            try
            {
                IWebElement elem = elementHelper.WaitForWebElementClickable(by);
                elem.Click();
            }
            catch (ElementClickInterceptedException ex)
            {
                Console.WriteLine($"Element click intercepted: {ex.Message}");
            }
        }

        // Check if an element is present on the page
        protected bool IsElementPresent(By by)
        {
            return elementHelper.IsElementPresent(by);
        }

        // Wait for an element to be clickable
        protected void WaitForWebElementClickable(By by)
        {
            elementHelper.WaitForWebElementClickable(by);
        }
    }
}
