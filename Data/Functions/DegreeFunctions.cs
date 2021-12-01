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
    public class DegreeFunctions : IDegreeInterface
    {


        public DegreeFunctions()
        {

        }
        public List<Levell> levels { get; set; } = new List<Levell>();
        public List<Degree> Degrees { get; set; } = new List<Degree>();
        Degree Dergres = new Degree();

        public int CreateDegree(Degree degree)
        {
            try
            {
                if (degree == null)
                {
                    return 0;
                }
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                _ = degree.Levels == null;

                context.Degree.Add(degree);
                context.SaveChanges();

            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return degree.IdDegree;

        }

        public bool CheckNameNoExists(String DegreeName)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var result = (from NameEx in context.Degree.AsNoTracking()
                              where NameEx.DegreeName == DegreeName
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




        public int DeleteDegree(int IdDegree)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                Dergres = context.Degree.Include(sh => sh.Levels).SingleOrDefault(h => h.IdDegree == IdDegree);
                if (Dergres == null)
                {
                    return 0;
                }
                context.Degree.Remove(Dergres);
                context.SaveChanges();
                return Dergres.IdDegree;
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al extraer datos.", error);
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Failed to delet data.", error);
            }


        }

        public List<Levell> GetLevels()
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                levels = context.levels.ToList();
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al extraer datos.", error);
            }
            catch (Exception error)
            {
                throw new ArgumentNullException("Fallo al extraer datos.", error);
            }
            return levels;
        }

        public Degree GetDegree(int IdDegree)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                Dergres = context.Degree.Include(sh => sh.Levels).SingleOrDefault(p => p.IdDegree == IdDegree);
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al extraer datos.", error);
            }
            return Dergres;
        }
        public List<Degree> GetDegree()
        {
            try
            {

                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                Degrees = context.Degree.Include(sh => sh.Levels).ToList();
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al extraer datos.", error);
            }

            return Degrees;
        }

        public int UpdateDegree(Degree degree)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var ID = degree.IdDegree;
                Dergres = context.Degree.Include(sh => sh.Levels).FirstOrDefault(h => h.IdDegree == ID);

                if (Degrees == null)
                {
                    return 0;
                }

                Dergres.DegreeName = degree.DegreeName;
                Dergres.DegreeDateCreated = degree.DegreeDateCreated;
                Dergres.NumStudent = degree.NumStudent;
                Dergres.LevellId = degree.LevellId;
                context.SaveChanges();
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al actualizar datos", error);
            }
            return Dergres.IdDegree;
        }


        //**********************************************************************

        public List<Degree> GetDegreeByIdLevel(int id)
        {
            List<Degree> dgr = new List<Degree>();
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var Grados = db.Degree.Where(d => d.LevellId == id);


                if (Grados != null)
                {
                    dgr = Grados.ToList();
                    return dgr;
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error al buscar el usuario", error);
            }
            return dgr;
        }


    }
}
