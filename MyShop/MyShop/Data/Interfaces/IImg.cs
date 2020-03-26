using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Interfaces
{
    public interface IImg
    {
        IEnumerable<Img> imgs { get; }
        Img GetImg(int id);
        bool Insert(Img img);
        bool Delete(Img img);
    }
}
