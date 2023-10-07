using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace selenium_training.tests
{
    internal class ChangeNicknameTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void ChangeNickname_CorrectValues_Success()
        {
            string url = "https://poczta.interia.pl/logowanie/";
            LogInPage logInPage = new LogInPage(driver, url);
            string email = "testingemail1@interia.eu";
            string password = "VeryStrongPassword";
            string expectedNickname = "New Nickname";
            logInPage.PopUpClick();

            IWebDriver mainPage = logInPage.LogIn(email, password);
            ChangeNicknamePage changeNicknamePage = new ChangeNicknamePage(mainPage);
            changeNicknamePage.GoToGeneralSettings();
            changeNicknamePage.ChangeNickname(expectedNickname);

            changeNicknamePage.GoToGeneralSettings();
            Thread.Sleep(2000);
            string actual = changeNicknamePage.CheckNickname();

            Assert.That(actual, Is.EqualTo(expectedNickname));

        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
