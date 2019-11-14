using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFirst.SampleTest.Pages
{
    class ContactPage
    {
        private ChromeDriver driver;

        private static string statusBar;
        private static string myforename;
        private static string mysurname;
        private static string myemail;
        private static string mytelephone;
        private static string mymessage;


        public ContactPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public void EnterForename(string forename)=> driver.FindElementById("forename").SendKeys(forename);
        
        public void EnterSurname(string surname)=> driver.FindElementById("surname").SendKeys(surname);
        
        public void EnterEmail(string email)=> driver.FindElementById("email").SendKeys(email);
        
        public void EnterTelephone(string telephone)=> driver.FindElementById("telephone").SendKeys(telephone);
  
        public void EnterMessage(string message)=> driver.FindElementById("message").SendKeys(message);

        public string getMsgBeforeFeedback()
        {
            return driver.FindElementByClassName("alert-info").Text;
        }

        public string getMsgAfterFeedback()
        {
            return driver.FindElementByClassName("alert-success").Text;
        }

        public string getMandatoryFieldErrMsg()
        {
            return driver.FindElementByClassName("alert-error").Text;
        }

        public void clickSubmit()
        {
            driver.FindElementByClassName("btn-contact").Click();
        }


    }
}
