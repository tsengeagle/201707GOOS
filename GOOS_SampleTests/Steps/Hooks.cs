using System.Linq;
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

            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));
            if (!tags.Any())
            {
                return;
            }
            using (var dbcontext = new TestModels.TestGOOSEntities())
            {
                foreach (var tag in tags)
                {
                    dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}s]");
                }
                dbcontext.SaveChangesAsync();
            } 
        }

        [Scope(Tag = "web")]
        [BeforeScenario()]
        public void BeforeScenario()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

    }
}