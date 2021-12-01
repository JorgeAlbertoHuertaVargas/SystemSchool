using Data.Functions;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Logic.DegreLogic
{
    public class DegreeLogic
    {

        DegreeFunctions Degref = new DegreeFunctions();

        public List<Degree> GetDegreeList()
        {
            try
            {
                return Degref.GetDegree();
            }
            catch (Exception ex)

            {
                throw new("Failed extraerd data!.", ex);
            }


        }


        public Degree GetSingleDegree(int IdDegree)
        {
            try
            {
                return Degref.GetDegree(IdDegree);
            }
            catch (DataException e)
            {
                throw new("Failed to insert data.", e);
            }
            catch (Exception ex)
            {
                throw new("Failed to insert data.", ex);
            }
        }

        public List<Levell> GetLevelsList()
        {
            try
            {
                return Degref.GetLevels();
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al actualizar datos", error);
            }
            catch (Exception ex)
            {
                throw new("Failed to insert data.", ex);
            }
        }

        public int DeleteDegreAll(int idDegree)
        {
            try
            {
                return Degref.DeleteDegree(idDegree);
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al actualizar datos", error);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert data.", ex);
            }
        }

        public int UpdateDegreeAll(Degree degreeToEdit)
        {
            try
            {
                return Degref.UpdateDegree(degreeToEdit);
            }
            catch (DataException error)
            {
                throw new DataException("Fallo al actualizar datos", error);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert data.", ex);
            }
        }

        public int CreatDegreeAll(Degree degreeToEdit)
        {
            try
            {
                return Degref.CreateDegree(degreeToEdit);
            }
            catch (DataException me)
            {
                throw new DataException("Fallo al actualizar datos", me);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to insert data.", ex);
            }
        }

        public bool CheckNomberNoExists(string degreeName)
        {
            try
            {
                return Degref.CheckNameNoExists(degreeName);
            }
            catch (DataException me)
            {
                throw new DataException("Fallo al actualizar datos", me);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to comprobate.", ex);
            }
        }

        //***************************************************************
        public List<Degree> GetDegreeByIdLevel(int id)
        {
            return Degref.GetDegreeByIdLevel(id);
        }


    }
}
