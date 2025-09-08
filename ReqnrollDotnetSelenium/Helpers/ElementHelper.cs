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

        public IWebElement FindElement(By by)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(10000);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            return wait.Until(d => d.FindElement(by));
        }

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
        
        public void WaitForWebElement(By by, int timeoutMs = 5000)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMs);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.Until(d => d.FindElement(by));
        }

        public IWebElement WaitForWebElementClickable(By by, int timeoutMs = 10000)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMs);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(1000)
            };
            return wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }

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
