using System;
using System.Collections.Generic;

namespace GOOS_Sample.Models
{
    public interface IRepository<T>
    {
        void Save(T model);
        Budgets Read(Func<T, bool> predict);
    }
}