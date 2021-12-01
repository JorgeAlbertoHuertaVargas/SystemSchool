using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Functions;
using Data.Interfaces;
using Entities.Entities;

namespace Logic.RoleLogic
{
    public class RoleLogic
    {
        private readonly IRole obj = new RoleFunctions();

        //GetAllRole
        public List<Role> GetAllRole()
        {
            try
            {
                return obj.GetAllRole();
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al traer los datos del Rol", e);
            }
        }

        //AddSections
        public void AddRole(Role rol)
        {
            try
            {
                obj.AddRole(rol);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al agregar los datos del rol", e);
            }

        }

        public Role GetRole(int idrol)
        {
            try
            {
                return obj.GetRole(idrol);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al extraer los datos del rol", e);
            }

        }

        public bool Edit(Role rol)
        {
            try
            {
                return obj.Edit(rol);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al editar los datos del rol", e);
            }

        }

        public bool Eliminar(int id)
        {
            try
            {
                return obj.DeleteRole(id);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al eliminar la sección", e);
            }

        }
    }
}
