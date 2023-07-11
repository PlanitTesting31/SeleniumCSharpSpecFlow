using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationSolution.Utilities;
using System.Collections.Generic;

namespace SeleniumAutomationSolution.Pages.Widgets
{
    public class DatePickerPage : BasePage
    {
        public DatePickerPage(IWebDriver driver)
            : base(driver)
        {
        }

        readonly By DatePickerMonthYearInput = By.CssSelector("[id='datePickerMonthYearInput']");
        readonly By DatePicker_MonthSelect = By.CssSelector("Select[class='react-datepicker__month-select']");
        readonly By DatePicker_YearSelect = By.CssSelector("Select[class='react-datepicker__year-select']");
        readonly By DatePicker_DateSelect = By.XPath("//div[@class='react-datepicker__month']//child::div[@role='option']");
        readonly By DateAndTimePickerInput = By.CssSelector("[id='dateAndTimePickerInput']");
        readonly By DateAndTimePickerMonthView = By.CssSelector("[class='react-datepicker__month-read-view']");
        readonly By DateAndTimePickerYearView = By.CssSelector("[class='react-datepicker__year-read-view']");
        readonly By DatePicker_MonthDropDown = By.CssSelector("[class='react-datepicker__month-dropdown'] div");
        readonly By DatePicker_YearDropDown = By.CssSelector("[class='react-datepicker__year-dropdown'] div");
        readonly By DatePicker_Time = By.CssSelector("[class='react-datepicker__time-container '] li");

        public void SelectDate(string currentDate, string currentMonth, string currentYear)
        {
            IWebElement datePickerMonthYearInput = UICommon.GetElement(DatePickerMonthYearInput, d);
            datePickerMonthYearInput.Click();

            //Select Month
            IWebElement datePicker_MonthSelect = UICommon.GetElement(DatePicker_MonthSelect, d);
            datePicker_MonthSelect.Click();
            SelectElement dropDown = new SelectElement(datePicker_MonthSelect);
            dropDown.SelectByText(currentMonth);

            //Select Year
            IWebElement datePicker_YearSelect = UICommon.GetElement(DatePicker_YearSelect, d);
            datePicker_YearSelect.Click();
            SelectElement dropDownYear = new SelectElement(datePicker_YearSelect);
            dropDownYear.SelectByText(currentYear);

            //SelectDate
            //IWebElement datePicker_DateSelect = UICommon.GetElement(DatePicker_DateSelect, d);
            IList<IWebElement> dates = new List<IWebElement>(d.FindElements(DatePicker_DateSelect));

            foreach (IWebElement ele in dates)
            {
                string date = ele.Text;
                if (date.Equals(currentDate))
                {
                    ele.Click();
                    break;
                }
            }

        }
        public string GetSelectedDate()
        {
            IWebElement datePickerMonthYearOutput = UICommon.GetElement(DatePickerMonthYearInput, d);
            string selectedDate = datePickerMonthYearOutput.GetAttribute("value");
            return selectedDate;
        }

        public void SelectDateAndTime(string currentDate, string currentMonth, string currentYear, string currentTime)
        {
            IWebElement dateAndTimePickerInput = UICommon.GetElement(DateAndTimePickerInput, d);
            dateAndTimePickerInput.Click();

            //Select Month
            IWebElement dateAndTimePicker_MonthView = UICommon.GetElement(DateAndTimePickerMonthView, d);
            dateAndTimePicker_MonthView.Click();


            IList<IWebElement> months = new List<IWebElement>(d.FindElements(DatePicker_MonthDropDown));

            foreach (IWebElement ele in months)
            {
                string month = ele.Text;
                if (month.Equals(currentMonth))
                {
                    UICommon.MoveToElement(ele, d);
                    new Actions(d).MoveToElement(ele).Click().Perform();
                    break;
                }
            }

            //Select Year
            IWebElement dateAndTimePickerYearView = UICommon.GetElement(DateAndTimePickerYearView, d);
            dateAndTimePickerYearView.Click();

            IList<IWebElement> years = new List<IWebElement>(d.FindElements(DatePicker_YearDropDown));

            foreach (IWebElement ele in years)
            {
                string year = ele.Text;
                if (year.Equals(currentYear))
                {
                    ele.Click();
                    break;
                }
            }

            //SelectDate
            IList<IWebElement> dates = new List<IWebElement>(d.FindElements(DatePicker_DateSelect));

            foreach (IWebElement ele in dates)
            {
                string date = ele.Text;
                if (date.Equals(currentDate))
                {
                    ele.Click();
                    break;
                }
            }


            //Select Time
            IList<IWebElement> timeList = new List<IWebElement>(d.FindElements(DatePicker_Time));
            foreach (IWebElement ele in timeList)
            {
                string time = ele.Text;
                if (time.Equals(currentTime))
                {
                    ele.Click();
                    break;
                }
            }

        }
        public string GetSelectedDateAndTime()
        {
            IWebElement dateAndTimePickerOutput = UICommon.GetElement(DateAndTimePickerInput, d);
            string selectedDate = dateAndTimePickerOutput.GetAttribute("value");
            return selectedDate;
        }
    }
}
