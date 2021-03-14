using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support;

namespace ParallelTestsPOM.XHelper
{
    public  static class Helper
    {

        public static IWebDriver initilizer(int second)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Configuration.baseUrl);


            TimeSpan seconds = TimeSpan.FromSeconds(second);
            driver.Manage().Timeouts().ImplicitWait = seconds;

            return driver;
        }
    }
}
