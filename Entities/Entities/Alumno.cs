using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Alumno { 
    
        [Key]
        public int IdAlumno { get; set; }
        public string Codigo { get; set; }
        [Required]
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Nacimiento { get; set; }
        public int IdUsers { get; set; }
        public Degree Degree { get; set; }
        public int IdDegrees { get; set; }
        public Section Sections { get; set; }
        public int IdSections { get; set; }
        public int IdApoderados { get; set; }

    }
}
