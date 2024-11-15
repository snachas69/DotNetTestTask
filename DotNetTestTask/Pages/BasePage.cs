using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace DotNetTestTask.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        private WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitForElement(By by)
        {
            return this.Wait.Until(driver => driver.FindElement(by));
        }

        public string GetPageTitle()
        {
            return this.Driver.Title;
        }
    }
}
