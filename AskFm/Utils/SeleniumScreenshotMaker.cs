#region Usages

using System;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using NUnitReporter.Reporting.Helpers.Ext;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

#endregion

namespace AskFm.Utils
{

    public class SeleniumScreenshotMaker : IScreenCaptureHelperExtension
    {
        public static Screenshot FinalScreenshot { get; set; }
        public static bool CaptureScreenshot { get; set; }
        private RemoteWebDriver _driver;

        public SeleniumScreenshotMaker(RemoteWebDriver driver)
        {
            _driver = driver;
            CaptureScreenshot = true;
            FinalScreenshot = null;
        }

        public string MakeScreenshot(string imagePath)
        {
            if (_driver == null || !CaptureScreenshot)
            {
                return null;
            }
            Screenshot screenshot;
            try
            {
                screenshot = _driver.TakeScreenshot();
                FinalScreenshot = screenshot;
            }
            catch (Exception)
            {
                screenshot = FinalScreenshot;
            }
            var imageName = string.Format("screenshot{0}.png", Environment.TickCount);
            if (null == screenshot)
            {
                //                return CaptureScreen(imagePath, imageName); TODO make screen capture from node's desktop
                return null;
            }
            screenshot.SaveAsFile(Path.Combine(imagePath, imageName), ImageFormat.Png);
            return imageName;
        }
    }

    public static class WebDriverScreenExtension
    {
        public static void CloseDriver(this RemoteWebDriver driver)
        {
            SeleniumScreenshotMaker.FinalScreenshot = driver.TakeScreenshot();
            driver.Quit();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static Screenshot TakeScreenshot(this RemoteWebDriver driver)
        {
            var screenshot = driver.GetScreenshot();
            return screenshot;
        }
    }
}
