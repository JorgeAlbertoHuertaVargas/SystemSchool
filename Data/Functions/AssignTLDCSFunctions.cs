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
    public class AssignTLDCSFunctions:IAssignTLDCS
    {
        public List<AssignTLDCS> ListarAssign { get; set; } = new List<AssignTLDCS>();
        public AssignTLDCS AddAssignTLDCS(AssignTLDCS TLDCS)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            db.AssignTLDCS.Add(TLDCS);
            db.SaveChanges();
            return TLDCS;
        }

        public List<AssignTLDCS> GetAllAssignTeacher(int id)
        {
            //AssignTLDCS ListarAssign = new AssignTLDCS();
            try
            {
                //ListarAssign = db.AssignTLDCS.Include(tea => tea.Teacher).Where(l => l.TeacherIdTeacherr == id).Select(x => x).ToList()    ;
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                ListarAssign = db.AssignTLDCS.Include(t => t.Teacher).Include(l => l.Level).Include(c => c.Course).Include(s => s.Section).Include(d => d.Degree).Where(t => t.TeacherIdTeacher == id).ToList();
                //ListarAssign = db.AssignTLDCS.Include(t => t.Teacher).ToList();
                return ListarAssign;
            }
            catch (Exception error)
            {
                throw new Exception("Fallo al extraer datos.", error);
            }
        }

        public bool DeleteAssign(int id)
        {
            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var t = db.AssignTLDCS.Find(id);

                if (t != null)
                {
                    db.AssignTLDCS.Remove(t);
                    db.SaveChanges();
                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al eliminar el Asignación", ex);
            }

            return confirmar;
        }
    }
}
