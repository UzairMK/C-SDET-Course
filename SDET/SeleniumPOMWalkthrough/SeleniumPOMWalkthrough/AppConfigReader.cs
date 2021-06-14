using System.Configuration;

namespace SeleniumPOMWalkthrough
{
    public static class AppConfigReader
    {
        public readonly static string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public readonly static string SignInPageUrl = ConfigurationManager.AppSettings["signinpage_url"];
        public readonly static string ContactUsPageUrl = ConfigurationManager.AppSettings["contactuspage_url"];
    }
}
