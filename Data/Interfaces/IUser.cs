using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace Data.Interfaces
{
    public interface IUser
    {
        public List<User> GetAllUser();
        public bool AddUser(User user);
        public User GetUser(int iduser);
        public void UpdateUser(User user);
        public bool DeleteUser(int id);
        public User Validation(string Codigo, string pass);
        public bool validausercode(string code, string user);
        User AgregarUsuario(User user);
    }
}
