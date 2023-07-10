using SeleniumAutomationSolution.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public class HomePageStepDefinition 
    {
        Global global;

        public HomePageStepDefinition(Global global)
        {
            this.global = global;
        }

        [Given(@"I navigate to ""(.*)"" sections of the homepage")]
        public void GivenINavigateToSectionOfTheHomepage(string sectionTitle)
        {
            HomePage homePageNew = new HomePage(global.driver);
            homePageNew.ClickOnSectionWith(sectionTitle);
        }


    }
}
