using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Role
    {
        public Role()
        {
            Paramets = new HashSet<Paramet>();
            Users = new HashSet<User>();
        }

        public int IdRole { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Paramet> Paramets { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
