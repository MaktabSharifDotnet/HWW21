using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.HWW21.Models
{
    public class CreateCategoryViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام دسته بندی ")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد")]
        public string Name { get; set; }
    }
}
