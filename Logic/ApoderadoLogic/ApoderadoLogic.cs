using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ApoderadoLogic
{
    public class ApoderadoLogic
    {
        private readonly IApoderado _apoderado = new Data.Functions.ApoderadoFunctions();

        public Apoderado AddApoderado(Apoderado apoderado)
        {
            try
            {
                return _apoderado.AddApoderado(apoderado);
            }
            catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }


        public List<Apoderado> GetApoderados()
        {
            try
            {
                return _apoderado.GetApoderados();
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }
    }
}
