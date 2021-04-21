using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//создает заказ(интерфейс)
namespace Shop.Date.interfaces
{
     public interface IAllOrders
    {
      void createOrder(Order order);
    }
}
