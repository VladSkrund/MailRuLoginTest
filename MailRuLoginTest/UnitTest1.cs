using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace MailRuLoginTest
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _emailField = By.XPath("//*[@id='mailbox']/form[1]/div[1]/div[2]/input");
        private readonly By _enterEmailButton = By.XPath("//*[@id='mailbox']/form[1]/button[1]");
        private readonly By _passwordField = By.XPath("//*[@id='mailbox']/form[1]/div[2]/input");
        private readonly By _enterPasswordButton = By.XPath("//*[@id='mailbox']/form[1]/button[2]");
        private readonly By _arrowButton = By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]");
        private readonly By _userActualLogin = By.XPath("/html/body/div[3]/div[1]/div/div[3]/div/div/div[1]/div/div[1]/div");

        private const string _email = "";//enter here your rumail adress 
        private const string _password = ""; //enter here your rumail password 
        private const string _userExpectedLogin = ""; //enter here your rumail login
        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://mail.ru");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void Test1()
        {
            var login = driver.FindElement(_emailField);
            login.SendKeys(_email);
            var enterEmail = driver.FindElement(_enterEmailButton);
            enterEmail.Click();
            var password = driver.FindElement(_passwordField);
            password.SendKeys(_password);
            var enterPassword = driver.FindElement(_enterPasswordButton);
            enterPassword.Click();
            Thread.Sleep(1000);
            var arrowButton = driver.FindElement(_arrowButton);
            arrowButton.Click();
            Thread.Sleep(1000);
            var actualLogin = driver.FindElement(_userActualLogin).Text;
            Assert.AreEqual(_userExpectedLogin, actualLogin, "Login is wrong"); 
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}