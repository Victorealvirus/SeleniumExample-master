using FluentAssertions;
using LawDepotInterview.GuiTests.PageObjects;
using LawDepotInterview.GuiTests.SeleniumHelpers;
using LawDepotInterview.GuiTests.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text;
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
        public void LoginWithValidCredentialsShouldSucceed()
        {
            // Arrange
            // Act
            new LoginPage(_driver).LoginAsStdUser(_baseUrl);

            // Assert
            new ProductsList(_driver).GetInventory.Displayed.Should().BeTrue();
        }

    }
}


