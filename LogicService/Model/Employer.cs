using System.ComponentModel.DataAnnotations;

namespace LogicService.Model;

public class Employer
{
    [Key]
    public int EmployerId { get; set; }
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Phone { get; set; } = default!;
    public string Website { get; set; } = default!;
    public List<EmployeeEmployer> EmployeeEmployers { get; set; } = new();
    public bool Deleted { get; set; }
}