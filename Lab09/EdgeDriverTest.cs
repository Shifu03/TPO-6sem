using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

class EdgeDriverTest
{
    static void Main()
    {
        // Инициализация WebDriver
        IWebDriver driver = new EdgeDriver();

        Actions actions = new Actions(driver);

        //Открыть сайт drweb.by
        driver.Navigate().GoToUrl("https://www.drweb.by/");

        Thread.Sleep(2000);

        IWebElement menuButton = driver.FindElement(By.XPath("//div[@class = \"grid grid-rows-[auto_auto_1fr_auto] min-h-screen\"]/header/div[1]/div[1]/div[@class = \"flex gap-4 lg:[.search-showed_&]:hidden\"]/button[1]"));
        menuButton.Click();

        Thread.Sleep(2000);

        IWebElement abLab = driver.FindElement(By.XPath("//div[@class = \"grid grid-rows-[auto_auto_1fr_auto] min-h-screen\"]/header/div[1]/div[1]/div[1]/nav[1]/div[2]/ul/li[2]/a"));
        abLab.Click();

        Thread.Sleep(2000);

        IWebElement virusLibruaryList = driver.FindElement(By.XPath("//div[@class = \"HEAD clearfix\"]/div[2]/div[2]/div[5]/dl/dt"));

        // Навести курсор на элемент
        actions.MoveToElement(virusLibruaryList).Perform();

        Thread.Sleep(2000);

        IWebElement virusLibruary = driver.FindElement(By.XPath("//div[@class = \"HEAD clearfix\"]/div[2]/div[2]/div[5]/dl/dd/div/ul/li[1]/a"));
        virusLibruary.Click();

        Thread.Sleep(2000);

        //Найти поисковую строку
        IWebElement searchInput = driver.FindElement(By.XPath("//div[@class = \"CONTENT\"]/div[1]/div[1]/form/div/div/input"));

        //Выполнить поиск по ключевому слову или фразе
        string keyword = "Linux";
        searchInput.SendKeys(keyword);

        Thread.Sleep(1000);

        searchInput.Submit();

        Thread.Sleep(5000);

        // Закрытие браузера
        driver.Quit();
    }
}
