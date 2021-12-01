using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Apoderado
    {
        public Apoderado()
        {
            Alumnos = new HashSet<Alumno>();
            Retirados = new HashSet<Retirado>();
        }

        public int IdApoderado { get; set; }
        public string Nombre { get; set; }
        public string ApellidoP { get; set; }
        public string ApellidoM { get; set; }
        public int Dni { get; set; }
        public string Telefono { get; set; }
        public string Parentesco { get; set; }

        public virtual ICollection<Alumno> Alumnos { get; set; }
        public virtual ICollection<Retirado> Retirados { get; set; }
    }
}
