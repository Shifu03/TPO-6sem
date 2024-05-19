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
            IWebElement virusLibraryList = driver.FindElement(By.XPath("//div[@class = \"HEAD clearfix\"]/div[2]/div[2]/div[5]/dl/dt"));
            actions.MoveToElement(virusLibraryList).Perform();
        }

        public DrWebVirusLibraryPage GoToVirusLibraryPage()
        {
            IWebElement virusLibrary = driver.FindElement(By.XPath("//div[@class = \"HEAD clearfix\"]/div[2]/div[2]/div[5]/dl/dd/div/ul/li[1]/a"));
            virusLibrary.Click();

            return new DrWebVirusLibraryPage(driver);
        }
    }
}
