using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public  interface ICourse
    {
       

        List<Course> GetCursosAll();
        Course ShowCurses(int idcurso);
        int RegistrarCurso(Course cursos);
        bool CheckNameNoExists(String cursoNomb);

        List<Course> SelecDeCursos();

        int UpdateCurso(Course cursos);
        int DeleteCurso(int Idcurso);
        
    }
}
