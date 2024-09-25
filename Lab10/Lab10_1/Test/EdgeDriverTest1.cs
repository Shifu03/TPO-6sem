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

            DrWebHomePage homePage = new DrWebHomePage(driver);

            homePage.NavigateTo();

            logger.LogInformation("Переход на главную страницу Dr.Web\n");

            Thread.Sleep(1000);

            DrWebLaboratoryPage labPage = homePage.GoToLabPage();

            logger.LogInformation("Переход на страницу лаборатории Dr.Web\n");

            Thread.Sleep(1000);

            labPage.HoverOverVirusLibrary();

            Thread.Sleep(1000);

            DrWebVirusLibraryPage virusLibraryPage = labPage.GoToVirusLibraryPage();

            logger.LogInformation("Переход на страницу вирусной библиотеки Dr.Web\n");

            Thread.Sleep(1000);

            string keyword = "Linux";
            virusLibraryPage.Search(keyword);

            Thread.Sleep(3000);

            DriverSingleton.closeDriver();

            logger.LogInformation("Test ended successfully!\n");
        }
        catch (Exception e) {
            Screenshoter.TakeScreenshot();
            logger.LogError("Test do not ended or ended with errors!");
        }
    }
}
