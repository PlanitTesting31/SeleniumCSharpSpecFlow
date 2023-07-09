using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public sealed class ElementsStepDefinition : BaseTest
    {

        HomePage homePage = new HomePage(driver);
        TextBoxPage textBoxPage = new TextBoxPage(driver);
        CheckBoxPage checkBoxPage = new CheckBoxPage(driver);
        WebTablePage webTablePage = new WebTablePage(driver);
        ButtonsPage buttonsPage = new ButtonsPage(driver);
        UploadAndDownloadPage uploadAndDownloadPage = new UploadAndDownloadPage(driver);

        [When(@"I submit ""(.*)"" details with data from the table:")]
        public void WhenISubmitTheTextBoxDetailsWithDataFromTheTable(string subMenu, Table table)
        {          

            homePage.ExpandMenuAndClickItem("Elements", subMenu);

            if (table.Header.Contains("FullName"))
                textBoxPage.SetFullName(table.Rows.First()["FullName"]);
            else
                throw new Exception("Full name is not present in the table");
            textBoxPage.SetEmail(table.Rows.First()["Email"]);
            textBoxPage.SetCurrentAddress(table.Rows.First()["CurrentAddress"]);
            textBoxPage.SetPermanentAddress(table.Rows.First()["PermanentAddress"]);
            textBoxPage.ClickSubmitButton();
        }

        [Then(@"the submitted details of user should be displayed from the table:")]
        public void ThenTheSubmittedDetailsShouldBePopulated(Table table)
        {
            Assert.AreEqual("Name:" + table.Rows.First()["FullName"], textBoxPage.GetFullName());
            Assert.AreEqual("Email:" + table.Rows.First()["Email"], textBoxPage.GetEmail());
            Assert.AreEqual("Current Address :" + table.Rows.First()["CurrentAddress"], textBoxPage.GetCurrentAddress());
            Assert.AreEqual("Permananet Address :" + table.Rows.First()["PermanentAddress"], textBoxPage.GetPermanentAddress());
        }


        //CheckkBox

        [When(@"I expand the following ""(.*)"" in the page and select the checkbox's from the table:")]
        public void WhenIExpandTheFollowingInThePageAndSelectTheCheckboxS(string subMenu, Table table)
        {
            homePage.ExpandMenuAndClickItem("Elements", subMenu);

            if (table.Header.Contains("Home"))
                checkBoxPage.ExpandHomeCheckBox();
            switch (table.Rows.First()["Home"])
            {

                case "Desktop":
                    if (table.Header.Contains("Desktop"))
                    {
                        checkBoxPage.ClickOnCheckBox("Desktop", table.Rows.First()["Desktop"]);
                    }
                    else
                    {
                        checkBoxPage.ClickOnCheckBox("Desktop");
                    }
                    break;

                case "Documents":
                    if (table.Header.Contains("Documents"))
                    {
                        checkBoxPage.ClickOnCheckBox("Documents", table.Rows.First()["Documents"]);
                    }
                    else
                    {
                        checkBoxPage.ClickOnCheckBox("Documents");
                    }
                    break;

                case "Downloads":
                    if (table.Header.Contains("Downloads"))
                    {
                        checkBoxPage.ClickOnCheckBox("Downloads", table.Rows.First()["Downloads"]);
                    }
                    else
                    {
                        checkBoxPage.ClickOnCheckBox("Downloads");
                    }
                    break;


                default:
                    throw new Exception($"Check box: {table.Rows.First()["Home"]} is not present");


            }

        }

        [Then(@"the checkbox details should be displayed from the table:")]
        public void ThenTheCheckboxDetailsShouldBeDisplayedFromTheTable(Table table)
        {
            Assert.AreEqual(table.Rows.First()["Desktop"], checkBoxPage.GetSelectedCheckBoxText());

        }


        //WebTables
     
        [When(@"I update ""(.*)"" details with data from the table:")]
        public void WhenIUpdateDetailsWithDataFromTheTable(string subMenu, Table table)
        {
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            webTablePage.SetSearchBoxValue(table.Rows.First()["FirstName"]);
            webTablePage.ClickEditAction();
            
        }


        [When(@"I Edit ""(.*)"" of the user and submit with data from the table:")]
        public void WhenIEditOfTheUserAndSubmitWithDataFromTheTable(string userFormField, Table table)
        {
           webTablePage.SetUserFormValue(userFormField,table);
            webTablePage.ClickSubmitButton();
            
        }

        [Then(@"the new value is populated with data from the table:")]
        public void ThenTheNewValueOfIsPopulatedWithDataFromTheTable(Table table)
        {
            Assert.AreEqual(table.Rows.First()["Age"],webTablePage.GetValuefromTable());

        }


        
        //Buttons

        [When(@"I click ""(.*)"" from the table:")]
        public void WhenIClickFromTheTable(string subMenu, Table table)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            buttonsPage.ClickButton(table.Rows.First()["Button"]);
        }

        [Then(@"message is populated for button from table :")]
        public void ThenButtonTextIsPopulated(Table table)
        {
            switch (table.Rows.First()["Button"])
            {
                case "Double Click Me":
                    Assert.AreEqual("You have done a double click", buttonsPage.GetButtonMessage());
                    break;
                case "Right Click Me":
                    Assert.AreEqual("You have done a right click", buttonsPage.GetButtonMessage());
                    break;
                case "Click Me":
                    Assert.AreEqual("You have done a dynamic click", buttonsPage.GetButtonMessage());
                    break;
                default:
                    throw new Exception($"Button: {table.Rows.First()["Button"]} is not present");
            }           

        }

        //Upload and download
        [When(@"I click ""(.*)"" for file")]
        public void WhenIClick(string subMenu)
        {
            homePage.ScrollBar();
            homePage.ExpandMenuAndClickItem("Elements", subMenu);
            uploadAndDownloadPage.ClickUploadFile();            
            
        }

        [Then(@"upload and download of file is successful")]
        public void ThenUploadAndDownloadOfFileIsSuccessful()
        {
            Assert.AreEqual(@"C:\fakepath\sampleFile.jpeg", uploadAndDownloadPage.GetUploadOutputText());
            Assert.AreEqual(true, uploadAndDownloadPage.ClickDownloadButton());
            
         }


    }
}
