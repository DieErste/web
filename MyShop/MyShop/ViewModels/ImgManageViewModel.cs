using Microsoft.AspNetCore.Http;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ImgManageViewModel
    {
        public string modelName { get; set; }
        public string btnName { get; set; }
        [Display(Name = "Файл")]
        [Required(ErrorMessage = "Выберите файл")]
        public IFormFile formFile { get; set; }
        public Img img { get; set; }
    }
}
