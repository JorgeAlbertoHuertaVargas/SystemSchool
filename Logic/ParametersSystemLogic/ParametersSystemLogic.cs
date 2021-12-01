using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ParametersSystemLogic
{
    public class ParametersSystemLogic
    {
        private IParametersSystem _parameters = new Data.Functions.ParametersSystemFunctions();

        public List<ParametersSystem> GetAllParametersSystem()
        {
            try
            {
                return _parameters.GetAllParametersSystem();
            }
            catch (DataException DataEx)
            {
                throw DataEx;
            }
           
        }

        public ParametersSystem GetParametersSystemById(int id)
        {
            try
            {
                return _parameters.GetParametersSystemById(id);
            }
            catch (DataException DataEx)
            {
                throw DataEx;
            }
      
        }

        public bool UpdateParametersSystem(int id, string value, bool state)
        {
            try
            {
                return _parameters.UpdateParametersSystem(id, value, state);
            }
            catch (DataException DataEx)
            {
                throw DataEx;
            }
         
        }

        public bool UpdateStateParameter(int id, bool state)
        {
            try
            {
                return _parameters.UpdateStateParameter(id, state);
            }
            catch (DataException DataEx)
            {
                throw DataEx;
            }
          
        }
    }
}
