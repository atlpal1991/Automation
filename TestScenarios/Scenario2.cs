using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support;

namespace ParallelTestsPOM.TestScenarios
{
    public class Scenario2
    {
        IWebDriver driver;
        [OneTimeSetUp]
        public void initialise()
        {
             driver = XHelper.Helper.initilizer(5);
            
        }


        [Test]
        public void ValidLogin()
        {
            Console.WriteLine(2);
        }


        [OneTimeTearDown]
        public void Clean()
        { driver.Quit(); }
    }
}
