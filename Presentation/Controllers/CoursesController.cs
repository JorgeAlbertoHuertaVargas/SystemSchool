using Entities.Entities;
using Logic.CourseLogic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Presentation.Controllers
{
    public class CoursesController : Controller
    {
         private readonly CourseLogic _CapalogicoCurso = new CourseLogic();

            public IActionResult Index()
            {

                return View();
            }

            //LISTAR CURSOS
            [HttpGet]
            public IActionResult GetCursosLista()
            {
                try
                {
                    if (_CapalogicoCurso.GetCursosListar() != null)
                    {

                        return Json(_CapalogicoCurso.GetCursosListar());
                    }

                    return Json(0);
                }
                catch (Exception error)
                {
                    throw new ArgumentNullException("Failed to extract  data.", error);
                }
            }

            //SHOW CURSOS
            [HttpPost]
            public IActionResult ShowCurso(Course cursos)
            {
                try
                {

                    if (cursos.IdCourse != 0)
                    {
                        return Json(_CapalogicoCurso.showCurses(cursos.IdCourse));
                    }

                    return Json(cursos.IdCourse);
                }
                catch (Exception error)
                {
                    throw new ArgumentNullException("Failed to mostrar data.", error);
                }

            }

            //ELIMINAR CURSO
            [HttpPost]
            public IActionResult CursoDelete(Course cursos)
            {
                try
                {
                    if (cursos.IdCourse > 0)
                    {
                        return Json(_CapalogicoCurso.DeleteCourses(cursos.IdCourse));
                    }

                    return Json(cursos.IdCourse);
                }
                catch (Exception error)
                {
                    throw new ArgumentNullException("Failed to delete course.", error);
                }
            }

            //SELCECT DE CURSOS
            [HttpPost]
            public IActionResult SelectCuersos()
            {
                try
                {
                    if (_CapalogicoCurso.SelecDeCursos() != null)
                    {
                        return Json(_CapalogicoCurso.SelecDeCursos());
                    }

                    return Json(0);
                }
                catch (Exception error)
                {
                    throw new ArgumentNullException("Failed to List data.", error);
                }
            }

            //REGISTAR CURSO
            [HttpPost]
            public IActionResult RegistrarCursos(Course cursos)
            {
                try
                {
                    if (cursos.CourseName == null || cursos.CourseDateCreated == null)
                    {
                        return Json(null);
                    }

                    if (CheckNameDegre(cursos.CourseName))
                    {

                        return Json(true);
                    }
                    else
                    {
                        return Json(_CapalogicoCurso.CreatCursos(cursos));
                    }
                }
                catch (Exception error)
                {
                    throw new ArgumentNullException("Failed to insert data.", error);
                }
            }

            //VERIFICAR NOMBRE DEL CURSO
            private bool CheckNameDegre(string cursoNomb)
            {
                try
                {
                    if (_CapalogicoCurso.CheckNomberNoExists(cursoNomb))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception error)
                {
                    throw new ArgumentNullException("No se pudo verificar el obj.", error);
                }
            }
            //ACTUALIZAR CURSOS
            public IActionResult UpdateCurso(Course cursos)

            {
                try
                {
                    if (cursos.CourseName == null || cursos.CourseDateCreated == null)
                    {
                        return Json(null);
                    }

                    if (CheckNameDegre(cursos.CourseName))
                    {

                        return Json(true);
                    }

                    else
                    {
                        return Json(_CapalogicoCurso.UpdateCourses(cursos));
                    }
                }
                catch (Exception error)
                {
                    throw new ArgumentNullException("Failed to Update data.", error);
                }

            }


        }


    }

