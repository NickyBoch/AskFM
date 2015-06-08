using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AskFm.Base;
using AskFm.Utils;
using NUnitReporter.Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions.Internal;
using OpenQA.Selenium.Interactions;

namespace AskFm.Pages
{
    internal class IncomingMessagesPage : BasePage
    {
        private string xpathForDeleteFirstPart = "//div[contains(@id,'_question_')][";
        private string xpathForDeleteSecondPart = "]//a[contains(@class,'delete hintable')]";
        //private static By _questionBox= By.XPath("//div[contains(@class,'questionBox')]");
        private static By _questionDivs = By.XPath("//div[contains(@id,'inbox_question')]");
        private static By _sponsoredQuestionDivs = By.XPath("//div[contains(@class,'questionBox-sponsored')]");
        private static By _dailydQuestionDivs = By.XPath("//div[contains(@class,'questionBox-daily')]");
        private static By _showMoreButton = By.XPath("//input[contains(@class,'submit-button-more submit-button-active')]");
        private static By _inboxMenuItem = By.Id("main_menu_inbox");


        internal void OpenPage()
        {
            Click("Open Inbox page", _inboxMenuItem);
        }

        internal int GetDailyQuestionsCount()
        {
            Reporter.Log("Find daily question");
            int count = Driver.FindElements(_dailydQuestionDivs).Count;
            Reporter.Log("Number of daily question: " + count);
            return count;
        }

        internal int GetSponsoredQuestionsCount()
        {
            Reporter.Log("Find sponsored question");
            int count = Driver.FindElements(_sponsoredQuestionDivs).Count;
            Reporter.Log("Number of sponsored question: " + count);
            return count;
        }

        internal int GetQuestionsCount()
        {
            Reporter.Log("Find questions");
            int count = Driver.FindElements(_questionDivs).Count;
            Reporter.Log("Number of question: " + count);
            return count;
        }

        internal void ShowMoreQuestions()
        {
            var element = Driver.FindElement(_showMoreButton);
            while (element.Displayed && element.Size.Height != 0 && element.Size.Width != 0)
            {
                Click("Show more questions", _showMoreButton);
                element = Driver.FindElement(_showMoreButton);
            }
        }

        internal void RemoveQuestionAt(int index)
        {
            Reporter.Log("Remove question at: " + index);
            var elements = Driver.FindElement(By.XPath(xpathForDeleteFirstPart + index + xpathForDeleteSecondPart));
            ClickWithJS("Click delete message button", elements);
        }

        internal void MoveMouseOverDeleteButton(int index)
        {
            var elements = Driver.FindElement(By.XPath(xpathForDeleteFirstPart + index + xpathForDeleteSecondPart));
            MouseOverWithJS("Move mouse over element", elements);
            //MouseOutWithJS("Move mouse out element", elements);
        }
    }
}
