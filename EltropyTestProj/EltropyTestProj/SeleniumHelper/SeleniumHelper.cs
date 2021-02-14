using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace Structura.GuiTests.SeleniumHelpers
{
    //Specflow:
    //[Binding]
    public class SeleniumHelper
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
                // Avoid synchronization issues by applying timed delay to each step if necessary
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes((5));
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(5);
                return _driver;
            }
        }

        //Specflow:
        //[AfterTestRun]
        public static void AfterTestRun()
        {
            ResetDriver();
        }


        public static void Wait(int miliseconds, int maxTimeOutSeconds = 60)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 1, maxTimeOutSeconds));
            var delay = new TimeSpan(0, 0, 0, 0, miliseconds);
            var timestamp = DateTime.Now;
            wait.Until(webDriver => (DateTime.Now - timestamp) > delay);
        }


        public static string GetCosasBuildVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            var result = string.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.MinorRevision);

            return result;
        }

        public static List<string> ExcelReader()
        {
            //Read the excel document using Microsoft Office package
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            int sprowCnt = 0; // row count
            int spcolumnCnt = 0; // column count
            List<string> userhandles = new List<string>();

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"<strong>C:\splessons.xlsx</strong>", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            range = xlWorkSheet.UsedRange;

            for (sprowCnt = 1; sprowCnt <= range.Rows.Count; sprowCnt++)
            {
                for (spcolumnCnt = 1; spcolumnCnt <= range.Columns.Count; spcolumnCnt++)
                {
                    userhandles.Add((range.Cells[sprowCnt, spcolumnCnt] as Excel.Range).Value2);
                    //Console.WriteLine(" Coulmn Number: " + spcolumnCnt + "--> " + (range.Cells[sprowCnt, spcolumnCnt] as Excel.Range).Value2);
                }
            }

            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            return userhandles;

        }
    }
}
