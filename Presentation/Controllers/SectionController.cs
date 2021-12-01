using Entities.Entities;
using Logic.SectionLogic;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;
using System;
using System.Data;

namespace Presentation.Controllers
{

    public class SectionController : BaseController
    {
        private readonly SectionLogic secs = new SectionLogic();

        //GET:Section
        public ActionResult Index()
        {

            return View();

        }

        [HttpGet]
        public IActionResult GetAllSection()
        {
            return Json(secs.GetAllSections());

        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Section section)
        {
            try
            {
                if (section.SectionName == null)
                {
                    ModelState.AddModelError("", "Debe ingresar un nombre a la Sección");
                    return View("Index", section);
                }
                else
                {
                    if (section.Detail == null)
                    {
                        section.Detail = "----------------";
                        secs.AddSections(section);
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        secs.AddSections(section);
                        BasicNotification("Se a agregado con exito la sección", NotificationType.Success, "Correcto!");
                        return RedirectToAction("Index");
                    }
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Ocurrio un error al agregar una sección");
                return View(section);
            }

        }

        public ActionResult GetSection(int idsection)
        {

            var sec = secs.GetSection(idsection);
            return Json(sec);
        }

        [HttpPost]
        public ActionResult Edit(Section sec)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var Level = secs.Edit(sec);
                    return Json(sec);
                }
                //ModelState.AddModelError("", "Debe ingresar un nombre a la Sección");
                else
                {

                    ModelState.AddModelError("", "De de ingresar un nombre a la Nivel");
                    return View();

                }

            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);

            }



        }

        public ActionResult Delete(int id)
        {
            var delet = secs.Eliminar(id);
            return Json(delet);
        }



    }
}
