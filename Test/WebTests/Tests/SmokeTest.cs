using FluentAssertions;
using OpenQA.Selenium.Chrome;
using SeleniumFirst.SampleTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeleniumFirst.SampleTest
{
    public class SmokeTest
    {
             
        // TODO: Create WebDriver and configure it ONCE per test class
        
        [Fact(DisplayName = "Selenium Jupiter Toys Feedback test")]
        public void JupiterToysSearch()
        {
            using (var driver = new ChromeDriver(@".\"))
            {
                driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(15));
                driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com/");
                driver.Manage().Window.Maximize();
                HomePage homePage = new HomePage(driver);
                // TODO: Verify we are actually on the Jupiter Toys home page
                Assert.Equal("Jupiter Toys",(driver.FindElementByClassName("brand").Text));  

                ContactPage contactPage = homePage.clickContact();

                // TODO: Check that the status msg is what we expect: "We welcome your feedback - tell it how it is."
                 Assert.Equal("We welcome your feedback - tell it how it is.", contactPage.getMsgBeforeFeedback() ); 

                contactPage.EnterForename("kapil");
                contactPage.EnterSurname("Batra");
                contactPage.EnterEmail("kaptest@gmai.com");
                contactPage.EnterTelephone("045363738");
                contactPage.EnterMessage("test message");

                contactPage.clickSubmit();
                // TODO: Check that the status message is "Thanks kapil, we appreciate your feedback"
                Assert.Equal("Thanks kapil, we appreciate your feedback.", contactPage.getMsgAfterFeedback());

                //driver.FindElementByCssSelector("li#nav-login").Click;
                // driver.FindElementByCssSelector("div.hero-unit h1")
                driver.Quit();
            }
        }

        [Fact (DisplayName = "Negative Test- Selenium Jupiter Toys Feedback")]
        public void FeedbackNegativeTest()
        {
            using (var driver = new ChromeDriver(@".\"))
            {
                driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(15));
                driver.Navigate().GoToUrl("http://jupiter.cloud.planittesting.com/");
                driver.Manage().Window.Maximize();
                HomePage homePage = new HomePage(driver);
                // TODO: Verify we are actually on the Jupiter Toys home page
                Assert.Equal("Jupiter Toys", (driver.FindElementByClassName("brand").Text));

                ContactPage contactPage = homePage.clickContact();

                // TODO: Check that the status msg is what we expect: "We welcome your feedback - tell it how it is."
                Assert.Equal("We welcome your feedback - tell it how it is.", contactPage.getMsgBeforeFeedback());

                //Mandatory field error message check
                contactPage.clickSubmit();
                // TODO: Check that the status message is " but we won't get it unless you complete the form correctly."
                Assert.Equal("We welcome your feedback - but we won't get it unless you complete the form correctly.", contactPage.getMandatoryFieldErrMsg());

                //driver.FindElementByCssSelector("li#nav-login").Click;
                // driver.FindElementByCssSelector("div.hero-unit h1")
                driver.Quit();
            }
        }

    }
}
