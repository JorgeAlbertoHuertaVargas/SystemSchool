using Entities.Entities;
using Logic;
using Logic.GradoCursoLogic;
using Logic.DegreLogic;
using Logic.TeacherLogic;
using Logic.UserLogic;
using Microsoft.AspNetCore.Mvc;
using Presentation.Extensions;
using System;
using System.Data;
using Logic.SectionLogic;
using Logic.AssignTLDCSLogic;

namespace Presentation.Controllers
{
    public class TeacherController : BaseController
    {
        private readonly TeacherLogic _tea = new TeacherLogic();
        private readonly UserLogic _user = new UserLogic();
        private Teacher _teacher = new Teacher();
        private readonly DegreeLogic _degree = new DegreeLogic();
        private readonly GradosCursoLogic _gradoSeccion = new GradosCursoLogic();
        private readonly SectionLogic _section = new SectionLogic();
        private readonly AssignTLDCSLogic _assign = new();

        private readonly LevellLogic lvl;

        public TeacherController(LevellLogic levellLogic)
        {
            lvl = levellLogic;
        }
        //Vista principal del modulo docente
        public ActionResult Index()
        {
            return View();
        }
        //Obtener todo los maestros registrados.
        [HttpGet]
        public ActionResult GetAllTeacher()
        {
            return Json(_tea.GetAllTeacher());
        }
        //Vista para agregar docente.
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //Agregar docente a la base de datos
        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            try
            {
                _tea.AddTeacher(teacher);
                return View();

            }
            catch (Exception error)
            {
                throw new DataException("Fallo al Agregar Datos del Maestro.", error);
            }
        }
        //Obtener un docente mediante el id.
        public ActionResult GetTeacher(int idtea)
        {
            var te = _tea.GetTeacher(idtea);
            return Json(te);
        }

        //Modificar docente.
        [HttpPost]
        public ActionResult Edit(Teacher teac)
        {
            bool confirm = _tea.Edit(teac);
            return Json(confirm);
        }

        //Agregar usuario
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _user.AgregarUsuario(user);
                    return RedirectToAction("Index", "Teacher");
                }

                return View();
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }
        }
        //Validar usuario, para que no exista duplicidad
        //de usuario.
        [HttpPost]
        public ActionResult ValidationUser(string code, string user)
        {
            var resp = _user.validauser(code, user);
            return Json(resp);
        }

        //Buscador de usuario.
        public IActionResult GetUser()
        {
            return Json(_user.GetUsuarios());
        }

        //Eliminar usuario.
        public ActionResult Delete(int id)
        {
            var user = _tea.GetTeacher(id);
            var iduser = user.UserIdUser;
            bool confirm = _tea.Eliminar(id);
            if (confirm)
            {
                _user.Delete(iduser);
            }
            return RedirectToAction("Index");
        }

        //***************************************
        //Agregar asignación al docente.
        [HttpGet]
        public IActionResult GetGradosCurso(int idDegree)
        {
            var cour = _gradoSeccion.GetGardoCursosListar(idDegree);
            return Json(cour);
        }
        //Obtener toda las secciones.
        [HttpGet]
        public ActionResult GetAllSection()
        {
            return Json(_section.GetAllSections());
        }
        //Obtener grado mediante el id de nivel.
        [HttpGet]
        public IActionResult GetDegreeByIdLevel(int id)
        {
            var degr = _degree.GetDegreeByIdLevel(id);

            return Json(degr);
        }
        //Obtener nivel mediante el nombre del turno.
        [HttpGet]
        public IActionResult GetLevelByTurn(string turn)
        {
            var level = lvl.GetLevelByTurn(turn);
            return Json(level);
        }
        //Vista de asignación del docente, con datos
        //incluidos del docente.
        [HttpGet]
        public ActionResult Assign(int idTeacher)
        {
            _teacher = new Teacher();
            _teacher = _tea.GetTeacher(idTeacher);
            var idteacher = _teacher.IdTeacher;
            var nameTeacher = _teacher.FirstName;
            ViewData["id"] = idteacher;
            ViewData["name"] = nameTeacher;
            ViewData["lastname"] = _teacher.LastName;
            return View();
        }
        //Agregar asignación al docente.
        [HttpPost]
        public ActionResult AddAssignTeacher(AssignTLDCS LDCS)
        {
            var a = _assign.AddTeacher(LDCS);
            return Json(a);
        }
        //Eliminar asignacion del docente.
        public ActionResult DeleteAssign(int id)
        {
            bool confirm = _assign.DeleteAssign(id);

            return Json(confirm);
        }
        //Obtener toda las asignaciones del docente.
        [HttpGet]
        public ActionResult GetAllAssignTeacher(int id)
        {
            return Json(_assign.GetAllAssignTeacher(id));
        }

    }
}
