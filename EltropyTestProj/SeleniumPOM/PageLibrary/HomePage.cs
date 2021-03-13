using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Configuration;
using System.Collections.Generic;


namespace SeleniumPOM 
{
    public class HomePage : BasePage
    {
        public HomePage()
        {
        }

        //From City
        [FindsBy(How = How.Id, Using = "fromCity")]
        public IWebElement From { get; set; }

        //To City
        [FindsBy(How = How.Id, Using = "toCity")]
        public IWebElement To { get; set; }

        //Departure Date
        [FindsBy(How = How.Id, Using = "departure")]
        public IWebElement departDate { get; set; }

        //Return Date
        [FindsBy(How = How.Id, Using = "return")]
        public IWebElement returnDate { get; set; }

        //Flight Search Button
        [FindsBy(How = How.ClassName, Using = "primaryBtn font24 latoBold widgetSearchBtn")]
        public IWebElement searchButton { get; set; }

        public void testmethod()
        {
            string baseurl = ConfigurationManager.AppSettings["TargetUrl"];
            _driver.Navigate().GoToUrl(baseurl);

            Console.WriteLine("test1");
        }





    }
}
