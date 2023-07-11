using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.Widgets;
using System;
using System.Globalization;
using System.Linq;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public class WidgetsStepDefinition
    {
        readonly HomePage homePage;
        readonly AutoCompleteTextBoxPage autoCompleteTextBoxPage;
        readonly DatePickerPage datePickerPage;
        readonly ToolTipPage toolTipPage;

        public WidgetsStepDefinition(Global global)
        {
            homePage = new HomePage(global.driver);
            autoCompleteTextBoxPage = new AutoCompleteTextBoxPage(global.driver);
            datePickerPage = new DatePickerPage(global.driver);
            toolTipPage = new ToolTipPage(global.driver);
        }

        readonly string date = DateTime.Now.ToString("dd");
        readonly string month = DateTime.Now.AddMonths(1).ToString("MMMM");
        readonly string year = DateTime.Now.ToString("yyyy");
        readonly string time = DateTime.Now.ToString("h:mm tt");

        [When(@"I click Auto Complete to enter data from the table:")]
        public void WhenIClickToEnterDataFromTheTable(Table table)
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Auto Complete");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                autoCompleteTextBoxPage.SetAutoCompleteMultiColourTextBox(table.Rows[i]["ColorName"]);
            }
        }

        [Then(@"the data is submitted correctly from the table:")]
        public void ThenTheDataIsSubmittedCorrectly(Table table)
        {
            for (int i = 0; i < table.Rows.Count(); i++)
            {
                Assert.IsTrue(autoCompleteTextBoxPage.GetAutoCompleteMultipleTextBoxResult().Contains(table.Rows[i]["ColorName"]),
                    table.Rows[i]["ColorName"] + " not found in the list : " + autoCompleteTextBoxPage.GetAutoCompleteMultipleTextBoxResult());
            }
        }

        [When(@"I click Auto Complete to enter the data from the table:")]
        public void WhenIClickToEnterTheDataFromTheTable(Table table)
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Auto Complete");
            autoCompleteTextBoxPage.SetAutoCompleteSingleTextBox(table.Rows.First()["ColorName"]);


        }

        [Then(@"the details are submitted correctly from the table:")]
        public void ThenTheDetailsAreSubmittedCorrectlyFromTheTable(Table table)
        {
            Assert.AreEqual(table.Rows.First()["ColorName"], autoCompleteTextBoxPage.GetAutoCompleteSingleTextBoxResult());
        }

        //DatePicker
        [When(@"I click Date Picker to select today date")]
        public void WhenIClickToSelectDateFromTheTable()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Date Picker");
            datePickerPage.SelectDate(date, month, year);
        }

        [Then(@"the date is selected correctly")]
        public void ThenTheSelectedDateFromTheTableIsPopulated()
        {
            //Convert Full Month name to number
            string actualDate = "";
            int monthNumber = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture).Month;
            if (monthNumber < 10)
            {
                actualDate = "0" + monthNumber + "/" + date + "/" + year;
            }
            else
            {
                actualDate = monthNumber + "/" + date + "/" + year;
            }
            Console.WriteLine(actualDate);
            Assert.AreEqual(actualDate, datePickerPage.GetSelectedDate());
        }

        [When(@"I click Date Picker to select today date and time")]
        public void WhenIClickToSelectDateAndTimeFromTheTable()
        {

            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Date Picker");
            datePickerPage.SelectDateAndTime(date, month, year, time);

        }

        [Then(@"the date and time is selected correctly")]
        public void ThenTheDateAndTimeIsSelectedWithDataFromTheTable()
        {
            //July 13, 2023 3:30 AM
            string dateAndTimeConcat = month + " " + date + ", " + year + " " + time;
            Assert.AreEqual(dateAndTimeConcat, datePickerPage.GetSelectedDateAndTime());
        }

        //Tool tips
        [When(@"I click Tool Tips and mouser over the content")]
        public void WhenIClickAndMouserOverTheContent(Table table)
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Tool Tips");
            toolTipPage.MouseHoverTheToolTipInfo(table.Rows.First()["ToolTipContent"]);


        }

        [Then(@"the info validated correctly for tool tip from the table:")]
        public void ThenToolInfoIsValidatedCorrectly(Table table)
        {
            Assert.AreEqual("You hovered over the " + table.Rows.First()["ToolTipContent"], toolTipPage.GetToolTipText());
        }

    }
}
