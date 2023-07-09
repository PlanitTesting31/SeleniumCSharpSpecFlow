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
    public class DragAndDropPage : BasePage
    {

        IWebDriver d;
        public DragAndDropPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        By Draggable = By.CssSelector("[id='draggable']");
        By Droppable = By.CssSelector("[id='droppable']");

        public void PerformDragAndDrop()
        {
            IWebElement dragMe = UICommon.GetElement(Draggable, d);
            IWebElement dropHere = UICommon.GetElement(Droppable, d);
            Actions action = new Actions(d);
            Thread.Sleep(3000);
            action.DragAndDrop(dragMe, dropHere).Perform();
        }

        public string GetDroppableText()
        {
            IWebElement droppableText = UICommon.GetElement(Droppable, d);
            string dropText = droppableText.Text;
            return dropText;
        }
    }
}
