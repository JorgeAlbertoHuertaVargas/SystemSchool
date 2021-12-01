using Data.Functions;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.CourseLogic
{
    public class CourseLogic
    {
        CourseFuctions CapadeDatosCurso = new CourseFuctions();

        public List<Course> GetCursosListar()
        {
            try
            {
                return CapadeDatosCurso.GetCursosAll();
            }
            catch (Exception ex)

            {
                throw new("Failed extraerd data!.", ex);
            }
        }

        public int CreatCursos(Course cursos)
        {
            try
            {
                return CapadeDatosCurso.RegistrarCurso(cursos);
            }

            catch (Exception ex)
            {
                throw new Exception("Failed to insert data.", ex);
            }
        }

        public bool CheckNomberNoExists(string degreeName)
        {
            try
            {
                return CapadeDatosCurso.CheckNameNoExists(degreeName);
            }

            catch (Exception ex)
            {
                throw new Exception("Failed to comprobate.", ex);
            }
        }

        public object showCurses(int idcurso)
        {
            try
            {
                return CapadeDatosCurso.ShowCurses(idcurso);
            }
            catch (DataException e)
            {
                throw new("Failed to insert data.", e);
            }
            catch (Exception ex)
            {
                throw new("Failed to insert data.", ex);
            }
        }

        public List<Course> SelecDeCursos()
        {
            try
            {
                return (List<Course>)CapadeDatosCurso.SelecDeCursos();
            }
            catch (Exception ex)

            {
                throw new("Failed extraerd data!.", ex);
            }
        }

        public int DeleteCourses(int Idcurso)
        {
            try
            {
                return CapadeDatosCurso.DeleteCurso(Idcurso);
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al Al Eliminar", error);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Eliminar data.", ex);
            }
        }

        public int UpdateCourses(Course cursos)
        {
            try
            {
                return CapadeDatosCurso.UpdateCurso(cursos);
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al actualizar datos", error);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Actualizar data.", ex);
            }
        }
        
    }
}
