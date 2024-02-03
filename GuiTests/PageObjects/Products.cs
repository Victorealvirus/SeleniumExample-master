using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
        public IWebElement GetBikeLightRemoveFromCartButton()
        {
            return _driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        }
        public IWebElement GetShoppingCartLink()
        {
            return _driver.FindElement(By.ClassName("shopping_cart_link"));
        }
        public IWebElement GetTShirtLink()
        {
            return _driver.FindElement(By.Id("item_1_title_link"));
        }
        public IWebElement GetOnsieLink()
        {
            return _driver.FindElement(By.Id("item_2_title_link"));
        }

        public IWebElement GetHamburgerMenuButton()
        {
            return _driver.FindElement(By.ClassName("bm-burger-button"));
        }
        public IWebElement GetLogoutButton()
        {
            return _driver.FindElement(By.Id("logout_sidebar_link"));
        }
        public void SetProductSortOrder(string sortOrder)
        {
            var select = new SelectElement(_driver.FindElement(By.ClassName("product_sort_container")));
            select.SelectByText(sortOrder);
        }
    }
}
