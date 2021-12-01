using Data.DataContext;
using Data.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions
{
    public class AlumnoFunctions:IAlumno
    {
        public Alumno AddAlumno(Alumno alumno)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                context.Alumnos.Add(alumno);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return alumno;
        }

        public List<Alumno> GetAlumno()
        {
            List<Alumno> alumnos = new List<Alumno>();
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                alumnos = context.Alumnos.Include(sh=>sh.Degree ).Include(sh=>sh.Sections).ToList();
                
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al extraer datos.", error);
            }
            return alumnos;

        }

        public bool DeleteAlumno(int id)
        {
            bool confirmar = false;
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var result = context.Alumnos.SingleOrDefault(p => p.IdAlumno == id);

                if (result != null)
                {
                    confirmar = true;
                    context.Alumnos.Remove(result);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al eliminar Alumno: ", error);
            }

            return confirmar;
        }

        public Alumno GetAlumnoById(int id)
        {
            Alumno alumno = new Alumno();
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var result = context.Alumnos.SingleOrDefault(p=>p.IdAlumno==id);
                if (result != null)
                {
                    alumno = result;
                }
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al buscar Id Level", error);
            }

            return alumno;
        }

        public Alumno GetFilterAlumno(int id_grado, int id_seccion, string name, string correo, string codigo)
        {
            Alumno alumnos = new Alumno();
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var result = context.Alumnos.SingleOrDefault(p => p.IdDegrees == id_grado || p.IdSections==id_seccion || p.Nombres==name || p.Correo==correo || p.Codigo==codigo);
                if (result != null)
                {
                    alumnos = result;
                }
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al buscar Id Level", error);
            }

            return alumnos;

        }



        public bool ExistenciaName(string NameAlumno)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var result = (from NameEx in context.Alumnos.AsNoTracking()
                              where NameEx.Nombres == NameAlumno 
                              select NameEx ).Any();
                if (result)
                {
                    return result;
                }
                return result;
            }
            catch (Exception error)
            {
                throw new Exception("Failed to delet data.", error);
            }
        }

    }
}
