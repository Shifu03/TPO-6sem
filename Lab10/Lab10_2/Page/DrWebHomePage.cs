using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_2.Page {
    internal class DrWebHomePage {
        private IWebDriver driver;

        public DrWebHomePage(IWebDriver driver) {
            this.driver = driver;
        }

        public void NavigateTo() {
            driver.Navigate().GoToUrl(Parameters.PathsAndURLs.homePage);
        }

        public DrWebCheckingPage GoToCheckingPage() {
            IWebElement checkLinkButton = driver.FindElement(By.XPath(Parameters.PathsAndURLs.checkLinkButton));
            try {
                checkLinkButton.Click();
            }
            catch (Exception ex) {
                driver.Navigate().GoToUrl(Parameters.PathsAndURLs.vms);
            }

            return new DrWebCheckingPage(driver);
        }
    }
}
