using Data.DataContext;
using Data.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace Data.Functions
{
    public class CourseFuctions : ICourse
    {
        public List<Course> ListadeCursos { get; set; } = new List<Course>();
        Course cursos = new Course();

        public List<Course> GetCursosAll()
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                ListadeCursos = context.Courses.ToList();
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al extraer datos.", error);
            }

            return ListadeCursos;
        }
        public int RegistrarCurso(Course cursos)
        {
            try
            {
                if (cursos == null)
                {
                    return 0;
                }
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                context.Courses.Add(cursos);
                context.SaveChanges();

            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return cursos.IdCourse;
        }

        public bool CheckNameNoExists(String cursoNomb)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var result = (from NameEx in context.Courses.AsNoTracking()
                              where NameEx.CourseName == cursoNomb
                              select NameEx).Any();
                if (result)
                {
                    return result;
                }
                return result;
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to delet data.", error);
            }
        }

        public List<Course> SelecDeCursos()
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                ListadeCursos = (from item in context.Courses.AsNoTracking()
                                 select new Course()
                                 {
                                     IdCourse = item.IdCourse,
                                     CourseName = item.CourseName
                                 }).ToList();



            }
            catch (Exception error)
            {
                throw new DataException("Fallo al extraer datos.", error);
            }

            return ListadeCursos;
        }
        public Course ShowCurses(int idcurso)
        {
            try
            {

                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                cursos = context.Courses.SingleOrDefault(p => p.IdCourse == idcurso);
                if (cursos == null)
                {
                    Course c = new Course();
                    return c;
                }
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al extraer datos .", error);
            }
            return cursos;
        }

        public int UpdateCurso(Course cursos)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var ID = cursos.IdCourse;
                var cursosbd = context.Courses.FirstOrDefault(h => h.IdCourse == ID);

                if (cursos == null)
                {
                    return 0;
                }

                cursosbd.CourseName = cursos.CourseName;
                cursosbd.CourseDateCreated = cursos.CourseDateCreated;
                context.SaveChanges();
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Fallo al actualizar datos", error);
            }
            return cursos.IdCourse;
        }

        public int DeleteCurso(int Idcurso)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                cursos = context.Courses.SingleOrDefault(h => h.IdCourse == Idcurso);
                if (cursos == null)
                {
                    return 0;
                }
                context.Courses.Remove(cursos);
                context.SaveChanges();
                return cursos.IdCourse;
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al Eliminar datos.", error);
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed  delet data.", error);
            }

        }

        //*****************************************************
        
    }
}
