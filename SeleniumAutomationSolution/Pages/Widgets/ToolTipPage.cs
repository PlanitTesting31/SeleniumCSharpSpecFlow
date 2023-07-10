using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Pages.Widgets
{
    public class ToolTipPage : BasePage
    {

        IWebDriver d;
        public ToolTipPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        By ToolTipText = By.CssSelector("div [class='tooltip-inner']");//div[text()='You hovered over the Contrary']
        By ToolTip(string toolTipValue) => By.XPath("//a[text()='"+toolTipValue+"']");

        public void MouseHoverTheToolTipInfo(string toolTipText)
        {
            IWebElement tooTip = UICommon.GetElement(ToolTip(toolTipText), d);
            Thread.Sleep(2000);
            new Actions(d).MoveToElement(tooTip).Perform();
        }

        public string GetToolTipText()
        {
            IWebElement toolTipText = UICommon.GetElement(ToolTipText, d);
            string toolTipInfo = toolTipText.Text;
            return toolTipInfo;
        }
    }
}
