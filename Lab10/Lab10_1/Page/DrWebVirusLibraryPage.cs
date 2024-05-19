using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_1.Page
{
    internal class DrWebVirusLibraryPage
    {
        private IWebDriver driver;

        public DrWebVirusLibraryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Search(string keyword)
        {
            IWebElement searchInput = driver.FindElement(By.XPath("//div[@class = \"CONTENT\"]/div[1]/div[1]/form/div/div/input"));
            searchInput.SendKeys(keyword);
            searchInput.Submit();
        }
    }
}
