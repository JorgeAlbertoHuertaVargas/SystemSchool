using DocumentFormat.OpenXml.Math;
using Entities.Entities;
using Logic.AlumnoLogic;
using Logic.ApoderadoLogic;
using Logic.APPLogic;
using Logic.DegreLogic;
using Logic.SectionLogic;
using Logic.UserLogic;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Language;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AlumnoController : Controller
    {
        APPLogic applogic = new APPLogic();
        private readonly AlumnoLogic alumnos = new AlumnoLogic();
        private readonly SectionLogic section = new SectionLogic();
        private readonly DegreeLogic grado = new DegreeLogic();
        private readonly ApoderadoLogic apoderados = new ApoderadoLogic();
        private readonly UserLogic usuarios = new UserLogic();
        public IActionResult Registrar()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return View(alumnos.GetAlumnos());
        }

        //PETICION POST A URL :https://eldni.com/pe/buscar-por-dni
        [HttpPost]
        public async Task<string> Consulta_DNIAsync(String DNItext)
        {

            Task<String> resp = (Task<string>)applogic.ConsultarDNIAsync(DNItext);

            String result = await resp;
            return result;
        }

        [HttpPost]
        public IActionResult Registrar(Alumno alumno)
        { 
            try
            {
                if (ModelState.IsValid)
                {

                    alumnos.AddAlumno(alumno);
                    return RedirectToAction("Registrar");
                }

                return View();
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        [HttpGet]
        public IActionResult DeleteAlumnos(int idAlumno) 
        {
            try
            {
                var Alumno = alumnos.DeleteAlumno(idAlumno);

                return RedirectToAction("Listar");

            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        [HttpPost]
        public ActionResult ExistenciaName(string nombres)  
        {
            try
            {
                var Alumno = alumnos.ExistenciaNombre(nombres);

                return Json(Alumno);
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        public ActionResult GetAlumnoById(int id)
        {
            var Alumno = alumnos.GetAlumnoById(id);
            return Json(Alumno);
        }


        public ActionResult GetFilterAlumno(int id_grado, int id_seccion, string name, string correo, string codigo)
        {
            var Alumnos = alumnos.GetFilterAlumno(id_grado,id_seccion,name,correo,codigo);
            return Json(Alumnos);
        }


        [HttpGet]
        public IActionResult ListarSeccion()
        {
            return Json(section.GetAllSections());

        }

        [HttpGet]
        public IActionResult ListarGrado()
        {
            return Json(grado.GetDegreeList());

        }


        [HttpPost]
        public IActionResult RegistrarApoderado(Apoderado apoderado)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    apoderados.AddApoderado(apoderado);
                    return RedirectToAction("Registrar");
                }

                return View();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public IActionResult ObtenerApoderado()
        {
            return Json(apoderados.GetApoderados());
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuarios.AgregarUsuario(user);
                    return RedirectToAction("Registrar");
                }

                return View();
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }


        [HttpGet]
        public IActionResult ObtenerUsario()
        {
            return Json(usuarios.GetUsuarios());
        }



    }
}
