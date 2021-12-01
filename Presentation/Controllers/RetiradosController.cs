using Entities.Entities;
using Logic.RetiradosLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class RetiradosController : Controller
    {

        public readonly RetiradosLogic Retirado = new RetiradosLogic();
        public IActionResult Index()
        {

            try
            {
                if (Retirado.GetRetirados() != null)
                {
                    ViewBag.ErrorMessage = "No hay ninguna sección agregada";
                    return View(Retirado.GetRetirados());

                }
                else
                {
                    ViewBag.ErrorMessage = "No hay ninguna sección agregada";
                    return View();
                }

            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        [HttpPost]
        public IActionResult RegistrarRetirados(Retirado retirados)
        {
            try
            {
                if (ModelState.IsValid)
                {

                  var retir= Retirado.AddRetirados(retirados);
                    return Json(retir);
                }

                return View();
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }


    }
}
