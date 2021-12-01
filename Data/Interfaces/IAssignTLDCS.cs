using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IAssignTLDCS
    {
        AssignTLDCS AddAssignTLDCS(AssignTLDCS TLDCS);
        List<AssignTLDCS> GetAllAssignTeacher(int id);

        public bool DeleteAssign(int id);
    }
}
