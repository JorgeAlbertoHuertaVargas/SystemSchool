using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Retirado
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public int IdUsuario { get; set; }
        public int IdGrado { get; set; }
        public int IdSeccion { get; set; }
        public int IdEncargado { get; set; }
        public string Motivo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? DateTimeRetiro { get; set; }

        public virtual Apoderado IdEncargadoNavigation { get; set; }
        public virtual Degree IdGradoNavigation { get; set; }
    }
}
