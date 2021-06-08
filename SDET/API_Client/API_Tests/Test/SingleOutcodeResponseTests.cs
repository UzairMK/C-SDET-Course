using System.Threading.Tasks;
using NUnit.Framework;

namespace API_Tests
{
    public class WhenTheSingleOutcodeServiceIsCalled_WithAValidOutcode
    {
        private SingleOutcodeService _singleOutcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singleOutcodeService = new SingleOutcodeService();
            await _singleOutcodeService.MakeRequest("B7");
        }

        [Category("Happy path")]
        [Test]
        public void StatusIs200()
        {
            Assert.That(_singleOutcodeService.JsonResponse["status"].ToString(), Is.EqualTo("200"));
            Assert.That(_singleOutcodeService.CallManager.StatusDescription, Is.EqualTo("OK"));
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.Response.status, Is.EqualTo(200));
        }

        [Category("Happy path")]
        [Test]
        public void Country_IsEngland()
        {
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.Response.result.country[0], Is.EqualTo("England"));
        }
    }

    public class WhenTheSingleOutcodeServiceIsCalled_WithAnInvalidOutcode
    {
        private SingleOutcodeService _singleOutcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singleOutcodeService = new SingleOutcodeService();
            await _singleOutcodeService.MakeRequest("7B");
        }

        [Category("Sad path")]
        [Test]
        public void StatusIs404()
        {
            Assert.That(_singleOutcodeService.JsonResponse["status"].ToString(), Is.EqualTo("404"));
            Assert.That(_singleOutcodeService.CallManager.StatusDescription, Is.EqualTo("Not Found"));
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.Response.status, Is.EqualTo(404));
        }

        [Category("Sad path")]
        [Test]
        public void OutcodeNotFoundErrorMessageRecieved()
        {
            Assert.That(_singleOutcodeService.JsonResponse["error"].ToString(), Is.EqualTo("Outcode not found"));
        }
    }

    public class WhenTheSingleOutcodeServiceIsCalled_WithNoOutcode
    {
        private SingleOutcodeService _singleOutcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singleOutcodeService = new SingleOutcodeService();
            await _singleOutcodeService.MakeRequest("");
        }

        [Category("Sad path")]
        [Test]
        public void StatusIs400()
        {
            Assert.That(_singleOutcodeService.JsonResponse["status"].ToString(), Is.EqualTo("400"));
            Assert.That(_singleOutcodeService.CallManager.StatusDescription, Is.EqualTo("Bad Request"));
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.Response.status, Is.EqualTo(400));
        }

        [Category("Sad path")]
        [Test]
        public void InvalidLongitudeLatitudeSubmittedErrorMessageRecieved()
        {
            Assert.That(_singleOutcodeService.JsonResponse["error"].ToString(), Is.EqualTo("Invalid longitude/latitude submitted"));
        }
    }
}
