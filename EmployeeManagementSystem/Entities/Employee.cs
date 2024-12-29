using System;

namespace EmployeeManagementSystem.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Foreign Keys
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }

        // Navigation Properties
        public Department Department { get; set; }
        public Designation Designation { get; set; }
    }
}
