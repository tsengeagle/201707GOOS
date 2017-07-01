using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace GOOS_SampleTests.Steps
{
    [Binding]
    public class InsertData
    {
        [Given(@"budget table has a budget")]
        public void GivenBudgetTableHasABudget(Table table)
        {
            var db = new TestModels.TestGOOSEntities();
            db.Budgets.AddRange(table.CreateSet<TestModels.Budgets>());
            db.SaveChanges();

        }
    }
}