using Data.DataContext;
using Data.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Data.Functions
{
    public class UserFunctions : IUser
    {

        public User AgregarUsuario(User user)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                user.Pass = UserFunctions.GetMD5(user.Pass);
                context.User.Add(user);
                context.SaveChanges();
            }
            catch (Exception error)
            {

                throw new DataException("Failed to insert data.", error);
            }

            return user;
        }

        public bool AddUser(User user)
        {
            bool confirm = false;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                user.Pass = UserFunctions.GetMD5(user.Pass);
                db.User.Add(user);
                db.SaveChanges();
                confirm = true;
                return confirm;
            }
            catch (Exception e)
            {
                throw new Exception("Error al agregar los usuarios.", e);
            }
            return confirm;

        }

        public bool DeleteUser(int id)
        {
            bool confirmar = true;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var u = db.User.Find(id);

                if (u != null)
                {
                    db.User.Remove(u);
                    db.SaveChanges();

                }
                else
                {
                    confirmar = false;
                }
            }
            catch (Exception ex)
            {
                throw new DataException("Fallo al eliminar la sección", ex);
            }

            return confirmar;

        }

        public List<User> GetAllUser()
        {
            List<User> user = new List<User>();
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                
                        return db.User.ToList();
                
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar los usuarios.", e);
            }

            return user;
        }

        public User GetUser(int iduser)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
            return db.User.Find(iduser);
        }

        public void UpdateUser(User user)
        {
            using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);

            var u = db.User.Find(user.IdUser);
            u.UserName = user.UserName;
            u.Pass = user.Pass;
            u.RoleIdRole = user.RoleIdRole;
            db.SaveChanges();
        }

        public User Validation(string Codigo, string pass)
        {
            try
            {
                using var context = new DatabaseContext(DatabaseContext.ops.dbOptions);
                var compare = UserFunctions.GetMD5(pass);
                var filter = context.User.Include(sh => sh.Role).SingleOrDefault(h => h.Codigo == Codigo);
                if (filter.Pass == compare)
                {
                    return filter;
                }
                return filter;
            }
            catch (Exception error)
            {

                throw new DataException("Failed Capa Datos.", error);
            }

        }


        //Function encryt 
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }


        //Function Desencrypt
        //public static string DesEncriptar(string _cadenaAdesencriptar)
        //{
        //    string result = string.Empty;
        //    byte[] decryted =
        //    Convert.FromBase64String(_cadenaAdesencriptar);
        //    //result = 
        //    System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
        //    result = System.Text.Encoding.Unicode.GetString(decryted);
        //    return result;
        //}

        public bool validausercode(string code, string user)
        {
            bool confirm = false;
            try
            {
                using var db = new DatabaseContext(DatabaseContext.ops.dbOptions);
                //var result = (from u in db.Userr
                //              where u.UserName == user /* u.Codigo == code*/
                //              select u).Any();

                //var result = (from u in db.Userr where u.UserName == user select u).FirstOrDefault();
                //var result2 = (from u in db.Userr where u.Codigo == code select u).FirstOrDefault();
                var result2 = db.User.Where(u => u.UserName == user || u.Codigo == code);

                if (result2.Any())
                {
                    confirm = true;
                    return confirm;

                }
                return confirm;
            }
            catch (Exception error)
            {
                throw new Exception("Error al buscar el usuario", error);
            }
        }
    }
}
