using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace API_Tests
{
    class MultiPostcodeService
    {
        public ICallManager CallManager { get; set; }
        public JObject JsonResponse { get; set; }
        public string[] PostcodesSelected { get; set; }
        public DTO<MultiPostcodeResponse> MultiPostcodeDTO { get; set; }
        public string PostcodesResponse { get; set; }

        public MultiPostcodeService()
        {
            CallManager = new CallManager();
            MultiPostcodeDTO = new DTO<MultiPostcodeResponse>();
        }

        public async Task MakeRequest(string[] postcodes)
        {
            PostcodesSelected = postcodes;

            PostcodesResponse = await CallManager.MakePostcodesRequestAsync(postcodes);

            JsonResponse = JObject.Parse(PostcodesResponse);

            MultiPostcodeDTO.DeserealizeResponse(PostcodesResponse);
        }
    }
}
