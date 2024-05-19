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
            driver.Navigate().GoToUrl("https://www.drweb.by/");
        }

        public DrWebLaboratoryPage GoToLabPage()
        {
            IWebElement menuButton = driver.FindElement(By.XPath("//div[@class = \"grid grid-rows-[auto_auto_1fr_auto] min-h-screen\"]/header/div[1]/div[1]/div[@class = \"flex gap-4 lg:[.search-showed_&]:hidden\"]/button[1]"));
            menuButton.Click();

            IWebElement abLab = driver.FindElement(By.XPath("//div[@class = \"grid grid-rows-[auto_auto_1fr_auto] min-h-screen\"]/header/div[1]/div[1]/div[1]/nav[1]/div[2]/ul/li[2]/a"));
            abLab.Click();

            return new DrWebLaboratoryPage(driver);
        }
    }
}
