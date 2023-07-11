using OpenQA.Selenium;

namespace SeleniumAutomationSolution
{
    public class Global
    {
        public IWebDriver driver;
        public dynamic sharedScenarioBuffer = new System.Dynamic.ExpandoObject();
    }
}
