using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Pages.Widgets
{
    public class AutoCompleteTextBoxPage : BasePage
    {
        public AutoCompleteTextBoxPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        By AutoCompleteMultipleInput = By.CssSelector("[id='autoCompleteMultipleInput']");
        By AutoCompleteSingleInput = By.CssSelector("[id='autoCompleteSingleInput']");
        By AutoCompleteMultipleResult = By.XPath("//div[@id='autoCompleteMultiple']//child::div[contains(@class,'auto-complete__value-container')]");
        By AutoCompleteSingleResult = By.XPath("//div[@id='autoCompleteSingle']//child::div[contains(@class,'auto-complete__value-container')]");
        
        public void SetAutoCompleteMultipleTextBox(string colorName)
        {
            //This Scroll is required to set text box in view
            UICommon.VerticalScrollBar(d);
            IWebElement autoCompleteMultipleBox = UICommon.GetElement(AutoCompleteMultipleInput, d);
            
                autoCompleteMultipleBox.SendKeys(colorName);
                Thread.Sleep(1000);
                IList<IWebElement> optionsToSelect = d.FindElements(By.XPath("//div[text()='" + colorName + "']"));
                Thread.Sleep(4000);
            foreach (IWebElement option in optionsToSelect)
            {
                Console.WriteLine(option);
                if (option.Text.Equals(colorName))
                {
                    Console.WriteLine("Trying to select: " + colorName);
                    option.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }    
                   
        }
        public void SetAutoCompleteSingleTextBox(string colorName)
        {
            Thread.Sleep(2000);
            IWebElement autoCompleteSingleBox = UICommon.GetElement(AutoCompleteSingleInput, d);
            autoCompleteSingleBox.SendKeys(colorName);
            autoCompleteSingleBox.SendKeys(Keys.Enter);
        }

        public string[] GetAutoCompleteMultipleTextBoxResult()
        {
            IWebElement autoCompleteMultipleTextBoxResult = UICommon.GetElement(AutoCompleteMultipleResult, d);
            string result = autoCompleteMultipleTextBoxResult.Text;
            string[] mutipleResult = result.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            return mutipleResult;
        }

        public string GetAutoCompleteSingleTextBoxResult()
        {
            IWebElement autoCompleteSingleTextBoxResult = UICommon.GetElement(AutoCompleteSingleResult, d);
            string result = autoCompleteSingleTextBoxResult.Text;
            return result;
        }
    }
}
