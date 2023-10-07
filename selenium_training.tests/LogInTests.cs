using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using SeleniumExtras.PageObjects;

namespace selenium_training.tests
{
    public class LogInTests
    {
        IWebDriver webDriver;

        [SetUp]
        public void SetUp() 
        {
            webDriver = new EdgeDriver();
        }

        [Test]
        public void LogIn_CorrectCrudentials_LogInSuccessfully()
        {
            string url = "https://poczta.interia.pl/logowanie/";
            LogInPage logInPage = new LogInPage(webDriver, url);
            string email = "testingemail1@interia.eu";
            string password = "VeryStrongPassword";
            string expectedUrl = "https://poczta.interia.pl/next";

            logInPage.LogIn(email, password);

            logInPage.ValidateLogIn(expectedUrl);
        }

        [TestCase("blabla", "bla")]
        [TestCase("blabla", "")]
        [TestCase("", "bla")]
        [TestCase("", "")]
        public void LogIn_IncorrectCrudentials_LogInfailed(string email, string password)
        {
            string url = "https://poczta.interia.pl/logowanie/";
            LogInPage logInPage = new LogInPage(webDriver, url);
            string expectedUrl = "https://poczta.interia.pl/logowanie/";

            logInPage.LogIn(email, password);

            logInPage.ValidateLogIn(expectedUrl);
        }

        [TearDown]
        public void TearDown()
        {
            webDriver.Dispose();
        }
    }
}