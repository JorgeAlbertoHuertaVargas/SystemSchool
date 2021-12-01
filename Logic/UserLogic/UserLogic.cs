using Data.Functions;
using Data.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;

namespace Logic.UserLogic
{
    public class UserLogic
    {
        UserFunctions CapaDatosUser = new UserFunctions();
        private readonly IUser obj = new UserFunctions();

        public User Validation(string Codigo, string Pass)
        {
            try
            {

                return CapaDatosUser.Validation(Codigo, Pass);
            }
            catch (Exception error)
            {

                throw new Exception("Failed extraed data in Cap Logic.", error);
            }

        }


        public bool AddUser(User user)
        {
            return CapaDatosUser.AddUser(user);
        }

        public User AgregarUsuario(User user)
        {
            try
            {
                return CapaDatosUser.AgregarUsuario(user);
            }
            catch (Exception ex)
            {

                throw new DataException("Failed to insert data.", ex);
            }
        }

        public List<User> GetUsuarios()
        {
            try
            {
                return CapaDatosUser.GetAllUser();
            }
            catch (Exception error)
            {

                throw new DataException("Fallo al insertar datos.", error);
            }
        }

        public bool validauser(string code, string user)
        {
            return obj.validausercode(code, user);
        }

        public bool Delete(int id)
        {
            try
            {
                return obj.DeleteUser(id);
            }
            catch (Exception e)
            {
                throw new Exception("Hubo un error al eliminar la sección", e);
            }

        }


    }
}
