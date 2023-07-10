using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumAutomationSolution.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SeleniumAutomationSolution.Pages.Elements
{
    public class UploadAndDownloadPage : BasePage
    {
        IWebDriver d;
        public UploadAndDownloadPage(IWebDriver driver)
            : base(driver)
        {
            this.d = driver;

        }

        //Selectors
        By DownloadButton= By.CssSelector("[id='downloadButton']");
        By UploadButton = By.CssSelector("[id='uploadFile']");
        By UploadOutputText = By.CssSelector("[id='uploadedFilePath']");

        public void ClickUploadFile()
        {
            IWebElement uploadButton = UICommon.GetElement(UploadButton, d);
           
            //Upload sample file in Utilities from User Directory
            var desktopPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = (desktopPath + "\\Utilities\\UploadFile\\sampleFile.jpeg");
           
            UICommon.MoveToElement(uploadButton, d);
            UICommon.WaitUntilDisplayed(UploadButton, d);
            new Actions(d).MoveToElement(uploadButton).Click().Perform();
            Thread.Sleep(5000);
            uploadButton.SendKeys(path);
            Thread.Sleep(5000);
            
        }

        public string GetUploadOutputText()
        {
            IWebElement uploadText = UICommon.GetElement(UploadOutputText, d);
            string uploadOutputText = uploadText.Text;
            return uploadOutputText;
        }

        public bool ClickDownloadButton()
        {
            //Need to update code to delete downloaded file
            bool file;
            IWebElement downloadButton = UICommon.GetElement(DownloadButton, d);
            downloadButton.Click();
            Thread.Sleep(5000);
            
            //Gets All files in user directory downloads
            var desktopPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            var filePaths = Directory.GetFiles(desktopPath+"\\downloads");
            
            List<string> listItemsName = new List<string>();
            for (int i = 0; i < filePaths.Length; i++)
            {
                string[] split = filePaths[i].Split('\\');
                listItemsName.Add(split.Last());
            }

            if (listItemsName.Contains("sampleFile.jpeg"))
            {
                file = true;
                return file;
            }
            else
            {
                file = false;
                return file;
            }
            
         }

        public void DeleteFilesAndDirectory()
        {
            var desktopPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent.Parent.FullName;
            var filePath = (desktopPath + "\\downloads\\sampleFile.jpeg");            
            if (File.Exists(filePath))
            {
                File.Delete(filePath); //delete the downloaded  file
            }
        }

    }
}
