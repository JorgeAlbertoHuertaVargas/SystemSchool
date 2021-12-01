using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Teacher
    {
        [Key]
        public int IdTeacher { get; set; }

        [Required]
        public int UserIdUser { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Nombre del Maestro")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name = "Apellido del Maestro")]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        //public User user { get; set; }
        public User User { get; set; }
        //[ForeignKey("IdTeacherr")]
        //public ICollection<LevelDegreeCourseSection> IdTeacherr { get; set; }

    }
}
