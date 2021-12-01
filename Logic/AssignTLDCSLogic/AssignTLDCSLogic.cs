using Data.Functions;
using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.AssignTLDCSLogic
{
    public class AssignTLDCSLogic
    {
        private readonly AssignTLDCSFunctions assign = new AssignTLDCSFunctions();
        public AssignTLDCS AddTeacher(AssignTLDCS TLDCS)
        {
            try
            {
                return assign.AddAssignTLDCS(TLDCS);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al agregar los datos del maestro", e);
            }

        }

        public List<AssignTLDCS> GetAllAssignTeacher(int id)
        {
            try
            {
                return assign.GetAllAssignTeacher(id);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al traer los datos del maestro", e);
            }
        }
    
        public bool DeleteAssign(int id)
        {
            return assign.DeleteAssign(id);
        }
    }
}
