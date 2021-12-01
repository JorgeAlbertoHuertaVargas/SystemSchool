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
    public class RoleFunctions : IRole
    {
        public void AddRole(Role rol)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            db.Role.Add(rol);
            db.SaveChanges();
        }

        public bool DeleteRole(int idrole)
        {
            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var r = db.Role.Find(idrole);

                if (r != null)
                {
                    db.Role.Remove(r);
                    db.SaveChanges();

                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al eliminar el Rol", ex);
            }

            return confirmar;
        }

        public bool Edit(Role rol)
        {
            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var r = db.Role.Find(rol.IdRole);

                if (r != null)
                {
                    r.RoleName = rol.RoleName;
                    db.SaveChanges();

                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al actualizar los datos del Rol", ex);
            }

            return confirmar;
        }

        public List<Role> GetAllRole()
        {
            List<Role> Rol = new List<Role>();
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                
                return db.Role.ToList();
                
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar los roles.", e);
            }

            return Rol;
        }

        public Role GetRole(int idrole)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            return db.Role.Find(idrole);
        }
    }
}
