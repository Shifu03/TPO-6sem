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

                // Создаем экземпляр страницы DrWebHomePage
                DrWebHomePage homePage = new DrWebHomePage(driver);

                // Открываем сайт drweb.by
                homePage.NavigateTo();

                Thread.Sleep(2000);

                // Нажимаем на кнопку "Проверить ссылку"
                DrWebCheckingPage checkingPage = homePage.GoToCheckingPage();

                Thread.Sleep(2000);

                // Вводим некорректную ссылку для проверки
                checkingPage.EnterLink("www.экзампл.123");

                Thread.Sleep(2000);

                // Нажимаем кнопку "Отправить"
                checkingPage.Submit();

                Thread.Sleep(5000);

                // Закрываем браузер
                DriverSingleton.CloseDriver();

                logger.LogInformation("Test ended successfully!");
            }
            catch (Exception e) {
                logger.LogError("Test do not ended or ended with errors!");
            }
        }
    }
}
