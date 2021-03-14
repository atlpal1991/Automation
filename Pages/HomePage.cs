using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace ParallelTestsPOM.Pages
{
    public class HomePage
    {
        public HomePage(IWebDriver driver)
        { PageFactory.InitElements(driver, this); }

        [FindsBy(How = How.Id, Using = "")]
        public IWebElement a1 {get; set;}


        [FindsBy(How = How.Id, Using = "")]
        public IWebElement a2 { get; set; }


        [FindsBy(How = How.Id, Using = "")]
        public IWebElement a3 { get; set; }


        [FindsBy(How = How.Id, Using = "")]
        public IWebElement a4 { get; set; }


        [FindsBy(How = How.Id, Using = "")]
        public IWebElement a5 { get; set; }




    }
}
