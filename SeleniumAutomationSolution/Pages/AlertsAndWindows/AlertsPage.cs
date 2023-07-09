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
    public class AlertsPage : BasePage
    {
        public AlertsPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;
        }

        By PromptButton = By.CssSelector("[id='promtButton']");
        By PromptResult = By.CssSelector("[id='promptResult']");


        public void ClickPromptButtonAndSendText(string name)
        {
            IWebElement promptButton = UICommon.GetElement(PromptButton, d);
            // promptButton.Click();
            ((IJavaScriptExecutor)d).ExecuteScript("arguments[0].click()", promptButton);
            Thread.Sleep(1000);
            IAlert alert = d.SwitchTo().Alert();           
             alert.SendKeys(name);
            Thread.Sleep(1000);
             alert.Accept();
        }

        public string GetPromptResult()
        {
            IWebElement promptResult = UICommon.GetElement(PromptResult, d);
            string promptText = promptResult.Text;
            return promptText;

        }
    }
}
