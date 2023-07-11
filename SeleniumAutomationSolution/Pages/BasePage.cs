using OpenQA.Selenium;
using System;

namespace SeleniumAutomationSolution.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver d;
        public int waitsec = Properties.Settings.Default.WaitTime;

        public BasePage(IWebDriver driver)
        {
            this.d = driver;
            d.SwitchTo().DefaultContent();
            d.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(waitsec));
            d.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(waitsec));
        }
    }
}
