using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class Cart
    {
        private readonly IWebDriver _driver;

        public Cart(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement GetCheckoutButton()
        {
            return _driver.FindElement(By.Id("checkout"));
        }
    }
}
