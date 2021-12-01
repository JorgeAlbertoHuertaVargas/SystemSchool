using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace Entities.Entities
{
   public class Degree
    {
        public int IdDegree { get; set; } = 0;
        [StringLength(50)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[A-Z a-z0-9ÑñáéíóúÁÉÍÓÚ\\-\\_]+$",
            ErrorMessage = "El Nombre debe ser alfanumérico.")]
        [Display(Name = "DegreeName")]
        public String DegreeName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime? DegreeDateCreated { get; set; }

        [Range(1, 40)]
        public int NumStudent { get; set; }

       
        public Levell Levels { get; set; }
        public int LevellId { get; set; }


        [ForeignKey("IdDegrees")]
        public ICollection<Alumno> IdDegrees { get; set; }

        [ForeignKey("Id_grado")]
        public ICollection<Retirado> Id_grado { get; set; }

        //[ForeignKey("IdDegre")]
        //public ICollection<LevelDegreeCourseSection> IdDegre { get; set; }

        
    }
}
