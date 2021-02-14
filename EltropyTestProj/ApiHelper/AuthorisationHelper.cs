using System;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace ApiHelper
{
    public static class AuthorisationHelper
    {

        //Get me token 
         public static async Task<string> GetMeToken(string apiPath, string Consumerkey, string Consumerkeysecret)
        {

            var baseUri = new Uri(apiPath);
            var encodedConsumerKey = HttpUtility.UrlEncode(Consumerkey);
            var encodedConsumerKeySecret = HttpUtility.UrlEncode(Consumerkeysecret);
            var encodedPair = Base64Encode(String.Format("{0}:{1}", encodedConsumerKey, encodedConsumerKeySecret));

            HttpRequestMessage requestToken = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseUri, "oauth2/token"),
                Content = new StringContent("grant_type=client_credentials")
            };

            requestToken.Content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded") { CharSet = "UTF-8" };
            requestToken.Headers.TryAddWithoutValidation("Authorization", String.Format("Basic {0}", encodedPair));


            var client = new HttpClient();
            var bearerResult = await client.SendAsync(requestToken);
            var bearerData = await bearerResult.Content.ReadAsStringAsync();
            var bearerToken = JObject.Parse(bearerData)["access_token"].ToString();

            return bearerToken;

        }


            private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
