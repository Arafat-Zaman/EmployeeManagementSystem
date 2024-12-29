using System.Collections.Generic;

namespace EmployeeManagementSystem.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Employee> Employees { get; set; }
    }
}
