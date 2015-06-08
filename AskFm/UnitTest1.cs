using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Collections;
using OpenQA.Selenium.Support.UI;

namespace AskFm
{
  
    public class UnitTest1
    {
//        private int timeout = 10;
//        static private RemoteWebDriver driver;
//        private int lastCheckMessageCount = 0;
//        private int currentCheckMessageCount = 0;

//        [Test]
//        public void TestMethod1()
//        {
//#if false
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            //Login
//            driver.Navigate().GoToUrl("http://ask.fm/");
//            driver.FindElement(By.ClassName("link-login")).Click();
//            driver.FindElement(By.Id("login")).SendKeys("Inokenti4");
//            driver.FindElement(By.Id("password")).SendKeys("VerySecretPassword");
//            driver.FindElement(By.Id("logBox_submit-button")).Click();
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//#endif
//            string str = driver.FindElement(By.Id("notification-q-digit")).Text;
//            Int32.TryParse(str, out lastCheckMessageCount);

//            Console.WriteLine(String.Format("Current messages count: {0}", lastCheckMessageCount));

//            //Logout
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.ClassName("link-logout")).Click();
//        }

//        [Test]
//        public void TestMethod2()
//        {
//#if false
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            //Login
//            driver.Navigate().GoToUrl("http://ask.fm/");
//            driver.FindElement(By.ClassName("link-login")).Click();
//            driver.FindElement(By.Id("login")).SendKeys("Pyato4kin");
//            driver.FindElement(By.Id("password")).SendKeys("VerySecretPassword");
//            driver.FindElement(By.Id("logBox_submit-button")).Click();
//#endif

//            //Open friends
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.Id("main_menu_friends")).Click();
//            driver.FindElement(By.XPath("//div[@id='wrapper']/div/div[3]/div/div[2]/a/span")).Click();
//            //Ask
//            driver.FindElement(By.Id("profile-input")).SendKeys("Hello there with logout!!!");
//            driver.FindElement(By.Id("question_submit")).Click();
//            //Logout
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.ClassName("link-logout")).Click();
//        }

//        [Test]
//        public void TestMethod3()
//        {
//            //Login
//            driver.Navigate().GoToUrl("http://ask.fm/");
//            driver.FindElement(By.ClassName("link-login")).Click();
//            driver.FindElement(By.Id("login")).SendKeys("Inokenti4");
//            driver.FindElement(By.Id("password")).SendKeys("VerySecretPassword");
//            driver.FindElement(By.Id("logBox_submit-button")).Click();
//            //
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            string str = driver.FindElement(By.Id("notification-q-digit")).Text;
//            Int32.TryParse(str, out currentCheckMessageCount);
//            //
//            if (lastCheckMessageCount < currentCheckMessageCount)
//            {
//                Console.WriteLine("New Message!!!");
//                Console.WriteLine(String.Format("Current messages count: {0}", currentCheckMessageCount));
//                lastCheckMessageCount = 0;
//                currentCheckMessageCount = 0;
//            }

//            //Logout
//            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
//            driver.FindElement(By.ClassName("link-logout")).Click();
        }


#if false
        [TestFixtureSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
#endif


#if false
        [TestFixtureTearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
#endif

    }
}
