using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    public class CommonSteps
    {
        [Scope(Tag = "web")]
        [BeforeScenario()]
        public void BeforeScenario()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

    }
}