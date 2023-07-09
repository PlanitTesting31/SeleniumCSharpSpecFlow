using SeleniumAutomationSolution.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public sealed class HomePageStepDefinition : BaseTest
    {
        

        [Given(@"I navigate to ""(.*)"" sections of the homepage")]
        public void GivenINavigateToSectionOfTheHomepage(string sectionTitle)
        {
            HomePage homePageNew = new HomePage(driver);
            homePageNew.ClickOnSectionWith(sectionTitle);
        }


    }
}
