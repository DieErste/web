using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ItemManageController : Controller
    {
        private readonly ILogger _logger;
        private readonly IItem _item;
        private readonly ICategory _category;
        private readonly Session _session;
        private readonly IImg _img;

        public ItemManageController(ILogger<ItemManageController> logger, IItem item, ICategory category, Session session, IImg img)
        {
            _logger = logger;
            _item = item;
            _category = category;
            _session = session;
            _img = img;
        }

        [Route("ItemManage")]
        [Route("ItemManage/List")]
        [Route("ItemManage/List/{msg}")]
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
            IEnumerable<Item> items = _item.items.OrderBy(i => i.id);
            var obj = new ItemManageViewModel
            {
                modelName = "Позиции",
                items = items
            };
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = _item.GetItem(id);
            if (obj == null)
            {
                return RedirectToAction("List", new { msg = "Ошибка (объект не найден)" });
            }
            var list = new SelectList(_category.categories.ToList(), "id", "name");
            var list2 = new SelectList(_img.imgs.ToList(), "id", "name");
            var obj2 = new ItemEditViewModel
            {
                modelName = "Редактирование позиции",
                btnName = "Изменить",
                categories = list,
                item = obj,
                imgs = list2,
                imgBtnName = "Добавить изображение"
            };
            return View(obj2);
        }

        [HttpPost]
        public IActionResult Edit(ItemEditViewModel itemEditViewModel)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            itemEditViewModel.item.category = _category.GetCategory(itemEditViewModel.item.categoryID);
            itemEditViewModel.item.img = _img.GetImg(itemEditViewModel.item.imgID);
            if (itemEditViewModel == null || !ModelState.IsValid || !_item.Edit(itemEditViewModel.item))
            {
                ModelState.AddModelError("", "Ошибка проверки");
                // список пропадает - приходится переопределять
                itemEditViewModel.categories = new SelectList(_category.categories.ToList(), "id", "name");
                itemEditViewModel.imgs = new SelectList(_img.imgs.ToList(), "id", "name");
                return View(itemEditViewModel);
            }
            return RedirectToAction("List");
        }

        public IActionResult Insert()
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var list = new SelectList(_category.categories.ToList(), "id", "name");
            var list2 = new SelectList(_img.imgs.ToList(), "id", "name");
            var obj = new ItemEditViewModel
            {
                modelName = "Добавление позиции",
                btnName = "Создать",
                categories = list,
                imgs = list2,
                imgBtnName = "Добавить изображение"
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult Insert(ItemEditViewModel itemEditViewModel)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            itemEditViewModel.item.category = _category.GetCategory(itemEditViewModel.item.categoryID);
            itemEditViewModel.item.img = _img.GetImg(itemEditViewModel.item.imgID);
            if (itemEditViewModel.item == null || !ModelState.IsValid || !_item.Insert(itemEditViewModel.item))
            {
                ModelState.AddModelError("", "Ошибка проверки");

                // список пропадает - приходится переопределять
                itemEditViewModel.categories = new SelectList(_category.categories.ToList(), "id", "name");
                itemEditViewModel.imgs = new SelectList(_img.imgs.ToList(), "id", "name");
                return View(itemEditViewModel);
            }
            return RedirectToAction("List");
        }

        public RedirectToActionResult Delete(int id)
        {
            if (!_session.ChkSession())
            {
                return RedirectToAction("Login", "Auth");
            }
            var obj = _item.GetItem(id);
            if (obj == null || !_item.Delete(obj))
            {
                return RedirectToAction("List", new { msg = "Ошибка (объект не найден)" });
            }
            return RedirectToAction("List");
        }
    }
}
