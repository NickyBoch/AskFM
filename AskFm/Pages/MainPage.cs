using AskFm.Base;
using OpenQA.Selenium;
using System;
using NUnitReporter.Reporting;

namespace AskFm.Pages
{
    internal class MainPage : BasePage
    {
        private By _notificationCount = By.Id("notification-q-digit");
        private By _menuMessagesCount = By.Id("inbox_menu_counter");

        internal int GetIncomingMessagesNotifyCount()
        {
            int returnVal;
            Reporter.Log("Get number of new messages");
            var element = Driver.FindElement(_notificationCount);           
            Int32.TryParse(element.Text,out returnVal);
            return returnVal;
        }

        internal void WaitForMenuLoad()
        {
            Reporter.Log("Wait for menu load");
            WaitForElementPresent(_notificationCount);
        }

        internal int GetIncomingMessagesMenuCount()
        {
            int returnVal;
            Reporter.Log("Get number of all messages from menu");
            var element = Driver.FindElement(_menuMessagesCount);
            Int32.TryParse(element.Text, out returnVal);
            return returnVal;
        }

        internal void ScrollBy(int x, int y)
        {
            MouseScrollWithJS("Try to scroll", x, y);
        }
    }
}
