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
        public RestClient Client { get; set; }
        public JObject ResponseContent { get; set; }
        public string PostcodeSelected { get; set; }
        public string StatusCode { get; set; }
        public SinglePostcodeResponse ResponseObject { get; set; }

        public SinglePostcodeService()
        {
            Client = new RestClient() {BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public async Task MakeRequest(string postcode)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type","application/json");
            PostcodeSelected = postcode;

            request.Resource = $"postcodes/{postcode.ToLower().Replace(" ","")}";

            var response = await Client.ExecuteAsync(request);

            ResponseContent = JObject.Parse(response.Content);
            StatusCode = response.StatusCode.ToString();
            ResponseObject = JsonConvert.DeserializeObject<SinglePostcodeResponse>(response.Content);
        }
    }
}
