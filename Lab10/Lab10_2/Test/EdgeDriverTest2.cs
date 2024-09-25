using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Lab10_2.Page;
using Lab10_2.Driver;
using Microsoft.Extensions.Logging;
using System.Drawing.Imaging;
using System.Drawing;
using Lab10_1.Log;

namespace Lab10_2.Test {
    internal class EdgeDriverTest2 {
        static void Main() {

            var loggerFactory = LoggerFactory.Create(
                    builder => builder
                        .AddConsole()
                        .AddDebug()
                        .SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug)
            );

            var logger = loggerFactory.CreateLogger<EdgeDriverTest2>();

            try {
                Console.WriteLine("Какой браузер вы хотите использовать? Firefox(1) или Edge(2), введите соответствующее целочисленное значение:");

                int numberForChoosingBrowser = Convert.ToInt32(Console.ReadLine());

                IWebDriver driver = DriverSingleton.GetDriver(numberForChoosingBrowser);

                DrWebHomePage homePage = new DrWebHomePage(driver);

                homePage.NavigateTo();

                logger.LogInformation("Переход на главную страницу Dr.Web\n");

                Thread.Sleep(2000);

                DrWebCheckingPage checkingPage = homePage.GoToCheckingPage();

                logger.LogInformation("Переход на страницу проверки ссылок\n");

                Thread.Sleep(2000);

                checkingPage.EnterLink("www.экзампл.123");

                Thread.Sleep(2000);

                checkingPage.Submit();

                logger.LogInformation("Проверка ссылки \"www.экзампл.123\"\n");

                Thread.Sleep(5000);

                DriverSingleton.CloseDriver();

                logger.LogInformation("Test ended successfully!\n");
            }
            catch (Exception e) {
                Screenshoter.TakeScreenshot();
                logger.LogError("Test do not ended or ended with errors!");
                
            }
        }
    }
}
