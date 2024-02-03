using OpenQA.Selenium;

namespace LawDepotInterview.GuiTests.PageObjects
{
    public class Confirmation
    {
        private readonly IWebDriver _driver;

        public Confirmation(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement GetFinishButton()
        {
            return _driver.FindElement(By.Id("finish"));
        }

        public IWebElement GetTotal()
        {
            return _driver.FindElement(By.ClassName("summary_info_label summary_total_label"));
        }
    }
}
