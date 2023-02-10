using System;
using System.Collections.Generic;

namespace Skola.Models
{
    public partial class Class
    {
        public Class()
        {
            Grades = new HashSet<Grade>();
            StudentClasses = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string Class1 { get; set; } = null!;
        public bool? Active { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}
