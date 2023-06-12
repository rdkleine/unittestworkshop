using System.ComponentModel.DataAnnotations;

namespace LogicService.Model;

public class EmployeeEmployer
{
    [Key]
    public int EmployeeEmployerId { get; set; }
    public int EmployeeId { get; set; }
    public int EmployerId { get; set; }
    public Employee Employee { get; set; } = default!;
    public Employer Employer { get; set; } = default!;
    public bool Deleted { get; set; }
}