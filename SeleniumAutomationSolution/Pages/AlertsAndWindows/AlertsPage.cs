using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;

namespace SeleniumAutomationSolution.Pages.AlertsAndWindows
{
    public class AlertsPage : BasePage
    {
        public AlertsPage(IWebDriver driver)
            : base(driver)
        {
        }

        readonly By PromptButton = By.CssSelector("[id='promtButton']");
        readonly By PromptResult = By.CssSelector("[id='promptResult']");

        public void ClickPromptButtonAndSendText(string name)
        {
            IWebElement promptButton = UICommon.GetElement(PromptButton, d);
            ((IJavaScriptExecutor)d).ExecuteScript("arguments[0].click()", promptButton);
            IAlert alert = d.SwitchTo().Alert();
            alert.SendKeys(name);
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
