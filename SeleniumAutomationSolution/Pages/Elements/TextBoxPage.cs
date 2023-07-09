using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Pages
{
    class TextBoxPage : BasePage    {

        IWebDriver d;
        public TextBoxPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;
           
        }

        //Selectors
        By CurrentAddress = By.CssSelector("[id='currentAddress']");
        By PermanentAddress = By.CssSelector("[id='permanentAddress']");
        By Submit = By.CssSelector("[id='submit']");
        
        By FullName = By.CssSelector("[id='userName']");
        By Email = By.CssSelector("[id='userEmail']");
        By TextBoxOutputName = By.CssSelector("p#name");
        By TextBoxOutputEmail = By.CssSelector("p#email");
        By TextBoxOutputCurrentAddress = By.CssSelector("p#currentAddress");
        By TextBoxOutputPermanentAddress = By.CssSelector("p#permanentAddress");



      

        public void SetFullName(string fullName)
        {
            IWebElement ele = UICommon.GetElement(FullName, d);
            ele.SendKeys(fullName);
        }
        public void SetEmail(string email)
        {
            IWebElement ele = UICommon.GetElement(Email, d);
            ele.SendKeys(email);
        }

        public void SetCurrentAddress(string currentAddress)
        {
            IWebElement ele = UICommon.GetElement(CurrentAddress, d);
            ele.SendKeys(currentAddress);
        }

        public void SetPermanentAddress(string permanentAddress)
        {
            IWebElement ele = UICommon.GetElement(PermanentAddress, d);
            ele.SendKeys(permanentAddress);
        }

        public void ClickSubmitButton()
        {
            IWebElement elem = UICommon.GetElement(Submit, d);
            UICommon.MoveToElement(elem, d).Click();
        }

        public void ClickOnTextBoxSubMenu(string title)
        {
                       
            //IWebElement element= ElementsSubMenu(title).WaitUntilDisplayed(d);
           // new Actions(d).MoveToElement(element).Click().Perform();
            /* IWebElement ele = UICommon.GetElement(, d);
             UICommon.MoveToElement(ele, d);
             UICommon.WaitUntilDisplayed(ElementsSubMenu(title), d);
             */
        }

        public string GetFullName()
        {
            return TextBoxOutputName.WaitUntilDisplayed(d).Text;
        }

        public string GetEmail()
        {
            return UICommon.WaitUntilDisplayed(TextBoxOutputEmail, d).Text;
        }

        public string GetCurrentAddress()
        {
            return UICommon.WaitUntilDisplayed(TextBoxOutputCurrentAddress, d).Text;
        }

        public string GetPermanentAddress()
        {
            return UICommon.WaitUntilDisplayed(TextBoxOutputPermanentAddress, d).Text;
        }
    }
}
