using Data.DataContext;
using Data.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions
{
    public class LevellFunctions:Repository<Levell>,ILevell

    {
       public LevellFunctions(DatabaseContext databaseContext): base(databaseContext) { }
    

        public Levell AddLevel(Levell level)
        {
            try
            {
                _ = Insert(level);
            }
            catch (Exception error)
            {
                throw new DataException("Fallo al insertar datos.", error);
            }

            return level;
        }

        public List<Levell> GetAllLevels()
        {
            List<Levell> levels = new List<Levell>();

            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

                levels = context.levels.ToList();

     
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al extraer datos.", error);
            }

            return levels;
        }


        public bool UpdateLevel(Levell level)
        {
            bool confirmar = true;

            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

                var result = context.levels.SingleOrDefault(p => p.Id == level.Id);

                if (result != null)
                {
                    result.Id = level.Id;
                    result.Levelname = level.Levelname;
                    result.Turn = level.Turn;

                    context.SaveChanges();
                }
                else
                {
                    confirmar = false;
                }

            }
            catch (Exception error)
            {

                throw new DataException("Fallo al actualizar datos", error);
            }

            return confirmar;
        }

        public Levell GetLevelById(int id)
        {
            Levell level = new Levell();

            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

                var result = context.levels.SingleOrDefault(p => p.Id == id);

                if (result != null)
                {
                    level = result;
                }

            }
            catch (Exception error)
            {

                throw new DataException("Fallo al buscar Id Level", error);
            }

            return level;
        }

        public bool DeleteLevelById(int id)
        {
            bool confirmar = false;

            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);

                var result = context.levels.SingleOrDefault(p => p.Id == id);

                if (result != null)
                {
                    confirmar = true;
                    context.levels.Remove(result);
                    context.SaveChanges();
                }

            }
            catch (Exception error)
            {

                throw new DataException("Fallo al eliminar Level. ", error);
            }

            return confirmar;
        }

        public List<Levell> GetLevelByTurn(string turn)
        {
            List<Levell> level = new List<Levell>();
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var Turnos = db.levels.Where(u => u.Turn == turn);


                if (Turnos!=null)
                {
                    level = Turnos.ToList();
                    return level;
                }
            }
            catch (Exception error)
            {
                throw new Exception("Error al buscar el usuario", error);
            }
            return level;
        }


    }
}
