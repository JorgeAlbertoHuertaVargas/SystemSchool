using Entities.Entities;
using Logic.CalendarioLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly CalendarioLogic calendarios = new CalendarioLogic();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Calendario calendario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    calendarios.AddCalendario(calendario);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }



        [HttpGet]
        public ActionResult ListarCalendario()
        {
            return Json(calendarios.GetCalendario());
        }
    }
}
