using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GOOS_Sample.Models
{
    public class BudgetRepository : IRepository<Budgets>
    {
        public void Save(Budgets model)
        {
            var db = new Models.GOOSEntities();
            db.Budgets.Add(model);
            db.SaveChanges();
        }
    }
}