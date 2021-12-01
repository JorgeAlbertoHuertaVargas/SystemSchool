using Data.DataContext;
using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions
{
   public class ApoderadoFunctions: IApoderado
    {
        public Apoderado AddApoderado(Apoderado apoderado)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                context.Apoderados.Add(apoderado);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return apoderado;
        }


        public List<Apoderado> GetApoderados()
        {

            List<Apoderado> apoderados = new List<Apoderado>();

            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                apoderados = context.Apoderados.ToList();
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return apoderados;
        }
    }
}
