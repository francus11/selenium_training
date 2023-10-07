using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace selenium_training
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string email = "testingemail1@interia.eu";
            string password = "VeryStrongPassword";
            IWebDriver webDriver = new EdgeDriver();
            webDriver.Navigate().GoToUrl("https://poczta.interia.pl/logowanie/");
            IWebElement emailField = webDriver.FindElement(By.Id("email"));
            IWebElement passwordField = webDriver.FindElement(By.Id("password"));
            //problem with submitting by clicking button
            IWebElement submitButton = webDriver.FindElement(By.XPath("//button[@type='submit']"));
            emailField.Clear();
            passwordField.Clear();

            emailField.SendKeys(email);
            passwordField.SendKeys(password);
            passwordField.Submit();
            // I don't know why it isn't working
            //submitButton.Click();


            Console.WriteLine("Hello, World!");
        }
    }
}