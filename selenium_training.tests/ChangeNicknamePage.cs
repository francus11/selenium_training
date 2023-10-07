using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_training.tests
{
    internal class ChangeNicknamePage
    {
        private IWebDriver driver;
        public ChangeNicknamePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public By SettingsButton { get; set; } = By.ClassName("icon-gearwheel");
        public By MainSettings { get; set; } = By.LinkText("Główne ustawienia");
        public By NicknameField { get; set; } = By.CssSelector(".FormInput>input");
        //public By NicknameField { get; set; } = By.ClassName("menu-account");

        public void GoToGeneralSettings()
        {
            driver.Navigate().GoToUrl("https://ustawienia-pocztowe.interia.pl/#/ustawienia?iwa_source=poczta_next_ustawienia");
        }

        public void ChangeNickname(string nickname)
        {
            driver.FindElement(NicknameField).Click();
            driver.FindElement(NicknameField).SendKeys(Keys.Control + "a");
            driver.FindElement(NicknameField).SendKeys(Keys.Delete);
            driver.FindElement(NicknameField).SendKeys(nickname);
            driver.FindElement(NicknameField).Submit();
        }

        public string CheckNickname()
        {
            return driver.FindElement(NicknameField).GetAttribute("value");
        }
    }
}
