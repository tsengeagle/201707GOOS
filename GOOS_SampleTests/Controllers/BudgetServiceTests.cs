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
        private IRepository<Budgets> _budgetRepository=Substitute.For<IRepository<Budgets>>();

        [TestMethod]
        public void TestBudgetsSave()
        {
            _service=new BudgetService(_budgetRepository);
            _service.Create(new BudgetAddViewModel() { Amount = 1000, Month = "2017/01"});
            _budgetRepository.Received().Save(Arg.Is<Budgets>(x => x.Amount == 1000 && x.YearMonth == "2017/01"));

        }


        [TestMethod()]
        public void CreateTest_when_exist_record_should_update_budget()
        {
            this._service = new BudgetService(_budgetRepository);

            var budgetFromDb = new Budgets { Amount = 999, YearMonth = "2017-02" };

            _budgetRepository.Read(Arg.Any<Func<Budgets, bool>>())
                .ReturnsForAnyArgs(budgetFromDb);

            var model = new BudgetAddViewModel { Amount = 2000, Month = "2017-02" };

            //act
            this._service.Create(model);

            //assert
            _budgetRepository.Received()
                .Save(Arg.Is<Budgets>(x => x == budgetFromDb && x.Amount == 2000));
        }

    }
}
