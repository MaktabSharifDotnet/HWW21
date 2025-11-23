using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.HWW21.Models
{
    public class AuthenticationViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد")]
        public string Username { get; set; }


        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "{0} نمی‌تواند خالی باشد")]
        public string Password { get; set; }

        public IFormFile? ProfileImage { get; set; }
    }
}
