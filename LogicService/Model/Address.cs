using System.ComponentModel.DataAnnotations;

namespace LogicService.Model;

public class Address
{
    [Key]
    public int AddressId { get; set; }
    public string Street { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public Employee EmployeeFromHomeAddress { get; set; }
    public Employee EmployeeFromPostalAddress { get; set; }
    public bool Deleted { get; set; }
}