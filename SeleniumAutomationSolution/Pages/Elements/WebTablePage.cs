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
    public class WebTablePage : BasePage
    {

        IWebDriver d;
        public WebTablePage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        //Selectors
        By SearchBox = By.CssSelector("[id='searchBox']");
        By Edit = By.CssSelector("[title='Edit']");
        By UserFormFields(string value) => By.XPath("//input[@id='"+value+"']");
        By SubmitButton = By.CssSelector("[id='submit']");
        By TableRow = By.CssSelector("[class='rt-tr -odd']");

        public void SetSearchBoxValue(string userName)
        {
            IWebElement SearchTextBox = UICommon.GetElement(SearchBox, d);
            SearchTextBox.SendKeys(userName);
            Thread.Sleep(3000);
            SearchTextBox.SendKeys(Keys.Control + Keys.Enter);
        }

        public void ClickEditAction()
        {
            IWebElement EditButton = UICommon.GetElement(Edit, d);
            EditButton.Click();
        }

       public void SetUserFormValue(string userFormtitle, Table table)
        {
                    
            IWebElement userFormField = UICommon.GetElement(UserFormFields(userFormtitle), d);
            userFormField.Clear();
            userFormField.SendKeys(table.Rows.First()["Age"]);
        }

        public void ClickSubmitButton()
        {
            IWebElement submit = UICommon.GetElement(SubmitButton, d);
            UICommon.MoveToElement(submit, d);
            UICommon.WaitUntilDisplayed(SubmitButton, d);
            Thread.Sleep(5000);
            new Actions(d).MoveToElement(submit).Click().Perform();
        }

        public string GetValuefromTable()
        {
            IWebElement tableRow = UICommon.GetElement(TableRow, d);
            string value = tableRow.Text.Split('\n')[2];
            Console.WriteLine(value);
            return value.Trim();
        }


    }
}
