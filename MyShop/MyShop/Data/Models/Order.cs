using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Кол-во имволов не менее 3 и не более 30")]
        [RegularExpression("^[a-zA-Zа-яА-Я]*$", ErrorMessage = "Символы не допустимы")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Кол-во имволов не менее 3 и не более 30")]
        [RegularExpression("^[a-zA-Zа-яА-Я]*$", ErrorMessage = "Символы не допустимы")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(240, MinimumLength = 5, ErrorMessage = "Кол-во имволов не менее 5 и не более 240")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string adress { get; set; }

        [Display(Name = "Номер телефона")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Кол-во имволов не менее 4 и не более 30")]
        [RegularExpression("^[0-9+]*$", ErrorMessage = "Символы не допустимы")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [StringLength(90, MinimumLength = 5, ErrorMessage = "Кол-во имволов не менее 5 и не более 90")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
