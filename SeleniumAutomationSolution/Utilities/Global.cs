using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using SeleniumAutomationSolution.Environment;
using System.Diagnostics;
using TechTalk.SpecFlow;



namespace SeleniumAutomationSolution
{
    public class Global
    {
        public IWebDriver driver;
        public dynamic sharedScenarioBuffer = new System.Dynamic.ExpandoObject();
        public string dynamicDate;
    }
}
