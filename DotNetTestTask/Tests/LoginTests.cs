using DotNetTestTask.Pages;
using FluentAssertions;
using OpenQA.Selenium;

namespace DotNetTestTask.Tests
{
    public class LoginTests : IClassFixture<TestFixture>
    {
        private readonly IWebDriver driver;
        private readonly LoginPage loginPage;
        private readonly DashboardPage dashboardPage;

        public LoginTests(TestFixture fixture)
        {
            this.driver = fixture.Driver;
            this.loginPage = new LoginPage(this.driver);
            this.dashboardPage = new DashboardPage(this.driver);
        }

        [Theory]
        [InlineData("", "", "Username is required")]
        [InlineData("standard_user", "", "Password is required")]
        [InlineData("non-standard_user", "secret_sauce", "Username and password do not match any user in this service")]
        [InlineData("non-standard_user", "secret_recipe", "Username and password do not match any user in this service")]
        public void TestLoginErrorMessages(string username, string password, string expectedError)
        {
            // Act
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClickLogin();

            // Assert
            string actualError = loginPage.GetErrorMessage();
            actualError.Should().Contain(expectedError);
        }

        [Fact]
        public void TestSuccessfulLogin()
        {
            // Arrange
            string validUsername = "standard_user";
            string validPassword = "secret_sauce";
            string expectedTitle = "Swag Labs";

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Act
            loginPage.EnterUsername(validUsername);
            loginPage.EnterPassword(validPassword);
            loginPage.ClickLogin();

            // Assert
            // Validate that the user successfully lands on the dashboard page
            dashboardPage.IsOnDashboard().Should().BeTrue("because the user should be redirected to the dashboard after a successful login");

            // Validate that the page title matches the expected title
            driver.Title.Should().Be(expectedTitle, $"because the page title should be '{expectedTitle}' after login");
        }
    }
}
