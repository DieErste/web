using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrder _order;
        private readonly ShopCart _shopCart;
        private readonly ILogger _logger;

        public OrderController(IOrder order, ShopCart shopCart, ILogger<OrderController> logger)
        {
            _order = order;
            _shopCart = shopCart;
            _logger = logger;
        }

        //[Route("Order")]
        //[Route("Order/Checkout")]
        public IActionResult Checkout()
        {
            if (!_shopCart.GetShopCartItems().Any())
                return RedirectToAction("Index", "ShopCart");
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.shopCartItems = _shopCart.GetShopCartItems();
            if (!_shopCart.shopCartItems.Any())
            {
                return RedirectToAction("Index", "ShopCart");
            }
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            _order.createOrder(order);
            return RedirectToAction("Complete");
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
