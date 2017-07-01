using System;
using GOOS_Sample.Models;
using GOOS_Sample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GOOS_SampleTests.Controllers
{
    [TestClass]
    public class BudgetServiceTests
    {
        private IBudgetService _service;
        private IRepository<Budgets> _budgetRepository;

        [TestMethod]
        public void TestBudgetsSave()
        {
            _service=new BudgetService(_budgetRepository);
            _service.Create(new BudgetAddViewModel() { Amount = 1000, Month = "2017/01"});
            _budgetRepository.Received().Save(Arg.Is<Budgets>(x => x.Amount == 1000 && x.YearMonth == "2017/01"));

        }

    }
}
