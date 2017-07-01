using GOOS_Sample.Controllers;

namespace GOOS_Sample.Models
{
    public interface IBudgetService
    {
        void Create(BudgetAddViewModel budgetAddViewModel);
    }
}