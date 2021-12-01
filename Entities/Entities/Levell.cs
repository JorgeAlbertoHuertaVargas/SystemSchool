using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Levell
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Levelname { get; set; }
        [Required]
        public string Turn { get; set; }

        //[ForeignKey("IdLevel")]
        //public ICollection<LevelDegreeCourseSection> IdLevel { get; set; }

    }
}
