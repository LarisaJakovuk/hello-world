using OpenQA.Selenium;


namespace SeleniumCheckBoxDemo.Pages
{
    public class BasicPage
    {

        protected static IWebDriver Driver;

        public BasicPage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }


        public void CloseBrowser()
        {
            Driver.Quit();
        }


    }
}