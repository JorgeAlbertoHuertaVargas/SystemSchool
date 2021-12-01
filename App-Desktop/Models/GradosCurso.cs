using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class GradosCurso
    {
        public int GradosCursoId { get; set; }
        public int Gradoid { get; set; }
        public int CoursesIdCourse { get; set; }

        public virtual Course CoursesIdCourseNavigation { get; set; }
    }
}
