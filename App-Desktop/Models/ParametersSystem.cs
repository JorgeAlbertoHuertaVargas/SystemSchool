using System;
using System.Collections.Generic;

#nullable disable

namespace App_Desktop.Models
{
    public partial class ParametersSystem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool State { get; set; }
    }
}
