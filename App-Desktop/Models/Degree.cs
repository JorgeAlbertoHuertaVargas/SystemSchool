using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Degree
    {
        public Degree()
        {
            Alumnos = new HashSet<Alumno>();
            AssignTldcs = new HashSet<AssignTldc>();
            Retirados = new HashSet<Retirado>();
        }

        public int IdDegree { get; set; }
        public string DegreeName { get; set; }
        public DateTime? DegreeDateCreated { get; set; }
        public int NumStudent { get; set; }
        public int LevellId { get; set; }

        public virtual Level Levell { get; set; }
        public virtual ICollection<Alumno> Alumnos { get; set; }
        public virtual ICollection<AssignTldc> AssignTldcs { get; set; }
        public virtual ICollection<Retirado> Retirados { get; set; }
    }
}
