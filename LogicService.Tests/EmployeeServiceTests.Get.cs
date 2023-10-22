using AutoFixture;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace LogicService.Tests;

public partial class EmployeeServiceTestsGet : BaseBlazorTest
{
    public EmployeeServiceTestsGet(ITestOutputHelper outputHelper) : base(outputHelper)
    { }

    [Fact]
    public void GetUsingDb_HappyFlow_ShouldReturnEmployee()
    {
        // Arrange
        TestContext!.Services.AddScoped<IDataService, DataService>();
        var employee = new Model.Employee
        {
            EmployeeId = 1,
            FirstName = "John",
            LastName = "Doe",
            EmailAddress = ""
        };
        using var dbContext = TestContext!.Services.GetService<DatabaseContext>();
        dbContext!.Employees.Add(employee);
        dbContext.SaveChanges();

        // Act
        var employeeService = TestContext!.Services.GetService<IEmployeeService>() as IEmployeeService;
        var result = employeeService!.Get(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.EmployeeId);
    }

    [Fact]
    public void GetMockDb_HappyFlow_ShouldReturnEmployee()
    {
        // Arrange
        var dbMock = new Moq.Mock<IDataService>();
        dbMock.Setup(x => x.GetEmployee(1)).Returns(new Dto.Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe" });
        TestContext!.Services.AddScoped<IDataService>(x => dbMock.Object);

        // Act
        var employeeService = TestContext!.Services.GetService<IEmployeeService>() as IEmployeeService;
        var result = employeeService!.Get(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.EmployeeId);
    }

    [Fact]
    public void GetUsingDatabuilder_HappyFlow_ShouldReturnEmployee()
    {
        // Arrange
        TestContext!.Services.AddScoped<IDataService, DataService>();
        using var dbContext = TestContext!.Services.GetService<DatabaseContext>();
        var employeeBuilder = new EmployeeBuilder(dbContext!);
        employeeBuilder
            .AddAddress(employeeBuilder.CreateAddress(upd =>
            {
                upd.AddressId = 1234;
                upd.PostalCode = "1234AB";
                upd.Street = "Voorstraat";
                upd.City = "Hoorn";
                return upd;
            }))
            .AddEmployee(employeeBuilder.CreateEmployee(upd =>
            {
                upd.HomeAddressId = 1234;
                return upd;
            }))
            .Build();

        // Act
        var employeeService = TestContext!.Services.GetService<IEmployeeService>() as IEmployeeService;
        var result = employeeService!.Get(1);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(1, result.EmployeeId);
        Assert.Equal("Hoorn", result.HomeAddress.City);
    }

    [Fact]
    public void GetUsingAutofixture_HappyFlow_ShouldReturnEmployee()
    {
        // Arrange
        var fixture = new Fixture();
        fixture.Behaviors.Add(new OmitOnRecursionBehavior(recursionDepth: 1));
        var employee = fixture.Create<Model.Employee>();
        TestContext!.Services.AddScoped<IDataService, DataService>();
        using var dbContext = TestContext!.Services.GetService<DatabaseContext>();
        dbContext!.Employees.Add(employee);
        dbContext.SaveChanges();

        // Act
        var employeeService = TestContext!.Services.GetService<IEmployeeService>() as IEmployeeService;
        var result = employeeService!.Get(employee.EmployeeId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(employee.EmployeeId, result.EmployeeId);
        Assert.Equal(result.HomeAddress.City, result.HomeAddress.City);
    }
}
