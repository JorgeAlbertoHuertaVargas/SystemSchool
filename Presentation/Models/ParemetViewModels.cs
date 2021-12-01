using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class ParemetViewModels
    {
        public int ParemetId { get; set; }
        public string ParemetName { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }

        public Paremet Paremet { get; set; }
        public List<Paremet> ParemetList { get; set; }
    }
}
