using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Dtos.CategoryAgg;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class CategoryController(ICategoryAppService categoryAppService) : Controller
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
            if (!ModelState.IsValid)
            {
                return View(createCategoryViewModel);
            }
            CreateCategoryDto category = new CreateCategoryDto() 
            {
               Name = createCategoryViewModel.Name,
               AuthorId = LocalStorage.AuthorLoginId
            };
            try
            {
                int categoryId=categoryAppService.Create(category);
                if (categoryId<0)
                {

                    TempData["Warning"] = "فرآیند ایجاد دسته بندی با خطا مواجه شد دوباره تلاش کنید.";
                    return View(createCategoryViewModel);

                }
                
              
                return RedirectToAction("Index", "Author");
            }
            catch (Exception ex) 
            {
                TempData["Warning"]= ex.Message;
                return View(createCategoryViewModel);
            }
           
            
        }

        public IActionResult Edit(int categoryId) 
        {
            if (LocalStorage.AuthorLoginId==0)
            {
                return RedirectToAction("Login" ,"Authentication");
            }
            try
            {
                CategoryDto categoryDto = categoryAppService.GetById(categoryId);
                CreateCategoryViewModel createCategoryViewModel = new CreateCategoryViewModel() 
                {
                    Id = categoryId,
                   Name= categoryDto.Name,
                };
                return View(createCategoryViewModel);
            }
            catch (Exception ex) 
            {
                TempData["Warning"] = ex.Message;
                return RedirectToAction("index","Author");
            }
            
            
        }

        [HttpPost]
        public IActionResult Edit(CreateCategoryViewModel createCategoryViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(createCategoryViewModel);
            }
            try
            {
                CategoryDto categoryDto = new CategoryDto() 
                {
                   Id = createCategoryViewModel.Id,
                   Name = createCategoryViewModel.Name,
                };
               int result= categoryAppService.Edit(categoryDto);
                if (result<0)
                {
                    TempData["Warning"] = "خطایی رخ داد ، دوباره تلاش کنید.";
                    return View(createCategoryViewModel);
                }
            }
            catch (Exception ex) 
            {
                TempData["Warning"] = ex.Message;
                return View(createCategoryViewModel);
            }

            return RedirectToAction("Index","Author");
        }


        [HttpPost]
        public IActionResult Delete(int categoryId) 
        {
            if (LocalStorage.AuthorLoginId == 0)
            {
                return RedirectToAction("Login", "Authentication");
            }

            try
            {
               int result= categoryAppService.Delete(categoryId);
                if (result<0)
                {
                    TempData["Warning"] = "خطایی رخ داده دوباره تلاش کنید.";
                    return RedirectToAction("index", "Author");
                }
            }
            catch (Exception ex) 
            {
                TempData["Warning"] = ex.Message;
                return RedirectToAction("index", "Author");
            }

            return RedirectToAction("index" , "Author");
        }

    }
}
