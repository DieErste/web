using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Item item { get; set; }
        [Display(Name = "Кол-во")]
        [Range(1, 100, ErrorMessage = "Диапозон чисел от 1 до 100")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public uint quantity { get; set; }
        [Display(Name = "Цена")]
        [DataType(DataType.Currency)]
        public double price { get; set; }
        public string shopCartID { get; set; }

    }
}
