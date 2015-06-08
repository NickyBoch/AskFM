using AskFm.Pages;
using NUnitReporter.Reporting;

namespace AskFm.GeneralActionsNS
{
    class GeneralActions
    {
        private readonly LoginPage _loginPage;
        private readonly FriendsPage _friendsPage;
        private readonly SendMessagePage _sendMessagePage;
        private readonly SettingsPage _settingsPage;
        private readonly IncomingMessagesPage _inboxPage;

        public GeneralActions()
        {
            _loginPage = new LoginPage();
            _friendsPage = new FriendsPage();
            _sendMessagePage = new SendMessagePage();
            _settingsPage = new SettingsPage();
            _inboxPage = new IncomingMessagesPage();
        }

        internal void Login(string login, string pass)
        {
            Reporter.Log(MessageTypes.ActionTitle,"Login AskFm");
            _loginPage.WaitForLoginButton();
            _loginPage.LoginClick();
            _loginPage.TypeLogin(login);
            _loginPage.TypePassword(pass);
            _loginPage.SubminLogin();
        }

        internal void Logout()
        {
            Reporter.Log(MessageTypes.ActionTitle, "Logout AskFm");
            _loginPage.WaitForLogoutButton();
            _loginPage.LogOut();
        }

        internal void ChooseFriend()
        {
            Reporter.Log(MessageTypes.ActionTitle, "Choose Friend");
            _friendsPage.OpenPage();
            _friendsPage.ChooseFriend();
        }

        internal void SendMessage(string message,int count)
        {
            Reporter.Log(MessageTypes.ActionTitle, "Send " + count + " messages ");
            for (int i = 0; i < count; i++)
            {
                _sendMessagePage.WaitForMessageBox();
                _sendMessagePage.TypeMessage(message + " " + i);
                _sendMessagePage.SubmitMessage();
                _sendMessagePage.WaitForMessageSend();
                _sendMessagePage.WaitForMoreMessageSendButton();
                _sendMessagePage.SubmitSendMoreMessagesButton();
            }   
        }

        internal void ChangeLanguage(string languageVar1, string languageVar2)
        {
            Reporter.Log(MessageTypes.ActionTitle, "Change language to" + languageVar1 + " or " + languageVar2);
            _settingsPage.WaitForLanguageComboBox();
            _settingsPage.SelectLanguage(languageVar1, languageVar2);
            _settingsPage.SubmitChanges();
            _settingsPage.WaitForSettingSave();
        }


        internal void OpenAllQuestion()
        {
            Reporter.Log(MessageTypes.ActionTitle, "Open all question divs");
            _inboxPage.OpenPage();
            _inboxPage.ShowMoreQuestions();
        }

        internal void DeleteQuestionAt(int index)
        {
            Reporter.Log(MessageTypes.ActionTitle, "Delete question at: " + index);
            _inboxPage.MoveMouseOverDeleteButton(index);
            _inboxPage.RemoveQuestionAt(index);
        }

        internal int GetAllMessageCount()
        {
            Reporter.Log(MessageTypes.ActionTitle, "GetAllMessageCount");
            return _inboxPage.GetDailyQuestionsCount() + _inboxPage.GetSponsoredQuestionsCount() +
                   _inboxPage.GetQuestionsCount();
        }

    }
}