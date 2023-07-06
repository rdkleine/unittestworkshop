namespace LogicService.Dto;

public class Employer
{
    public int EmployerId { get; set; }
}

public class Employee
{
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
    public string Street { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
}