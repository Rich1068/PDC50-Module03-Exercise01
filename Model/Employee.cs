using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module02Exercise01.Model
{
    public class Employee
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullNames => $"{FirstName} {LastName}";
        public string Position { get; set; }
        public string Department { get; set; }
        public Boolean IsActive { get; set; }

        public string EmployeeInfo => $"{FullNames} {Position} {Department}";

        public string IsActiveString => IsActive ? "Active" : "Inactive";


    }
}
