using System;
using System.Collections.Generic;

namespace Skola.Models
{
    public partial class staff
    {
        public staff()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string? Role { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
