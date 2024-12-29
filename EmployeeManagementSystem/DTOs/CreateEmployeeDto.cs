using System.ComponentModel.DataAnnotations;

public class CreateEmployeeDto
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    public int DesignationId { get; set; }
}
