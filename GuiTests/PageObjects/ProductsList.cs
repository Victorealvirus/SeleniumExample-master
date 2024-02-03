﻿using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class ProductsList
    {
        private readonly IWebDriver _driver;

        public ProductsList(IWebDriver driver)
        {
            _driver = driver;
            GetInventory = _driver.FindElement(By.Id("inventory_container"));
            GetBackpackAddToCartButton = _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            GetBikeLightAddToCartButton = _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            GetShoppingCartLink = _driver.FindElement(By.ClassName("shopping_cart_link"));
        }
        public IWebElement GetInventory { get; set; }
        public IWebElement GetBackpackAddToCartButton { get; set; }
        public IWebElement GetBikeLightAddToCartButton { get; set; }
        public IWebElement GetShoppingCartLink { get; set; }
    }    
}
