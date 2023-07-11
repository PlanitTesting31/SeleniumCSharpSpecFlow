using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumAutomationSolution.Pages;
using SeleniumAutomationSolution.Pages.Elements;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public class ElementsStepDefinition
    {
        readonly Global global;
        readonly HomePage homePage;
        readonly TextBoxPage textBoxPage;
        readonly CheckBoxPage checkBoxPage;
        readonly WebTablePage webTablePage;
        readonly ButtonsPage buttonsPage;
        readonly UploadAndDownloadPage uploadAndDownloadPage;

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

        [When(@"I submit text box details with data from the table")]
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
            global.sharedScenarioBuffer.TextBox = table;
        }

        [Then(@"the details of user should be submitted successfully")]
        public void ThenTheSubmittedDetailsShouldBePopulated()
        {
            Table table = global.sharedScenarioBuffer.TextBox;
            Assert.AreEqual("Name:" + table.Rows.First()["FullName"], textBoxPage.GetFullName());
            Assert.AreEqual("Email:" + table.Rows.First()["Email"], textBoxPage.GetEmail());
            Assert.AreEqual("Current Address :" + table.Rows.First()["CurrentAddress"], textBoxPage.GetCurrentAddress());
            Assert.AreEqual("Permananet Address :" + table.Rows.First()["PermanentAddress"], textBoxPage.GetPermanentAddress());
        }


        //CheckkBox
        [When(@"I expand the following check box in the page")]
        public void ExpandTheFollowingCheckBoxInThePage(Table table)
        {
            homePage.ExpandMenuAndClickItem("Elements", "Check Box");
            foreach (var row in table.Rows)
            {
                checkBoxPage.ExpandMenu(row["ExpandMenu"]);
            }
        }

        [When(@"I select the check box")]
        public void ISelectTheCheckBox(Table table)
        {
            foreach (var row in table.Rows)
            {
                checkBoxPage.ClickOnCheckBox(row["Name"]);
            }
        }


        [Then(@"the checkbox details should be displayed from the table:")]
        public void ThenTheCheckboxDetailsShouldBeDisplayedFromTheTable(Table table)
        {
            Assert.IsTrue(checkBoxPage.GetSelectedCheckBoxText().Contains(table.Rows.First()["Name"]),
                "Expected value " + table.Rows.First()["Name"] + " not found in the actual" + checkBoxPage.GetSelectedCheckBoxText().ToString());

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
            string age = new Random().Next(10, 90).ToString();
            global.sharedScenarioBuffer.Age = age;
            webTablePage.SetUserFormValue(userFormField, age);
            webTablePage.ClickSubmitButton();

        }

        [Then(@"the age is successfully updated in web table")]
        public void ThenTheNewValueOfIsPopulatedWithDataFromTheTable()
        {
            string expectedValue = global.sharedScenarioBuffer.Age;
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
            Assert.AreEqual(table.Rows.First()["Message"], buttonsPage.GetButtonMessage());

        }

        //Upload and download

        [When(@"I upload a file in 'upload and download' page")]
        public void WhenINavigateToUploadAndDownloadAndUploadAFile()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Elements", "Upload and Download");
            uploadAndDownloadPage.ClickUploadButton();
        }

        [Then(@"file is uploaded successfully")]
        public void ThenFileIsUploadedSuccessfully()
        {
            Assert.AreEqual(@"C:\fakepath\sampleFile.jpeg", uploadAndDownloadPage.GetUploadOutputText());
        }

        [When(@"I download a file in 'upload and download' page")]
        public void WhenINavigateToUploadAndDownloadAndDownloadAFile()
        {
            homePage.ScrollToBottom();
            homePage.ExpandMenuAndClickItem("Elements", "Upload and Download");
            uploadAndDownloadPage.ClickDownloadButton().WaitUntilFileIsDownlaoded("sampleFile.jpeg");
        }

        [Then(@"file is downloaded successfully")]
        public void ThenFileIsDownloadedSuccessfully()
        {
            string fileName = "sampleFile.jpeg";
            Assert.AreEqual(1, uploadAndDownloadPage.GetDowloadedFileCount(fileName),
                "sampleFile.jpeg did not get downlaoded");
            uploadAndDownloadPage.DeleteDownloadedFile(fileName);
        }

    }
}
