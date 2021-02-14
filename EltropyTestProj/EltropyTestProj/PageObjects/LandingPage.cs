using System.Drawing.Imaging;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;
using ApiHelper;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Tests.PageObjects
{
    public class LandingPage
    {
        private readonly IWebDriver _driver;

        public LandingPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        public void UserMainCpature(string baseUrl, string user)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            ScreenShotRemoteBrowser(user);
        }

        public void VerifyTweetList(string baseUrl, string user)
        {
            ApiMethods apiMethods = new ApiMethods();
            List<Tweet> X = apiMethods.GetTop10TweetsOf100(user, 100).Result;
            
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Text", typeof(string));
            table.Columns.Add("Retweet", typeof(int));
            table.Columns.Add("Fav", typeof(int));
            table.Columns.Add("CreateAt", typeof(System.DateTime));

            foreach (Tweet t in X)
            {
                string TweetBaseUrl = baseUrl + "/status/" + t.id;
                _driver.Navigate().GoToUrl(TweetBaseUrl);
                table.Rows.Add(t.id, t.text, t.retweet_count, t.favourites_count, t.created_at);

                ScreenShotRemoteBrowser(t.id.ToString());

                string Retweets = _driver.FindElement(By.XPath("//a[@href='' " + TweetBaseUrl + "'/retweets']/div/span/span")).Text;
                string Likes = _driver.FindElement(By.XPath("//a[@href='' " + TweetBaseUrl + "'/retweets/with_comments']/div/span/span")).Text;
            }

        }

        public void VerifyUSersFriend(string baseUrl, string user)
        {
            ApiMethods apiMethods = new ApiMethods();
            List<string> Friends = apiMethods.GetFriends(user, 100).Result;
            IWebElement searchbox = _driver.FindElement(By.XPath("//input[@aria-label = 'Search query']"));
            searchbox.Clear();
            System.Random rnd = new System.Random();
            int r = rnd.Next(Friends.Count);
            searchbox.SendKeys(Friends[r]);
            _driver.FindElement(By.PartialLinkText(Friends[r])).Click();



        }

            public void ScreenShotRemoteBrowser(string name)
        {
            try
            {
                
                Screenshot  image = ((ITakesScreenshot)_driver).GetScreenshot();
                var ResourcePath = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedFiles");
                //Save the screenshot
                image.SaveAsFile(ResourcePath + name + "_landingPage.png", ScreenshotImageFormat.Png);
            }
            catch (System.Exception e)
            {
                //Console.WriteLine(e);
                Assert.Fail("Failed with Exception: " + e);
            }
        }

        



        }

    
}