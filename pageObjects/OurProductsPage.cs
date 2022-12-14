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
    public class OurProductsPage
    {

        private IWebDriver driver;

        public OurProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "//div[normalize-space()='our products']")]
        private IWebElement ourProductsBtn;


        [FindsBy(How = How.XPath, Using = "//img[@class='step-image'][1]")]
        private IWebElement vendorVMS;


        [FindsBy(How = How.XPath, Using = "//img[@class='step-image'][2]")]
        private IWebElement insightATS;

        [FindsBy(How = How.CssSelector, Using = ".button-primary.large.w-button")]
        private IWebElement requestDemoBtn;

        public IWebElement RequestDemoBtn()
        {
            return requestDemoBtn;
        }


        public IWebElement VendorVMS()
        {
            return vendorVMS;
        }

        public IWebElement InsightATS()
        {
            return insightATS;
        }

        public IWebElement clickOurProd()
        {
            return ourProductsBtn;
        }

        public void OurProducts()
        {
            ourProductsBtn.Click();
        }

        public void ScrollDown()
        {
            IWebElement requestBtn = driver.FindElement(By.CssSelector(".button-primary.large.w-button"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", requestBtn);
        }

        public void waitForBtntoDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".button-primary.large.w-button")));

        }

        public void waitForinsightEl()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//img[@class='step-image'][2]")));

        }

        public void ScrolltillEle()
        {
            IWebElement requestBtn = driver.FindElement(By.CssSelector(".button-primary.large.w-button"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,3000)", requestBtn);

        }
















    }
}
