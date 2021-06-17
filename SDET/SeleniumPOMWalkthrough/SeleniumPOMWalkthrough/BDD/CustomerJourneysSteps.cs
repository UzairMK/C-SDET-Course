using System;
using TechTalk.SpecFlow;

namespace SeleniumPOMWalkthrough.BDD
{
    [Binding]
    public class CustomerJourneysSteps
    {
        AP_ContactUsSteps _contactUsSteps = new AP_ContactUsSteps();

        [Given(@"I want to submit a message to staff so I navigate to the contact us page")]
        public void GivenIWantToSubmitAMessageToStaffSoINavigateToTheContactUsPage()
        {
            _contactUsSteps.GivenIAmOnTheContactUsPage();
        }

        [When(@"I fill in the required fields:")]
        public void WhenIFillInTheRequiredFields(Table table)
        {
            _contactUsSteps.GivenIKnowTheValuesIGoingToPutInTheContactUsFields(table);
            _contactUsSteps.WhenIInputThoseValuesInTheContactUsFields();
        }

        [When(@"I press send")]
        public void WhenIPressSend()
        {
            _contactUsSteps.WhenIClickTheSendButton();
        }
        
        [When(@"I don't fill in any fields")]
        public void WhenIDonTFillInAnyFields()
        {
            
        }
        
        [When(@"I press send\. I should receive the message ""(.*)""")]
        public void WhenIPressSend_IShouldReceiveTheMessage(string alertMessage)
        {
            WhenIPressSend();
            ThenIShouldReceiveTheMessage(alertMessage);
        }
        
        [When(@"then I fill in the email field")]
        public void WhenThenIFillInTheEmailField()
        {
            _contactUsSteps.GivenIEnterInTheContactUsEmailField("testing@snailmail.ccm");
        }
        
        [When(@"then I fill in the message field")]
        public void WhenThenIFillInTheMessageField()
        {
            _contactUsSteps.GivenIEnterInTheContactUsMessageField("message");
        }
        
        [When(@"then I select a subject heading")]
        public void WhenThenISelectASubjectHeading()
        {
            _contactUsSteps.GivenISelectOptionNumberInTheSubjectHeadingField(1);
        }
        
        [Then(@"I should receive the message ""(.*)""")]
        public void ThenIShouldReceiveTheMessage(string alertMessage)
        {
            _contactUsSteps.ThenIShouldSeeAnSendAlertContainingTheErrorMessage(alertMessage);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _contactUsSteps.AfterScenario();
        }
    }
}
