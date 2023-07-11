using SeleniumAutomationSolution.Pages;
using TechTalk.SpecFlow;

namespace SeleniumAutomationSolution.Steps
{
    [Binding]
    public class HomePageStepDefinition
    {
        readonly Global global;

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
