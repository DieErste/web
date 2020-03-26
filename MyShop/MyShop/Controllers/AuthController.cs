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
    public class AuthController : Controller
    {
        private readonly ILogger _logger;
        private readonly Session _session;
        private readonly IUser _user;

        public AuthController(ILogger<AuthController> logger, Session session, IUser user)
        {
            _logger = logger;
            _session = session;
            _user = user;
        }

        public IActionResult Login()
        {
            if (_session.ChkSession())
            {
                return RedirectToAction("Menu", "ControlPanel");
            }
            var obj = new AuthViewModel
            {
                modelName = "Авторизация",
                btnName = "Вход"
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Login(AuthViewModel authViewModel)
        {
            if (!ModelState.IsValid || authViewModel.user == null)
            {
                return View(authViewModel);
            }
            _session.AddLogin(_user.GetUser(authViewModel.user.name));

            return RedirectToAction("Menu", "ControlPanel");
        }
    }
}
