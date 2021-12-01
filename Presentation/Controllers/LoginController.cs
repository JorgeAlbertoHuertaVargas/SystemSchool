using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using Logic.UserLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {

        private readonly UserLogic _CapaLogicoUser = new UserLogic();



        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Validation(string Codigo, string Pass, int IdRoles)
        {
            try
            {
                if (Codigo != null || Pass != null || IdRoles != 0)
                {
                    return Json(_CapaLogicoUser.Validation(Codigo, Pass));

                }
                return Json(null);
            }
            
            catch (Exception error)
            {
                throw new Exception("Failed validations data.", error);
            }
        }

        [HttpPost]
        //[AllowAnonymous]
        public IActionResult SetCrearSesion(string UserName, string Codigo, string RoleName)
        {
            HttpContext.Session.SetString(AllSession.UserName, Convert.ToString(UserName));
            HttpContext.Session.SetString(AllSession.Codigo, Convert.ToString(Codigo));
            HttpContext.Session.SetString(AllSession.RoleName, Convert.ToString(RoleName));
            return Json(true);
        }

                 
        public IActionResult Logout()
        {
            try
            {
             
                HttpContext.Session.Clear();
                return RedirectToAction("Index","Login");

            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
