using System;
using TechTalk.SpecFlow;
using SeleniumPOMWalkthrough.lib;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using SeleniumPOMWalkthrough.Util;
using TechTalk.SpecFlow.Assist;

namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public class AP_SignInSteps
    {
        private Credentials _credentials;
        public AP_Website<ChromeDriver> AP_Website { get; } = new AP_Website<ChromeDriver>();

        [BeforeScenario(@"google")]
        public void GoToGoogle()
        {
            AP_Website.SeleniumDriver.Navigate().GoToUrl(@"https://www.google.com");
        }

        [Given(@"I am on the sign in page")]
        public void GivenIAmOnTheSignInPage()
        {
            AP_Website.AP_SignInPage.VisitSignInPage();
        }

        [Given(@"I enter the email ""(.*)""")]
        public void GivenIEnterTheEmail(string email)
        {
            AP_Website.AP_SignInPage.InputEmailLogin(email);
        }

        [Given(@"I enter the password (.*)")]
        public void GivenIEnterThePassword(string password)
        {
            AP_Website.AP_SignInPage.InputPassword(password);
        }

        [Given(@"I have the credentials:")]
        public void GivenIHaveTheCredentials(Table table)
        {
            _credentials = table.CreateInstance<Credentials>();
        }

        [When(@"I enter these credentails")]
        public void WhenIEnterTheseCredentails()
        {
            AP_Website.AP_SignInPage.InputLoginCredentials(_credentials);
        }

        [When(@"I click the sign in button")]
        public void WhenIClickTheSignInButton()
        {
            AP_Website.AP_SignInPage.ClickSignIn();
        }

        [Then(@"I should see an alert containing the error message ""(.*)""")]
        public void ThenIShouldSeeAnAlertContainingTheErrorMessage(string alertMessage)
        {
            Assert.That(AP_Website.AP_SignInPage.GetAlertText(), Does.Contain(alertMessage));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }

    }
}
