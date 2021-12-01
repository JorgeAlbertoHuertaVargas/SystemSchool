using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
   public  class GradosCurso
    {
        [Key]
        public int GradosCursoId { get; set; }
        public int Gradoid { get; set; }
        public Course Courses { get; set; }
        public int CoursesIdCourse { get; set; }

        public GradosCurso()
        {
        }
        public GradosCurso(int Gradoid, int Cursosid)
        {
            this.Gradoid = Gradoid;
            this.CoursesIdCourse = Cursosid;
        }
        
    }
}
