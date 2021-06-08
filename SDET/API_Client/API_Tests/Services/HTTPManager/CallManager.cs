using Newtonsoft.Json.Linq;
using RestSharp;
using System.Threading.Tasks;

namespace API_Tests
{
    public class CallManager
    {
        private readonly IRestClient _client;

        public string StatusDescription { get; set; }

        public CallManager()
        {
            _client = new RestClient(AppConfigReader.BaseUrl);
        }

        public async Task<string> MakePostcodeRequestAsync(string postcode)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"postcodes/{postcode.ToLower().Replace(" ", "")}"
            };

            return await ExecuteRequestAsync(request);
        }

        public async Task<string> MakeOutcodeRequestAsync(string outcode)
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = $"outcodes/{outcode.ToLower().Replace(" ", "")}"
            };

            return await ExecuteRequestAsync(request);
        }

        public async Task<string> MakePostcodesRequestAsync(string[] postcodes)
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = "postcodes/"
            };
            JObject pcs = new JObject()
            {
                new JProperty("postcodes", new JArray() { postcodes })
            };
            request.AddJsonBody(pcs.ToString());

            return await ExecuteRequestAsync(request);
        }

        public async Task<string> ExecuteRequestAsync(RestRequest request)
        {
            request.AddHeader("Content-Type", "application/json");

            var response = await _client.ExecuteAsync(request);

            StatusDescription = response.StatusDescription.ToString();

            return response.Content;
        } 
    }
}
