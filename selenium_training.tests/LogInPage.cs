using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_training.tests
{
    internal class LogInPage
    {
        private IWebDriver driver;

        public LogInPage(IWebDriver driver, string url)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
            Navigate(url);
        }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement LogInButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "navigation__new")]
        public IWebElement NewMessageButton { get; set; }

        public By RodoButton { get; set; } = By.ClassName("rodo-popup-agree");

        public void Navigate(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void PopUpClick()
        {
            driver.FindElement(RodoButton).Click();
        }

        public IWebDriver LogIn(string email, string password)
        {
            EmailField.Clear();
            PasswordField.Clear();
            EmailField.SendKeys(email);
            PasswordField.SendKeys(password);
            PasswordField.Submit();
            return driver;
        }

        public void ValidateLogIn(string expectedCount)
        {
            Assert.IsTrue(driver.Url.Contains(expectedCount));
        }

        public void SendEmail(string email, string text)
        {
            NewMessageButton.Click();
            
        }

    }
}
