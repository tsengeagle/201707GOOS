using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {

        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            var db=new Models.GOOSEntities();
            db.Budgets.Add(new Budgets() {Amount = model.Amount, YearMonth = model.Month});
            db.SaveChanges();

            ViewBag.Message = "added successfully";
            return View(model);
        }
    }

    public class BudgetAddViewModel
    {
        public int Amount { get; set; }
        public string Month { get; set; }
    }
}