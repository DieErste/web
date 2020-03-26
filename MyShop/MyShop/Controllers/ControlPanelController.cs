using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class ControlPanelController : Controller
    {
        private readonly ILogger _logger;
        private readonly Session _session;

        public ControlPanelController(ILogger<ControlPanelController> logger, Session session)
        {
            _logger = logger;
            _session = session;
        }

        public IActionResult Menu()
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            _session.login = _session.GetLogin();
            ViewBag.user = _session.login.user.name;

            return View();
        }
    }
}
