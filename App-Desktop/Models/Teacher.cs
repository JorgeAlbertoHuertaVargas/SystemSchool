using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            AssignTldcs = new HashSet<AssignTldc>();
        }

        public int IdTeacher { get; set; }
        public int UserIdUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual User UserIdUserNavigation { get; set; }
        public virtual ICollection<AssignTldc> AssignTldcs { get; set; }
    }
}
