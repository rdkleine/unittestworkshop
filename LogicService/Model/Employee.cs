using System.ComponentModel.DataAnnotations;

namespace LogicService.Model;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public DateTime? BirthDate { get; set; }
    public int? HomeAddressId { get; set; }
    public Address? HomeAddress { get; set; }
    public int? PostalAddressId { get; set; }
    public Address? PostalAddress { get; set; }
    public bool Deleted { get; set; }
}
