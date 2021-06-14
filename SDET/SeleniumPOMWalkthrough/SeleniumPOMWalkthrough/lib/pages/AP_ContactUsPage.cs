using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace SeleniumPOMWalkthrough.lib.pages
{
    public class AP_ContactUsPage
    {
        private readonly IWebDriver _seleniumDriver;
        private readonly string _contactUsPageUrl = AppConfigReader.ContactUsPageUrl;

        private IWebElement SubjectHeadingComboBox => _seleniumDriver.FindElement(By.Id("id_contact"));
        private IWebElement EmailField => _seleniumDriver.FindElement(By.Id("email"));
        private IWebElement OrderReferenceField => _seleniumDriver.FindElement(By.Id("id_order"));
        private IWebElement MessageField => _seleniumDriver.FindElement(By.Id("message"));
        private IWebElement SendButton => _seleniumDriver.FindElement(By.Id("submitMessage"));
        private IWebElement Alert => _seleniumDriver.FindElement(By.ClassName("alert"));

        public AP_ContactUsPage(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void VisitContactUsPage() => _seleniumDriver.Navigate().GoToUrl(_contactUsPageUrl);
        public void SelectSubjectHeading(int option)
        {
            SubjectHeadingComboBox.Click();
            Actions action = new Actions(_seleniumDriver).SendKeys(Keys.ArrowDown);
            switch (option)
            {
                case 1:
                    action.Perform();
                    break;
                case 2:
                    action.Perform();
                    action.Perform();
                    break;
                default:
                    break;
            }
            new Actions(_seleniumDriver).SendKeys(Keys.Enter).Perform();
        }
        public string SubjectMessage()
        {
            string message = "";
            for (int i = 0; i < 3; i++)
            {
                var item = _seleniumDriver.FindElement(By.Id($"desc_contact{i}"));
                if (item.Displayed)
                {
                    message += item.Text;
                }
            }
            return message;            
        }
        public void InputEmail(string email) => EmailField.SendKeys(email);
        public void InputOrderReference(string reference) => OrderReferenceField.SendKeys(reference);
        public void InputMessage(string message) => MessageField.SendKeys(message);
        public void ClickSend() => SendButton.Click();
        public string GetAlertMessage() => Alert.Text;
        public string GetPageTitle() => _seleniumDriver.Title;
    }
}
