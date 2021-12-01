using Logic.CalendarioLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class Bienvenido : Controller
    {

        public readonly CalendarioLogic calendario = new CalendarioLogic();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Map()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ListarCalendario()
        {
            return Json(calendario.GetCalendario());
        }

    }
}
