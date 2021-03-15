using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Remote;

namespace ParallelTestsPOM.XHelper
{
    public  static class Helper
    {

        public static IWebDriver initilizer(int second, int Choice)
        {
            IWebDriver driver = null;

            //Chrome
            if (Choice == 0)
            { OpenQA.Selenium.Chrome.ChromeOptions capability = new OpenQA.Selenium.Chrome.ChromeOptions();
                capability.AddAdditionalCapability("os_version", "10", true);
                capability.AddAdditionalCapability("resolution", "1920x1080", true);
                capability.AddAdditionalCapability("browser", "Chrome", true);
                capability.AddAdditionalCapability("browser_version", "latest-beta", true);
                capability.AddAdditionalCapability("os", "Windows", true);
                capability.AddAdditionalCapability("name", "BStack-[C_sharp] Sample Test", true); // test name
                capability.AddAdditionalCapability("build", "BStack Build Number 1", true); // CI/CD job or build name
                capability.AddAdditionalCapability("browserstack.user", "atulpal1", true);
                capability.AddAdditionalCapability("browserstack.key", "qeHMaqH1ZVbRxbuLRoGs", true);
                 driver = new RemoteWebDriver(
                  new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capability
                );
                driver.Navigate().GoToUrl(Configuration.baseUrl);
                

                //IWebDriver driver = new ChromeDriver();
                TimeSpan seconds = TimeSpan.FromSeconds(second);
                driver.Manage().Timeouts().ImplicitWait = seconds;
                //return driver;
            }


            //firefox
            if (Choice == 1)
            {
                OpenQA.Selenium.Firefox.FirefoxOptions capability = new OpenQA.Selenium.Firefox.FirefoxOptions();
                capability.AddAdditionalCapability("os_version", "10", true);
                capability.AddAdditionalCapability("resolution", "1920x1080", true);
                capability.AddAdditionalCapability("browser", "Firefox", true);
                capability.AddAdditionalCapability("browser_version", "latest", true);
                capability.AddAdditionalCapability("os", "Windows", true);
                capability.AddAdditionalCapability("name", "BStack-[C_sharp] Sample Test", true); // test name
                capability.AddAdditionalCapability("build", "BStack Build Number 1", true); // CI/CD job or build name
                capability.AddAdditionalCapability("browserstack.user", "atulpal1", true);
                capability.AddAdditionalCapability("browserstack.key", "qeHMaqH1ZVbRxbuLRoGs", true);
                driver = new RemoteWebDriver(
                  new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capability
                );
                driver.Navigate().GoToUrl(Configuration.baseUrl);


                //IWebDriver driver = new ChromeDriver();
                TimeSpan seconds = TimeSpan.FromSeconds(second);
                driver.Manage().Timeouts().ImplicitWait = seconds;
                //return driver;
            }



            return driver;
        }
    }
}
