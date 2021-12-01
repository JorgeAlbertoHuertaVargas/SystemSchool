
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Logic.DegreLogic;
using System;
using Presentation.Filters;

namespace Presentation.Controllers
{
    [AuthorizeUser]
    public class DegreesController : Controller
    {
        private readonly DegreeLogic _CapaLogicDegre = new DegreeLogic();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Seting()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetDegree()
        {
            try
            {
                if (_CapaLogicDegre.GetDegreeList() != null)
                {
                    return Json(_CapaLogicDegre.GetDegreeList());

                }
                return Json(0);

            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }
        }


        [HttpPost]
        public IActionResult ShowDegree(Degree degree)
        {
            try
            {
                if (_CapaLogicDegre.GetSingleDegree(degree.IdDegree) != null)
                {
                    return Json(_CapaLogicDegre.GetSingleDegree(degree.IdDegree));
                }
                return Json(0);
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }
        }


        [HttpGet]
        public IActionResult GetLevel()
        {
            try
            {
                if (_CapaLogicDegre.GetLevelsList() != null)
                {
                    return Json(_CapaLogicDegre.GetLevelsList());

                }
                return Json(0);
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }
        }


        public IActionResult DeleteDegree(int IdDegree)
        {
            try
            {
                if (IdDegree == 0)
                {
                    return Json(0);
                }
                else
                {
                    return Json(_CapaLogicDegre.DeleteDegreAll(IdDegree));
                }

            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }
        }


        [HttpPost]
        public IActionResult RegistrarGrados(Degree DegreeToEdit)
        {
            try
            {
                if (DegreeToEdit.NumStudent < 0 || DegreeToEdit.NumStudent == 0)
                {
                    return Json(null);
                }
                if (DegreeToEdit.DegreeName == null || DegreeToEdit.DegreeDateCreated == null || DegreeToEdit.LevellId == 0)
                {
                    return Json(null);
                }
                if (CheckNameDegre(DegreeToEdit.DegreeName))
                {

                    return Json(true);
                }
                else
                {
                    return Json(_CapaLogicDegre.CreatDegreeAll(DegreeToEdit));
                }
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }

        }



        public bool CheckNameDegre(string degreeName)
        {
            try
            {
                if (_CapaLogicDegre.CheckNomberNoExists(degreeName))
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
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }
        }


        // [HttpPut]
        public IActionResult UpdateDegree(Degree degree)
        {
            try
            {
                if (degree.NumStudent < 0 || degree.NumStudent == 0)
                {
                    return Json(null);
                }
                if (degree.DegreeName == null || degree.DegreeDateCreated == null || degree.LevellId == 0)
                {
                    return Json(null);
                }
                else
                {
                    return Json(_CapaLogicDegre.UpdateDegreeAll(degree));
                }
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to mostrar data.", error);
            }

        }


    }
}
