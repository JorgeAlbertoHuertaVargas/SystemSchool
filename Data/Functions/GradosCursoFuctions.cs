using Data.DataContext;
using Data.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Data.Functions
{
    public class GradosCursoFuctions : IGradosCurso
    {
        public List<GradosCurso> Listgradocurso { get; set; } = new List<GradosCurso>();

        GradosCurso gradoscurso = new GradosCurso();

        public int RegistrarGradosCurso(int gradoid, string cursos)
        {

            if (gradoid < 0 || cursos == null) { return 0; }
            string s = cursos.ToString();
            string[] split = s.Split(",".ToCharArray());

            return RegistrarGradosCursoOk(gradoid, split);


        }


        public int RegistrarGradosCursoOk(int gradoid, string[] split)
        {
            try
            {
                for (int i = 0; i < split.Length; i++)
                {
                    if (split[i] != "")
                    {
                        using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                        gradoscurso = new(gradoid, int.Parse(split[i]));
                        context.GradosCurso.Add(gradoscurso);
                        context.SaveChanges();
                    }

                }
                return gradoscurso.GradosCursoId;
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Fallo al extraer datos.", error);
            }
        }

        public int QuitarGradosCurso(int idCouse)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                Listgradocurso = context.GradosCurso.Where(u => u.CoursesIdCourse == idCouse).Select(x => x).ToList();
                if (Listgradocurso == null)
                {
                    return 0;
                }
                context.GradosCurso.Remove(Listgradocurso[0]);
                context.SaveChanges();
                return Listgradocurso[0].CoursesIdCourse;
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Fallo al Quit datos.", error);
            }
        }

        public List<GradosCurso> GetGradosCurso(int idgrado)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                Listgradocurso = context.GradosCurso.Include(sh => sh.Courses).Where(u => u.Gradoid == idgrado).Select(x => x).ToList();
                if (Listgradocurso != null)
                {
                    return Listgradocurso;
                }
                return Listgradocurso;
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Fallo al extraer datos.", error);
            }
        }

        //**************************************************************
        public List<GradosCurso> GetCourseByIdDegree(int id)
        {
            List<GradosCurso> crs = new List<GradosCurso>();
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var Cursos = db.GradosCurso.Where(gd => gd.Gradoid == id);


                if (Cursos != null)
                {
                    crs = Cursos.ToList();
                    return crs;
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error al buscar el usuario", error);
            }
            return crs;
        }

    }
}
