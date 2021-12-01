using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IParametersSystem
    {
        bool UpdateParametersSystem(int id, string value, bool state);
        bool UpdateStateParameter(int id, bool state);
        ParametersSystem GetParametersSystemById(int id);
        List<ParametersSystem> GetAllParametersSystem();
    }
}
