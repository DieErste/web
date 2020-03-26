using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class ImgRepository : IImg
    {
        private readonly ILogger _logger;
        private readonly AppDBContent _appDBContent;
        public ImgRepository(ILogger<ImgRepository> logger, AppDBContent appDBContent)
        {
            _logger = logger;
            _appDBContent = appDBContent;
        }

        public IEnumerable<Img> imgs => _appDBContent.img.OrderBy(x => x.id);

        public bool Delete(Img img)
        {
            var obj = _appDBContent.img.FirstOrDefault(x => x.id == img.id);
            if (obj == null)
            {
                return false;
            }
            //check before items
            IEnumerable<Item> items = _appDBContent.item.Where(i => i.imgID == img.id).ToList();
            if (items.Any())
            {
                return false;
            }
            _appDBContent.img.Remove(obj);
            _appDBContent.SaveChanges();
            return true;
        }

        public Img GetImg(int id) => _appDBContent.img.FirstOrDefault(c => c.id == id);

        public bool Insert(Img img)
        {
            var obj = _appDBContent.img.FirstOrDefault(x => x.path == img.path);
            if(obj != null)
            {
                return false;
            }
            _appDBContent.img.Add(img);
            _appDBContent.SaveChanges();
            return true;
        }
    }
}
