using System;
using System.Collections.Generic;

namespace Skola.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Grades = new HashSet<Grade>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public int Phonenumber { get; set; }
        public DateTime Hired { get; set; }
        public decimal Salary { get; set; }
        public int Staffid { get; set; }

        public virtual staff Staff { get; set; } = null!;
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
