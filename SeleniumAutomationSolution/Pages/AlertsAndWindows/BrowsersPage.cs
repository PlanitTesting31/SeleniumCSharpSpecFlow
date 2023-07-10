using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Pages.AlertsAndWindows
{
    public class BrowsersPage : BasePage
    {
        public BrowsersPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;
        }

        By Button (string buttonName) => By.XPath("//button[text()='"+buttonName+"']");
        By NewTabButton = By.CssSelector("button[id='tabButton']");
        By NewWindowButton = By.CssSelector("button[id='windowButton']");
        By NewWindowMessageButton = By.CssSelector("button[id='messageWindowButton']");
        By SampleHeadingText = By.CssSelector("[id='sampleHeading']");
        By WindowMessage = By.XPath("//body");

        public void ClickNewButton(string buttonValue)
        {
            IWebElement newTabButton = UICommon.GetElement(Button(buttonValue), d);
            newTabButton.Click();
        }

        public string GetTextFromNewTab()
        {
            string parentzwindow = d.CurrentWindowHandle;
            string newTabHandle = d.WindowHandles.Last();
            var newTab = d.SwitchTo().Window(newTabHandle);
            var elem = newTab.FindElement(SampleHeadingText);
            Thread.Sleep(3000);
            string sampleHeadingMessage = elem.Text;
            d.SwitchTo().Window(parentzwindow);
            return sampleHeadingMessage;
        }

        public string GetMessageFromNewWindow()
        {
            string parentzwindow = d.CurrentWindowHandle;
            IList<string> allWindowHandles = d.WindowHandles;
            foreach (string WindowHandle in allWindowHandles)
            {
                Console.WriteLine(WindowHandle);
                if (!WindowHandle.Equals(parentzwindow))
                {
                    d.SwitchTo().Window(WindowHandle);
                    break;
                }
            }
            
            Thread.Sleep(5000);
            string text = ((IJavaScriptExecutor)d).ExecuteScript("return document.body.textContent").ToString();
            d.SwitchTo().Window(parentzwindow);
            return text;
        }
    }
}
