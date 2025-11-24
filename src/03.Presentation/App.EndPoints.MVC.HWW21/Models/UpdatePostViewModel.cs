using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.HWW21.Models
{
    public class UpdatePostViewModel
    {
        public int PostId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد")]
        public string Title { get; set; }

        [Display(Name = "متن پست")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد")]
        public string Description { get; set; }

        public IFormFile? ImagePost { get; set; }
        public string? ImagePostOld { get; set; }


        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "{0} باید انتخاب شود.")]
        public int CategoryId { get; set; }
    }
}
