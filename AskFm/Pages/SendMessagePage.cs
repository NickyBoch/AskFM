using AskFm.Base;
using OpenQA.Selenium;
using NUnitReporter.Reporting;

namespace AskFm.Pages
{
    internal class SendMessagePage : BasePage
    {
        private By _enterMessage = By.Id("profile-input");
        private By _submitMessage = By.Id("question_submit");
        private By _messageSend = By.Id("reMotivation_box");
        private By _messageBox = By.Id("profile-input");
        private By _sendMoreMessage = By.ClassName("choiceAsk-logged");

        internal void TypeMessage(string message)
        {
            //Type("Type message: " + message, message, _enterMessage);
            IWebElement element = Driver.FindElement(_enterMessage);
            TypeWithJS("Type message: " + message, message, element);
        }

        internal void SubmitMessage()
        {
            Click("Submit message button click", _submitMessage);
        }

        internal void SubmitSendMoreMessagesButton()
        {
            Click("Click more message send button", _sendMoreMessage);
        }

        internal void WaitForMessageSend()
        {
            Reporter.Log("Wait for message send and resend button visible");
            WaitForElementVisible(TimeoutSeconds, _messageSend);
        }

        internal void WaitForMessageBox()
        {
            Reporter.Log("Wait for messagebox");
            WaitForElementPresent(_messageBox);
        }

        internal void WaitForMoreMessageSendButton()
        {
            Reporter.Log("Wait for more message send button");
            WaitForElementPresent(_sendMoreMessage);
        }
    }
}
