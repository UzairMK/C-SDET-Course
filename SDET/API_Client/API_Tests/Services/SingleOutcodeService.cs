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
    class SingleOutcodeService
    {
        public RestClient Client { get; set; }
        public JObject ResponseContent { get; set; }
        public string OutcodeSelected { get; set; }
        public string StatusCode { get; set; }
        public SingleOutcodeResponse ResponseObject { get; set; }

        public SingleOutcodeService()
        {
            Client = new RestClient() {BaseUrl = new Uri(AppConfigReader.BaseUrl) };
        }

        public async Task MakeRequest(string outcode)
        {
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type","application/json");
            OutcodeSelected = outcode;

            request.Resource = $"outcodes/{outcode.ToLower().Replace(" ","")}";

            var response = await Client.ExecuteAsync(request);

            ResponseContent = JObject.Parse(response.Content);
            StatusCode = response.StatusCode.ToString();
            ResponseObject = JsonConvert.DeserializeObject<SingleOutcodeResponse>(response.Content);
        }
    }
}
