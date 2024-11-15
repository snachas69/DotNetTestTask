using OpenQA.Selenium;

namespace DotNetTestTask.Drivers
{
    public class WebDriverSingleton
    {
        private static IWebDriver? driver;

        public static IWebDriver GetDriver(string browserType)
        {
            if (driver == null)
            {
                driver = WebDriverFactory.CreateWebDriver(browserType);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void QuitDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
