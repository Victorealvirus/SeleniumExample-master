using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class Products
    {
        private readonly IWebDriver _driver;

        public Products(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement GetInventory()
        {
            return _driver.FindElement(By.Id("inventory_container"));
        }
        public IWebElement GetBackpackAddToCartButton()
        {
            return _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
        }
        public IWebElement GetBikeLightAddToCartButton()
        {
            return _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        }
        public IWebElement GetShoppingCartLink()
        {
            return _driver.FindElement(By.ClassName("shopping_cart_link"));
        }
    }    
}
