using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class User
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Логин")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Кол-во имволов не менее 3 и не более 30")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Символы не допустимы")]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string name { get; set; }

        [Display(Name = "Пароль")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Кол-во имволов не менее 3 и не более 30")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Символы не допустимы")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        public string password { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public int roleID { get; set; }

        public virtual Role role { get; set; }
    }
}
