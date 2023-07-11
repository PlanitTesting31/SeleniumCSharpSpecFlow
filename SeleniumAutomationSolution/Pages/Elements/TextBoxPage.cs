using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;


namespace SeleniumAutomationSolution.Pages
{
    public class TextBoxPage : BasePage
    {
        public TextBoxPage(IWebDriver driver)
            : base(driver)
        {
        }

        //Selectors
        readonly By CurrentAddress = By.CssSelector("[id='currentAddress']");
        readonly By PermanentAddress = By.CssSelector("[id='permanentAddress']");
        readonly By Submit = By.CssSelector("[id='submit']");
        readonly By FullName = By.CssSelector("[id='userName']");
        readonly By Email = By.CssSelector("[id='userEmail']");
        readonly By TextBoxOutputName = By.CssSelector("p#name");
        readonly By TextBoxOutputEmail = By.CssSelector("p#email");
        readonly By TextBoxOutputCurrentAddress = By.CssSelector("p#currentAddress");
        readonly By TextBoxOutputPermanentAddress = By.CssSelector("p#permanentAddress");



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
            Submit.WaitUntilDisplayed(d);
            UICommon.ScrollToBottom(d);
            UICommon.MoveToElement(elem, d).Click();
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
