using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Pages.Interactions
{
    public class SortListPage : BasePage
    {
        IWebDriver d;
        public SortListPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        By NumberList = By.CssSelector("[id='demo-tabpane-list']");
        By BeforeSortList = By.XPath("//*[@id='demo-tabpane-list']");

        //Get Text Before sorting
        IList<string> beforeSortText = new List<string>();
        IList<IWebElement> beforeSortList;
        
       
        public void SortTheList()
        {
            beforeSortList = d.FindElements(BeforeSortList);
            foreach (IWebElement e in beforeSortList)
            {
                string text = e.Text;
                beforeSortText.Add(text);
            }
          
            //Sorting List by dragging
            IList<IWebElement> list = d.FindElements(By.XPath("//* [@id='demo-tabpane-list']/div/div"));
            UICommon.VerticalScrollBar(d);
            Thread.Sleep(1000);
            for (int i = 1; i < list.Count; i++)
            {

                IWebElement element = d.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div[" + i + "]"));

                IWebElement destination6 = d.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div[6]"));
                IWebElement destination5 = d.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div[5]"));
                IWebElement destination4 = d.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div[4]"));
                IWebElement destination3 = d.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div[3]"));
                IWebElement destination2 = d.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div[2]"));
                IWebElement destination1 = d.FindElement(By.XPath("//*[@id='demo-tabpane-list']/div/div[1]"));

                Actions action = new Actions(d);

                if (element != null)
                {
                    action.DragAndDrop(element, destination6).Perform();
                    action.DragAndDrop(element, destination5).Perform();
                    action.DragAndDrop(element, destination4).Perform();
                    action.DragAndDrop(element, destination3).Perform();
                    action.DragAndDrop(element, destination2).Perform();
                    action.DragAndDrop(element, destination1).Perform();
                    break;
                }
            }
            
            Thread.Sleep(5000);
        }

       public IList<string> GetBeforeSortList()
        {
            Thread.Sleep(2000);
            return beforeSortText;
        }

        public IList<string> GetAfterSortList()
        {
            IList<string> afterSortText = new List<string>();
            IList<IWebElement> afterSortList = d.FindElements(BeforeSortList);
            Thread.Sleep(3000);
            foreach (IWebElement e in afterSortList)
            {
                string text = e.Text;
                afterSortText.Add(text);

            }
            return afterSortText;

        }
    }
}
