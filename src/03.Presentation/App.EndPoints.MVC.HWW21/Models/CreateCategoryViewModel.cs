using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.HWW21.Models
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد")]
        public string Name { get; set; }
    }
}
