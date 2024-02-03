using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class Item
    {
        private readonly IWebDriver _driver;

        public Item(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement GetTitle()
        {
            return _driver.FindElement(By.CssSelector("div[class='inventory_details_name large_size']"));
        }
        public IWebElement GetDescription()
        {
            return _driver.FindElement(By.CssSelector("div[class='inventory_details_desc large_size']"));
        }
        public IWebElement GetPrice()
        {
            return _driver.FindElement(By.ClassName("inventory_details_price"));
        }
        public IWebElement GetTShirtAddToCartButton()
        {
            return _driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        }
        public IWebElement GetOnsieAddToCartButton()
        {
            return _driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        }
        public IWebElement GetGoBackToProductsButton()
        {
            return _driver.FindElement(By.Id("back-to-products"));
        }
        public IWebElement GetShoppingCartLink()
        {
            return _driver.FindElement(By.ClassName("shopping_cart_link"));
        }
    }
}
