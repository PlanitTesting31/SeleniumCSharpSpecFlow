using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public sealed class InteractionsStepDefinition : BaseTest
    {
        HomePage homePage = new HomePage(driver);
        SortListPage sortListPage = new SortListPage(driver);
        DragAndDropPage dragAndDropPage = new DragAndDropPage(driver);


        [When(@"I click list in ""(.*)"" from the table:")]
        public void WhenIClickListInFromTheTable(string subMenu)
        {

            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            sortListPage.SortTheList();
        }

        [Then(@"list is sorted in descending order")]
        public void ThenListIsSortedInDescendingOrder()
        {
           IList<string> beforeSortText = sortListPage.GetBeforeSortList();
            foreach (string e in beforeSortText)
            {
                Console.WriteLine(string.Join(",", e));
                //Console.WriteLine(e);
            }
            IList<string> afterSortText = sortListPage.GetAfterSortList();
            foreach (string e in afterSortText)
            {
                 Console.WriteLine(string.Join(",", e));
               // Console.WriteLine(e);
            }
            Assert.AreNotEqual(beforeSortText,afterSortText);
        }

        //Drag and drop
        [When(@"I do simple drag and drop in ""(.*)""")]
        public void WhenIDoSimpleDragAndDropIn(string subMenu)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            dragAndDropPage.PerformDragAndDrop();

        }

        [Then(@"dropped message is populated")]
        public void ThenDroppedMessageIsPopulated()
        {
            Assert.AreEqual("Dropped!",dragAndDropPage.GetDroppableText());
        }



    }
}
