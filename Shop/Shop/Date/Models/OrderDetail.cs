using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//описываем каждый товар который мы преобритаем
namespace Shop.Date.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }//конкретный заказ его id
        public int CarID { get; set; }//id самого товара который мы преобратаем
        public uint price { get; set; }
        public virtual Car car { get; set; }//для б.д
        public virtual Order order { get; set; }//для б.д
   
    }
}
