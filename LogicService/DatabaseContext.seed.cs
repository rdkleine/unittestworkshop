using Microsoft.EntityFrameworkCore;

namespace LogicService;

public partial class DatabaseContext : DbContext
{
    private void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Model.Employer>()
            .HasData(
                new Model.Employer()
                {
                    EmployerId = 1,
                    Name = "Big Kahuna Burger",
                    Email = "info@bkb.company",
                    Phone = "+0800bigkburger",
                    Website = "https://bkb.company"
                },
                new Model.Employer()
                {
                    EmployerId = 2,
                    Name = "Jack Rabbit Slim's",
                    Email = "info@jackrabbit.com",
                    Phone = "0800123123",
                    Website = ""
                });

        modelBuilder
            .Entity<Model.Employee>()
            .HasData(new Model.Employee()
            {
                EmployeeId = 1,
                FirstName = "Tim",
                LastName = "Roth",
                EmailAddress = "tim.roth@logic.example.org",
                BirthDate = new DateTime(1961, 5, 14),
                HomeAddressId = 101
            },
            new Model.Employee()
            {
                EmployeeId = 2,
                FirstName = "Amanda",
                LastName = "Plummer",
                EmailAddress = "amanda.plummer@logic.example.org",
                HomeAddressId = 102
            },
            new Model.Employee()
            {
                EmployeeId = 3,
                FirstName = "Laura",
                LastName = "Lovelace",
                EmailAddress = "laura.lovelace@logic.example.org",
            },
            new Model.Employee()
            {
                EmployeeId = 4,
                FirstName = "John",
                LastName = "Travolta",
                EmailAddress = "Unknown",
            },
            new Model.Employee()
            {
                EmployeeId = 5,
                FirstName = "Samuel",
                LastName = "Jackson",
                EmailAddress = "Unknown",
                BirthDate = new DateTime(1948, 12, 21),
            });

        modelBuilder
            .Entity<Model.Address>()
            .HasData(new Model.Address()
            {
                AddressId = 101,
                City = "Denver",
                Country = "Usa",
                PostalCode = "40022",
                Street = "Cowstreet 13",
            }, new Model.Address()
            {
                AddressId = 102,
                City = "Hollywood",
                Country = "United states",
                PostalCode = "19922",
                Street = "Hollywood drive 99a",
            });
    }
}