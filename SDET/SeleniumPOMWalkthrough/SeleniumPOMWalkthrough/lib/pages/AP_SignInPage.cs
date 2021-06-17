using OpenQA.Selenium;
using SeleniumPOMWalkthrough.Util;
using System;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_SignInPage
    {
        private readonly IWebDriver _seleniumDriver;
        private readonly string _signInPageUrl = AppConfigReader.SignInPageUrl;

        private IWebElement EmailField => _seleniumDriver.FindElement(By.Id("email"));
        private IWebElement PasswordField => _seleniumDriver.FindElement(By.Id("passwd"));
        private IWebElement SignInButton => _seleniumDriver.FindElement(By.Id("SubmitLogin"));
        private IWebElement SignInAlert => _seleniumDriver.FindElement(By.ClassName("alert"));

        public AP_SignInPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void VisitSignInPage() => _seleniumDriver.Navigate().GoToUrl(_signInPageUrl);
        public void InputEmailLogin(string email) => EmailField.SendKeys(email);
        public void InputPassword(string password) => PasswordField.SendKeys(password);
        public void ClickSignIn() => SignInButton.Click();
        public string GetAlertText() => SignInAlert.Text;
        public string GetPageTitle() => _seleniumDriver.Title;

        public void InputLoginCredentials(Credentials credentials)
        {
            InputEmailLogin(credentials.Email);
            InputPassword(credentials.Password);
        }
    }
}
