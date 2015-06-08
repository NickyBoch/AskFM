using AskFm.Base;
using OpenQA.Selenium;
using NUnitReporter.Reporting;

namespace AskFm.Pages
{
    internal class FriendsPage : BasePage
    {
        private By _friendsMenuItem = By.Id("main_menu_friends");
        private By _friendChoose = By.XPath("//div[@id='wrapper']/div/div[3]/div/div[2]/a/span");

        internal void OpenPage()
        {
            Click("Open Friends page", _friendsMenuItem);
        }

        internal void ChooseFriend()
        {
            Click("Choose Friend", _friendChoose);
        }

        internal void WaitForMenuLoad()
        {
            Reporter.Log("Wait for menu load");
            WaitForElementPresent(_friendsMenuItem);
        }

    }
}
