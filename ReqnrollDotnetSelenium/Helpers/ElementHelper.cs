using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.BrowsingContext;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace ReqnrollDotnetSelenium.Helpers
{
    public class ElementHelper(IWebDriver webDriver)
    {
        private readonly IWebDriver driver = webDriver;

        // Find element with a default timeout of 5000ms
        public IWebElement FindElement(By by)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(5000);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            return wait.Until(d => d.FindElement(by));
        }

        // Check if an element is present on the page
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        // Check if an element is clickable
        public bool IsElementClickable(By by)
        {
            try
            {
                ExpectedConditions.ElementToBeClickable(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        // Wait for an element to be present with a customizable timeout
        public void WaitForWebElement(By by, int timeoutMs = 5000)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMs);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.Until(d => d.FindElement(by));
        }

        // Wait for an element to be clickable with a customizable timeout
        public IWebElement WaitForWebElementClickable(By by, int timeoutMs = 5000)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMs);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(1000)
            };
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

        // Wait for an element to be visible with a customizable timeout
        public void WaitForWebElementVisible(By by, int timeoutMs = 5000)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMs);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }        
    }
}
