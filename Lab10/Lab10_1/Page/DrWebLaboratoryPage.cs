using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_1.Page
{
    internal class DrWebLaboratoryPage
    {
        private IWebDriver driver;
        private Actions actions;

        public DrWebLaboratoryPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
        }

        public void HoverOverVirusLibrary()
        {
            IWebElement virusLibraryList = driver.FindElement(By.XPath(Parameters.PathsAndURLs.virusLibraryList));
            actions.MoveToElement(virusLibraryList).Perform();
        }

        public DrWebVirusLibraryPage GoToVirusLibraryPage()
        {
            IWebElement virusLibrary = driver.FindElement(By.XPath(Parameters.PathsAndURLs.virusLabrary));
            virusLibrary.Click();

            return new DrWebVirusLibraryPage(driver);
        }
    }
}
