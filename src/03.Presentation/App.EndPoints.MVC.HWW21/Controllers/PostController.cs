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

        public IActionResult Edit(int id) 
        {

            if (LocalStorage.AuthorLoginId == 0)
            {
                return RedirectToAction("Login", "Authentication");
            }
            try
            {
                UpdatePostInfoDto updatePostInfoDto = postAppService.GetById(id);
                var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
                ViewBag.Categories = new SelectList(categories, "Id", "Name", updatePostInfoDto.CategoryId);
                UpdatePostViewModel updatePostViewModel = new UpdatePostViewModel()
                {
                    PostId = updatePostInfoDto.Id,
                    Title = updatePostInfoDto.Title,
                    Description = updatePostInfoDto.Description,
                    ImagePostOld = updatePostInfoDto.ImagePost,
                    CategoryId = updatePostInfoDto.CategoryId,
                };

                return View(updatePostViewModel);
            }
            catch (Exception ex) 
            {
                TempData["Warning"] = ex.Message;
                return RedirectToAction("Index", "Author");
            }

  
        }


        [HttpPost]
        public IActionResult Edit(UpdatePostViewModel  updatePostViewModel) 
        {
            if (!ModelState.IsValid)
            {
                var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
                ViewBag.Categories = new SelectList(categories, "Id", "Name" , updatePostViewModel.CategoryId);
                return View(updatePostViewModel);
            }
            try 
            {
                UpdatePostInfoDto updatePostInfoDto = new UpdatePostInfoDto()
                {
                    Id = updatePostViewModel.PostId,
                    Title = updatePostViewModel.Title,
                    Description = updatePostViewModel.Description,
                    CreatedAt = DateTime.Now,
                    
                    AuthorId = LocalStorage.AuthorLoginId,
                    CategoryId = updatePostViewModel.CategoryId,
                };
                if (updatePostViewModel.ImagePost!=null)
                {
                    string newImagePath= updatePostViewModel.ImagePost.UploadFile("Posts")!;
                    updatePostInfoDto.ImagePost = newImagePath;
                }
                else 
                {
                    updatePostInfoDto.ImagePost = updatePostViewModel.ImagePostOld;
                }


               int result= postAppService.Edit(updatePostInfoDto);
                if (result < 0) 
                {
                    var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
                    ViewBag.Categories = new SelectList(categories, "Id", "Name", updatePostViewModel.CategoryId);
                    TempData["Warning"] = "فرآیند ادیت با خطا روبرو شد لطفا دوباره تلاش کنید";
                    return View(updatePostViewModel);
                }

                return RedirectToAction("index", "Author");
            }
            catch(Exception ex) 
            {
                var categories = categoryAppService.GetAllForAuthor(LocalStorage.AuthorLoginId);
                ViewBag.Categories = new SelectList(categories, "Id", "Name", updatePostViewModel.CategoryId);
                TempData["Warning"] = ex.Message;
                return View(updatePostViewModel);
            }
             
        }

    }
}
