using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace API_Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var restClient = new RestClient("https://api.postcodes.io/");

            var restRequest = new RestRequest();
            restRequest.Method = Method.GET;

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.Timeout = -1;

            var postcode = "EC2Y 5AS";
            restRequest.Resource = $"postcodes/{postcode.ToLower().Replace(" ","")}";

            var singlePostcodeResponse = await restClient.ExecuteAsync(restRequest);
            Console.WriteLine("RestSharp response:");
            Console.WriteLine(singlePostcodeResponse.Content);

            JObject postcodes = new JObject()
            {
                new JProperty("postcodes", new JArray() { new string[] { "OX49 5NU", "B7 4BB", "NE30 1DP" } })
            };

            var restClient2 = new RestClient("https://api.postcodes.io/postcodes/");

            var restRequest2 = new RestRequest(Method.POST);
            restRequest2.Timeout = -1;

            restRequest2.AddHeader("Content-Type", "application/json");
            restRequest2.AddJsonBody(postcodes.ToString());

            var bulkPostcodeResponse = await restClient2.ExecuteAsync(restRequest2);

            Console.WriteLine("Bulk RestSharp response:");
            var bulkResponse = JObject.Parse(bulkPostcodeResponse.Content);
            Console.WriteLine(bulkResponse["status"]);
            Console.WriteLine(bulkResponse["result"][0]["query"]);

            var restClient3 = new RestClient("https://api.postcodes.io/");

            var restRequest3 = new RestRequest();
            restRequest3.Method = Method.GET;

            restRequest3.AddHeader("Content-Type", "application/json");
            restRequest3.Timeout = -1;

            var outcode = "B7";
            restRequest3.Resource = $"outcodes/{outcode.ToLower().Replace(" ", "")}";

            var outcodePostcodeResponse = await restClient3.ExecuteAsync(restRequest3);
            Console.WriteLine("Lookup Outcode RestSharp response:");
            Console.WriteLine(outcodePostcodeResponse.Content);

            var singlePostcode = JsonConvert.DeserializeObject<SinglePostcodeResponse>(singlePostcodeResponse.Content);
            var bulkPostcodes = JsonConvert.DeserializeObject<MultiPostcodeResponse>(bulkPostcodeResponse.Content);
            var outcodePostcode = JsonConvert.DeserializeObject<SingleOutwardResponse>(outcodePostcodeResponse.Content);

            Console.WriteLine("Single Postcode Response:");
            Console.WriteLine(singlePostcode.status);
            Console.WriteLine(singlePostcode.result.region);


            Console.WriteLine("Bulk Postcode Response:");
            Console.WriteLine(bulkPostcodes.status);
            foreach (var result in bulkPostcodes.result)
            {
                Console.WriteLine(result.result.region);
            }

            Console.WriteLine("Outcode Postcode Response:");
            Console.WriteLine(bulkPostcodes.status);
            Console.WriteLine(outcodePostcode.result.country[0]);
        }
    }
}
