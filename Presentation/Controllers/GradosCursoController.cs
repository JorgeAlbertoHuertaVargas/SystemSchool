using Entities.Entities;
using Logic.GradoCursoLogic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.Controllers
{
    public class GradosCursoController : Controller
    {
        private readonly GradosCursoLogic _CapaLogica = new GradosCursoLogic();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Post(int Gradoid, String Cursos)
        {
            try
            {
                if (Cursos != null)
                {
                    return Json(_CapaLogica.Registrar(Gradoid, Cursos));
                }
                return Json(null);
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }
        }

        [HttpPost]
        public IActionResult GetGradoCursosLista(int idDegree)
        {
            try
            {
                if (idDegree > 0)
                {
                    return Json(_CapaLogica.GetGardoCursosListar(idDegree));
                }
                return Json(null);

            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }
        }

        [HttpPost]
        public IActionResult QuitarCursoGrado(int idCouse)
        {
            try
            {
                if (idCouse > 0)
                {
                    return Json(_CapaLogica.QuitarGardoCursos(idCouse));
                }
                return Json(null);

            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to Quit data.", error);
            }
        }
    }
}
