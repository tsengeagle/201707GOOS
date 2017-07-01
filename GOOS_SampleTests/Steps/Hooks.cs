using System.Drawing.Printing;
using System.Linq;
using FluentAutomation;
using GOOS_Sample.Models;
using Microsoft.Practices.Unity;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    public class CommonSteps
    {
        public static IUnityContainer UnityContainer
        {
            get;
            set;
        }

        [BeforeTestRun()]
        public static void RegisterDIContainer()
        {

            UnityContainer = new UnityContainer();
            UnityContainer.RegisterType<IBudgetService, BudgetService>();

        }

        public static void CleanTestData()
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

        [BeforeScenario()]
        public void BeforeScenarioCleanData()
        {
            CleanTestData();
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            CleanTestData();
        }

        [Scope(Tag = "web")]
        [BeforeScenario()]
        public void BeforeScenario()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

    }
}