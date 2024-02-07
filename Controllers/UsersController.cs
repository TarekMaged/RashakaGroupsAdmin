using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository;
using RashakaGroupsAdmin.Repository.Interfaces;
using RashakaGroupsAdmin.Repository.UniteOfWork;
using RashakaGroupsAdmin.Services;
using System.Security.Claims;

namespace RashakaGroupsAdmin.Controllers
{

    public class UsersController : Controller
    {
        readonly IRashakaUniteOfWork repo;
        readonly IGroupUser iGroupUser;
        private  IHttpContextAccessor _httpAccessor;
        readonly ILogin loginService;
        public UsersController(ILogin _loginService, IGroupUser _iGroupUser, IHttpContextAccessor httpContextAccessor)
        {
            loginService = _loginService;
            repo = new RashakaUniteOfWork();
            iGroupUser = _iGroupUser;
            _httpAccessor = httpContextAccessor;
        }

        public IActionResult Steps(int id)
        {
            try
            {
                return View(iGroupUser.GetUsersSteps(id));
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("adminGroups"))
                {
                    return RedirectToAction("index", "home");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(Login user, string returnUrl)
        {
            try
            {
                ViewData["ReturnUrl"] = returnUrl;
                bool res = loginService.Login(user);
                if (res == true)
                {
                    if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                    return Redirect("/");
                }
                //if (res == "notValidData")
                //{
                //    ViewBag.message = "بيانات غير مكتملة";
                //}
                ViewBag.message = "اسم المستخدم أو رمز المرور غير صحيح";
                return View();
            }
            catch
            {
                ViewBag.message = "حدث خطأ حاول مرة أخرى";
                return View();
            }
        }


        public IActionResult Logout()
        {
            _httpAccessor.HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }




    }
}