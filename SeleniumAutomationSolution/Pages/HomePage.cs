using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Pages
{
    class HomePage: BasePage
    {
         private readonly IWebDriver d;

        public HomePage(IWebDriver driver)
            : base(driver)
        {
             this.d = driver;
        }

        //Selectors
         By Section(string text) => By.XPath($"//h5[text()='" + text + "']");

        By ElementsMenu(string text) => By.XPath($"//div[@class='header-text' and text()='" + text + "']");
        By ElementsSubMenu(string subMenu) => By.XPath("//span[@class='text' and text()='" + subMenu + "']");




        //Common function for all title card navigations
        public void ClickOnSectionWith(string title)
        {
            IWebElement ele = UICommon.GetElement(Section(title),d);
            UICommon.MoveToElement(ele,d);
            UICommon.WaitUntilDisplayed(Section(title),d);
            new Actions(d).MoveToElement(ele).Click().Perform();
        }

        public void ExpandMenuAndClickItem(string menu, string tiltle)
        {
            IWebElement HeaderMenu = ElementsMenu(menu).WaitUntilDisplayed(d);
            IWebElement SubMenuItem = d.FindElement(ElementsSubMenu(tiltle));
            if (!SubMenuItem.Displayed)
            {
                HeaderMenu.Click();
            }
            Thread.Sleep(5000);
            new Actions(d).MoveToElement(SubMenuItem).Click().Perform();
            //ElementsSubMenu(tiltle).WaitUntilDisplayed(d).Click();
            ((IJavaScriptExecutor)d).ExecuteScript("arguments[0].click();", SubMenuItem);
            
        }

        public void ScrollBar()
        {
            UICommon.VerticalScrollBar(d);
        }


    }
}
