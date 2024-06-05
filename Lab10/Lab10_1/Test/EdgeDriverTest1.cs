using Lab10_1.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;

class EdgeDriverTest1
{ 
    static void Main()
    {
        try
        {
            IWebDriver driver = new FirefoxDriver();

            // Создание экземпляра страницы DrWebHomePage
            DrWebHomePage homePage = new DrWebHomePage(driver);

            // Открыть сайт drweb.by
            homePage.NavigateTo();

            Thread.Sleep(2000);

            // Переход к странице "Лаборатория"
            DrWebLaboratoryPage labPage = homePage.GoToLabPage();

            Thread.Sleep(2000);

            // Навести курсор на элемент "База вирусов"
            labPage.HoverOverVirusLibrary();

            Thread.Sleep(2000);

            // Переход к странице "База вирусов"
            DrWebVirusLibraryPage virusLibraryPage = labPage.GoToVirusLibraryPage();

            Thread.Sleep(2000);

            // Выполнить поиск по ключевому слову или фразе
            string keyword = "Linux";
            virusLibraryPage.Search(keyword);

            Thread.Sleep(5000);

            // Закрытие браузера
            driver.Quit();

            Console.WriteLine("\nTest ended successfully!");
        }
        catch (Exception e)
        {
            Console.WriteLine("\nTest do not ended or ended with errors!");
        }
    }
}
