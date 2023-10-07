using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace selenium_training.tests
{

    public class SendLetterTests
    {
        IWebDriver webDriver1;
        IWebDriver webDriver2;

        [SetUp] 
        public void SetUp()
        {
            webDriver1 = new EdgeDriver();
            webDriver2 = new EdgeDriver();
        }
        [Test]
        public void SendLetter()
        {
            
            string url1 = "https://poczta.interia.pl/logowanie/";
            string url2 = "https://konto.onet.pl/signin?client_id=poczta.onet.pl.front.onetapi.pl";
            LogInPage emailPage1 = new LogInPage(webDriver1, url1);
            emailPage1.PopUpClick();
            LogInPage emailPage2 = new LogInPage(webDriver2, url2);
            emailPage2.RodoButton = By.ClassName("cmp-intro_acceptAll");
            Thread.Sleep(1000);
            emailPage2.PopUpClick();
            string email1 = "testingemail1@interia.eu";
            string email2 = "testingemail2@op.pl";
            string password1 = "VeryStrongPassword";
            string password2 = "VeryStrongPassword12";
            string expectedText = "dsafrevdsqewvaewqvssafqewq";

            SendEmailPage sendEmailPage = new SendEmailPage(emailPage1.LogIn(email1, password1));
            sendEmailPage.SendEmail(email2, expectedText);
            Thread.Sleep(10000);
            IWebDriver driver = emailPage2.LogIn(email2, password2);
            Thread.Sleep(8000);
            ReceiveMailPage receiveMailPage = new ReceiveMailPage(driver);
            string actual = receiveMailPage.ReceivedMail(email1);

            Assert.That(actual, Is.EqualTo(expectedText));
        }

        [TearDown] 
        public void TearDown()
        {
            webDriver1.Dispose();
            webDriver2.Dispose();
        }
    }
}
