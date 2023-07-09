using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver d;
        public int waitsec = Properties.Settings.Default.WaitTime;
        public dynamic sharedScenarioBuffer;

        public BasePage(IWebDriver driver)
        {
            this.d = driver;
            d.SwitchTo().DefaultContent();
            d.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(waitsec));
        }
       

    }
}
