using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using AskFm.Base;
using AskFm.Controls;
using AskFm.GeneralActionsNS;
using AskFm.Utils;
using NUnit.Framework;

namespace AskFm.Tests
{
    internal class DeleteMessageTest : BaseTest
    {
        private readonly GeneralActions _generalActions = new GeneralActions();
        //
        //private string _path;// = @"..\..\Data\Credentials.xlsx";
        //private string Sheet;// = "CredentialChrome";
        //private string userNameSender;// = "User1-1";
        //        
        private static int _currentMessageNotifyCount = 0;
        private static int _allMessageDivsCount = 0;
        private static int _allMessageMenuCount = 0;
        private static int _messageDivsCountBeforeDelete = 0;
        private static int _messageDivsCountAfterDelete = 0;

        #region

#if true
        [Test, Description("3st test - Delete message test")]
        public void TestMethod3()
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(startupPath, _path);
            UserData user = ReadDataFromExcel.GetUserData(_path, Sheet, userNameReceiver);
            //if (user == null) return;
            Login(user.Login, user.Password);
            //Login("Inokenti4", "VerySecretPassword");
            _currentMessageNotifyCount = PageControl.MainPage.GetIncomingMessagesNotifyCount();
            _generalActions.OpenAllQuestion();
            _messageDivsCountBeforeDelete = _generalActions.GetAllMessageCount();
            //PageControl.MainPage.ScrollBy(0, -4000);
            _generalActions.DeleteQuestionAt(5);
            _generalActions.OpenAllQuestion();
            _allMessageMenuCount = PageControl.MainPage.GetIncomingMessagesMenuCount();
            _allMessageDivsCount = _generalActions.GetAllMessageCount();
            _messageDivsCountAfterDelete = _allMessageDivsCount;
            Assert.AreEqual(_messageDivsCountBeforeDelete, _messageDivsCountAfterDelete + 1);
            Assert.AreEqual(_allMessageMenuCount, _allMessageDivsCount);
            //Assert.Greater(_currentMessageNotifyCount, _lastMessageNotifyCount);
            //Assert.True(false, "Test false");
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
