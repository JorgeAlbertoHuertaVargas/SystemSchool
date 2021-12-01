using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
   public interface IRetirados
    {
        Retirado AddRetirados(Retirado retirado);
        List<Retirado> GetRetirados();
        bool DeleteRetirados(int id);
    }
}
