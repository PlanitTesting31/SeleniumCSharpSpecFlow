using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;

namespace SeleniumAutomationSolution.Pages
{
    class HomePage : BasePage
    {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
            : base(driver)
        {
            this.driver = driver;
        }

        //Selectors
        private By Section(string text) => By.XPath($"//h5[text()='" + text + "']");
        private By ElementsMenu(string text) => By.XPath($"//div[@class='header-text' and text()='" + text + "']");
        private By ElementsSubMenu(string subMenu) => By.XPath("//span[@class='text' and text()='" + subMenu + "']");


        //Common function for all title card navigations
        public void ClickOnSectionWith(string title)
        {
            IWebElement ele = UICommon.GetElement(Section(title), driver);
            UICommon.MoveToElement(ele, driver);
            UICommon.WaitUntilDisplayed(Section(title), driver);
            new Actions(driver).MoveToElement(ele).Click().Perform();
        }

        public void ExpandMenuAndClickItem(string menu, string tiltle)
        {
            IWebElement HeaderMenu = ElementsMenu(menu).WaitUntilDisplayed(driver);
            IWebElement SubMenuItem = driver.FindElement(ElementsSubMenu(tiltle));
            if (!SubMenuItem.Displayed)
            {
                HeaderMenu.Click();
            }
            new Actions(driver).MoveToElement(SubMenuItem).Click().Perform();
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", SubMenuItem);

        }

        public void ScrollToBottom()
        {
            UICommon.ScrollToBottom(driver);
        }
    }
}
