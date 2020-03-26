using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class ImgManageController : Controller
    {
        private readonly ILogger _logger;
        private readonly Session _session;
        private readonly IHostingEnvironment _host;
        private readonly IImg _img;

        public ImgManageController(ILogger<ImgManageController> logger, Session session, IHostingEnvironment host, IImg img)
        {
            _logger = logger;
            _session = session;
            _host = host;
            _img = img;
        }

        [Route("ImgManage")]
        [Route("ImgManage/List")]
        [Route("ImgManage/List/{msg}")]
        public IActionResult List(string msg)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            if (msg != null)
            {
                ModelState.AddModelError("", msg);
            }
            var obj = new ImgListViewModel()
            {
                modelName = "Изображения",
                btnName = "Добавить",
                imgs = _img.imgs
            };
            return View(obj);
        }

        public IActionResult Delete(int id)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = _img.GetImg(id);
            if (obj == null || !_img.Delete(obj))
            {
                return RedirectToAction("List", new { msg = "Ошибка (объект не найден либо используется)" });
            }
            return RedirectToAction("List", new { msg = "Объект удален" });
        }

        public IActionResult Insert()
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = new ImgManageViewModel
            {
                modelName = "Добавление изображения",
                btnName = "Загрузить"
            };
            return View(obj);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ImgManageViewModel imgManageViewModel)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            if (!ModelState.IsValid)
            {
                return View(imgManageViewModel);
            }
            string filename = Path.GetFileNameWithoutExtension(imgManageViewModel.formFile.FileName);
            string extension = Path.GetExtension(imgManageViewModel.formFile.FileName);
            filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
            imgManageViewModel.img.path = "/img/" + filename;
            filename = Path.Combine(_host.WebRootPath + "/img/", filename);
            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                await imgManageViewModel.formFile.CopyToAsync(fileStream);
            }
            if (!_img.Insert(imgManageViewModel.img))
            {
                ModelState.AddModelError("", "Ошибка загрузки файла");
                return View(imgManageViewModel);
            }
            return RedirectToAction("List", new { msg = "Объект добавлен" });
        }
    }
}
