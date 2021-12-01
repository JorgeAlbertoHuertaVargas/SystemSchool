using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Level
    {
        public Level()
        {
            AssignTldcs = new HashSet<AssignTldc>();
            Degrees = new HashSet<Degree>();
        }

        public int Id { get; set; }
        public string Levelname { get; set; }
        public string Turn { get; set; }

        public virtual ICollection<AssignTldc> AssignTldcs { get; set; }
        public virtual ICollection<Degree> Degrees { get; set; }
    }
}
