using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Lab10_2.Page;

namespace Lab10_2.Test
{
    internal class EdgeDriverTest2
    {
        static void Main()
        {
            try
            {
                IWebDriver driver = new EdgeDriver();

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
                driver.Quit();

                Console.WriteLine("\nTest ended successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nTest do not ended or ended with errors!");
            }
        }
    }
}
