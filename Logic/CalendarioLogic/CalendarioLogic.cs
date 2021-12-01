using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.CalendarioLogic
{
    public class CalendarioLogic
    {
        private readonly ICalendario _calendario = new Data.Functions.CalendarioFunctions();

        public Calendario AddCalendario(Calendario calendario)
        {
            try
            {
                return _calendario.AddCalendario(calendario);
            }
            catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }


        public List<Calendario> GetCalendario()
        {
            try
            {
                return _calendario.GetCalendario();
            }
             catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }
    }
}
