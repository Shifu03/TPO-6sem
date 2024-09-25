using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_2.Page {
    internal class DrWebCheckingPage {
        private IWebDriver driver;

        public DrWebCheckingPage(IWebDriver driver) {
            this.driver = driver;
        }

        public void EnterLink(string link) {
            IWebElement linkInput = driver.FindElement(By.XPath(Parameters.PathsAndURLs.linkInput));
            linkInput.SendKeys(link);
        }

        public void Submit() {
            IWebElement submitButton = driver.FindElement(By.XPath(Parameters.PathsAndURLs.submitButton));
            submitButton.Click();
        }
    }
}
