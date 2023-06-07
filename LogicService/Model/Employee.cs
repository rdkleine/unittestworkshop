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
    public Address HomeAddress { get; set; } = default!;
    public Address PostalAddress { get; set; } = default!;
}

public class Address
{
    [Key]
    public int AddressId { get; set; }
    public string Street { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
}