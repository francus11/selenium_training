using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_training.tests
{
    internal class ReceiveMailPage
    {
        private IWebDriver webDriver;

        public By UnreadMail { get; set; } = By.CssSelector(".mail-list__item.is-unread");
        public By IFrameBox { get; set; } = By.XPath("//div/iframe");
        public By TextField { get; set; } = By.CssSelector("div p");
        public ReceiveMailPage(IWebDriver driver)
        {
            webDriver = driver;
            PageFactory.InitElements(webDriver, this);
        }

        public string ReceivedMail(string mail)
        {
            webDriver.FindElement(UnreadMail).Click();
            Thread.Sleep(1000);
            IWebElement webElement = webDriver.FindElement(IFrameBox);
            webDriver.SwitchTo().Frame(webElement);

            string text = webDriver.FindElement(TextField).Text;

            webDriver.SwitchTo().DefaultContent();

            return text;
        }
    }
}
