using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IGradosCurso
    {
        int RegistrarGradosCurso(int gradoid, string cursos);
       int QuitarGradosCurso(int idCouse);
       List<GradosCurso> GetGradosCurso(int idgrado);

        List<GradosCurso> GetCourseByIdDegree(int id);
    }
}
