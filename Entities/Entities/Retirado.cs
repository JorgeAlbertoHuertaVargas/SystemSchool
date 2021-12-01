using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
   public class Retirado
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int Id_usuario { get; set; }
        public Degree Degree { get; set; }
        public int Id_grado { get; set; }
        public Section Sections { get; set; }
        public int Id_Seccion { get; set; }
        public int Id_Encargado { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? DateTimeRetiro { get; set; }

    }
}
