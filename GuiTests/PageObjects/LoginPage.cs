using OpenQA.Selenium;

namespace Tests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement UserIdField { get; set; }
        public IWebElement PasswordField { get; set; }
        public IWebElement LoginButton { get; set; }

        private string stdUser = "standard_user";
        private string stdPassword = "secret_sauce";


        public void LoginAsStdUser(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            UserIdField = _driver.FindElement(By.Id("user-name"));
            UserIdField.Clear();
            UserIdField.SendKeys(stdUser);

            PasswordField = _driver.FindElement(By.Id("password"));
            PasswordField.Clear();
            PasswordField.SendKeys(stdPassword);

            LoginButton = _driver.FindElement(By.Id("login-button"));
            LoginButton.Click();
        }
    }
}