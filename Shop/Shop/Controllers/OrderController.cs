using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Shop.Date.interfaces;
using Shop.Date.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        [Route("Order")]
        [Route("Order/Checkout")]        
        public IActionResult Checkout()//возвращает хтмл, но на нем уже буду происходить действия, где пользователь будет вводить ФИО и т.д и завершать заказ
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cheсkout(Order order)//возвращает хтмл, где пользователь будет вводить ФИО и т.д и завершать заказ
        {
            shopCart.listShopItems = shopCart.getShopItems();

            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","У вас должны быть товары!");
            }

            if (ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complate");
            }

            return View(order);
        }

        public IActionResult Complate()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

    }
}
