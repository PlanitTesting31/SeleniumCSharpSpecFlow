using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;

namespace SeleniumAutomationSolution.Pages.BookStoreApplication
{

    public class BookStoreApplicationLoginPage : BasePage
    {

        public BookStoreApplicationLoginPage(IWebDriver driver)
            : base(driver)
        {
        }

        readonly By UserName = By.CssSelector("[id='userName']");
        readonly By UserPassword = By.CssSelector("[id='password']");
        readonly By UserID = By.CssSelector("[id = 'userName-value']");
        readonly By Login = By.CssSelector("[id='login']");
        readonly By Logout = By.XPath("//button[text()='Log out']");

        public void ClickUserLoginButton()
        {
            IWebElement login = UICommon.GetElement(Login, d);
            login.Click();
        }
        public void SetUserName(string userId)
        {
            IWebElement userName = UICommon.GetElement(UserName, d);
            userName.SendKeys(userId);
        }

        public void SetUserPassword(string password)
        {
            IWebElement userPassword = UICommon.GetElement(UserPassword, d);
            userPassword.SendKeys(password);
        }

        public string GetUserValueAfterLogin()
        {
            IWebElement userValue = UICommon.GetElement(UserID, d);
            return userValue.Text;
        }

        public void ClickLogout()
        {
            IWebElement logout = UICommon.GetElement(Logout, d);
            logout.Click();
        }
    }
}
