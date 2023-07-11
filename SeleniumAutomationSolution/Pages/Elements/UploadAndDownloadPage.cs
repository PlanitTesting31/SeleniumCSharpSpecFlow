using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace SeleniumAutomationSolution.Pages.Elements
{
    public class UploadAndDownloadPage : BasePage
    {
        public UploadAndDownloadPage(IWebDriver driver)
            : base(driver)
        {
        }

        //Selectors
        readonly By DownloadButton = By.CssSelector("[id='downloadButton']");
        readonly By UploadButton = By.CssSelector("[id='uploadFile']");
        readonly By UploadOutputText = By.CssSelector("[id='uploadedFilePath']");

        public void ClickUploadButton()
        {
            IWebElement uploadButton = UICommon.GetElement(UploadButton, d);

            //Upload sample file in Utilities from User Directory
            var desktopPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = (desktopPath + "\\Utilities\\UploadFile\\sampleFile.jpeg");

            UICommon.MoveToElement(uploadButton, d);
            UICommon.WaitUntilDisplayed(UploadButton, d);
            new Actions(d).MoveToElement(uploadButton).Click().Perform();
            uploadButton.SendKeys(path);
        }

        public string GetUploadOutputText()
        {
            IWebElement uploadText = UICommon.GetElement(UploadOutputText, d);
            string uploadOutputText = uploadText.Text;
            return uploadOutputText;
        }

        public UploadAndDownloadPage ClickDownloadButton()
        {
            IWebElement downloadButton = UICommon.GetElement(DownloadButton, d);
            ((IJavaScriptExecutor)d).ExecuteScript("arguments[0].scrollIntoView(true)", downloadButton);
            DownloadButton.WaitUntilDisplayed(d);
            new Actions(d).MoveToElement(downloadButton).Click().Perform();
            return this;
        }

        public void WaitUntilFileIsDownlaoded(string fileName)
        {
            new WebDriverWait(d, TimeSpan.FromSeconds(20)).Until(x=>GetDowloadedFileCount(fileName) > 0);
        }

        public int GetDowloadedFileCount(string fileName)
        {
            //Gets All files in user directory downloads
            var desktopPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            var filePaths = Directory.GetFiles(desktopPath + "\\downloads");

            List<string> listItemsName = new List<string>();
            for (int i = 0; i < filePaths.Length; i++)
            {
                string[] split = filePaths[i].Split('\\');
                listItemsName.Add(split.Last());
            }
            return listItemsName.Where(x=>x.Trim().Equals(fileName)).Count();
        }

        public void DeleteDownloadedFile(string fileName)
        {
            var desktopPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            var filePath = (desktopPath + "\\downloads\\"+ fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath); //delete the downloaded  file
            }
        }

    }
}
