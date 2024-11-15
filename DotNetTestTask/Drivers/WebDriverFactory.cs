using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium;

namespace DotNetTestTask.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browser)
        {
            IWebDriver driver;

            switch (browser.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "safari":
                    driver = new SafariDriver();
                    break;
                default:
                    throw new ArgumentException("Unsupported browser type");
            }

            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
