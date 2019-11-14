using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;

namespace SeleniumFirst.SampleTest.Pages
{
    class HomePage
    {
        private ChromeDriver driver;

        public HomePage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        public ContactPage clickContact()
        {
            driver.FindElementByCssSelector("li#nav-contact").Click() ;
            return new ContactPage(driver);
        }
    }
}
