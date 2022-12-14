using AHTG_QA_Automation_Assignment.pageObjects;
using AHTG_QA_Automation_Assignment.utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace AHTG_QA_Automation_Assignment
{
    public class E2ETest : Base
    {

        [Test,Category("DemoTest")]
        public void AssingmentTest()
        {
            HomePage home = new HomePage(driver);
            RequestDemoPage requestDemo = home.ClickDemoBtn();
            requestDemo.Sleep();
            
            var name = requestDemo.getName().GetAttribute("placeholder");
            var defnamevalue = "What's your name?";
            Assert.AreEqual(defnamevalue, name);

            var email = requestDemo.getEmail().GetAttribute("placeholder");
            var defemailvalue = "What's your email?";
            Assert.AreEqual(defemailvalue, email);

            OurTeamPage ourTeam = requestDemo.AboutUs();
            ourTeam.NavigateToUs();
            Thread.Sleep(2000);

            Boolean BrainSchwidderImg = ourTeam.BRImg().Displayed;
            Assert.IsTrue(BrainSchwidderImg);

            Boolean BenPalmerImg = ourTeam.BPImg().Displayed;
            Assert.IsTrue(BenPalmerImg);
            ourTeam.ViewMoreBtn();
            Thread.Sleep(2000);

            OurProductsPage ourproducts = ourTeam.products();
            ourproducts.OurProducts();
            Thread.Sleep(2000);

            Boolean TrioVMS = ourproducts.VendorVMS().Displayed;
            Assert.IsTrue(TrioVMS);

            ourproducts.waitForinsightEl();
            Boolean insATS = ourproducts.InsightATS().Enabled;
            Assert.IsTrue(insATS);

            ourproducts.ScrolltillEle();
            ourproducts.waitForBtntoDisplay();
            Boolean requestBtn = ourproducts.RequestDemoBtn().Displayed;
            Assert.IsTrue(requestBtn);



        }

    }
}