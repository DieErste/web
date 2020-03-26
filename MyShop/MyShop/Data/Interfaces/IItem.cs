using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Interfaces
{
    //описание методов
    public interface IItem
    {
        IEnumerable<Item> items { get; }
        IEnumerable<Item> favouriteItems { get; }
        Item GetItem(int id);
        bool Insert(Item item);
        bool Delete(Item item);
        bool Edit(Item item);
    }
}
