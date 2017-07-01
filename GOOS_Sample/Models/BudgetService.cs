using System;
using GOOS_Sample.Controllers;
using GOOS_Sample.ViewModels;

namespace GOOS_Sample.Models
{
    public class BudgetService : IBudgetService
    {
        private IRepository<Budgets> _budgetRepository;

        public BudgetService(IRepository<Budgets> budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        public void Create(BudgetAddViewModel budgetAddViewModel)
        {
            //var db = new Models.GOOSEntities();
            //db.Budgets.Add(new Budgets() { Amount = budgetAddViewModel.Amount, YearMonth = budgetAddViewModel.Month });
            //db.SaveChanges();

            _budgetRepository.Save(new Budgets(){Amount = budgetAddViewModel.Amount,YearMonth = budgetAddViewModel.Month});
        }
    }
}