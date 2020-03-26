using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    //абстрактный класс корзины
    public class ShopCart
    {
        private readonly AppDBContent _appDBContent;
        public ShopCart(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }

        public string shopCartID { get; set; }
        public List<ShopCartItem> shopCartItems { get; set; }

        //создание или получение текущей сессии корзины
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string shopCartID = session.GetString("ShopCartID") ?? Guid.NewGuid().ToString();

            session.SetString("ShopCartID", shopCartID);

            return new ShopCart(context) { shopCartID = shopCartID };
        }

        //добавление в корзину позиции
        //кол-во = 1 пока при первом добавлении оставил
        public void AddToCart(Item item)
        {
            _appDBContent.shopCartItem.Add(new ShopCartItem {
                shopCartID = shopCartID,
                item = item,
                quantity = 1,
                price = item.price
            });
            _appDBContent.SaveChanges();
        }

        //получение списка добавленны позиций
        public List<ShopCartItem> GetShopCartItems()
        {
            return _appDBContent.shopCartItem.Where(cartItem => cartItem.shopCartID == shopCartID).Include(cartItem => cartItem.item).ToList();
        }

        //массовое обновление в корзине кол-ва + цены
        public bool UpdShopCart(ShopCart shopCart)
        {
            foreach(var el in shopCart.shopCartItems)
            {
                var obj = _appDBContent.shopCartItem.Include(i => i.item).FirstOrDefault(i => i.id == el.id);
                if (obj == null) return false;
                obj.quantity = el.quantity;
                obj.price = el.item.price * el.quantity;
                _appDBContent.shopCartItem.Update(obj);
            }
            _appDBContent.SaveChanges();
            return true;
        }

        public bool DeleteFromCart(int shopCartItemId)
        {
            var obj = _appDBContent.shopCartItem.FirstOrDefault(i => i.id == shopCartItemId);
            if (obj == null)
                return false;
            _appDBContent.shopCartItem.Remove(obj);
            _appDBContent.SaveChanges();
            return true;
        }

    }
}
