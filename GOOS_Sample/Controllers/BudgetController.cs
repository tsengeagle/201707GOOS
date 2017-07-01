using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
        
        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            _service.Created += (sender, e) => { ViewBag.Message = "added successfully"; };
            _service.Updated += (sender, e) => { ViewBag.Message = "updated successfully"; };

            _service.Create(model);

            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}