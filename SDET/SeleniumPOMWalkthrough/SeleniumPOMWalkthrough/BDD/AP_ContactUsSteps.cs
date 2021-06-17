using System;
using SeleniumPOMWalkthrough.Util;
using SeleniumPOMWalkthrough.lib;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading;

namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public class AP_ContactUsSteps
    {
        private ContactUsFields _contactUsFields;
        private AP_Website<ChromeDriver> AP_Website { get; set; } = new AP_Website<ChromeDriver>();

        [BeforeScenario(@"Happy")]
        public void Happy()
        {
            AP_Website.SeleniumDriver.Navigate().GoToUrl(@"https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Smiling_smiley_yellow_simple.svg/1200px-Smiling_smiley_yellow_simple.svg.png");
        }

        [BeforeScenario(@"Sad")]
        public void Sad()
        {
            AP_Website.SeleniumDriver.Navigate().GoToUrl(@"https://upload.wikimedia.org/wikipedia/commons/thumb/e/e9/Sad_face.svg/2229px-Sad_face.svg.png");
        }

        [Given(@"I am on the contact us page")]
        public void GivenIAmOnTheContactUsPage()
        {
            AP_Website.AP_ContactUsPage.VisitContactUsPage();
        }
        
        [Given(@"I enter ""(.*)"" in the contact us email field")]
        public void GivenIEnterInTheContactUsEmailField(string email)
        {
            AP_Website.AP_ContactUsPage.InputEmail(email);
        }
        
        [Given(@"I enter ""(.*)"" in the contact us message field")]
        public void GivenIEnterInTheContactUsMessageField(string message)
        {
            AP_Website.AP_ContactUsPage.InputMessage(message);
        }

        public void GivenISelectOptionNumberInTheSubjectHeadingField(int optionNumber)
        {
            AP_Website.AP_ContactUsPage.SelectSubjectHeading(optionNumber);
        }

        [Given(@"I know the values I going to put in the contact us fields:")]
        public void GivenIKnowTheValuesIGoingToPutInTheContactUsFields(Table table)
        {
            _contactUsFields = table.CreateInstance<ContactUsFields>();
        }
        
        [When(@"I click the send button")]
        public void WhenIClickTheSendButton()
        {
            AP_Website.AP_ContactUsPage.ClickSend();
        }
        
        [When(@"I input those values in the contact us fields")]
        public void WhenIInputThoseValuesInTheContactUsFields()
        {
            AP_Website.AP_ContactUsPage.FillFields(_contactUsFields);
        }
        
        [Then(@"I should see an send alert containing the error message ""(.*)""")]
        public void ThenIShouldSeeAnSendAlertContainingTheErrorMessage(string alertMessage)
        {
            Assert.That(AP_Website.AP_ContactUsPage.GetAlertMessage(), Does.Contain(alertMessage));
        }

        [Then(@"I should see ""(.*)"" message under the subject combo box")]
        public void ThenIShouldSeeMessageUnderTheSubjectComboBox(string message)
        {
            Assert.That(AP_Website.AP_ContactUsPage.SubjectMessage(), Is.EqualTo(message));
        }

        [AfterScenario]
        public void AfterScenario()
        {
            AP_Website.SeleniumDriver.Quit();
            AP_Website.SeleniumDriver.Dispose();
        }
    }
}
