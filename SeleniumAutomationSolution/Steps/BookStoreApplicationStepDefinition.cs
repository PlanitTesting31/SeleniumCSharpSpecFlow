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
    public sealed class BookStoreApplicationStepDefinition
    {

        Global global;
        HomePage homePage;
        BookStoreApplicationLoginPage bookStoreApplicationLoginPage;

        public BookStoreApplicationStepDefinition(Global global)
        {
            this.global = global;
            homePage=new HomePage(global.driver);
            bookStoreApplicationLoginPage = new BookStoreApplicationLoginPage(global.driver);
        }

        [When(@"I login into the book store application")]
        public void WhenIWithDetailsFromTheTable()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Book Store Application", "Login");
            bookStoreApplicationLoginPage.SetUserName(System.Environment.GetEnvironmentVariable("BookStore_UserName"));
            bookStoreApplicationLoginPage.SetUserPassword(System.Environment.GetEnvironmentVariable("BookStore_Password"));
            bookStoreApplicationLoginPage.ClickUserLoginButton();

        }

        [Then(@"user login is successfull")]
        public void ThenUserLoginIsSuccessful()
        {
            Assert.AreEqual(System.Environment.GetEnvironmentVariable("BookStore_UserName"), bookStoreApplicationLoginPage.GetUserValueAfterLogin());
            bookStoreApplicationLoginPage.ClickLogout();

        }

    }
}
