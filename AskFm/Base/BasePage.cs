using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using AskFm.Utils;
using NUnitReporter.Reporting;

namespace AskFm.Base
{
    internal class BasePage
    {
        public const int TimeoutSeconds = 60;
        public const int NormalTimeoutSeconds = 30;
        public const int SmallTimeoutSeconds = 15;
        public const int ExtrasmallTimeoutSeconds = 5;
        public const int MicroTimeoutSeconds = 2;

        private RemoteWebDriver _driver;

        public RemoteWebDriver Driver
        {
            get { return _driver ?? (_driver = BaseTest.Driver); }
        }

        protected void WaitForElementPresent(By element)
        {
            WaitForElementPresent(TimeoutSeconds,element);
        }

        protected void WaitForElementPresent(int timeout, By element)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
            WebDriverWait wait=new WebDriverWait(Driver,TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(element));
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TimeoutSeconds));
        }

        protected void WaitForElementVisible(int timeout, By element)
        {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeout));
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementIsVisible(element));
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(TimeoutSeconds));
        }

        protected void Type(string message, string value, By element)
        {
            Reporter.Log(message);
            IWebElement input = GetElement(element);
            input.Clear();
            if (!String.IsNullOrEmpty(value))
            {
                input.SendKeys(value);
            }
        }

        protected void TypeWithoutClean(string message, string value, By element)
        {
            GetElement(element).SendKeys(value);
        }

        protected IWebElement GetElement(By element)
        {
            return Driver.FindElement(element);
        }

        protected void Click(string message, By locator)
        {
            Reporter.Log(message);
            var element = Driver.FindElement(locator);
            element.Click();
        }

        protected void SetElementAttributeWithJS(string logMessage, string attributeName, string attributeValue,IWebElement element)
        {
            Reporter.Log(logMessage);
            Driver.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", element, attributeName,
                attributeValue);
        }

        protected void MouseOverWithJS(string logMessage, IWebElement webElement)
        {
            Reporter.Log(logMessage);
            const string javaScript = @"if(document.createEvent)
                                        {
                                            var evObj = document.createEvent('MouseEvents');
                                            evObj.initEvent('mouseover', true, false);
                                            arguments[0].dispatchEvent(evObj);
                                        } 
                                        else if(document.createEventObject)
                                        {
                                            arguments[0].fireEvent('onmouseover');
                                        }";
            Driver.ExecuteScript(javaScript, webElement);
        }

        protected void MouseOutWithJS(string logMessage, IWebElement webElement)
        {
            Reporter.Log(logMessage);
            const string javaScript = @"if(document.createEvent)
                                        {
                                            var evObj = document.createEvent('MouseEvents');
                                            evObj.initEvent('mouseout', true, false);
                                            arguments[0].dispatchEvent(evObj);
                                        } 
                                        else if(document.createEventObject)
                                        {
                                            arguments[0].fireEvent('onmouseout');
                                        }";
            Driver.ExecuteScript(javaScript, webElement);
        }

        protected void ClickWithJS(string logMessage, IWebElement webElement)
        {
            Reporter.Log(logMessage);
            Driver.ExecuteScript("arguments[0].click();", webElement);
        }

        protected void MouseScrollWithJS(string logMessage, int x, int y)
        {
            string javaScript = @"window.scrollBy(" + x + "," + y + ");";
            Driver.ExecuteScript(javaScript);
        }

        protected void TypeWithJS(string logMessage, string typeMessage, IWebElement webElement)
        {
            Reporter.Log(logMessage);
            string javaScript = @"var textEvent = document.createEvent('TextEvent');
                                  textEvent.initTextEvent ('textInput', true, true, null, '" + typeMessage +
                                @"', 9, 'en-US');
                                arguments[0].dispatchEvent(textEvent);";
            Driver.ExecuteScript(javaScript, webElement);
        }
    }
}
