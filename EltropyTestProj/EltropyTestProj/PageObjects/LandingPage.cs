using System.Drawing.Imaging;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;
using ApiHelper;
using System.Collections.Generic;
using System.Data;

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
        }

            public void ScreenShotRemoteBrowser(string name)
        {
            try
            {
                
                Screenshot  image = ((ITakesScreenshot)_driver).GetScreenshot();
                //Save the screenshot
                image.SaveAsFile("C:/temp/" + name + "_landingPage.png", ScreenshotImageFormat.Png);
            }
            catch (System.Exception e)
            {
                //Console.WriteLine(e);
                Assert.Fail("Failed with Exception: " + e);
            }
        }

        



        }

    
}