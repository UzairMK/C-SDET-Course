using RestSharp;
using System.Threading.Tasks;

namespace API_Tests
{
    public interface ICallManager
    {
        string StatusDescription { get; set; }

        Task<string> MakePostcodeRequestAsync(string postcode);

        Task<string> MakeOutcodeRequestAsync(string outcode);

        Task<string> MakePostcodesRequestAsync(string[] postcodes);

        Task<string> ExecuteRequestAsync(RestRequest request);
    }
}
