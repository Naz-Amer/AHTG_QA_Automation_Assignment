using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;

namespace AHTG_QA_Automation_Assignment.pageObjects
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver,this);

        }

        [FindsBy(How = How.CssSelector,Using = ".button-primary.small.w-button")]
        private IWebElement reqDemoBtn;

       

      
        public IWebElement getEmail()
        {
            return reqDemoBtn;
        }


        public RequestDemoPage ClickDemoBtn()
        {
            reqDemoBtn.Click();
            return new RequestDemoPage(driver);
            

        }

       








    }


   
}
