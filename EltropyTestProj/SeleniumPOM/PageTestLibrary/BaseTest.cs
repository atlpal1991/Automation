using NUnit.Framework;
using SeleniumPOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium;

namespace SeleniumPOM
{
    public class BaseTest
    {
        public static IWebDriver _driver;

        [SetUp]
        public void SetupTest()
        {
            if (_driver == null)
            { _driver = Helper.Driver; }
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

    }
}
