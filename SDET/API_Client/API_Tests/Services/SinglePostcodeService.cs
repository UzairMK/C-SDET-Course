using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Tests
{
    class SinglePostcodeService
    {
        public CallManager CallManager { get; set; }
        public JObject JsonResponse { get; set; }
        public string PostcodeSelected { get; set; }
        public DTO<SinglePostcodeResponse> SinglePostcodeDTO { get; set; }
        public string PostcodeResponse { get; set; }

        public SinglePostcodeService()
        {
            CallManager = new CallManager();
            SinglePostcodeDTO = new DTO<SinglePostcodeResponse>();
        }

        public async Task MakeRequest(string postcode)
        {
            PostcodeSelected = postcode;

            PostcodeResponse = await CallManager.MakePostcodeRequestAsync(postcode);

            JsonResponse = JObject.Parse(PostcodeResponse);

            SinglePostcodeDTO.DeserealizeResponse(PostcodeResponse);
        }

        public int CodeCount()
        {
            return JsonResponse["result"]["codes"].ToList().Count();
        }
    }
}
