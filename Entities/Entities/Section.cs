using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Section
    {
        [Key]
        public int IdSection { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de la Sección")]
        public string SectionName { get; set; }
        [Display(Name = "Detalle")]
        public string Detail { get; set; }

        [ForeignKey("IdSections")]
        public ICollection<Alumno> IdSections { get; set; }

        [ForeignKey("Id_Seccion")]
        public ICollection<Retirado> Id_Seccion { get; set; }

        //[ForeignKey("IdSectionn")]
        //public ICollection<LevelDegreeCourseSection> IdSectionn { get; set; }
    }
}
