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

        [Test]
        public void StatusIs200()
        {
            Assert.That(_singlePostcodeService.JsonResponse["status"].ToString(), Is.EqualTo("200"));
            Assert.That(_singlePostcodeService.CallManager.StatusDescription, Is.EqualTo("OK"));
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.status, Is.EqualTo(200));
        }

        [Test]
        public void AdminDistrict_IsCityOfLondon()
        {
            Assert.That(_singlePostcodeService.SinglePostcodeDTO.Response.result.admin_district, Is.EqualTo("City of London"));
        }

        [Test]
        public void CodeCount_Is12()
        {
            Assert.That(_singlePostcodeService.CodeCount(), Is.EqualTo(12));
        }
    }
}
