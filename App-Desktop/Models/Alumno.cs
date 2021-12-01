using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Alumno
    {
        public int IdAlumno { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Nacimiento { get; set; }
        public int IdUsers { get; set; }
        public int IdDegrees { get; set; }
        public int IdSections { get; set; }
        public int IdApoderados { get; set; }

        public virtual Apoderado IdApoderadosNavigation { get; set; }
        public virtual Degree IdDegreesNavigation { get; set; }
        public virtual Section IdSectionsNavigation { get; set; }
    }
}
