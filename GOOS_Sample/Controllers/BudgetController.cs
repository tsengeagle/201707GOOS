using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GOOS_Sample.Models;
using GOOS_Sample.ViewModels;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService _service;

        public BudgetController(IBudgetService service)
        {
            _service = service;
        }

        public BudgetController()
        {
            _service=new BudgetService();
        }

        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            _service.Create(model);

            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}