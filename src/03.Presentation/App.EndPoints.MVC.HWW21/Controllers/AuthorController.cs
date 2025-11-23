using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Dtos.PostAgg;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class AuthorController(ICategoryAppService categoryAppService 
        , IPostAppService postAppService) : Controller
    {
      
        public IActionResult Index()
        {
            
            if(LocalStorage.AuthorLoginId==0)
            {
                return RedirectToAction("Login", "Authentication");
            }

            List<CategoryDto> categoryDtos = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
            List<PostDto> postDtos = postAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);

            AuthorDashboardViewModel authorDashboardViewModel = new AuthorDashboardViewModel() 
            {
                CategoryDtos = categoryDtos,
                PostDtos = postDtos,
            };

            return View(authorDashboardViewModel);
        }
    }
}
