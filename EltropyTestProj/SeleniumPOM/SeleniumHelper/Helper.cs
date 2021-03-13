using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM
{
    class Helper
    {

     private static IWebDriver _driver;

        public static void ResetDriver()
        {
            try
            {
                if (_driver != null)
                {
                    Driver.Close();
                    Driver.Quit();
                    _driver = null;
                }
            }
            catch (Exception ex) { }
        }
        public static IWebDriver Driver
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }
                _driver = new DriverFactory().Create();
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes((5));
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
                return _driver;
            }
        }
    }
}
