using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System.Collections.Generic;

namespace SeleniumAutomationSolution.Pages.Interactions
{
    public class SortListPage : BasePage
    {

        public SortListPage(IWebDriver driver)
            : base(driver)
        {
        }

        readonly By targetItem = By.CssSelector(".vertical-list-container .list-group-item");
        private By sourceItem(string number) => By.XPath("//div[contains(@class,'vertical-list-container')]//div[contains(@class,'list-group-item') and (text()='" + number + "')]");
        private By BeforeSortList = By.CssSelector(".vertical-list-container .list-group-item");

        //Get Text Before sorting
        readonly List<string> beforeSortText = new List<string>();
        IList<IWebElement> beforeSortList;


        public void SortTheList()
        {
            targetItem.WaitUntilDisplayed(d);
            beforeSortList = d.FindElements(BeforeSortList);
            foreach (IWebElement e in beforeSortList)
            {
                string text = e.Text;
                beforeSortText.Add(text);
            }

            UICommon.ScrollToBottom(d);
            for (int i = 1; i < beforeSortText.Count; i++)
            {
                IWebElement source = UICommon.GetElement(sourceItem(beforeSortText[i]), d);
                IWebElement target = UICommon.GetElement(targetItem, d);
                Actions action = new Actions(d);
                action.DragAndDrop(source, target).Perform();
            }
        }


        public List<string> GetBeforeSortList()
        {
            return beforeSortText;
        }

        public IList<string> GetAfterSortList()
        {
            IList<string> afterSortText = new List<string>();
            IList<IWebElement> afterSortList = d.FindElements(BeforeSortList);
            foreach (IWebElement e in afterSortList)
            {
                string text = e.Text;
                afterSortText.Add(text);

            }
            return afterSortText;

        }
    }
}
