using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Lab10_1.Log
{
    public static class Screenshoter
    {
        [DllImport("gdi32.dll")]
        private static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        public static string filePath = @"D:\Учёба\Лабы\TPO-6sem\Lab10\Lab10_1\Log\Screenshots\screenshot";

        public static int countOfScreenshots = 1;

        public static int screenWidth = GetSystemMetrics(0);
        public static int screenHeight = GetSystemMetrics(1);

        public static void TakeScreenshot()
        {
            using (Bitmap bitmap = new Bitmap(screenWidth, screenHeight))
            {
                // Получение дескриптора устройства для рабочего стола
                IntPtr desktopHwnd = GetDesktopWindow();
                IntPtr desktopDC = GetWindowDC(desktopHwnd);

                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    IntPtr bitmapDC = g.GetHdc();

                    // Копирование экрана в графический объект
                    BitBlt(bitmapDC, 0, 0, screenWidth, screenHeight, desktopDC, 0, 0, 0x00CC0020);

                    // Освобождение дескриптора устройства
                    g.ReleaseHdc(bitmapDC);
                }

                // Освобождение дескриптора рабочего стола
                ReleaseDC(desktopHwnd, desktopDC);

                // Сохранение изображения в файл
                bitmap.Save(filePath + $"{countOfScreenshots}.png", ImageFormat.Png);
                countOfScreenshots++;
            }
            Console.WriteLine("Скриншот сохранён по пути: " + filePath);
        }
    }
}
