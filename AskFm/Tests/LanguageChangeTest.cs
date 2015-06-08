using AskFm.GeneralActionsNS;
using AskFm.Base;
using NUnit.Framework;
using System;
using System.Configuration;
using System.IO;
using AskFm.Controls;
using AskFm.Utils;

namespace AskFm.Tests
{
    public class LanguageChangeTest : BaseTest
    {
        private readonly GeneralActions _generalActions = new GeneralActions();
        //
        //private string _path;// = @"..\..\Data\Credentials.xlsx";
        //private string Sheet;// = "CredentialChrome";
        //private string userNameSender;// = "User1-1";
        //private const string UserDataToSearch1 = "User1-6";
        //
        private const string Message = "Hello World!";
        private static int _lastMessageNotifyCount = 0;
        private const string EnglishLang = "English";
        private const string RussianLang = "Русский";

        #region 

#if true
        [Test, Description("1st test - Change Language test")]
        public void TestMethod1()
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(startupPath, _path);
            UserData user = ReadDataFromExcel.GetUserData(path, Sheet, userNameReceiver);
            //if (user == null) return;
            Login(user.Login, user.Password);
            //Login("Inokenti4", "VerySecretPassword");
            PageControl.SettingsPage.OpenPage();
            PageControl.SettingsPage.WaitForMenuLoad();
            _generalActions.ChangeLanguage(RussianLang, EnglishLang);
            _lastMessageNotifyCount = PageControl.MainPage.GetIncomingMessagesNotifyCount();
            _generalActions.Logout();
        }
#endif

        #endregion

        private void Login(string login, string pass)
        {
            PageControl.LoginPage.Open();
            _generalActions.Login(login, pass);
            PageControl.MainPage.WaitForMenuLoad();
        }
    }
}
