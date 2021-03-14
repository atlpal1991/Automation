using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support;

namespace ParallelTestsPOM.TestScenarios
{
    [Parallelizable]
    public class Scenario1
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void initialise()
        {
             driver = XHelper.Helper.initilizer(5);
        }


        [Test]
        public void InvalidLogin()
        {
            Console.WriteLine(1);
        
        }


        [OneTimeTearDown]
        public void Clean()
        { driver.Quit(); }

    }
}
