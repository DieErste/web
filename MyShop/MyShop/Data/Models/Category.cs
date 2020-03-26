using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class Category
    {
        public int id { set; get; }
        [Display(Name = "Название")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Кол-во имволов не менее 3 и не более 30")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Символы не допустимы")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string name { set; get; }

        public List<Item> items { set; get; }

    }
}
