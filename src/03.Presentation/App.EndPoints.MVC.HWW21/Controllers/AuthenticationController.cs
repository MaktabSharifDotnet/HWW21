using App.Domain.Core.Contracts.AuthorAgg.AppService;
using App.Domain.Core.Entities;
using App.EndPoints.MVC.HWW21.Extentions;
using App.EndPoints.MVC.HWW21.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.MVC.HWW21.Controllers
{
    public class AuthenticationController(IAuthorAppService authorAppService) : Controller
    {
        
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthenticationViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            try
            {
                int authorId = authorAppService.Login(loginViewModel.Username, loginViewModel.Password);
                if (authorId<0)
                {
                    TempData["Warning"] = "خطایی رخ داد دوباره تلاش کنید .";
                    return View(loginViewModel);
                }
                LocalStorage.AuthorLoginId = authorId;

            }
            catch (Exception ex) 
            {
                TempData["Warning"]=ex.Message;
                return View(loginViewModel);
            }
         
            
            return RedirectToAction("Index" , "Author");
        }

        public IActionResult Register() 
        {

            return View();
         
        }

        [HttpPost]
        public IActionResult Register(AuthenticationViewModel authenticationViewModel) 
        {
            if (!ModelState.IsValid)
            {
                return View(authenticationViewModel);
            }
            string? profileImage = authenticationViewModel.ProfileImage.UploadFile("Profiles");
            try
            {
                int authorId=authorAppService.Register(authenticationViewModel.Username, authenticationViewModel.Password, profileImage);
                if (authorId < 0) 
                {
                    TempData["Error"] = "خطایی رخ داده دوباره تلاش کنید ";
                    return View(authenticationViewModel);
                }
                LocalStorage.AuthorLoginId = authorId;
            }
            catch (Exception ex) 
            {
                TempData["Error"] = ex.Message;
                return View(authenticationViewModel);
            }

            return RedirectToAction("Index", "Author");

        }

    }
}
