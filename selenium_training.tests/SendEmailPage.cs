using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace selenium_training.tests
{
    internal class SendEmailPage
    {
        private IWebDriver driver;

        public By NewMessageButton { get; set; } = By.ClassName("navigation__new");
        public By EmailField { get; set; } = By.ClassName("email-input-plain-input");
        public By SubjectField { get; set; } = By.Id("subject");
        public By TextFrame { get; set; } = By.Id("uiTinymce0_ifr");
        public By TextField { get; set; } = By.Id("tinymce");
        public By SendButton { get; set; } = By.XPath("//button[@ng-click='sendButtonClickHandler()']");


        public SendEmailPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void SendEmail(string email, string text)
        {
            driver.FindElement(NewMessageButton).Click();
            driver.FindElement(EmailField).SendKeys(email);
            driver.FindElement(SubjectField).SendKeys("Test");
            driver.SwitchTo().Frame("uiTinymce0_ifr");
            driver.FindElement(TextField).SendKeys(text);
            driver.SwitchTo().DefaultContent();
            driver.FindElement(SendButton).Click();

        }
    }
}
