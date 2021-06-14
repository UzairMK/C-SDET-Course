using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumWalkthrough
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickSignIn_ThenIAmTakenToTheSignInPage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
                IWebElement _signinlink = driver.FindElement(By.LinkText("Sign in"));
                _signinlink.Click();
                Thread.Sleep(2000);
                Assert.That(driver.Title, Is.EqualTo("Login - My Store"));
            }
        }

        [Test]
        public void GivenIAmOnTheSignInPage_AndIEnterA4DigitPassword_WhenIClickTheSignInButton_ThenIAmGivenAnErrorMessage()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=authentication&back=my-account");
                IWebElement _emailField = driver.FindElement(By.Id("email"));
                _emailField.SendKeys("testing@snailmail.ccm");
                IWebElement _passwordField = driver.FindElement(By.Id("passwd"));
                _passwordField.SendKeys("1234");
                IWebElement _signInButton = driver.FindElement(By.Id("SubmitLogin"));
                _signInButton.Click();
                Thread.Sleep(2000);
                IWebElement _alertMessage = driver.FindElement(By.ClassName("alert"));
                Assert.That(_alertMessage.Text.Contains("Invalid password"));
            }
        }

        [Test]
        public void JohnLewisExample()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.johnlewis.com/");

                var homeAndGardenElement = driver.FindElement(By.LinkText("Home & Garden"));
                Thread.Sleep(2000);
                var acceptAllCookiesButton = driver.FindElement(By.ClassName("c-button-yMKB7"));
                acceptAllCookiesButton.Click();
                Actions action = new Actions(driver);
                action.MoveToElement(homeAndGardenElement).Perform();
                Thread.Sleep(5000);
                var beddingLink = driver.FindElement(By.LinkText("Bedding"));
                beddingLink.Click();
                Assert.That(driver.Title.Contains("Bedding | Bed Sets and Bed Linen"));
            }
        }

        [Test]
        public void WelcomeToTheInternet_ABTesting()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
                IWebElement hyperlink1 = driver.FindElement(By.LinkText("A/B Testing"));
                hyperlink1.Click();
                IWebElement pageHeading = driver.FindElement(By.ClassName("example"));
                Assert.That(pageHeading.Text.Contains("A/B"));

                var hyperlink2 = driver.FindElement(By.LinkText("Elemental Selenium"));
                hyperlink2.Click();
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                Assert.That(driver.Title, Is.EqualTo("Elemental Selenium: Receive a Free, Weekly Tip on Using Selenium like a Pro"));
            }
        }

        [Test]
        public void WelcomeToTheInternet_AddRemoveElements()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
                IWebElement hyperlink1 = driver.FindElement(By.LinkText("Add/Remove Elements"));
                hyperlink1.Click();
                IWebElement pageHeading = driver.FindElement(By.Id("content"));
                Assert.That(pageHeading.Text.Contains("Add/Remove Elements"));

                var addElementButton = driver.FindElement(By.CssSelector("button"));
                addElementButton.Click();
                addElementButton.Click();
                addElementButton.Click(); 
                addElementButton.Click();
                addElementButton.Click();
                var deleteButtons = driver.FindElement(By.Id("elements"));
                Assert.That(deleteButtons.Text.Trim(), Is.EqualTo("DeleteDeleteDeleteDeleteDelete"));
            }
        }

        [Test]
        public void WelcomeToTheInternet_Checkboxes()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/");
                IWebElement hyperlink1 = driver.FindElement(By.LinkText("Checkboxes"));
                hyperlink1.Click();
                IWebElement pageHeading = driver.FindElement(By.Id("content"));
                Assert.That(pageHeading.Text.Contains("Checkboxes"));

                var checkbox1 = driver.FindElement(By.CssSelector("input:nth-child(1)"));
                var checkbox2 = driver.FindElement(By.CssSelector("input:nth-child(3)"));
                checkbox1.Click();
                checkbox2.Click();
                Assert.That(checkbox1.Selected);
                Assert.That(!checkbox2.Selected);
            }
        }
    }
}