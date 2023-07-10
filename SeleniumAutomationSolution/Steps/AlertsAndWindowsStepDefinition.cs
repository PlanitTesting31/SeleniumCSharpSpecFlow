using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.AlertsAndWindows;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public class AlertsAndWindowsStepDefinition
    {

        Global global;

        public AlertsAndWindowsStepDefinition(Global global)
        {
            this.global = global;
        }


        [When(@"I click following buttons in Browser Windows page")]
        public void WhenIClickButtonsInFromTheTable(Table table)
        {
            new HomePage(global.driver).ExpandMenuAndClickItem("Alerts, Frame & Windows", "Browser Windows");
            new BrowsersPage(global.driver).ClickNewButton(table.Rows.First()["ButtonName"]);
        }

        [Then(@"sample heading text is populated in new tab")]
        public void ThenSampleHeadingTextIsPopulated()
        {
            Assert.AreEqual("This is a sample page", new BrowsersPage(global.driver).GetTextFromNewTab());
        }


        [When(@"I click button in ""(.*)"" from the table:")]
        public void WhenIClickButtonInFromTheTable(string subMenu, Table table)
        {
            new HomePage(global.driver).ExpandMenuAndClickItem("Alerts, Frame & Windows", subMenu);
            new BrowsersPage(global.driver).ClickNewButton(table.Rows.First()["Button"]);
        }

        [Then(@"sample heading message is populated in new window")]
        public void ThenSampleHeadingMessageIsPopulated()
        {
            string message = new BrowsersPage(global.driver).GetMessageFromNewWindow();
            Console.WriteLine(message);
        }

        [When(@"I click following buttons in Alerts page")]
        public void WhenIClickAndClickButtonFromTheTable(Table table)
        {
            HomePage homePage = new HomePage(global.driver);
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Alerts, Frame & Windows", "Alerts");
            new AlertsPage(global.driver).ClickPromptButtonAndSendText(table.Rows.First()["ButtonName"]);

        }

        [Then(@"alert message is populated")]
        public void ThenCloseTheAlertSucessfully()
        {
            Assert.AreEqual("You entered Prompt Button", new AlertsPage(global.driver).GetPromptResult());

        }
    }
}
