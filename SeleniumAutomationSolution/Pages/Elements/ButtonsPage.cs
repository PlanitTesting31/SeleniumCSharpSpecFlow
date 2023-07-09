using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumAutomationSolution.Pages.Elements
{
    class ButtonsPage : BasePage
    {
        IWebDriver d;
        public ButtonsPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        //Selectors
        By Button(string buttonTitle) => By.XPath("//button[text()='" + buttonTitle + "']");
        By ButtonText(string buttonId) => By.XPath("//p[@id='"+ buttonId+"']");

        string buttonName = "";

        public void ClickButton(string buttonValue)
        {
            buttonName = buttonValue;
            IWebElement button = UICommon.GetElement(Button(buttonValue), d);
            switch (buttonValue)
            {
                case "Double Click Me":
                    new Actions(d).MoveToElement(button).DoubleClick().Perform();
                    break;
                case "Right Click Me":
                    new Actions(d).MoveToElement(button).ContextClick().Perform();
                    break;
                case "Click Me":
                    // new Actions(d).MoveToElement(button).Click().Perform();
                    button.Click();
                    break;
                default:
                    throw new Exception($"Button: {buttonValue} is not present");
            }
            Thread.Sleep(5000);
        }

        //Id locators are dynamic hence ID's are passed as parameters based on button selected
        public string GetButtonMessage()
        {
            switch (buttonName)
            {
                case "Double Click Me":
                    IWebElement buttonDoubleClick = UICommon.GetElement(ButtonText("doubleClickMessage"), d);
                    string doubleClickText = buttonDoubleClick.Text;
                    Console.WriteLine(doubleClickText);
                    return doubleClickText;
                case "Right Click Me":
                    IWebElement buttonRightClick = UICommon.GetElement(ButtonText("rightClickMessage"), d);
                    string rightClickText = buttonRightClick.Text;
                    Console.WriteLine(rightClickText);
                    return rightClickText;
                    
                case "Click Me":
                    IWebElement buttonClick = UICommon.GetElement(ButtonText("dynamicClickMessage"), d);
                    string clickText = buttonClick.Text;
                    Console.WriteLine(clickText);
                    return clickText;
                    
                default:
                    throw new Exception($"Button: {buttonName} is not present");
            }
                        
        }
    }
}
