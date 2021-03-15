using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace ParallelTestsPOM.Pages
{
    public class HomePage
    {
        public HomePage(IWebDriver driver)
        { PageFactory.InitElements(driver, this); }

        [FindsBy(How = How.XPath, Using = "//input[@title='Search for products, brands and more']")]
        public IWebElement searchText { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@title='Mobiles']")]
        public IWebElement Clickablelebel { get; set; }


        [FindsBy(How = How.Id, Using = "")]
        public IWebElement a3 { get; set; }


        [FindsBy(How = How.ClassName, Using = "_24_Dny")]
        public IWebElement samsungFilter { get; set; }


        [FindsBy(How = How.ClassName, Using = "_24_Dny _3tCU7L")]
        public IWebElement flipkartAssured { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='_2KpZ6l _2doB4z']")]
        public IWebElement PopUp { get; set; }







    }
}
