using OpenQA.Selenium;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_HomePage
    {
        private readonly IWebDriver _seleniumDriver;
        private readonly string _homePageUrl = AppConfigReader.BaseUrl;

        private IWebElement SignInLink => _seleniumDriver.FindElement(By.LinkText("Sign in"));
        private IWebElement ContactUsLink => _seleniumDriver.FindElement(By.LinkText("Contact us"));

        public AP_HomePage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void VisitHomePage() => _seleniumDriver.Navigate().GoToUrl(_homePageUrl);
        public void VisitSignInPage() => SignInLink.Click();
        public void VisitContactUsPage() => ContactUsLink.Click();
        public string GetPageTitle() => _seleniumDriver.Title;
    }
}
