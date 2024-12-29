using System.Collections.Generic;

namespace EmployeeManagementSystem.Entities
{
    public class Designation
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Navigation Property
        public ICollection<Employee> Employees { get; set; }
    }
}
