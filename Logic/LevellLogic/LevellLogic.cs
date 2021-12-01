using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LevellLogic : ILevellLogic
    {
        /// private readonly ILevell _level = new Data.Functions.LevellFunctions();

        private ILevell _level;

        public LevellLogic(ILevell levell)
        {
            _level = levell;
        }

        public Levell AddLevel(Levell level)
        {
            try
            {
                return _level.AddLevel(level);
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }

        }


        public List<Levell> GetAllLevels()
        {
            try
            {
                return _level.GetAllLevels();
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        public bool UpdateLevel(Levell level)
        {
            try
            {
                return _level.UpdateLevel(level);
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        public Levell GetLevelById(int id)
        {
            try
            {
                return _level.GetLevelById(id);
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        public bool DeleteLevelById(int id)
        {
            try
            {
                return _level.DeleteLevelById(id);

            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        
        public List<Levell> GetLevelByTurn(string turn)
        {
            return _level.GetLevelByTurn(turn);
        }



    }



    public interface ILevellLogic
    {
        Levell AddLevel(Levell level);
        List<Levell> GetAllLevels();
        bool UpdateLevel(Levell level);
        Levell GetLevelById(int id);
        bool DeleteLevelById(int id);

    }
}
