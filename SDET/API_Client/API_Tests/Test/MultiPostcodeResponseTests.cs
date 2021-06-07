using System.Threading.Tasks;
using NUnit.Framework;


namespace API_Tests
{
    public class WhenTheMultiPostcodeServiceIsCalled_WithAValidOutcode
    {
        private MultiPostcodeService _multiPostcodeService;

        [OneTimeSetUp]
        public async Task OneTimeSetUp()
        {
            _multiPostcodeService = new MultiPostcodeService();
            string[] postcodes = { "EC2Y 5AS", "OX49 5NU", "B7 4BB", "NE30 1DP" };
            await _multiPostcodeService.MakeRequest(postcodes);
        }

        [Test]
        public void StatusIs200()
        {
            Assert.That(_multiPostcodeService.ResponseContent["status"].ToString(), Is.EqualTo("200"));
            Assert.That(_multiPostcodeService.StatusCode, Is.EqualTo("OK"));
            Assert.That(_multiPostcodeService.ResponseObject.status, Is.EqualTo(200));
        }

        [Test]
        public void AdminDistricts_AreCorrect_ForTheGivenPostcodes()
        {
            Assert.That(_multiPostcodeService.ResponseObject.result[0].result.admin_district, Is.EqualTo("City of London"));
            Assert.That(_multiPostcodeService.ResponseObject.result[1].result.admin_district, Is.EqualTo("South Oxfordshire"));
            Assert.That(_multiPostcodeService.ResponseObject.result[2].result.admin_district, Is.EqualTo("Birmingham"));
            Assert.That(_multiPostcodeService.ResponseObject.result[3].result.admin_district, Is.EqualTo("North Tyneside"));
        }
    }
}
