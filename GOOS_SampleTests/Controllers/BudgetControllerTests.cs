using System;
using FluentAssertions;
using GOOS_Sample.Controllers;
using GOOS_Sample.Models;
using GOOS_Sample.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace GOOS_SampleTests.Controllers
{
    [TestClass]
    public class BudgetControllerTests
    {
        private BudgetController _controller;
        private IBudgetService _service = Substitute.For<IBudgetService>();

        [TestMethod]
        public void TestAddBudget()
        {
            _controller = new BudgetController(_service);
            var result = _controller.Add(new BudgetAddViewModel() { Amount = 2000, Month = "2017/01" });
            _service.Received().Create(Arg.Is<BudgetAddViewModel>(x => x.Amount == 2000 && x.Month == "2017/01"));
        }
    }
}
