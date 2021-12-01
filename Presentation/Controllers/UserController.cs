using Entities.Entities;
using Logic.UserLogic;
using Logic.RoleLogic;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserLogic uss = new UserLogic();
        private readonly RoleLogic rol = new RoleLogic();
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = rol.GetAllRole();
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            uss.AddUser(user);
            ViewBag.SuccessMessage = "Se registro con exito";
            BasicNotification("Se a agregado con exito la sección", NotificationType.Success, "Correcto!");
            return View();
        }


    }
}
