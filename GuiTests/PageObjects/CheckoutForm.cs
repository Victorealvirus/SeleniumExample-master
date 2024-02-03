using OpenQA.Selenium;
using System;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class CheckoutForm
    {
        private readonly IWebDriver _driver;

        public CheckoutForm(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement GetFirstNameField()
        {
            return _driver.FindElement(By.Id("first-name"));
        }
        public void SetFirstNameField(string firstName = "First Name")
        {
            IWebElement firstNameField = GetFirstNameField();
            firstNameField.Clear();
            firstNameField.SendKeys(firstName);
        }
        public IWebElement GetLastNameField()
        {
            return _driver.FindElement(By.Id("last-name"));
        }
        public void SetLastNameField(string lastName = "Last Name")
        {
            IWebElement lastNameField = GetLastNameField();
            lastNameField.Clear();
            lastNameField.SendKeys(lastName);
        }
        public IWebElement GetPostalCodeField()
        {
            return _driver.FindElement(By.Id("postal-code"));
        }
        public void SetPostalCodeField(string postalCode = "Postal Code")
        {
            IWebElement postalCodeField = GetPostalCodeField();
            postalCodeField.Clear();
            postalCodeField.SendKeys(postalCode);
        }

        public IWebElement GetContinueButton()
        {
            return _driver.FindElement(By.Id("continue"));
        }
        public IWebElement GetError()
        {
            return _driver.FindElement(By.CssSelector("div[class='error-message-container error']"));
        }
    }
}
