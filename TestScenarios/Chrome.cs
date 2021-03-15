using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using ParallelTestsPOM.XHelper;
using ParallelTestsPOM.Pages;

namespace ParallelTestsPOM.TestScenarios
{
    [Parallelizable]
    public class Chrome
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void initialise()
        {
             driver = XHelper.Helper.initilizer(5, 0);
        }


        [Test]
        public void searchSamsungMobile()
        {
            driver.Navigate().GoToUrl(Configuration.baseUrl);
            HomePage flipKart = new HomePage(driver);
            flipKart.PopUp.Click();
            flipKart.searchText.SendKeys("Samsung Galaxy S10");
            flipKart.searchText.SendKeys(Keys.Enter);
            flipKart.Clickablelebel.Click();
            flipKart.samsungFilter.Click();
            //flipKart.flipkartAssured.Click();


            //Fetch All the Products Text
            List<IWebElement> list_of_products_names = driver.FindElements(By.XPath("//div[@class='_4rR01T']")).ToList<IWebElement>();
            List<IWebElement> list_of_products_price = driver.FindElements(By.XPath("//div[@class='_30jeq3 _1_WHN1']")).ToList<IWebElement>();
            List<IWebElement> list_of_products_links = driver.FindElements(By.XPath("//*[@class='_1fQZEK']")).ToList<IWebElement>();


            for (int i=0; i<5; i++)
            {
                Console.WriteLine(list_of_products_names[i].Text);
                Console.WriteLine(list_of_products_price[i].Text);
                Console.WriteLine(list_of_products_links[i].GetAttribute("href"));

            }
        }


        [OneTimeTearDown]
        public void Clean()
        { driver.Quit(); }

    }
}
