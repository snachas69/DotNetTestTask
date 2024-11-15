using OpenQA.Selenium;

namespace DotNetTestTask.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver) { }

        public bool IsOnDashboard()
        {
            return this.Driver.Url == "https://www.saucedemo.com/inventory.html";
        }
    }
}
