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
        IWebElement FirstNameField { get; set; }
        IWebElement LastNameField { get; set; }
        IWebElement PostalCodeField { get; set; }
        public IWebElement GetFirstNameField()
        {
            return FirstNameField = _driver.FindElement(By.Id("first-name"));
        }
        public void SetFirstNameField(string firstName = "First Name")
        {
            FirstNameField.Clear();
            FirstNameField.SendKeys(firstName);
        }
        public IWebElement GetLastNameField()
        {
            return LastNameField = _driver.FindElement(By.Id("last-name"));
        }
        public void SetLastNameField(string lastName = "Last Name")
        {
            LastNameField.Clear();
            LastNameField.SendKeys(lastName);
        }
        public IWebElement GetPostalCodeField()
        {
            return PostalCodeField = _driver.FindElement(By.Id("postal-code"));
        }
        public void SetPostalCodeField(string postalCode = "Postal Code")
        {
            PostalCodeField.Clear();
            PostalCodeField.SendKeys(postalCode);
        }

        public IWebElement GetContinueButton()
        {
            return _driver.FindElement(By.Id("continue"));
        }
    }
}
