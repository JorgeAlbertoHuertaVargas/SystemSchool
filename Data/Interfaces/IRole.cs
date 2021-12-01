using System.Collections.Generic;
using Entities.Entities;

namespace Data.Interfaces
{
    public interface IRole
    {
        public List<Role> GetAllRole();
        public void AddRole(Role rol);
        public Role GetRole(int idrole);
        public bool Edit(Role rol);
        public bool DeleteRole(int idrole);
    }
}
