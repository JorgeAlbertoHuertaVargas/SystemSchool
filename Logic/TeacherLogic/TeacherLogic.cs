using Entities.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Functions;

namespace Logic.TeacherLogic
{
    public class TeacherLogic
    {
        private readonly ITeacher _teacher = new TeacherFunctions();

        //Obtener todo los datos de los docentes
        //registrados
        public List<Teacher> GetAllTeacher()
        {
            try
            {
                return _teacher.GetAllTeacher();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al traer los datos del maestro", e);
            }
        }
        //Agregar docente
        public Teacher AddTeacher(Teacher teacher)
        {
            try
            {
                return _teacher.AddTeacher(teacher);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al agregar los datos del maestro", e);
            }

        }
        //Obtener datos del docente mediante el id.
        public Teacher GetTeacher(int idteacher)
        {
            try
            {
                return _teacher.GetTeacher(idteacher);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al extraer los datos del maestro", e);
            }

        }
        //Modificar docente.
        public bool Edit(Teacher teacher)
        {
            try
            {
                return _teacher.Edit(teacher);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al editar los datos del maestro", e);
            }

        }
        //Eliminar docente.
        public bool Eliminar(int id)
        {
            try
            {
                return _teacher.DeleteTeacher(id);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al eliminar el maestro", e);
            }

        }

    }
}
