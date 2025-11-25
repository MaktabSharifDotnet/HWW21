using App.Domain.AppServices.CategoryAgg;
using App.Domain.Core.Contracts.CategoryAgg.AppService;
using App.Domain.Core.Contracts.PostAgg.AppService;
using App.Domain.Core.Dtos.PostAgg;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class HomeController(IPostAppService _postAppService , ICategoryAppService categoryAppService ) : Controller
    {
        

        public IActionResult Index(int? categoryId)
        {

            List<PostInfoDto> postInfoDtos= _postAppService.GetAll(categoryId);

            var categories = categoryAppService.GetAll();
            ViewBag.Categories = categories;

            return View(postInfoDtos);
        }


     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
