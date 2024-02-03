using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class CartList
    {
        private readonly IWebDriver _driver;

        public CartList(IWebDriver driver)
        {
            _driver = driver;
            GetInventory = _driver.FindElement(By.Id("inventory_container"));
        }
        public IWebElement GetInventory { get; set; }
        public IWebElement GetBackpackAddToCartButton { get; set; }
        public IWebElement GetBikeLightAddToCartButton { get; set; }
        public IWebElement GetShoppingCartLink { get; set; }
    }
}
