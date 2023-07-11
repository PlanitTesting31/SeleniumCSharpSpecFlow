using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;

namespace SeleniumAutomationSolution.Pages.Widgets
{
    public class ToolTipPage : BasePage
    {

        public ToolTipPage(IWebDriver driver)
            : base(driver)
        {
        }

        readonly By ToolTipText = By.CssSelector("div [class='tooltip-inner']");
        private By ToolTip(string toolTipValue) => By.XPath("//a[text()='" + toolTipValue + "']");

        public void MouseHoverTheToolTipInfo(string toolTipText)
        {
            IWebElement toolTip = UICommon.GetElement(ToolTip(toolTipText), d);
            ((IJavaScriptExecutor)d).ExecuteScript("arguments[0].scrollIntoView(true)",toolTip);
             new Actions(d).MoveToElement(toolTip).Perform();
        }

        public string GetToolTipText()
        {
            IWebElement toolTipText = UICommon.GetElement(ToolTipText, d);
            string toolTipInfo = toolTipText.Text;
            return toolTipInfo;
        }
    }
}