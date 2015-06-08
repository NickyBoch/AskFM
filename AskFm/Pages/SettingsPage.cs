using AskFm.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using NUnitReporter.Reporting;

namespace AskFm.Pages
{
    internal class SettingsPage : BasePage
    {
        private By _settingsMenu = By.Id("main_menu_settings");
        private By _languageComboBox = By.Id("user_language_id");
        private By _submitChanges = By.Id("user_submit");
        private By _profileUpdated = By.Id("profile_updated");
        private static string _currentLang = "";

        internal void OpenPage()
        {
            Click("OpenPage to settings page", _settingsMenu);
        }

        internal void WaitForLanguageComboBox()
        {
            Reporter.Log("Wait for language combobox load");
            WaitForElementPresent(_languageComboBox);
        }

        internal void SelectLanguage(string languageVar1,string languageVar2)
        {
            Reporter.Log("Select language: " + languageVar1 + " or " + languageVar2);
            var element = Driver.FindElement(_languageComboBox);
            SelectElement clickThis = new SelectElement(element);
            IWebElement elem = clickThis.SelectedOption;
            string text = elem.Text;
            _currentLang = (text == "English") ? languageVar1 : languageVar2;
            clickThis.SelectByText(_currentLang);
        }

        internal void WaitForMenuLoad()
        {
            Reporter.Log("Wait for menu load");
            WaitForElementPresent(_settingsMenu);
        }

        internal void SubmitChanges()
        {
            Click("Click save changes", _submitChanges);
        }

        internal void WaitForSettingSave()
        {
            Reporter.Log("Wait for profile updated");
            WaitForElementVisible(TimeoutSeconds, _profileUpdated);
            IWebElement element = Driver.FindElement(_profileUpdated);
            string pattern = "";
            if (_currentLang == "English")
            {
                pattern = "Your profile has been updated";
            }
            else if (_currentLang == "Русский")
            {
                pattern = "Ваш профиль был обновлен";
            }
            StringAssert.Contains(pattern, element.Text);
        }

    }
}
