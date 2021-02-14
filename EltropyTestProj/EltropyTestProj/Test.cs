using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;
using Tests.PageObjects;
using Excel = Microsoft.Office.Interop.Excel;

namespace Test
{
    [TestFixture]
    public class FillFormIntegrationTest
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;

        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Create();
            _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
            _verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
            
        }

        [Test]
        public void TestImplement()
        {
            //read 100 twitter user from excel sheet
            List<string> Users= SeleniumHelper.ExcelReader();
            


            foreach (string i in Users)
            {
                _baseUrl = "https://twitter.com/" + i;

                //Code to capture homepage of user
                new LandingPage(_driver).UserMainCpature(_baseUrl, i);

                //code to verify top 10 tweets of user being fetched via API
                new LandingPage(_driver).VerifyTweetList(_baseUrl, i);

                //Code to verify users friend list operations
                new LandingPage(_driver).VerifyUSersFriend(_baseUrl, i);

            }

        }

        
    }
}

