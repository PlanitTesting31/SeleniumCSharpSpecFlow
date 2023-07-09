using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.BookStoreApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public sealed class BookStoreApplicationStepDefinition : BaseTest
    {
        HomePage homePage = new HomePage(driver);
        BookStoreApplicationLoginPage bookStoreApplicationLoginPage = new BookStoreApplicationLoginPage(driver);

        [When(@"I  ""(.*)"" with details from the table:")]
        public void WhenIWithDetailsFromTheTable(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            bookStoreApplicationLoginPage.SetUserName(table.Rows.First()["UserName"]);
            bookStoreApplicationLoginPage.SetUserPassword(table.Rows.First()["Password"]);
            bookStoreApplicationLoginPage.ClickUserLoginButton();

        }

        [Then(@"user login is successful with details from the table:")]
        public void ThenUserLoginIsSuccessful(Table table)
        {
            Assert.AreEqual(table.Rows.First()["UserName"], bookStoreApplicationLoginPage.GetUserValueAfterLogin());
            bookStoreApplicationLoginPage.ClickLogout();

        }

    }
}
