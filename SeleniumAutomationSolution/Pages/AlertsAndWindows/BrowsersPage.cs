using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumAutomationSolution.Pages.AlertsAndWindows
{
    public class BrowsersPage : BasePage
    {

        public BrowsersPage(IWebDriver driver)
            : base(driver)
        {
        }

        private By Button(string buttonName) => By.XPath("//button[text()='" + buttonName + "']");
        private readonly By SampleHeadingText = By.CssSelector("[id='sampleHeading']");

        public void ClickNewButton(string buttonValue)
        {
            IWebElement newTabButton = UICommon.GetElement(Button(buttonValue), d);
            Button(buttonValue).WaitUntilDisplayed(d);
            newTabButton.Click();
        }

        public string GetTextFromNewTab()
        {
            string parentzwindow = d.CurrentWindowHandle;
            string newTabHandle = d.WindowHandles.Last();
            var newTab = d.SwitchTo().Window(newTabHandle);
            var elem = newTab.FindElement(SampleHeadingText);
            SampleHeadingText.WaitUntilDisplayed(d);
            string sampleHeadingMessage = elem.Text;
            d.SwitchTo().Window(parentzwindow);
            return sampleHeadingMessage;
        }

        public string GetMessageFromNewWindow()
        {
            string parentWindow = d.CurrentWindowHandle;
            IList<string> allWindowHandles = d.WindowHandles;
            foreach (string WindowHandle in allWindowHandles)
            {
                Console.WriteLine(WindowHandle);
                if (!WindowHandle.Equals(parentWindow))
                {
                    d.SwitchTo().Window(WindowHandle);
                    break;
                }
            }

            string text = ((IJavaScriptExecutor)d).ExecuteScript("return document.body.textContent").ToString();
            d.SwitchTo().Window(parentWindow);
            return text;
        }
    }
}
