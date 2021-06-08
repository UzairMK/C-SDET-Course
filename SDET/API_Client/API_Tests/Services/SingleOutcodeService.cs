using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace API_Tests
{
    class SingleOutcodeService
    {
        public CallManager CallManager { get; set; }
        public JObject JsonResponse { get; set; }
        public string OutcodeSelected { get; set; }
        public DTO<SingleOutcodeResponse> SingleOutcodeDTO { get; set; }
        public string OutcodeResponse { get; set; }

        public SingleOutcodeService()
        {
            CallManager = new CallManager();
            SingleOutcodeDTO = new DTO<SingleOutcodeResponse>();
        }

        public async Task MakeRequest(string outcode)
        {
            OutcodeSelected = outcode;

            OutcodeResponse = await CallManager.MakeOutcodeRequestAsync(outcode);

            JsonResponse = JObject.Parse(OutcodeResponse);

            SingleOutcodeDTO.DeserealizeResponse(OutcodeResponse);
        }
    }
}
