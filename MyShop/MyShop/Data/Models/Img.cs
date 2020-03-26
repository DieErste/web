using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class Img
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string name { get; set; }
        [Display(Name = "Путь")]
        public string path { get; set; }
        public List<Item> items { set; get; }
    }
}
