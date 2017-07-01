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

            var budgetFromDb = db.Budgets.FirstOrDefault(x => x.YearMonth == model.YearMonth);

            if (budgetFromDb == null)
            {
                db.Budgets.Add(model);
            }
            else
            {
                budgetFromDb.Amount = model.Amount;
            }

            db.SaveChanges();
        }

        public Budgets Read(Func<Budgets, bool> predict)
        {
            var db=new Models.GOOSEntities();
            return db.Budgets.FirstOrDefault(predict);
        }
    }
}