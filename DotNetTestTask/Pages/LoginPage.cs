using DotNetTestTask.Utilities;
using OpenQA.Selenium;

namespace DotNetTestTask.Pages
{
    internal class LoginPage : BasePage
    {
        private IWebElement UsernameInput => Driver.FindElement(By.Id("user-name"));
        private IWebElement PasswordInput => Driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => Driver.FindElement(By.CssSelector("#login-button"));
        private IWebElement ErrorMessage => Driver.FindElement(By.CssSelector(".error-message-container"));

        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.Driver.Navigate().GoToUrl(Config.BaseUrl);
        }

        public void EnterUsername(string username)
        {
            this.UsernameInput.Clear();
            this.UsernameInput.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            this.PasswordInput.Clear();
            this.PasswordInput.SendKeys(password);
        }

        public void ClickLogin()
        {
            this.LoginButton.Click();
        }

        public string GetErrorMessage()
        {
            return this.ErrorMessage.Text;
        }
    }
}
