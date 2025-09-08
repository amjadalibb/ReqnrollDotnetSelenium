using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReqnrollDotnetSelenium.Config
{
    public class DriverConfig
    {
        // Initialize WebDriver based on the specified browser type
        public IWebDriver InitializeDriver(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Safari:
                    return new SafariDriver();

                case BrowserType.Edge:
                    return new EdgeDriver();

                case BrowserType.Firefox:
                    return new FirefoxDriver();

                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    chromeOptions.AddArguments("start-maximized");
                    return new ChromeDriver(chromeOptions);

                default:
                    throw new ArgumentException("Browser is not available");
            }
        }
        // Enum for supported browser types
        public enum BrowserType
        {
            Safari,
            Edge,
            Firefox,
            Chrome
        };
    }
}
