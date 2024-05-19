using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_2.Page
{
    internal class DrWebHomePage
    {
        private IWebDriver driver;

        public DrWebHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://www.drweb.by/");
        }

        public DrWebCheckingPage GoToCheckingPage()
        {
            IWebElement checkLinkButton = driver.FindElement(By.XPath("/html/body/div[2]/main/div/div[3]/a[1]"));
            try
            {
                checkLinkButton.Click();
            }
            catch (Exception ex)
            {
                driver.Navigate().GoToUrl("https://vms.drweb.by/online/?utm_medium=glavnaya&utm_source=drweb_site&utm_campaign=urlonline");
            }

            return new DrWebCheckingPage(driver);
        }
    }
}
