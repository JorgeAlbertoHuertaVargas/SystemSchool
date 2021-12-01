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
    public class ParametersSystemFunctions: IParametersSystem
    {
        public bool UpdateStateParameter(int id, bool state)
        {
            bool confirmar = false;
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    var result = context.ParametersSystems.SingleOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                        result.State = state;
                        context.SaveChanges();
                        confirmar = true;
                    }
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return confirmar;
        }

        public bool UpdateParametersSystem(int id, string value, bool state)
        {
            bool confirmar = true;
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    var result = context.ParametersSystems.SingleOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                        result.Value = value;
                        result.State = state;
                        context.SaveChanges();
                    }
                    else
                    {
                        confirmar = false;
                    }
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return confirmar;
        }

        public ParametersSystem GetParametersSystemById(int id)
        {
            ParametersSystem NewParameter = new ParametersSystem();
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    var result = context.ParametersSystems.SingleOrDefault(p => p.Id == id);
                    if (result != null)
                    {
                        NewParameter.Id = result.Id;
                        NewParameter.Type = result.Type;
                        NewParameter.Value = result.Value;
                        NewParameter.State = result.State;
                    }
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return NewParameter;
        }


        public List<ParametersSystem> GetAllParametersSystem()
        {
            List<ParametersSystem> parameters = new List<ParametersSystem>();
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.ops.dbOptions))
                {
                    parameters = context.ParametersSystems.ToList();
                }
            }
            catch (Exception error)
            {
                throw new DataException("Failed to insert data.", error);
            }
            return parameters;
        }
    }
}
