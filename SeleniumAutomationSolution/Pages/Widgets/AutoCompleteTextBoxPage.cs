using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;

namespace SeleniumAutomationSolution.Pages.Widgets
{
    public class AutoCompleteTextBoxPage : BasePage
    {
        public AutoCompleteTextBoxPage(IWebDriver driver)
            : base(driver)
        {
        }

        readonly By AutoCompleteMultipleInput = By.CssSelector("[id='autoCompleteMultipleInput']");
        readonly By AutoCompleteSingleInput = By.CssSelector("[id='autoCompleteSingleInput']");
        readonly By AutoCompleteMultipleResult = By.XPath("//div[@id='autoCompleteMultiple']//child::div[contains(@class,'auto-complete__value-container')]");
        readonly By AutoCompleteSingleResult = By.XPath("//div[@id='autoCompleteSingle']//child::div[contains(@class,'auto-complete__value-container')]");

        public void SetAutoCompleteMultiColourTextBox(string colorName)
        {
            //This Scroll is required to set text box in view
            UICommon.ScrollToBottom(d);
            IWebElement autoCompleteMultipleBox = UICommon.GetElement(AutoCompleteMultipleInput, d);

            autoCompleteMultipleBox.SendKeys(colorName);
            autoCompleteMultipleBox.SendKeys(Keys.Enter);
            IList<IWebElement> optionsToSelect = d.FindElements(By.XPath("//div[text()='" + colorName + "']"));
            foreach (IWebElement option in optionsToSelect)
            {
                Console.WriteLine(option);
                if (option.Text.Equals(colorName))
                {
                    Console.WriteLine("Trying to select: " + colorName);
                    option.Click();
                    break;
                }
            }

        }
        public void SetAutoCompleteSingleTextBox(string colorName)
        {
            IWebElement autoCompleteSingleBox = UICommon.GetElement(AutoCompleteSingleInput, d);
            autoCompleteSingleBox.SendKeys(colorName);
            autoCompleteSingleBox.SendKeys(Keys.Enter);
        }

        public string[] GetAutoCompleteMultipleTextBoxResult()
        {
            IWebElement autoCompleteMultipleTextBoxResult = UICommon.GetElement(AutoCompleteMultipleResult, d);
            AutoCompleteMultipleResult.WaitUntilDisplayed(d);
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
