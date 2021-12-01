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
    public class CalendarioFunctions:ICalendario
    {
        public Calendario AddCalendario(Calendario calendario)
        {
            try
            {
                using var contex = new DatabaseContext(DatabaseContext.ops.dbOptions);
                contex.calendarios.Add(calendario);
                contex.SaveChanges();
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return calendario;
        }

        public List<Calendario> GetCalendario()
        {
            List<Calendario> calendarios = new List<Calendario>();
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                calendarios = context.calendarios.ToList();
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al extraer datos.", error);
            }

            return calendarios;
        }

     
    }
}
