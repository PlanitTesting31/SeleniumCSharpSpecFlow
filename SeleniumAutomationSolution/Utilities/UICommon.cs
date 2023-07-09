using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Utilities
{
    public static class UICommon
    {
        static int waitsec = Properties.Settings.Default.WaitTime;

        public static IWebElement GetElement(By searchType, IWebDriver d)
        {

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement elem = wait.Until(ExpectedConditions.ElementIsVisible(searchType));
            ElementHighlight(elem, d);
            return elem;
            
        }

        public static bool ObjectNotExists(By searchType, IWebDriver d)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until((driver) => { return d.FindElements(searchType).Count == 0; });
            return true;
        }

        public static bool ObjectExists(By searchType, IWebDriver d)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until((driver) => { return d.FindElements(searchType).Count > 0; });
            return true;
        }


        public static void ClickButton(By searchType, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            MoveToElement(elem,d);
            new Actions(d).MoveToElement(elem).Click().Perform();
            
        }

        public static void SetValue(this By searchType, string value, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            elem.Clear();
            elem.SendKeys(value);

        }

        public static void ElementHighlight(IWebElement element, IWebDriver d)
        {
            var jsDriver = (IJavaScriptExecutor)d;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }

        public static IWebElement MoveToElement(this IWebElement element, IWebDriver d)
        {
            var jsDriver = (IJavaScriptExecutor)d;
            string scrollToElement = @"$(arguments[0].scrollIntoView(true))";
            jsDriver.ExecuteScript(scrollToElement, new object[] { element });
            return element;
        }

        public static void  VerticalScrollBar(IWebDriver d)
        {
            ((IJavaScriptExecutor)d).ExecuteScript("window.scrollBy(0,70)");

        }

        //Waits
        public static IWebElement WaitUntilDisplayed(this By element, IWebDriver d)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
           return wait.Until(ExpectedConditions.ElementIsVisible(element));
        }

    }
}
