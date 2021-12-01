using Entities.Entities;
using Logic;
using Logic.ParametersSystemLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Language;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class LevellController : Controller
    {
        //private LevellLogic level = new LevellLogic();

        private LevellLogic level;

        public LevellController(LevellLogic levellLogic)
        {
            level = levellLogic;
        }


        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Json(level.GetAllLevels());

        }


        [HttpGet]
        public ActionResult Crear()
        {

            //ViewBag.LanguageButtons = new LanguageModelButtons().GetLanguageForView();

            return View();
        }


        [HttpPost]

        public IActionResult Crear(Levell levell)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    level.AddLevel(levell);

                    TempData["Mensaje"] = "Successfully";

                    return RedirectToAction("Crear");

                }

                return View();


            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }


        }

        public ActionResult GetLevel(int id)
        {
            var Level = level.GetLevelById(id);

            return Json(Level);
        }


        [HttpPost]
        public ActionResult EditLevel(Levell levell)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var Level=level.UpdateLevel(levell);

                    return Json(Level);
                }
                else
                {

                    ModelState.AddModelError("","De de ingresar un nombre a la Nivel");
                    return View();

                }

            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
        
            }
        }


        public IActionResult DeletLevel(int id)
        {
            try
            {
                var Nivel = level.DeleteLevelById(id);

                return Json(Nivel);
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }


    }
}
