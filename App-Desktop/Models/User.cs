using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class User
    {
        public User()
        {
            Teachers = new HashSet<Teacher>();
        }

        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Codigo { get; set; }
        public string Pass { get; set; }
        public int RoleIdRole { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Role RoleIdRoleNavigation { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
