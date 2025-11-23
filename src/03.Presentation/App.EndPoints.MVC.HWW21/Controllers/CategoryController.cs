using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Create()
        {
            if (LocalStorage.AuthorLoginId==0)
            {
                return RedirectToAction("Login" , "Authentication");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryViewModel createCategoryViewModel)
        {
            CreateCategoryDto category = new CreateCategoryDto() 
            {
               Name = createCategoryViewModel.Name,
               AuthorId = LocalStorage.AuthorLoginId
            };
            return View();
        }
    }
}
