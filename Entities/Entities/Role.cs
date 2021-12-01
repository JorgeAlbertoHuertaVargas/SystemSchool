using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    public class Role
    {
        [Key]
        public int IdRole { get; set; }
        [Required(ErrorMessage ="Se requiere nombre de usuario")]
        [Display(Name ="Nombre del Rol")]
        public string RoleName { get; set; }

        //[ForeignKey("RoleIdRole")]
        //public ICollection<User> RoleIdRole { get; set; }

    }
}
