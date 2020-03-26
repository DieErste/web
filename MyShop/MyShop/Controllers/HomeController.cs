using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private IItem _item;
        public HomeController(ILogger<HomeController> logger, IItem item)
        {
            _logger = logger;
            _item = item;
        }

        public ViewResult Index()
        {
            var obj = new HomeViewModel
            {
                modelName = "Избранное",
                favouriteItems = _item.favouriteItems
            };
            return View(obj);
        }
    }
}
