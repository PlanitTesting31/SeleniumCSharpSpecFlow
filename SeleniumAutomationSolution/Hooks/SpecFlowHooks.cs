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
    public sealed class SpecFlowHooks :BaseTest
    {
      //  protected static IWebDriver driver;
       // protected TestEnvironment environment;

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
                    driver = new FirefoxDriver();
                    break;
                case BrowserType.IE:
                    driver = new InternetExplorerDriver(options);
                    break;
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");
            }

            driver.Navigate().GoToUrl(TestEnvironment.GetEnvironment().Url);
            driver.Manage().Window.Maximize();

        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
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
