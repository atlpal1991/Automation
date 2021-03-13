using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;

namespace SeleniumPOM
{

    class DriverFactory
    {
        public IWebDriver Create()
        {
            IWebDriver driver;
            var driverToUse = ConfigurationManager.AppSettings["DriverToUse"];
            switch (driverToUse)
            {
                case "InternetExplorer":
                    driver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return driver;

        }

    }
}
