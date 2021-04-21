using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.interfaces
{
    public interface ICarsCategory
    {

        IEnumerable<Category> AllCategories { get; }

    }
}
