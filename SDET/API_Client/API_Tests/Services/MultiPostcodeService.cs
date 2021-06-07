using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace API_Tests
{
    class MultiPostcodeService
    {
        public RestClient Client { get; set; }
        public JObject ResponseContent { get; set; }
        public string[] PostcodesSelected { get; set; }
        public string StatusCode { get; set; }
        public MultiPostcodeResponse ResponseObject { get; set; }

        public MultiPostcodeService()
        {
            Client = new RestClient() {BaseUrl = new Uri(AppConfigReader.BaseUrl + "postcodes/") };
        }

        public async Task MakeRequest(string[] postcodes)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type","application/json");
            PostcodesSelected = postcodes;

            JObject pcs = new JObject()
            {
                new JProperty("postcodes", new JArray() { postcodes })
            };
            request.AddJsonBody(pcs.ToString());

            var response = await Client.ExecuteAsync(request);

            ResponseContent = JObject.Parse(response.Content);
            StatusCode = response.StatusCode.ToString();
            ResponseObject = JsonConvert.DeserializeObject<MultiPostcodeResponse>(response.Content);
        }
    }
}
