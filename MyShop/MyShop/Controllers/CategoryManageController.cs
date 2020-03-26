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
    public class CategoryManageController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICategory _category;
        private readonly Session _session;

        public CategoryManageController(ILogger<CategoryManageController> logger, ICategory category, Session session)
        {
            _logger = logger;
            _category = category;
            _session = session;
        }

        [Route("CategoryManage")]
        [Route("CategoryManage/List")]
        [Route("CategoryManage/List/{msg}")]
        public IActionResult List(string msg)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            if(msg != null)
            {
                ModelState.AddModelError("", msg);
            }
            IEnumerable<Category> categories = _category.categories.OrderBy(x => x.id);
            var obj = new CategoryManageViewModel
            {
                modelName = "Категории",
                btnName = "Добавить",
                categories = categories
            };
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = _category.GetCategory(id);
            if (obj == null)
            {
                return RedirectToAction("List", new { msg = "Ошибка (объект не найден)" });
            }
            var obj2 = new CategoryEditViewModel
            {
                modelName = "Редактирование категории",
                btnName = "Изменить",
                category = obj

            };
            return View(obj2);
        }

        [HttpPost]
        public IActionResult Edit(CategoryEditViewModel categoryEditViewModel)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = categoryEditViewModel.category;
            if (obj == null || !ModelState.IsValid || !_category.Edit(obj))
            {
                ModelState.AddModelError("", "Ошибка проверки");
                return View(categoryEditViewModel);
            }
            return RedirectToAction("List");
        }

        public IActionResult Insert()
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = new CategoryEditViewModel
            {
                modelName = "Добавление категории",
                btnName = "Создать"
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Insert(CategoryEditViewModel categoryEditViewModel)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            if (categoryEditViewModel.category == null || !ModelState.IsValid || !_category.Insert(categoryEditViewModel.category))
            {
                ModelState.AddModelError("", "Ошибка проверки");
                return View(categoryEditViewModel);
            }
            return RedirectToAction("List");
        }

        public RedirectToActionResult Delete(int id)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = _category.GetCategory(id);
            if (obj == null || !_category.Delete(obj))
            {
                return RedirectToAction("List", new { msg = "Ошибка (объект не найден либо используется)" });
            }
            return RedirectToAction("List");
        }
    }
}
