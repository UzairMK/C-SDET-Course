using System.Linq;
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
            Assert.That(_multiPostcodeService.JsonResponse["status"].ToString(), Is.EqualTo("200"));
            Assert.That(_multiPostcodeService.CallManager.StatusDescription, Is.EqualTo("OK"));
            Assert.That(_multiPostcodeService.MultiPostcodeDTO.Response.status, Is.EqualTo(200));
        }

        [Test]
        public void AdminDistricts_AreCorrect_ForTheGivenPostcodes()
        {
            var ResponseResult = _multiPostcodeService.MultiPostcodeDTO.Response.result;
            Assert.That(ResponseResult.Where(x => x.query == "EC2Y 5AS").FirstOrDefault().result.admin_district, Is.EqualTo("City of London"));
            Assert.That(ResponseResult.Where(x => x.query == "OX49 5NU").FirstOrDefault().result.admin_district, Is.EqualTo("South Oxfordshire"));
            Assert.That(ResponseResult.Where(x => x.query == "B7 4BB").FirstOrDefault().result.admin_district, Is.EqualTo("Birmingham"));
            Assert.That(ResponseResult.Where(x => x.query == "NE30 1DP").FirstOrDefault().result.admin_district, Is.EqualTo("North Tyneside"));
        }
    }
}
