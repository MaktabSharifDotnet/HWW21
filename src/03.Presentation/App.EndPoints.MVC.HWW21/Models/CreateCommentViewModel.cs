using System.ComponentModel.DataAnnotations;

namespace App.EndPoints.MVC.HWW21.Models
{
    public class CreateCommentViewModel
    {
        [Required(ErrorMessage = "لطفاً نام و نام خانوادگی را وارد کنید.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "لطفاً ایمیل را وارد کنید.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "لطفاً امتیاز خود را انتخاب کنید.")]
        [Range(1, 5, ErrorMessage = "امتیاز باید بین ۱ تا ۵ باشد.")]
        public int Score { get; set; }



        [Required(ErrorMessage = "لطفاً متن دیدگاه را وارد کنید.")]
        public string Text { get; set; }

        [Required]
        public int PostId { get; set; }
    }
}
