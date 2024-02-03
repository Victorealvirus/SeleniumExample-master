using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class Login
    {
        private readonly IWebDriver _driver;

        public Login(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UserIdField { get; set; }
        public IWebElement PasswordField { get; set; }
        public IWebElement LoginButton { get; set; }

        private string stdUser = "standard_user";
        private string stdPassword = "secret_sauce";


        public void LoginWithCredentials(string baseUrl, string username, string password)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            UserIdField = _driver.FindElement(By.Id("user-name"));
            UserIdField.Clear();
            UserIdField.SendKeys(username);

            PasswordField = _driver.FindElement(By.Id("password"));
            PasswordField.Clear();
            PasswordField.SendKeys(password);

            LoginButton = _driver.FindElement(By.Id("login-button"));
            LoginButton.Click();
        }

        public void LoginAsStandardUser(string baseUrl)
        {
            LoginWithCredentials(baseUrl, stdUser, stdPassword);
        }

        public IWebElement GetLoginError()
        {
            return _driver.FindElement(By.CssSelector("div[class='error-message-container error']"));
        }
    }
}