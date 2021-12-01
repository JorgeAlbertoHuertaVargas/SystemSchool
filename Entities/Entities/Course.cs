using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; } = 1;
        [StringLength(50)]
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression(@"^[A-Z a-z0-9ÑñáéíóúÁÉÍÓÚ\\-\\_]+$",
              ErrorMessage = "El Nombre debe ser alfanumérico.")]
        [Display(Name = "CourseName")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? CourseDateCreated { get; set; }


        //[ForeignKey("CoursesIdCourse")]
        //public ICollection<GradosCurso> CoursesIdCourse { get; set; }

        //[ForeignKey("IdCoursee")]
        //public ICollection<LevelDegreeCourseSection> IdCoursee { get; set; }
    }
}
