using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Dtos.PostAgg;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.HWW21.Extentions;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class PostController(IPostAppService postAppService , ICategoryAppService categoryAppService) : Controller
    {
        public IActionResult Create()
        {
            if (LocalStorage.AuthorLoginId == 0) 
            {
               return RedirectToAction("Login" , "Authentication");
            }

            var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePostViewModel createPostViewModel)
        {
            if (!ModelState.IsValid)
            {
                var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View(createPostViewModel);
            }

            try
            {
                string? imagePath =createPostViewModel.ImagePost.UploadFile("Posts");

                CreatePostDto createPostDto = new CreatePostDto() 
                {
                   Title = createPostViewModel.Title,
                   Description = createPostViewModel.Description,
                   CreatedAt = DateTime.Now,
                   ImagePost = imagePath,
                   AuthorId = LocalStorage.AuthorLoginId,
                   CategoryId = createPostViewModel.CategoryId,
                };

               int postId= postAppService.Create(createPostDto);
                if (postId>0)
                {
                    TempData["Success"] = "پست با موفقیت اضافه شد.";
                    return RedirectToAction("Index", "Author");
                }
                var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                TempData["Warning"] = "فرآیند ایجاد پست با خطا مواجه شد دوباره تلاش کنید.";
                return View(createPostViewModel);
            }
            catch (Exception ex) 
            {
                var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                TempData["Warning"] = "فرآیند ایجاد پست با خطا مواجه شد دوباره تلاش کنید.";
                return View(createPostViewModel);
            }
            
        }
    }
}
