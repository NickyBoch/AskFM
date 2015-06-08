using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AskFm.Base;
using AskFm.Controls;
using AskFm.GeneralActionsNS;
using AskFm.Utils;
using NUnit.Framework;
using System.Configuration;

namespace AskFm.Tests
{
    class SendMessagesTest : BaseTest
    {
        private readonly GeneralActions _generalActions = new GeneralActions();
        //
        //private string _path;// = @"..\..\Data\Credentials.xlsx";
        //private string Sheet;//= "CredentialChrome";
        //private string UserDataToSearch1;// = "User1-6";
        //
        private const string Message = "Hello World!";
        #region

#if true
        [Test, Description("2nd test - 1st user send new message to 2nd user")]
        public void TestMethod2()
        {
            string startupPath = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(startupPath, _path);
            UserData user = ReadDataFromExcel.GetUserData(path, Sheet, userNameSender);
            //if (user == null) return;
            Login(user.Login, user.Password);
            //Login("Pyato4kin", "VerySecretPassword");
            PageControl.FriendsPage.WaitForMenuLoad();
            _generalActions.ChooseFriend();
            Random rand = new Random();
            int count = rand.Next(2, 8);
            _generalActions.SendMessage(Message, count);
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
