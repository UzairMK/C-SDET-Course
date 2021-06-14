using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumPOMWalkthrough.lib;
using System.Threading;

namespace SeleniumPOMWalkthrough.tests
{
    public class AP_ContactUs_Tests
    {
        public AP_Website<ChromeDriver> AP_Website = new AP_Website<ChromeDriver>();

        [Test]
        public void GivenIAmOnTheHomePage_WhenIClickContactUsButton_ThenIShouldBeTakenToContactUsPage()
        {
            AP_Website.AP_HomePage.VisitHomePage();
            AP_Website.AP_HomePage.VisitContactUsPage();
            Assert.That(AP_Website.SeleniumDriver.Title, Does.Contain("Contact us - My Store"));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_AndAllRequiredFieldsHaveAValidValue_WhenIClickSendButton_ThenIShouldGetASuccessMessage()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.SelectSubjectHeading(1);
            AP_Website.AP_ContactUsPage.InputEmail("testing@snailmail.ccm");
            AP_Website.AP_ContactUsPage.InputOrderReference("12345");
            AP_Website.AP_ContactUsPage.InputMessage("message");
            AP_Website.AP_ContactUsPage.ClickSend();
            Assert.That(AP_Website.AP_ContactUsPage.GetAlertMessage(), Does.Contain("Your message has been successfully sent to our team."));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_WhenIClickSendButton_ThenIShouldGetInvalidEmailErrorMessage()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.ClickSend();
            Assert.That(AP_Website.AP_ContactUsPage.GetAlertMessage(), Does.Contain("Invalid email address"));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_AndIInputAValidEmail_WhenIClickSendButton_ThenIShouldGetMessageBlankErrorMessage()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.InputEmail("testing@snailmail.ccm");
            AP_Website.AP_ContactUsPage.ClickSend();
            Assert.That(AP_Website.AP_ContactUsPage.GetAlertMessage(), Does.Contain("The message cannot be blank"));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_AndIInputAValidEmail_AndAMessage_WhenIClickSendButton_ThenIShouldGetSelectSubjectErrorMessage()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.InputEmail("testing@snailmail.ccm");
            AP_Website.AP_ContactUsPage.InputMessage("message");
            AP_Website.AP_ContactUsPage.ClickSend();
            Assert.That(AP_Website.AP_ContactUsPage.GetAlertMessage(), Does.Contain("Please select a subject from the list provided"));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_AndIInputAValidEmailAMessageAndSelectASubject_WhenIClickSendButton_ThenIShouldGetSuccessMessage()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.SelectSubjectHeading(2);
            AP_Website.AP_ContactUsPage.InputEmail("testing@snailmail.ccm");
            AP_Website.AP_ContactUsPage.InputMessage("message");
            AP_Website.AP_ContactUsPage.ClickSend();
            Assert.That(AP_Website.AP_ContactUsPage.GetAlertMessage(), Does.Contain("Your message has been successfully sent to our team"));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_WhenISelectChooseSubject_ThenNoSubjectMessageShouldBePresent()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.SelectSubjectHeading(0);
            Assert.That(AP_Website.AP_ContactUsPage.SubjectMessage(), Does.Contain(""));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_WhenISelectCustomerServiceSubject_ThenCustomerServiceMessageShouldBePresent()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.SelectSubjectHeading(1);
            Assert.That(AP_Website.AP_ContactUsPage.SubjectMessage(), Does.Contain("For any question about a product, an order"));
        }

        [Test]
        public void GivenIAmOnTheContactUsPage_WhenISelectWebmasterSubject_ThenWebmasterMessageShouldBePresent()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
            AP_Website.AP_ContactUsPage.SelectSubjectHeading(2);
            Assert.That(AP_Website.AP_ContactUsPage.SubjectMessage(), Does.Contain("If a technical problem occurs on this website"));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
