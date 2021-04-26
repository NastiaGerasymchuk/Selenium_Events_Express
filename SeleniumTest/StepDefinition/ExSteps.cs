using System;
using TechTalk.SpecFlow;

namespace SeleniumTest.StepDefinition
{
    [Binding]
    public class ExSteps
    {
        [Given(@"go to add event page")]
        public void GivenGoToAddEventPage()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
