using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class ProductsList
    {
        private readonly IWebDriver _driver;

        public ProductsList(IWebDriver driver)
        {
            _driver = driver;
            GetInventory = _driver.FindElement(By.Id("inventory_container"));

        }
        public IWebElement GetInventory { get; set; }
    }
}
