using NUnit.Framework;
using NUnitReporter.Reporting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;
using System.IO;
using AskFm.Utils;
using NUnitReporter.Reporting.Helpers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AskFm.Base
{
    public class BaseTest
    {
        public static RemoteWebDriver Driver;
        public string _path;
        public string Sheet;
        public string userNameSender;
        public string userNameReceiver;
        private string browserType;

        [TestFixtureSetUp]
        public void SetUp()
        {
            try
            {
                _path = ConfigurationManager.AppSettings.Get("excelFileName");
                Sheet = ConfigurationManager.AppSettings.Get("excelSheetName");
                userNameSender = ConfigurationManager.AppSettings.Get("userNameSender");
                userNameReceiver = ConfigurationManager.AppSettings.Get("userNameReceiver");
                browserType = ConfigurationManager.AppSettings.Get("browserType");

                switch (browserType)
                {
                    case "Chrome":
                        Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), new ChromeOptions(), TimeSpan.FromMinutes(7));
                        break;
                    case "Firefox":
                        Driver = new FirefoxDriver();
                        break;
                    case "IE":
                        Driver = new InternetExplorerDriver();
                        break;
                    default:
                        break;
                }


                Driver.Manage().Window.Maximize();
                Reporter.AddReporter(new ConsoleReporterHelper());
                Reporter.AddHelperExtension(new SeleniumScreenshotMaker(Driver));
                Reporter.SetProperty(ReporterHelperProperties.WorkingDirectory, Path.Combine(Utilities.GetProjectDirectory(), ".reports"));
                Reporter.InitTestReporting();
            }
            catch (Exception)
            {

            }

            
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            if (Utilities.RunWithoutAddin)
            {
                Reporter.FinishTestReporting();
            }

            if (Driver != null)
            {
                Driver.CloseDriver();
                Driver = null;
            }
        }
    }
}
