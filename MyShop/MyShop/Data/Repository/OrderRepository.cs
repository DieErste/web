using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;

        public OrderRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            _appDBContent = appDBContent;
            _shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            _appDBContent.order.Add(order);

            var items = _shopCart.shopCartItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    itemID = el.item.id,
                    orderID = order.id,
                    price = el.price,
                    quantity = el.quantity
                };
                _appDBContent.orderDetail.Add(orderDetail);
            }
            _appDBContent.SaveChanges();
        }
    }
}
