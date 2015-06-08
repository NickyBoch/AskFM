using AskFm.Base;
using OpenQA.Selenium;
using NUnitReporter.Reporting;

namespace AskFm.Pages
{
    internal class LoginPage : BasePage
    {
        private By _loginMenuClick = By.ClassName("link-login");
        private By _loginInput = By.Id("login");
        private By _passInput = By.Id("password");
        private By _loginSubmit = By.Id("logBox_submit-button");
        private By _logoutSubmit = By.ClassName("link-logout");

        public void Open()
        {
            Reporter.Log("Navigate to site main page");
            Driver.Navigate().GoToUrl("http://ask.fm/");
        }

        internal void LoginClick()
        {
            Click("Login menu click", _loginMenuClick);
        }

        public void LogOut()
        {
            Click("Logout click", _logoutSubmit);
        }

        internal void WaitForLogoutButton()
        {
            Reporter.Log("Wait for logout button");
            WaitForElementPresent(_logoutSubmit);
        }

        internal void TypeLogin(string login)
        {
            Type("Type login: " + login, login, _loginInput);
        }

        internal void TypePassword(string password)
        {
            Type("Type password: " + password, password, _passInput);
        }

        internal void SubminLogin()
        {
            Click("Login submit click", _loginSubmit);
        }

        internal void WaitForLoginButton()
        {
            Reporter.Log("Wait for login button");
            WaitForElementPresent(_loginMenuClick);
        }
    }
}
