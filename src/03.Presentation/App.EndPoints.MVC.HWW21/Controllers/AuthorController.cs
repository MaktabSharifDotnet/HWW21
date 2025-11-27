using App.Domain.AppServices.CommentAgg;
using App.Domain.Core.Contracts.AuthorAgg.AppService;
using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Dtos.AuthorAgg;
using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Dtos.CommentAgg;
using App.Domain.Core.Dtos.PostAgg;
using App.Domain.Core.Entities;
using App.Domain.Core.Enums.CommentAgg;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class AuthorController(ICategoryAppService categoryAppService 
        , IPostAppService postAppService , IAuthorAppService authorAppService ,
        ICommentAppService commentAppService) : Controller
    {
      
        public IActionResult Index()
        {
            
            if(LocalStorage.AuthorLoginId==0)
            {
                return RedirectToAction("Login", "Authentication");
            }

            List<CategoryDto> categoryDtos = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
            List<PostDto> postDtos = postAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
            try
            {
                AuthorInfoDto? authorInfoDto=authorAppService.GetById(LocalStorage.AuthorLoginId);
                AuthorDashboardViewModel authorDashboardViewModel = new AuthorDashboardViewModel()
                {
                    CategoryDtos = categoryDtos,
                    PostDtos = postDtos,
                    AuthorName = authorInfoDto!.Username,
                    AuthorProfileImage = authorInfoDto.ProfileImagePath
                };

                return View(authorDashboardViewModel);
            }
            catch (Exception ex) 
            {
                TempData["Warning"] = ex.Message;
                return RedirectToAction("Login" , "Authentication");
            }
           
       
        }


        public IActionResult Comment(int postId) 
        {
            if (LocalStorage.AuthorLoginId == 0)
            {
                return RedirectToAction("Login", "Authentication");
            }

            try
            {
                List<CommentDto> commentDtos=commentAppService.GetByPostId(postId);
                return View(commentDtos);
            }
            catch (Exception ex) 
            {
                TempData["Warning"] = ex.Message;
                return RedirectToAction("Index", "Author");
            }
            
        }

        [HttpPost]
        public IActionResult ChangeCommentStatus(int commentId, int postId, StatusEnum status) 
        {

            if (LocalStorage.AuthorLoginId == 0)
            {
                return RedirectToAction("Login", "Authentication");
            }

            try
            {
                int result= commentAppService.ChangeStatus(commentId, postId, status);
                if (result<0)
                {
                    TempData["Warning"] = "خطایی رخ داده دوباره تلاش کنید.";
                    return RedirectToAction("Index", "Author");
                }
                if (result > 0) 
                {
                    TempData["Success"] = "تغییر با موفقیت انجام شد";
                }

            }
            catch (Exception ex) 
            {
                TempData["Warning"] = ex.Message;
                return RedirectToAction("Index", "Author");
            }
            return RedirectToAction("Index", "Author");

        }
    }
}
