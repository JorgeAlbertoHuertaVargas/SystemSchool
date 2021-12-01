using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.AlumnoLogic
{
    public class AlumnoLogic
    {
        private readonly IAlumno _alumno = new Data.Functions.AlumnoFunctions();

        public Alumno AddAlumno(Alumno alumno)
        {
            try
            {
                return _alumno.AddAlumno(alumno);
            }
            catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }

        public List<Alumno> GetAlumnos()
        {
            try
            {
                return _alumno.GetAlumno();
            }
            catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }

        public bool DeleteAlumno(int id)
        {
            try
            {
                return _alumno.DeleteAlumno(id);

            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        public Alumno GetAlumnoById(int id)
        {
            try
            {
                return _alumno.GetAlumnoById(id);
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }


        public Alumno GetFilterAlumno(int id_grado, int id_seccion, string name, string correo, string codigo)
        {

            try
            {
                return _alumno.GetFilterAlumno(id_grado,id_seccion,name,correo,codigo);
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        public bool ExistenciaNombre(string NameAlumno)
        {
            try
            {
                return _alumno.ExistenciaName(NameAlumno);
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }
    }
}
