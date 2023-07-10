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
    public class ElementsStepDefinition
    {
        Global global;
        HomePage homePage;
        TextBoxPage textBoxPage;
        CheckBoxPage checkBoxPage; 
        WebTablePage webTablePage;
        ButtonsPage buttonsPage;
        UploadAndDownloadPage uploadAndDownloadPage;

        public ElementsStepDefinition(Global global)
        {
            this.global = global;
            homePage = new HomePage(global.driver);
            textBoxPage = new TextBoxPage(global.driver);
            checkBoxPage = new CheckBoxPage(global.driver);
            webTablePage = new WebTablePage(global.driver);
            buttonsPage = new ButtonsPage(global.driver);
            uploadAndDownloadPage = new UploadAndDownloadPage(global.driver);

        }


        [When(@"I submit Text Box details with data from the table:")]
        public void WhenISubmitTheTextBoxDetailsWithDataFromTheTable(Table table)
        {          

            homePage.ExpandMenuAndClickItem("Elements", "Text Box");

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

        [When(@"I expand the following Check Box in the page and select the checkbox's from the table:")]
        public void WhenIExpandTheFollowingInThePageAndSelectTheCheckboxS(Table table)
        {
            homePage.ExpandMenuAndClickItem("Elements", "Check Box");

            if (table.Header.Contains("Home"))
                checkBoxPage.ExpandHomeCheckBox();
            switch (table.Rows.First()["Home"])
            {

                case "Desktop":
                    if (table.Header.Contains("Expand"))
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
     
        [When(@"I search details of the user in Web Tables page")]
        public void WhenIUpdateDetailsWithDataFromTheTable(Table table)
        {
            homePage.ExpandMenuAndClickItem("Elements", "Web Tables");
            webTablePage.SetSearchBoxValue(table.Rows.First()["FirstName"]);
            webTablePage.ClickEditAction();
            
        }


        [When(@"I update ""(.*)"" of the user")]
        public void WhenIEditOfTheUserAndSubmitWithDataFromTheTable(string userFormField)
        {
            string age = new Random().Next(10,90).ToString();
            global.dynamicDate= age;
            webTablePage.SetUserFormValue(userFormField, age);
            webTablePage.ClickSubmitButton();
            
        }

        [Then(@"the age is successfully updated in web table")]
        public void ThenTheNewValueOfIsPopulatedWithDataFromTheTable()
        {
            string expectedValue = global.dynamicDate;
            Assert.AreEqual(expectedValue, webTablePage.GetValuefromTable());
        }


        
        //Buttons

        [When(@"I click following button from Buttons page")]
        public void WhenIClickFromTheTable(Table table)
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Elements", "Buttons");
            buttonsPage.ClickButton(table.Rows.First()["Button"]);
        }

        [Then(@"the message is populated in the page")]
        public void ThenButtonTextIsPopulated(Table table)
        {
            switch (table.Rows.First()["Message"])
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
        [When(@"I click Upload and Download for file")]
        public void WhenIClick()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Elements", "Upload and Download");
            uploadAndDownloadPage.ClickUploadFile();            
            
        }

        [Then(@"upload and download of file is successful")]
        public void ThenUploadAndDownloadOfFileIsSuccessful()
        {
            Assert.AreEqual(@"C:\fakepath\sampleFile.jpeg", uploadAndDownloadPage.GetUploadOutputText());
            Assert.AreEqual(true, uploadAndDownloadPage.ClickDownloadButton());
            uploadAndDownloadPage.DeleteFilesAndDirectory();
            
         }


    }
}
