using DotNetTestTask.Drivers;
using DotNetTestTask.Utilities;
using OpenQA.Selenium;
namespace DotNetTestTask.Tests
{
    public class TestFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public TestFixture()
        {
            string browser = Config.Browser ?? "chrome";

            this.Driver = WebDriverSingleton.GetDriver(browser);
        }

        public void Dispose()
        {
            this.Driver?.Quit();
        }
    }
}
