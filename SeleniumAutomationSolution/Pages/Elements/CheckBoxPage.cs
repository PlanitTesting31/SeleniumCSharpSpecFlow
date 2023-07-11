using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;

namespace SeleniumAutomationSolution.Pages.Elements
{
    public class CheckBoxPage : BasePage
    {

        public CheckBoxPage(IWebDriver driver)
            : base(driver)
        {
        }

        //Selectors
        private By CheckBox_Expand(string title) => By.XPath("//span[text()='" + title + "']/ancestor::span//button");
        private By CheckBox(string title) => By.XPath("//span[text()='" + title + "']/parent::label//span[@class='rct-checkbox']");
        readonly By OutputText = By.XPath("//div[@id='result']");


        public void ExpandMenu(string name)
        {
            IWebElement elem = UICommon.GetElement(CheckBox_Expand(name), d);
            elem.Click();
        }

        //Common function to click any check box under home check box
        public void ClickOnCheckBox(string subTitle)
        {
            IWebElement ele = UICommon.GetElement(CheckBox(subTitle), d);
            new Actions(d).MoveToElement(ele).Click().Perform();
        }

        public string[] GetSelectedCheckBoxText()
        {
            var output = UICommon.WaitUntilDisplayed(OutputText, d).Text.Split('\n');
            return output;
        }
    }
}
