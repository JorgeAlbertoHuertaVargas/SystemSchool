using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Apoderado
    {
        [Key]
        public int IdApoderado { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de la Sección")]
        public string Nombre { get; set; }
        [Required]
        public string ApellidoP { get; set; }
        [Required]
        public string ApellidoM { get; set; }
        [Required]
        public int Dni { get; set; }
        public string Telefono { get; set; }
        public string Parentesco { get; set; }

        [ForeignKey("IdApoderados")]
        public ICollection<Alumno> IdApoderados { get; set; }

        [ForeignKey("Id_Encargado")]
        public ICollection<Retirado> Id_Encargado { get; set; }
    }
}
