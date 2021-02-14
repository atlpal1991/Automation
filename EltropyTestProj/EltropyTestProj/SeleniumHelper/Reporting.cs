using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EltropyTestProj.SeleniumHelper
{
    public class Result
    {

        public Result(string handle, string url, int retweet_count, int favourites_count, string created_at)
        {
            this.id = id;
            this.text = text;
            this.retweet_count = retweet_count;
            this.favourites_count = favourites_count;
            this.created_at = created_at;
        }

        public double id
        {
            get;
            set;
        }
        public string text
        {
            get;
            set;
        }
        public int retweet_count
        {
            get;
            set;
        }
        public int favourites_count
        {
            get;
            set;
        }

        public string created_at
        {
            get;
            set;
        }
    }
    /*
    class Reporting
    {
        private static IWebDriver _driver;
        public static void report(String actualValue, String expectedValue)
		{
			if (actualValue.Equals(expectedValue))
			{
				Result r = new Result("Pass", "Actual value '" + actualValue + "' matches expected value");
				details.add(r);
			}
			else
			{
				Result r = new Result("Fail", "Actual value '" + actualValue + "' does not match expected value '" + expectedValue + "'");
				details.add(r);
			}
		}


		public static void writeResults()
		{
			try
			{
				String reportIn = new String(Files.readAllBytes(Paths.get(templatePath)));
				for (int i = 0; i < details.size(); i++)
				{
					reportIn = reportIn.replaceFirst(resultPlaceholder, "<tr><td>" + Integer.toString(i + 1) + "</td><td>" + details.get(i).getResult() + "</td><td>" + details.get(i).getResultText() + "</td></tr>" + resultPlaceholder);
				}

				String currentDate = new SimpleDateFormat("dd-MM-yyyy").format(new Date());
				String reportPath = "Z:\\Documents\\Bas\\blog\\files\\report_" + currentDate + ".html";
				Files.write(Paths.get(reportPath), reportIn.getBytes(), StandardOpenOption.CREATE);

			}
			catch (Exception e)
			{
                System.out.println("Error when writing report file:\n" + e.toString());
			}
		}
    */

}
