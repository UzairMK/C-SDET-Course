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

        [Test]
        public void StatusIs200()
        {
            Assert.That(_singleOutcodeService.JsonResponse["status"].ToString(), Is.EqualTo("200"));
            Assert.That(_singleOutcodeService.CallManager.StatusDescription, Is.EqualTo("OK"));
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.Response.status, Is.EqualTo(200));
        }

        [Test]
        public void Country_IsEngland()
        {
            Assert.That(_singleOutcodeService.SingleOutcodeDTO.Response.result.country[0], Is.EqualTo("England"));
        }
    }
}
