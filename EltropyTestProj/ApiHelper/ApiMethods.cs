using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiHelper
{

    public class Tweet
    {
        
        public Tweet(double id, string text, int retweet_count, int favourites_count, string created_at)
        {
            this.id = id;
            this.text = text;
            this.retweet_count = retweet_count;
            this.favourites_count = favourites_count;
            this.created_at = created_at;
        }
        
        public double id
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }
        public int retweet_count
        {
            get;
            set;
        }
        public int favourites_count
        {
            get;
            set;
        }

        public string created_at
        {
            get;
            set;
       }
}
    public class ApiMethods
    {
        public static string Consumerkey = "YrfBeTHrMUCuSD4kdAMBF69WX";
        public static string Consumersecret = "10Xbelb6ftIsnqNVvukPI1BwbL9nn2QnoX0QheetSYo0t32hJ8";
        public static string Url = "https://api.twitter.com";


        public async Task<List<Tweet>> GetTop10TweetsOf100(string userName, int count, string accessToken = null)
        {
            if (accessToken == null)
            {
                accessToken = await AuthorisationHelper.GetMeToken(Url, Consumerkey, Consumersecret);
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/statuses/user_timeline.json?count={0}&screen_name={1}&exclude_replies=1", count, userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            dynamic json = JsonConvert.DeserializeObject<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTwitts = (json as IEnumerable<dynamic>);

            if (enumerableTwitts == null)
            {
                return null;
            }

            List<Tweet> Tweets = new List<Tweet>();

            for (int i = 1; i < enumerableTwitts.Count(); i++)
            {
                Tweets.Add(new Tweet((double)enumerableTwitts.ElementAt(i)["id"], (string) enumerableTwitts.ElementAt(i)["text"], (int)enumerableTwitts.ElementAt(i)["retweet_count"], (int)enumerableTwitts.ElementAt(i)["favorite_count"], (string)enumerableTwitts.ElementAt(i)["created_at"]));
            }


            //Sorting Tweets based on Retweetcount
            for (int i = 0; i < Tweets.Count; i++)
            {
                var item = Tweets[i];
                var currentIndex = i;
                while (currentIndex > 0 && Tweets[currentIndex - 1].retweet_count > item.retweet_count)
                {
                    Tweets[currentIndex] = Tweets[currentIndex - 1];
                    currentIndex--;
                }

                Tweets[currentIndex] = item;
            }

            List<Tweet> Top10Tweets = Tweets.GetRange(0, 10);
            return Top10Tweets;
        }

        public async Task<List<string>> GetFriends(string userName, int count, string accessToken = null)
        {
            if (accessToken == null)
            {
                accessToken = await AuthorisationHelper.GetMeToken(Url, Consumerkey, Consumersecret);
            }

            var requestUserTimeline = new HttpRequestMessage(HttpMethod.Get, string.Format("https://api.twitter.com/1.1/friends/list.json?count={0}&screen_name={1}", count, userName));
            requestUserTimeline.Headers.Add("Authorization", "Bearer " + accessToken);
            var httpClient = new HttpClient();
            HttpResponseMessage responseUserTimeLine = await httpClient.SendAsync(requestUserTimeline);
            dynamic json = JsonConvert.DeserializeObject<object>(await responseUserTimeLine.Content.ReadAsStringAsync());
            var enumerableTwitts = (json as IEnumerable<dynamic>);

            if (enumerableTwitts == null)
            {
                return null;
            }

            List<string> Friends = new List<string>();

            for (int i = 1; i < enumerableTwitts.Count(); i++)
            {
                Friends.Add(enumerableTwitts.ElementAt(i)["users"]);
                
            }

            return Friends;
        }

    }

}

