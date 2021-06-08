using System;
using System.Threading.Tasks;
using NUnit.Framework;


namespace API_Tests
{
    public class WhenTheSinglePostcodeServiceIsCalled_WithAValidPostcode
    {
        private SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequest("EC2Y 5AS");
        }

        [Category("Happy path")]
        [Test]
        public void StatusIs200()
        {
            Assert.That(_singlePostcodeService.JsonResponse["status"].ToString(), Is.EqualTo("200"));
            Assert.That(_singlePostcodeService.CallManager.StatusDescription, Is.EqualTo("OK"));
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.status, Is.EqualTo(200));
        }

        [Category("Happy path")]
        [Test]
        public void AdminDistrict_IsCityOfLondon()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.result.admin_district, Is.EqualTo("City of London"));
        }

        [Category("Happy path")]
        [Test]
        public void CodeCount_Is12()
        {
            Assert.That(_singlePostcodeService.CodeCount(), Is.EqualTo(12));
        }
    }

    public class WhenTheSinglePostcodeServiceIsCalled_WithAnInvalidPostcode
    {
        private SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequest("ABCD 123");
        }

        [Category("Sad path")]
        [Test]
        public void StatusIs404()
        {
            Assert.That(_singlePostcodeService.JsonResponse["status"].ToString(), Is.EqualTo("404"));
            Assert.That(_singlePostcodeService.CallManager.StatusDescription, Is.EqualTo("Not Found"));
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.status, Is.EqualTo(404));
        }

        [Category("Sad path")]
        [Test]
        public void InvalidPostcodeErrorMessageRecieved()
        {
            Assert.That(_singlePostcodeService.JsonResponse["error"].ToString(), Is.EqualTo("Invalid postcode"));
        }
    }

    public class WhenTheSinglePostcodeServiceIsCalled_WithNoPostcode
    {
        private SinglePostcodeService _singlePostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _singlePostcodeService = new SinglePostcodeService();
            await _singlePostcodeService.MakeRequest("");
        }

        [Category("Sad path")]
        [Test]
        public void StatusIs400()
        {
            Assert.That(_singlePostcodeService.JsonResponse["status"].ToString(), Is.EqualTo("400"));
            Assert.That(_singlePostcodeService.CallManager.StatusDescription, Is.EqualTo("Bad Request"));
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.status, Is.EqualTo(400));
        }

        [Category("Sad path")]
        [Test]
        public void NoPostcodeErrorMessageRecieved()
        {
            Assert.That(_singlePostcodeService.JsonResponse["error"].ToString(), Is.EqualTo("No postcode query submitted. Remember to include query parameter"));
        }
    }
}
