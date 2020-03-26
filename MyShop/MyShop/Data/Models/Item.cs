using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    //класс позиция
    public class Item
    {
        public int id { set; get; }
        [Display(Name = "Название")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Кол-во имволов не менее 3 и не более 30")]
        //[RegularExpression("^[a-zA-Z\"]*$", ErrorMessage = "Символы не допустимы")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string name { set; get; }
        [Display(Name = "Описание")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Кол-во имволов не менее 3 и не более 1000")]
        //[RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Символы не допустимы")]
        public string desc { set; get; }
        [Display(Name = "Цена")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Неверный диапазон чисел")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public double price { set; get; }
        [Display(Name = "Мера измерения")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Кол-во имволов не менее 3 и не более 30")]
        public string uom { set; get; }
        [Display(Name = "Избранное")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public bool favourite { set; get; }
        [Display(Name = "В наличии")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public bool available { set; get; }
        [Display(Name = "Категория")]
        [ScaffoldColumn(false)]
        public int categoryID { set; get; }
        public virtual Category category { get; set; }
        [Display(Name = "Изображение")]
        [ScaffoldColumn(false)]
        public int imgID { set; get; }
        public virtual Img img { get; set; }
    }
}
