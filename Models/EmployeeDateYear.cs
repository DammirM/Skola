using System;
using System.Collections.Generic;

namespace Skola.Models
{
    public partial class EmployeeDateYear
    {
        public string FullName { get; set; } = null!;
        public string? Role { get; set; }
        public DateTime Hired { get; set; }
    }
}
