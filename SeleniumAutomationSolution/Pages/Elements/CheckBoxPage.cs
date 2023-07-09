using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Pages.Elements
{
    class CheckBoxPage : BasePage
    {

        IWebDriver d;
        public CheckBoxPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        //Selectors
        By ElementsMenu(string text) => By.XPath($"//div[@class='header-text' and text()='" + text + "']");
        By ElementsSubMenu(string subMenu) => By.XPath("//span[@class='text' and text()='" + subMenu + "']");
        By CheckBox_Home(string title) => By.XPath("//span[text()='"+title+"']/ancestor::span//button");
        By CheckBox(string title) => By.XPath("//span[text()='" + title + "']/parent::label//span[@class='rct-checkbox']");
        By Output = By.XPath("//div[@id='result']");


       
        public void ExpandHomeCheckBox()
        {
            IWebElement elem = UICommon.GetElement(CheckBox_Home("Home"), d);
            elem.Click();
        }

        //Common function to click any check box under home check box
        public void ClickOnCheckBox(string title, string subTitle = null)
        {
            IWebElement ele = UICommon.GetElement(CheckBox(title), d);
            UICommon.MoveToElement(ele, d);
            UICommon.WaitUntilDisplayed(CheckBox(title), d);
            if (subTitle != null)
            {
                IWebElement e1 = UICommon.GetElement(CheckBox(title), d);
                UICommon.MoveToElement(ele, d);
                UICommon.WaitUntilDisplayed(CheckBox(title), d);
                Thread.Sleep(5000);
                new Actions(d).MoveToElement(e1).Click().Perform();
                //e1.Click();
            }
            else 
            {
                Thread.Sleep(5000);
                new Actions(d).MoveToElement(ele).Click().Perform();
            }
                
        }
        
        public string GetSelectedCheckBoxText()
        {
            var output = UICommon.WaitUntilDisplayed(Output, d).Text.Split('\n')[2];
            return output.Trim();
        }
    }
}
