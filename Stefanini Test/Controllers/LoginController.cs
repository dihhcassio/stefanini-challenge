using Stefanini_Test.Domain.Enums;
using Stefanini_Test.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stefanini_Test.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;
        public LoginController(IAuthService authService) {
            _authService = authService;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(string email, string password)
        {
            try
            {
                var user = _authService.GetUserAutenticated(email, password);
                Session["UserID"] = user.Id;
                Session["UserRole"] = user.Role;
                return RedirectToAction("Index", "Customer");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", "The email and / or password entered is invalid.Please try again.");
            }

            return View("Index");
        }
    }
}