using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPOM
{
   public  class BasePage
    {

       public static IWebDriver _driver;
       public BasePage()
        {
            if (_driver == null)
            { _driver = Helper.Driver; }
        }

    }
}
