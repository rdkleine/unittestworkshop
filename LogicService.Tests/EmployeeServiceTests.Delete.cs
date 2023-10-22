
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace LogicService.Tests;

public partial class EmployeeServiceTestsDelete : BaseBlazorTest
{
    public EmployeeServiceTestsDelete(ITestOutputHelper outputHelper) : base(outputHelper)
    { }

    [Fact]
    public void Delete_HappyFlow_Deleted()
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
        employeeService!.Delete(1);

        // Assert
        Assert.Empty(dbContext!.Employees.Where(e => e.Deleted == false));
    }

    [Fact]
    public void MockDelete_HappyFlow_Deleted()
    {
        // Arrange
        var dbMock = new Moq.Mock<IDataService>();
        dbMock.Setup(x => x.GetEmployee(1)).Returns(new Dto.Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe" });
        TestContext!.Services.AddScoped<IDataService>(x => dbMock.Object);

        // Act
        var employeeService = TestContext!.Services.GetService<IEmployeeService>() as IEmployeeService;
        employeeService!.Delete(1);

        // Assert
        dbMock.Verify(x => x.DeleteEmployee(1), Moq.Times.Once);
    }    
}
