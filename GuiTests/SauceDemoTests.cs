using FluentAssertions;
using LawDepotInterview.GuiTests.PageObjects;
using LawDepotInterview.GuiTests.SeleniumHelpers;
using LawDepotInterview.GuiTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Tests.PageObjects;

namespace LawDepotInterview.GuiTests
{
    [TestFixture]
    public class SauceDemoTests
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Create();
            _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
            _verificationErrors.ToString().Should().BeEmpty("No verification errors are expected.");
        }

        [Test]
        public void LoginWithInvalidCredentialsShouldFailWithCorrectErrors()
        {
            // Arrange
            // Act
            Login loginPage = new Login(_driver);

            //Invalid credentials
            loginPage.LoginWithCredentials(_baseUrl, "BadUser", "BadPassword");

            //Assert
            loginPage.GetLoginError().Text
                .Should().Be("Epic sadface: Username and password do not match any user in this service");

            //Invalid credentials
            loginPage.LoginWithCredentials(_baseUrl, "locked_out_user", "secret_sauce");

            // Assert
            loginPage.GetLoginError().Text
                .Should().Be("Epic sadface: Sorry, this user has been locked out.");
        }


        [Test]
        public void CheckoutWithGoodDataShouldSucceed()
        {
            // Arrange
            // Act

            Login loginPage = new Login(_driver);
            loginPage.LoginAsStdUser(_baseUrl);

            //Add two items to cart
            Products productsList = new Products(_driver);
            productsList
                .GetBackpackAddToCartButton().Click();
            productsList
                .GetBikeLightAddToCartButton().Click();
            productsList
                .GetShoppingCartLink().Click();

            Cart cart = new Cart(_driver);
            cart.GetCheckoutButton().Click();

            //Fill Checkout form with valid user data
            CheckoutForm checkoutForm = new CheckoutForm(_driver);
            checkoutForm.SetFirstNameField();
            checkoutForm.SetLastNameField();
            checkoutForm.SetPostalCodeField();
            checkoutForm.GetContinueButton().Click();

            // Assert

            //Total should be as expected
            Confirmation confirmation = new Confirmation(_driver);
            confirmation.GetTotal().Text.Should().Be("Total: $43.18");
            confirmation.GetFinishButton().Click();

            CheckoutComplete checkoutComplete = new CheckoutComplete(_driver);
            checkoutComplete.GetCompleteText().Text
                .Should().Be("Your order has been dispatched, and will arrive just as fast as the pony can get there!");

            //We get back to the products page
            checkoutComplete.GetBackToProductsButton().Click();
            productsList.GetInventory().Displayed.Should().BeTrue();
        }


        [Test]
        public void AddingToCartFromItemPageShouldSucceed()
        {
            // Arrange
            // Act

            Login loginPage = new Login(_driver);
            loginPage.LoginAsStdUser(_baseUrl);

            //Validate data and Add Sauce Labs Bolt T-Shirt to cart
            Products productsList = new Products(_driver);
            productsList.GetTShirtLink().Click();

            Item item = new Item(_driver);
            item.GetTitle().Text.Should().Be("Sauce Labs Bolt T-Shirt");
            item.GetDescription().Text
                .Should().Be("Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.");
            item.GetPrice().Text.Should().Be("$15.99");
            item.GetTShirtAddToCartButton().Click();

            //We should return to products page
            item.GetGoBackToProductsButton().Click();
            productsList.GetInventory().Displayed.Should().BeTrue();

            //Go into onsie page and add to cart
            productsList.GetOnsieLink().Click();
            item.GetOnsieAddToCartButton().Click();
            item.GetShoppingCartLink().Click();

            //Cart should reflect the right items
            Cart cart = new Cart(_driver);
            IList<IWebElement> elements = _driver.FindElements(By.ClassName("inventory_item_name"));
            elements[0].Text.Should().Be("Sauce Labs Bolt T-Shirt");
            elements[1].Text.Should().Be("Sauce Labs Onesie");
        }
    }
}


