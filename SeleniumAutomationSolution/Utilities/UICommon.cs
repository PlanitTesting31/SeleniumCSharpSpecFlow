using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAutomationSolution.Utilities
{
    public static class UICommon
    {
        static readonly int waitsec = Properties.Settings.Default.WaitTime;

        public static IWebElement GetElement(By searchType, IWebDriver d)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement elem = wait.Until(ExpectedConditions.ElementIsVisible(searchType));
            ElementHighlight(elem, d);
            return elem;
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

        public static void ScrollToBottom(IWebDriver d)
        {
            ((IJavaScriptExecutor)d).ExecuteScript("window.scrollBy(0,200)");

        }

        //Waits
        public static IWebElement WaitUntilDisplayed(this By element, IWebDriver d)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            return wait.Until(ExpectedConditions.ElementIsVisible(element));
        }
    }
}
