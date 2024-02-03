using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class CheckoutComplete
    {
        private readonly IWebDriver _driver;

        public CheckoutComplete(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement GetCompleteText()
        {
            return _driver.FindElement(By.ClassName("complete-text"));
        }
    }
}
