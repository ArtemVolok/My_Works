using Shop.Date.interfaces;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Date.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

       public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }

        //ф-ция создает товар в корзине
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;//устанавливаем текущее время заказа
            appDBContent.Order.Add(order);//добавляем заказ в табличку

            var items = shopCart.listShopItems;//хранит все товары, которые преобретает пользователь, в shopCart они все хранятся

            foreach(var el in items) // создаем то, что хранится в корзине
            {
                var orderDetail = new OrderDetail()
                {
                    CarID = el.car.id,
                    orderID = order.id,
                    price = el.car.price
                };
                appDBContent.OrderDetail.Add(orderDetail);//добавляем в базу
            }
            appDBContent.SaveChanges();//сохраняем базу
        }
    }
}
