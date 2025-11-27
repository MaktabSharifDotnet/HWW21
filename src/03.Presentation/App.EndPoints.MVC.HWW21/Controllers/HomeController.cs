using App.Domain.AppServices.CategoryAgg;
using App.Domain.AppServices.CommentAgg;
using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Dtos.CommentAgg;
using App.Domain.Core.Dtos.PostAgg;
using App.EndPoints.MVC.HWW21.Extentions;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class HomeController(IPostAppService _postAppService
        , ICategoryAppService categoryAppService, ICommentAppService commentAppService) : Controller
    {

        public IActionResult Index(int? categoryId)
        {
            
            List<PostInfoDto> postInfoDtos = _postAppService.GetAll(categoryId);

            var categories = categoryAppService.GetAll();
            ViewBag.Categories = categories;

            return View(postInfoDtos);
        }

        public IActionResult Comment(int postId)
        {
            try
            {
                
                List<CommentDto> commentDtos = commentAppService.GetApprovedByPostId(postId);

                ViewBag.PostId = postId;

                return View(commentDtos);
            }
            catch (Exception ex)
            {
                TempData["Warning"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

       
        public IActionResult CreateComment(int postId) 
        {

            CreateCommentViewModel createCommentViewModel = new CreateCommentViewModel();
            createCommentViewModel.PostId = postId;
            return View(createCommentViewModel);
        }

        [HttpPost]
        public IActionResult CreateComment(CreateCommentViewModel createCommentViewModel) 
        {

            if (!ModelState.IsValid)
            {
                return View(createCommentViewModel);
            }

            bool isvalid= createCommentViewModel.Email.IsValidEmail();
            if (!isvalid) 
            {
                TempData["Warning"] = "ایمیل نا معتبر است.";
                return View(createCommentViewModel);
            }


            CreateCommentDto commentDto = new CreateCommentDto() 
            {
               FullName = createCommentViewModel.FullName,
               Email  = createCommentViewModel.Email,
               Score = createCommentViewModel.Score,
               Text = createCommentViewModel.Text,
               PostId = createCommentViewModel.PostId,
            };

            int commentId= commentAppService.Create(commentDto);
            if (commentId<0)
            {
                TempData["Warning"] = "خطایی رخ داد دوباره تلاش کنید..";
                return View(createCommentViewModel);
            }

            return RedirectToAction("Comment", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}