using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10_2.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

namespace Lab10_2.Driver
{
    internal class DriverSingleton
    {
        public static IWebDriver driver;

        private DriverSingleton() { }

        public static IWebDriver GetDriver(int numberOfBrowser)
        {
            if (driver == null)
            {
                switch (numberOfBrowser)
                {
                    case 1:
                        driver = new FirefoxDriver();
                        break;
                    case 2:
                        driver = new EdgeDriver();
                        break;
                }
            }
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
