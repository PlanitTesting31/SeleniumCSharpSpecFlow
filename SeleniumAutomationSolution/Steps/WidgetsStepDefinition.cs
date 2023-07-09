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
    public sealed class WidgetsStepDefinition : BaseTest
    {
        HomePage homePage = new HomePage(driver);
        AutoCompleteTextBoxPage autoCompleteTextBoxPage = new AutoCompleteTextBoxPage(driver);
        DatePickerPage datePickerPage = new DatePickerPage(driver);
        ToolTipPage toolTipPage = new ToolTipPage(driver);

        [When(@"I click ""(.*)"" to enter data from the table:")]
        public void WhenIClickToEnterDataFromTheTable(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            //To implement both colors
            List<string> colorList = new List<string>();
            colorList.Add(table.Rows.First()["ColorName1"]);
            colorList.Add(table.Rows.First()["ColorName2"]);
            for(int i=0; i< colorList.Count();i++)
            {
                autoCompleteTextBoxPage.SetAutoCompleteMultipleTextBox(colorList[i]);
            }

        }

        [Then(@"the data is submitted correctly from the table:")]
        public void ThenTheDataIsSubmittedCorrectly(Table table)
        {
            //List of colors from table
            List<string> colorListFromTable = new List<string>();
            colorListFromTable.Add(table.Rows.First()["ColorName1"]);
            colorListFromTable.Add(table.Rows.First()["ColorName2"]);

            //Color list updated from UI
            List<string> colorList = new List<string>();
            colorList.Add(autoCompleteTextBoxPage.GetAutoCompleteMultipleTextBoxResult()[0]);
            colorList.Add(autoCompleteTextBoxPage.GetAutoCompleteMultipleTextBoxResult()[1]);
            for (int i = 0; i < colorList.Count(); i++)
            {
                Assert.AreEqual(colorListFromTable[i], colorList[i]);
            }
        }

        [When(@"I click ""(.*)"" to enter the data from the table:")]
        public void WhenIClickToEnterTheDataFromTheTable(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            autoCompleteTextBoxPage.SetAutoCompleteSingleTextBox(table.Rows.First()["ColorName"]);


        }

        [Then(@"the details are submitted correctly from the table:")]
        public void ThenTheDetailsAreSubmittedCorrectlyFromTheTable(Table table)
        {
            Assert.AreEqual(table.Rows.First()["ColorName"], autoCompleteTextBoxPage.GetAutoCompleteSingleTextBoxResult());
        }


        //DatePicker
        [When(@"I click ""(.*)"" to select date from the table:")]
        public void WhenIClickToSelectDateFromTheTable(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
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


        [When(@"I click ""(.*)"" to select date and time from the table:")]
        public void WhenIClickToSelectDateAndTimeFromTheTable(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
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
        [When(@"I click ""(.*)"" and mouser over the content")]
        public void WhenIClickAndMouserOverTheContent(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            toolTipPage.MouseHoverTheToolTipInfo(table.Rows.First()["ToolTipContent"]);


        }

        [Then(@"the info validated correctly for tool tip from the table:")]
        public void ThenToolInfoIsValidatedCorrectly(Table table)
        {
            Assert.AreEqual("You hovered over the "+table.Rows.First()["ToolTipContent"], toolTipPage.GetToolTipText());
        }







    }
}
