using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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