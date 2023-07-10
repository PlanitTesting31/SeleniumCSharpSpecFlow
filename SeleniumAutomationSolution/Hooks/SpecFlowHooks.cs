using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumAutomationSolution.Environment;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Tests
{
    [Binding]
    public sealed class SpecFlowHooks
    {
        Global global;
      public SpecFlowHooks(Global global)
        {
            this.global = global;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };

            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.Firefox:
                    global.driver = new FirefoxDriver();
                    break;
                case BrowserType.IE:
                    global.driver = new InternetExplorerDriver(options);
                    break;
                case BrowserType.Chrome:
                    global.driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");
            }

            global.driver.Navigate().GoToUrl(TestEnvironment.GetEnvironment().Url);
            global.driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            global.driver.Quit();
            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.Firefox:
                    KillProcess("firefox.exe");
                    break;
                case BrowserType.IE:
                    KillProcess("iexplorer.exe");
                    break;
                case BrowserType.Chrome:
                    KillProcess("chrome.exe");
                    KillProcess("chromedriver.exe");
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");

            }
        }

        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }
    }
}
