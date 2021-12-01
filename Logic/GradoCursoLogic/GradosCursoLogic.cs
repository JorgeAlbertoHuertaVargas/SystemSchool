using Data.Functions;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.GradoCursoLogic
{
   public class GradosCursoLogic
    {
        GradosCursoFuctions CapadeDatos = new GradosCursoFuctions();

        public int Registrar(int gradoid, string cursos)
        {
            try
            {

                return CapadeDatos.RegistrarGradosCurso(gradoid, cursos);
            }
            catch (Exception error)
            {
                throw new Exception("Fallo al insert datos.", error);
            }
        }




        public List<GradosCurso> GetGardoCursosListar(int idDegree)
        {
            
            try
            {
                
                return CapadeDatos.GetGradosCurso(idDegree);
                
            }
            catch (Exception error)
            {
                throw new Exception("Fallo al extraer datos.", error);
            }
        }

        public int QuitarGardoCursos(int idCouse)
        {
            try
            {
                return CapadeDatos.QuitarGradosCurso(idCouse);
            }
            catch (Exception error)
            {
                throw new Exception("Fallo al Qiut datos.", error);
            }
        }

        //*****************************************************

        //public List<GradosCurso> GetCourseByIdDegree(int id)
        //{
        //    return CapadeDatos.GetCourseByIdDegree(id);
        //}

    }
}
