using SeleniumPOMWalkthrough.lib.pages;
using SeleniumPOMWalkthrough.lib.driver_config;
using OpenQA.Selenium;

namespace SeleniumPOMWalkthrough.lib
{
    public class AP_Website<T> where T : IWebDriver, new()
    {
        public IWebDriver SeleniumDriver { get; set; }
        public AP_HomePage AP_HomePage { get; set; }
        public AP_SignInPage AP_SignInPage { get; set; }
        public AP_ContactUsPage AP_ContactUsPage { get; set; }

        public AP_Website(int pageLoadInSecs = 60, int implicitWaitInSecs = 60)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadInSecs, implicitWaitInSecs).Driver;

            AP_HomePage = new AP_HomePage(SeleniumDriver);
            AP_SignInPage = new AP_SignInPage(SeleniumDriver);
            AP_ContactUsPage = new AP_ContactUsPage(SeleniumDriver);
        }

        public void DeleteCookies() => SeleniumDriver.Manage().Cookies.DeleteAllCookies();
    }
}
