using Lab10_1.Driver;
using Lab10_1.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;
using Lab10_1.Log;

class EdgeDriverTest1 { 
    static void Main() {

        var loggerFactory = LoggerFactory.Create(
                    builder => builder
                        .AddConsole()
                        .AddDebug()
                        .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug)
            );

        var logger = loggerFactory.CreateLogger<EdgeDriverTest1>();

        try {
            Console.WriteLine("Какой браузер вы хотите использовать? Firefox(1) или Edge(2), введите соответствующее целочисленное значение:");

            int numberForChoosingBrowser = Convert.ToInt32(Console.ReadLine());

            IWebDriver driver = DriverSingleton.GetDriver(numberForChoosingBrowser);

            // Создание экземпляра страницы DrWebHomePage
            DrWebHomePage homePage = new DrWebHomePage(driver);

            // Открыть сайт drweb.by
            homePage.NavigateTo();

            Thread.Sleep(1000);

            // Переход к странице "Лаборатория"
            DrWebLaboratoryPage labPage = homePage.GoToLabPage();

            Thread.Sleep(1000);

            // Навести курсор на элемент "База вирусов"
            labPage.HoverOverVirusLibrary();

            Thread.Sleep(1000);

            // Переход к странице "База вирусов"
            DrWebVirusLibraryPage virusLibraryPage = labPage.GoToVirusLibraryPage();

            Thread.Sleep(1000);

            // Выполнить поиск по ключевому слову или фразе
            string keyword = "Linux";
            virusLibraryPage.Search(keyword);

            Thread.Sleep(3000);

            // Закрытие браузера
            DriverSingleton.closeDriver();

            logger.LogInformation("Test ended successfully!");
        }
        catch (Exception e) {
            Screenshoter.TakeScreenshot();
            logger.LogError("Test do not ended or ended with errors!");
        }
    }
}
