using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHTG_QA_Automation_Assignment.pageObjects
{
    public class OurTeamPage
    {

        private IWebDriver driver;

        public OurTeamPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

        }


        [FindsBy(How = How.CssSelector, Using = ".dropdown-text")]
        private IWebElement aboutUsDropBtn;

        [FindsBy(How = How.CssSelector, Using = ".mega-menu-nav-link[href='/our-team']")]
        private IWebElement ourTeamBtn;


        [FindsBy(How = How.XPath, Using = "(//img[@class='testimonial-picture'])[1]")]
        private IWebElement BrainSchwinderImg;


        [FindsBy(How = How.XPath, Using = "(//img[@class='testimonial-picture'])[3]")]
        private IWebElement BenPalmerImg;

        [FindsBy(How = How.XPath, Using = "(//div[@class='team-card-fake-link'][normalize-space()='View More'])[3]")]
        private IWebElement viewMoreBtn;

        public IWebElement clickviewMore()
        {
            return viewMoreBtn;
        }

        public IWebElement BRImg()
        {
            return BrainSchwinderImg;
        }

        public IWebElement BPImg()
        {
            return BenPalmerImg;
        }


        public IWebElement aboutUs()
        {
            return aboutUsDropBtn;
        }

        public IWebElement ourTeamDBtn()
        {
            return ourTeamBtn;
        }

        public void NavigateToUs()
        {
            aboutUsDropBtn.Click();
            ourTeamBtn.Click();
        }

        public void ViewMoreBtn()
        {
            viewMoreBtn.Click();
        }

        public OurProductsPage products()
        {
            return new OurProductsPage(driver);
        }


    }
}
