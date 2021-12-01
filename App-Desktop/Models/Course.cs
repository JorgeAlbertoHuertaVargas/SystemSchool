using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Course
    {
        public Course()
        {
            AssignTldcs = new HashSet<AssignTldc>();
            GradosCursos = new HashSet<GradosCurso>();
        }

        public int IdCourse { get; set; }
        public string CourseName { get; set; }
        public DateTime CourseDateCreated { get; set; }

        public virtual ICollection<AssignTldc> AssignTldcs { get; set; }
        public virtual ICollection<GradosCurso> GradosCursos { get; set; }
    }
}
