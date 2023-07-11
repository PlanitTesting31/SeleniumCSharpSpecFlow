using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;

namespace SeleniumAutomationSolution.Pages.Interactions
{
    public class DragAndDropPage : BasePage
    {
        public DragAndDropPage(IWebDriver driver)
            : base(driver)
        {
        }

        readonly By Draggable = By.CssSelector("[id='draggable']");
        readonly By Droppable = By.CssSelector("[id='droppable']");

        public void DragAndDropTextBox()
        {
            IWebElement dragMe = UICommon.GetElement(Draggable, d);
            IWebElement dropHere = UICommon.GetElement(Droppable, d);
            Actions action = new Actions(d);
            action.DragAndDrop(dragMe, dropHere).Perform();
        }

        public string GetDroppableText()
        {
            IWebElement droppableText = UICommon.GetElement(Droppable, d);
            Droppable.WaitUntilDisplayed(d);
            string dropText = droppableText.Text;
            return dropText;
        }
    }
}
