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
            //_budgetRepository.Save(new Budgets(){Amount = budgetAddViewModel.Amount,YearMonth = budgetAddViewModel.Month});

            var budget = _budgetRepository.Read(x => x.YearMonth == budgetAddViewModel.Month);
            if (budget == null)
            {
                _budgetRepository.Save(new Budgets(){Amount = budgetAddViewModel.Amount,YearMonth = budgetAddViewModel.Month});
                var handler = this.Created;
                handler?.Invoke(this,EventArgs.Empty);
            }
            else
            {
                budget.Amount = budgetAddViewModel.Amount;
                _budgetRepository.Save(budget);
                var handler = this.Updated;
                handler?.Invoke(this,EventArgs.Empty);
            }
            
        }

        public event EventHandler Updated;
        public event EventHandler Created;
    }
}