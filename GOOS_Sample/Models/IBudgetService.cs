using System;
using GOOS_Sample.Controllers;
using GOOS_Sample.ViewModels;

namespace GOOS_Sample.Models
{
    public interface IBudgetService
    {
        void Create(BudgetAddViewModel budgetAddViewModel);
        event EventHandler Updated;
        event EventHandler Created;
    }
}