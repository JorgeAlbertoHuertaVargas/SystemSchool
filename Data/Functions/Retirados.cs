using Data.DataContext;
using Data.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Functions
{
    public class Retirados: IRetirados
    {
        public Retirado AddRetirados(Retirado retirado)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                context.Retirados.Add(retirado);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return retirado;
        }

        public List<Retirado> GetRetirados()
        {
            List<Retirado> retirados = new List<Retirado>();
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                retirados = context.Retirados.Include(sh => sh.Degree).Include(sh => sh.Sections).ToList();
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return retirados;
        }

        public  bool DeleteRetirados(int id)
        {
            bool confirmar = false;

            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var result = context.Retirados.SingleOrDefault(p => p.Id == id);

                if (result != null)
                {
                    confirmar = true;
                    context.Retirados.Remove(result);
                    context.SaveChanges();
                }
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return confirmar;
        }
    }
}
