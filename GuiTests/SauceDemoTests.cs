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
            loginPage.LoginWithCredentials(_baseUrl, "BadUser", "BadPassword");
            loginPage.GetLoginError().Text
                .Should().Be("Epic sadface: Username and password do not match any user in this service");

            // Assert
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
            confirmation.GetTotal().Should().Be("Total: $43.18");
            confirmation.GetFinishButton().Click();

            CheckoutComplete checkoutComplete = new CheckoutComplete(_driver);
            checkoutComplete.GetCompleteText()
                .Should().Be("Your order has been dispatched, and will arrive just as fast as the pony can get there!");

        }

    }
}


