using App.Domain.Core.Contracts.AuthorAgg.AppService;
using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Dtos.AuthorAgg;
using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Dtos.PostAgg;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class AuthorController(ICategoryAppService categoryAppService 
        , IPostAppService postAppService , IAuthorAppService authorAppService) : Controller
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
    }
}
