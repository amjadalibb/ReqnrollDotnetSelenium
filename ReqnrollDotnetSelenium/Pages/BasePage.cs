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

        protected IWebElement FindElement(By by)
        {
            return elementHelper.FindElement(by);
        }
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

        protected bool IsElementPresent(By by)
        {
            return elementHelper.IsElementPresent(by);
        }

        protected void WaitForWebElement(By by)
        {
            elementHelper.WaitForWebElement(by);
        }

        protected void WaitForWebElementClickable(By by)
        {
            elementHelper.WaitForWebElementClickable(by);
        }
        protected void WaitForWebElementVisible(By by)
        {
            elementHelper.WaitForWebElementVisible(by);
        }
        protected void IsElementClickable(By by)
        {
            elementHelper.IsElementClickable(by);
        }

    }
}
