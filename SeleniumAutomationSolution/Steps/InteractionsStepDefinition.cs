using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.Interactions;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public sealed class InteractionsStepDefinition
    {
        HomePage homePage;
        SortListPage sortListPage;
        DragAndDropPage dragAndDropPage;

        public InteractionsStepDefinition(Global global)
        {
            homePage = new HomePage(global.driver);
            sortListPage = new SortListPage(global.driver);
            dragAndDropPage = new DragAndDropPage(global.driver);
        }

        [When(@"I sort the list content")]
        public void WhenIClickListInFromTheTable()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Interactions", "Sortable");
            sortListPage.SortTheList();
        }

        [Then(@"list is sorted in descending order")]
        public void ThenListIsSortedInDescendingOrder()
        {
            List<string> beforeSortText = sortListPage.GetBeforeSortList();
            beforeSortText.Reverse();
            IList<string> afterSortText = sortListPage.GetAfterSortList();
            for (int i = 0; i < afterSortText.Count; i++)
            {
                Console.WriteLine("Comparing " + beforeSortText[i] + "=>" + afterSortText[i]);
                Assert.AreEqual(beforeSortText[i], afterSortText[i]);
            }

        }

        //Drag and drop
        [When(@"I drag the text box and drop on 'Drop here' text box")]
        public void WhenIDoSimpleDragAndDropIn()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Interactions", "Droppable");
            dragAndDropPage.DragAndDropTextBox();

        }

        [Then(@"dropped message is populated")]
        public void ThenDroppedMessageIsPopulated()
        {
            Assert.AreEqual("Dropped!", dragAndDropPage.GetDroppableText());
        }



    }
}
