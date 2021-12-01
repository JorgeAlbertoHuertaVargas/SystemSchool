using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IApoderado
    {
        Apoderado AddApoderado(Apoderado apoderado);
        List<Apoderado> GetApoderados();
    }
}
