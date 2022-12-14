using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHTG_QA_Automation_Assignment.pageObjects
{
    public  class RequestDemoPage
    {

        private IWebDriver driver;

        public RequestDemoPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }


        [FindsBy(How = How.Id, Using = "Full-Name")]
        private IWebElement name;

        [FindsBy(How = How.Id, Using = "Email")]
        private IWebElement email;


        public void waitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@value='submit message']")));

        }

        public IWebElement getName()
        {
            return name;
        }

        public IWebElement getEmail()
        {
            return email;
        }

        public OurTeamPage AboutUs()
        {
            return new OurTeamPage(driver);


        }

        public void Sleep()
        {
            Thread.Sleep(2000);
        }









    }
}
