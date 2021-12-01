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
    public class TeacherFunctions : ITeacher
    {
        public Teacher AddTeacher(Teacher teacher)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            db.Teacher.Add(teacher);
            db.SaveChanges();
            return teacher;
        }
        public bool DeleteTeacher(int id)
        {
            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var t = db.Teacher.Find(id);

                if (t != null)
                {
                    db.Teacher.Remove(t);
                    db.SaveChanges();

                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al eliminar el Maestro", ex);
            }

            return confirmar;
        }
        public bool Edit(Teacher teacher)
        {
            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var t = db.Teacher.Find(teacher.IdTeacher);

                if (t != null)
                {
                    t.FirstName = teacher.FirstName;
                    t.LastName = teacher.LastName;
                    t.UserIdUser = teacher.UserIdUser;
                    t.Phone = teacher.Phone;
                    db.SaveChanges();

                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al actualizar los datos de Maestro", ex);
            }

            return confirmar;
        }
        public List<Teacher> GetAllTeacher()
        {
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                return db.Teacher.Include(u => u.User).ToList();

            }
            catch (Exception e)
            {
                throw new Exception("Error al listar los usuarios.", e);
            }
        }
        public Teacher GetTeacher(int idteacher)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            return db.Teacher.Find(idteacher);
        }

    }
}
