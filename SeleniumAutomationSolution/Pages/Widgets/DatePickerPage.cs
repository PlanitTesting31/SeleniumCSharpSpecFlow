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

namespace SeleniumAutomationSolution.Pages.Widgets
{
    public class DatePickerPage : BasePage
    {
        IWebDriver d;
        public DatePickerPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        By DatePickerMonthYearInput = By.CssSelector("[id='datePickerMonthYearInput']");
        By DatePicker_MonthSelect = By.CssSelector("Select[class='react-datepicker__month-select']");
        By DatePicker_YearSelect = By.CssSelector("Select[class='react-datepicker__year-select']");
        By DatePicker_DateSelect = By.XPath("//div[@class='react-datepicker__month']//child::div[@role='option']");

        By DateAndTimePickerInput = By.CssSelector("[id='dateAndTimePickerInput']");
        By DateAndTimePickerMonthView = By.CssSelector("[class='react-datepicker__month-read-view']");
        By DateAndTimePickerYearView = By.CssSelector("[class='react-datepicker__year-read-view']");
        By DatePicker_MonthDropDown = By.CssSelector("[class='react-datepicker__month-dropdown'] div");
        By DatePicker_YearDropDown = By.CssSelector("[class='react-datepicker__year-dropdown'] div");
        By DatePicker_Time = By.CssSelector("[class='react-datepicker__time-container '] li");

        public void SelectDate(Table table)
        {
            IWebElement datePickerMonthYearInput = UICommon.GetElement(DatePickerMonthYearInput, d);
            datePickerMonthYearInput.Click();

            //Select Month
            IWebElement datePicker_MonthSelect = UICommon.GetElement(DatePicker_MonthSelect, d);
            datePicker_MonthSelect.Click();
            SelectElement dropDown = new SelectElement(datePicker_MonthSelect);
            dropDown.SelectByText(table.Rows.First()["Month"]);

            //Select Year
            IWebElement datePicker_YearSelect = UICommon.GetElement(DatePicker_YearSelect, d);
            datePicker_YearSelect.Click();
            SelectElement dropDownYear = new SelectElement(datePicker_YearSelect);
            dropDownYear.SelectByText(table.Rows.First()["Year"]);

            //SelectDate
            //IWebElement datePicker_DateSelect = UICommon.GetElement(DatePicker_DateSelect, d);
            IList<IWebElement> dates = new List<IWebElement> (d.FindElements(DatePicker_DateSelect));

            foreach(IWebElement ele in dates)
            {
                string date = ele.Text;
                if(date.Equals(table.Rows.First()["Date"]))
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

        public void SelectDateAndTime(Table table)
        {
            IWebElement dateAndTimePickerInput = UICommon.GetElement(DateAndTimePickerInput, d);
            dateAndTimePickerInput.Click();

            //Select Month
            IWebElement dateAndTimePicker_MonthView = UICommon.GetElement(DateAndTimePickerMonthView, d);
            Thread.Sleep(2000);
            dateAndTimePicker_MonthView.Click();
            Thread.Sleep(2000);

           // IWebElement dateAndTimePicker_MonthDropDown = UICommon.GetElement(DatePicker_MonthDropDown, d);
            //dateAndTimePicker_MonthDropDown.Click();
            IList<IWebElement> months = new List<IWebElement>(d.FindElements(DatePicker_MonthDropDown));
           
            foreach (IWebElement ele in months)
            {
                string month = ele.Text;
                if (month.Equals(table.Rows.First()["Month"]))
                {
                    // ele.Click();
                    UICommon.MoveToElement(ele, d);
                    new Actions(d).MoveToElement(ele).Click().Perform();
                    break;
                }
            }

            //Select Year
            IWebElement dateAndTimePickerYearView = UICommon.GetElement(DateAndTimePickerYearView,d);
            dateAndTimePickerYearView.Click();

           // IWebElement dateAndTimePicker_YearDropDown = UICommon.GetElement(DatePicker_YearDropDown, d);
           // dateAndTimePicker_YearDropDown.Click();
            IList<IWebElement> years = new List<IWebElement>(d.FindElements(DatePicker_YearDropDown));

            foreach (IWebElement ele in years)
            {
                string year = ele.Text;
                if (year.Equals(table.Rows.First()["Year"]))
                {
                    ele.Click();
                    break;
                }
            }

            //SelectDate
            //IWebElement datePicker_DateSelect = UICommon.GetElement(DatePicker_DateSelect, d);
            IList<IWebElement> dates = new List<IWebElement>(d.FindElements(DatePicker_DateSelect));

            foreach (IWebElement ele in dates)
            {
                string date = ele.Text;
                if (date.Equals(table.Rows.First()["Date"]))
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
                if (time.Equals(table.Rows.First()["Time"]))
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
