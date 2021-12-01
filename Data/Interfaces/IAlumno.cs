using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAlumno
    {
        Alumno AddAlumno(Alumno alumno);
        List<Alumno> GetAlumno();
        bool DeleteAlumno(int id);
        Alumno GetAlumnoById(int id);
        bool ExistenciaName(string NameAlumno);
        Alumno GetFilterAlumno(int id_grado, int id_seccion, string name, string correo, string codigo);
    }
}
