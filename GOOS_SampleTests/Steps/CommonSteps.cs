using FluentAutomation;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    public class CommonSteps
    {
        [BeforeScenario()]
        public void CleanDB()
        {
            var db = new TestModels.TestGOOSEntities();
            db.Budgets.RemoveRange(db.Budgets);
            db.SaveChanges();

        }
        [Scope(Tag = "web")]
        [BeforeScenario()]
        public void BeforeScenario()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

    }
}