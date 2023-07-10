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
    public sealed class InteractionsStepDefinition
    {

        Global global;
        HomePage homePage;
        SortListPage sortListPage;
        DragAndDropPage dragAndDropPage;

        public InteractionsStepDefinition(Global global)
        {
            this.global = global;
            homePage = new HomePage(global.driver);
            sortListPage = new SortListPage(global.driver);
            dragAndDropPage = new DragAndDropPage(global.driver);
        }

        [When(@"I click list in Sortable")]
        public void WhenIClickListInFromTheTable()
        {

            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Interactions", "Sortable");
            sortListPage.SortTheList();
        }

        [Then(@"list is sorted in descending order")]
        public void ThenListIsSortedInDescendingOrder()
        {
           IList<string> beforeSortText = sortListPage.GetBeforeSortList();
            foreach (string e in beforeSortText)
            {
                Console.WriteLine(string.Join(",", e));
                
            }
            IList<string> afterSortText = sortListPage.GetAfterSortList();
            foreach (string e in afterSortText)
            {
                 Console.WriteLine(string.Join(",", e));
               
            }
            Assert.AreNotEqual(beforeSortText,afterSortText);
        }

        //Drag and drop
        [When(@"I do simple drag and drop in Droppable")]
        public void WhenIDoSimpleDragAndDropIn()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Interactions", "Droppable");
            dragAndDropPage.PerformDragAndDrop();

        }

        [Then(@"dropped message is populated")]
        public void ThenDroppedMessageIsPopulated()
        {
            Assert.AreEqual("Dropped!",dragAndDropPage.GetDroppableText());
        }



    }
}
