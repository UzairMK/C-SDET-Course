using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib;

namespace SeleniumPOMWalkthrough.tests
{
    public class AP_SignIn_Tests
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();

        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickSignInButton_ThenIShouldBeTakenToSignInPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.VisitSignInPage();
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Login - My Store"));
        }

        [Test]
        public void GivenIAmOnTheSignInPage_AndIInputAValidEmail_AndA4CharPassword_WhenIClickSignInButton_ThenIShouldGetInvalidPasswordErrorMessage()
        {
            AP_Website.AP_SignInPage.VisitSignInPage();
            AP_Website.AP_SignInPage.InputEmailLogin("testing@snailmail.ccm");
            AP_Website.AP_SignInPage.InputPassword("1234");
            AP_Website.AP_SignInPage.ClickSignIn();
            Assert.That(AP_Website.AP_SignInPage.GetAlertText(), Does.Contain("Invalid password"));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
