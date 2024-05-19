using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_2.Page
{
    internal class DrWebCheckingPage
    {
        private IWebDriver driver;

        public DrWebCheckingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterLink(string link)
        {
            IWebElement linkInput = driver.FindElement(By.XPath("//*[@id=\"url_to_scan\"]"));
            linkInput.SendKeys(link);
        }

        public void Submit()
        {
            IWebElement submitButton = driver.FindElement(By.XPath("//*[@id=\"drwebscanformURL\"]/div/div[2]/button"));
            submitButton.Click();
        }
    }
}
