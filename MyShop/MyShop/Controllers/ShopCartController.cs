using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    //связь модели и отображения
    public class ShopCartController : Controller
    {
        private readonly ILogger _logger;
        private readonly IItem _item;
        private readonly ShopCart _shopCart;
        public ShopCartController(ILogger<ShopCartController> logger, IItem item, ShopCart shopCart)
        {
            _logger = logger;
            _item = item;
            _shopCart = shopCart;
        }

        //[Route("ShopCart")]
        //[Route("ShopCart/Index")]
        public ViewResult Index()
        {
            var obj = new ShopCartViewModel { shopCartItems = _shopCart.GetShopCartItems() };
            return View(obj);
        }

        [HttpPost]
        //[Route("ShopCart/Index/{shopCartViewModel}")]
        public IActionResult Index(ShopCartViewModel shopCartViewModel)
        {
            if (!_shopCart.GetShopCartItems().Any())
            {
                ModelState.AddModelError("","Добавьте товары в корзину");
                shopCartViewModel.shopCartItems = _shopCart.GetShopCartItems();
            }
            if (!ModelState.IsValid)
            {
                return View(shopCartViewModel);
            }
            for (int i = 0; i < shopCartViewModel.shopCartItems.Count; i++)
                shopCartViewModel.shopCartItems[i].price =
                    shopCartViewModel.shopCartItems[i].quantity * shopCartViewModel.shopCartItems[i].item.price;
            _shopCart.shopCartItems = shopCartViewModel.shopCartItems;
            if (!_shopCart.UpdShopCart(_shopCart))
            {
                ModelState.AddModelError("", "ошибка 2");
                return View(shopCartViewModel);
            }
            return RedirectToAction("Checkout", "Order");
        }

        public RedirectToActionResult addToCart(int itemID)
        {
            var item = _item.GetItem(itemID);
            if(item != null)
                _shopCart.AddToCart(item);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult deleteFromCart(int shopCartItemId)
        {
            if (!_shopCart.DeleteFromCart(shopCartItemId))
                ModelState.AddModelError("", "Позиция не найдена");
            return RedirectToAction("Index");
        }
    }
}
