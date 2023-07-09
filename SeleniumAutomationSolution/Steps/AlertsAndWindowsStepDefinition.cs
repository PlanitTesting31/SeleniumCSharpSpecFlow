using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.AlertsAndWindows;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public sealed class AlertsAndWindowsStepDefinition : BaseTest
    {

        HomePage homePage = new HomePage(driver);
        BrowsersPage browserPage = new BrowsersPage(driver);
        AlertsPage alertsPage = new AlertsPage(driver);
        
        [When(@"I click buttons in ""(.*)"" from the table:")]
        public void WhenIClickButtonsInFromTheTable(string subMenu, Table table)
        {
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            browserPage.ClickNewButton(table.Rows.First()["Button"]);
        }

        [Then(@"sample heading text is populated")]
        public void ThenSampleHeadingTextIsPopulated()
        {
            Assert.AreEqual("This is a sample page", browserPage.GetTextFromNewTab());
        }


        [When(@"I click button in ""(.*)"" from the table:")]
        public void WhenIClickButtonInFromTheTable(string subMenu, Table table)
        {
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            browserPage.ClickNewButton(table.Rows.First()["Button"]);
        }

        [Then(@"sample heading message is populated")]
        public void ThenSampleHeadingMessageIsPopulated()
        {
            string message = browserPage.GetMessageFromNewWindow();
            Console.WriteLine(message);
        }


        //Alerts

        [When(@"I click prompt button in ""(.*)"" and enter text from the table:")]
        public void WhenIClickAndClickButtonFromTheTable(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            alertsPage.ClickPromptButtonAndSendText(table.Rows.First()["Name"]);

        }

        [Then(@"alert message is populated")]
        public void ThenCloseTheAlertSucessfully()
        {
            Assert.AreEqual("You entered Prompt Button" , alertsPage.GetPromptResult());
            
        }




    }
}
