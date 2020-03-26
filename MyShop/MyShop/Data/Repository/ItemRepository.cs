using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class ItemRepository : IItem
    {
        private readonly ILogger _logger;
        private readonly AppDBContent _appDBContent;
        public ItemRepository(ILogger<ItemRepository> logger, AppDBContent appDBContent)
        {
            _logger = logger;
            _appDBContent = appDBContent;
        }
        public IEnumerable<Item> items => _appDBContent.item.Include(c => c.category).Include(x => x.img).OrderBy(x => x.id); //получаем данные по категории

        public IEnumerable<Item> favouriteItems => _appDBContent.item.Where(p => p.favourite).Include(c => c.category)
            .Include(x => x.img).OrderBy(x => x.id);

        public Item GetItem(int id) => _appDBContent.item.Include(x => x.category).Include(x => x.img).FirstOrDefault(p => p.id == id);

        public bool Insert(Item item)
        {
            // проверка не повторения имени
            if(_appDBContent.item.FirstOrDefault(i => string.Equals(i.name, item.name, StringComparison.OrdinalIgnoreCase)) != null)
            {
                return false;
            }
            _appDBContent.item.Add(item);
            _appDBContent.SaveChanges();
            return true;
        }

        public bool Delete(Item item)
        {
            var obj = _appDBContent.item.FirstOrDefault(c => c.id == item.id);
            if (obj == null)
            {
                return false;
            }
            _appDBContent.item.Remove(obj);
            _appDBContent.SaveChanges();
            return true;
        }

        public bool Edit(Item item)
        {
            var obj = _appDBContent.item.FirstOrDefault(c => c.id == item.id);
            if (obj == null)
            {
                return false;
            }
            obj.name = item.name;
            obj.desc = item.desc;
            obj.price = item.price;
            obj.uom = item.uom;
            obj.favourite = item.favourite;
            obj.available = item.available;
            obj.categoryID = item.categoryID;
            obj.category = _appDBContent.category.FirstOrDefault(c => c.id == item.categoryID);
            obj.imgID = item.imgID;
            obj.img = _appDBContent.img.FirstOrDefault(c => c.id == item.imgID);
            _appDBContent.item.Update(obj);
            _appDBContent.SaveChanges();
            return true;
        }
    }
}
