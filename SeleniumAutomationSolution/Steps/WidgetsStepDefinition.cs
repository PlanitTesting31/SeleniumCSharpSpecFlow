using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.Widgets;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public class WidgetsStepDefinition
    {
        HomePage homePage;
        AutoCompleteTextBoxPage autoCompleteTextBoxPage;
        DatePickerPage datePickerPage;
        ToolTipPage toolTipPage;
        Global global;

        public WidgetsStepDefinition(Global global)
        {
            this.global = global;
             homePage = new HomePage(global.driver);
             autoCompleteTextBoxPage = new AutoCompleteTextBoxPage(global.driver);
             datePickerPage = new DatePickerPage(global.driver);
             toolTipPage = new ToolTipPage(global.driver);
        }

        [When(@"I click Auto Complete to enter data from the table:")]
        public void WhenIClickToEnterDataFromTheTable(Table table)
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Auto Complete");
            for(int i=0; i< table.Rows.Count; i++)
            {
                autoCompleteTextBoxPage.SetAutoCompleteMultipleTextBox(table.Rows[i]["ColorName"]);
            }

        }

        [Then(@"the data is submitted correctly from the table:")]
        public void ThenTheDataIsSubmittedCorrectly(Table table)
        {
            for (int i = 0; i < table.Rows.Count(); i++)
            {
                Assert.IsTrue(autoCompleteTextBoxPage.GetAutoCompleteMultipleTextBoxResult().Contains(table.Rows[i]["ColorName"]),
                    table.Rows[i]["ColorName"]+ "not found in the list : "+ autoCompleteTextBoxPage.GetAutoCompleteMultipleTextBoxResult());
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
        [When(@"I click Date Picker to select date from the table:")]
        public void WhenIClickToSelectDateFromTheTable(Table table)
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Date Picker");
            datePickerPage.SelectDate(table);
        }

        [Then(@"the date is selected correctly with data from the table:")]
        public void ThenTheSelectedDateFromTheTableIsPopulated(Table table)
        {
            //Convert Full Month name to number
            string dateFromTheTable ="";
            int monthNumber = DateTime.ParseExact(table.Rows.First()["Month"], "MMMM", CultureInfo.CurrentCulture).Month;
            if(monthNumber < 10)
            {
                dateFromTheTable = "0"+monthNumber + "/" + table.Rows.First()["Date"] + "/" + table.Rows.First()["Year"];
            }
            else
            {
                dateFromTheTable = monthNumber + "/" + table.Rows.First()["Date"] + "/" + table.Rows.First()["Year"];
            }
            Console.WriteLine(dateFromTheTable);
            Assert.AreEqual(dateFromTheTable, datePickerPage.GetSelectedDate());
        }


        [When(@"I click Date Picker to select date and time from the table:")]
        public void WhenIClickToSelectDateAndTimeFromTheTable(Table table)
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Widgets", "Date Picker");
            datePickerPage.SelectDateAndTime(table);

        }

        [Then(@"the date and time is selected correctly with data from the table:")]
        public void ThenTheDateAndTimeIsSelectedWithDataFromTheTable(Table table)
        {
            //July 13, 2023 3:30 AM
            string dateAndTimeFromTheTable = table.Rows.First()["Month"] + " " + table.Rows.First()["Date"] + ", " + table.Rows.First()["Year"] + " " + table.Rows.First()["Time"] + " AM";
            Assert.AreEqual(dateAndTimeFromTheTable,datePickerPage.GetSelectedDateAndTime());
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
            Assert.AreEqual("You hovered over the "+table.Rows.First()["ToolTipContent"], toolTipPage.GetToolTipText());
        }







    }
}
