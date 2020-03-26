using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Interfaces
{
    //описание методов
    public interface ICategory
    {
        IEnumerable<Category> categories { get; }
        Category GetCategory(int id);
        bool Insert(Category category);
        bool Delete(Category category);
        bool Edit(Category category);
    }
}
