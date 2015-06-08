using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AskFm.Pages;

namespace AskFm.Controls
{
    internal class PageControl
    {
        private static LoginPage loginPage;
        private static FriendsPage _friendsPage;
        private static MainPage _mainPage;
        private static SettingsPage _settingsPage;
        private static IncomingMessagesPage _incomingMessagesPage;

        public static LoginPage LoginPage
        {
            get { return loginPage ?? new LoginPage(); }
        }

        public static FriendsPage FriendsPage
        {
            get { return _friendsPage ?? new FriendsPage(); }
        }

        public static MainPage MainPage
        {
            get { return _mainPage ?? new MainPage(); }
        }

        public static SettingsPage SettingsPage
        {
            get { return _settingsPage ?? new SettingsPage(); }
        }

        public static IncomingMessagesPage IncomingMessagesPage
        {
            get { return _incomingMessagesPage ?? new IncomingMessagesPage(); }
        }

    }
}
