using OpenQA.Selenium;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Pages.BookStoreApplication
{
    public class BookStoreApplicationLoginPage : BasePage
    {
        IWebDriver d;
        public BookStoreApplicationLoginPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        By UserName = By.CssSelector("[id='userName']");
        By UserPassword = By.CssSelector("[id='password']");
        By UserValue = By.CssSelector("[id = 'userName-value']");
        By Login = By.CssSelector("[id='login']");
        By Logout = By.XPath("//button[text()='Log out']");

        public void ClickUserLoginButton()
        {
            IWebElement login= UICommon.GetElement(Login, d);
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
            IWebElement userValue = UICommon.GetElement(UserValue, d);
            return userValue.Text;
        }

        public void ClickLogout()
        {
            IWebElement logout = UICommon.GetElement(Logout, d);
            logout.Click();
        }
    }
}
