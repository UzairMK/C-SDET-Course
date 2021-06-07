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
            Assert.That(_singlePostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
            Assert.That(_singlePostcodeService.StatusCode, Is.EqualTo("OK"));
            Assert.That(_singlePostcodeService.ResponseObject.status, Is.EqualTo(200));
        }

        [Test]
        public void AdminDistrict_IsCityOfLondon()
        {
            Assert.That(_singlePostcodeService.ResponseObject.result.admin_district, Is.EqualTo("City of London"));
        }
    }
}
