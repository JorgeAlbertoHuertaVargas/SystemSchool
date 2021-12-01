using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class User
    {
       [Key]  
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Dbe ingresar un Nombre de Usuario")]
        public string UserName { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        public string Codigo { get; set; }
        public string Pass { get; set; }
        public Role Role { get; set; }
        public int RoleIdRole { get; set; }

        public DateTime? DateCreated { get; set; }

        [ForeignKey("IdUsers")]
        public ICollection<Alumno> IdUsers { get; set; }

        [ForeignKey("Id_usuario")]
        public ICollection<Retirado> Id_usuario { get; set; }



    }
}
