using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_1.Page
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
            driver.Navigate().GoToUrl(Parameters.PathsAndURLs.homePage);
        }

        public DrWebLaboratoryPage GoToLabPage()
        {
            IWebElement menuButton = driver.FindElement(By.XPath(Parameters.PathsAndURLs.menuButton));
            menuButton.Click();

            IWebElement abLab = driver.FindElement(By.XPath(Parameters.PathsAndURLs.abLab));
            abLab.Click();

            return new DrWebLaboratoryPage(driver);
        }
    }
}
