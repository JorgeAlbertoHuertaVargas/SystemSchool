using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.RetiradosLogic
{
    public class RetiradosLogic
    {
        private readonly IRetirados _retirados = new Data.Functions.Retirados();

        public Retirado AddRetirados(Retirado retirado)
        {
            try
            {
                return _retirados.AddRetirados(retirado);
            }
            catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }

        public List<Retirado> GetRetirados()
        {
            try
            {
                return _retirados.GetRetirados();
            }
            catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }

        public bool DeleteAlumno(int id)
        {
            try
            {
                return _retirados.DeleteRetirados(id);

            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }
    }
}
