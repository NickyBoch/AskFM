using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AskFm.Tests;
using NUnit.Framework;

namespace AskFm.Suite
{
    internal class AskFMSuite
    {
        [Suite]
        public static ArrayList Suite
        {
            get
            {
                ArrayList suite = new ArrayList();
                suite.Add(new LanguageChangeTest());
                suite.Add(new SendMessagesTest());
                suite.Add(new DeleteMessageTest());
                return suite;
            }
        }
    }
}
