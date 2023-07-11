using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System;

namespace SeleniumAutomationSolution.Pages.Elements
{
    public class WebTablePage : BasePage
    {
        public WebTablePage(IWebDriver driver)
            : base(driver)
        {
        }

        //Selectors
        readonly By SearchBox = By.CssSelector("[id='searchBox']");
        readonly By EditIcon = By.CssSelector("[title='Edit']");
        readonly By SubmitButton = By.CssSelector("[id='submit']");
        readonly By TableRow = By.CssSelector("[class='rt-tr -odd']");
        private By UserFormFields(string value) => By.XPath("//input[@id='" + value + "']");
        

        public void SetSearchBoxValue(string userName)
        {
            IWebElement SearchTextBox = UICommon.GetElement(SearchBox, d);
            SearchTextBox.SendKeys(userName);
            SearchTextBox.SendKeys(Keys.Control + Keys.Enter);
        }

        public void ClickEditAction()
        {
            IWebElement EditButton = UICommon.GetElement(EditIcon, d);
            EditButton.Click();
        }

        public void SetUserFormValue(string userFormtitle, string age)
        {

            IWebElement userFormField = UICommon.GetElement(UserFormFields(userFormtitle), d);
            userFormField.Clear();
            userFormField.SendKeys(age.ToString()); ;
        }

        public void ClickSubmitButton()
        {
            IWebElement submit = UICommon.GetElement(SubmitButton, d);
            UICommon.MoveToElement(submit, d);
            UICommon.WaitUntilDisplayed(SubmitButton, d);
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
