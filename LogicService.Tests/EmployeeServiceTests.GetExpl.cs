using Microsoft.Extensions.DependencyInjection;

namespace LogicService.Tests;

public partial class EmployeeServiceTestsGet : BaseBlazorTest
{
    [Fact]
    public void Get_HappyFlow_ShouldReturnEmployee()
    {
        // Arrange
        var dbMock = new Moq.Mock<IDataService>();
        dbMock.Setup(x => x.GetEmployer(1)).Returns(new Dto.Employer { EmployerId = 1 });
        dbMock.Setup(x => x.GetEmployeeList(1)).Returns(
            new List<Dto.Employee>
            {
                new Dto.Employee { EmployeeId = 1, FirstName = "John", LastName = "Doe" },
                new Dto.Employee { EmployeeId = 2, FirstName = "Jane", LastName = "Doe" }
            });
        TestContext!.Services.AddScoped<IDataService>(x => dbMock.Object);

        // Act
        var employeeService = TestContext!.Services.GetService<IEmployeeService>() as IEmployeeService;
        var result = employeeService!.GetListForEmployer(1);

        // Assert
        Assert.NotNull(result);
        Assert.Collection(result,
            item => Assert.Equal("John", item.FirstName),
            item => Assert.Equal("Jane", item.FirstName));
    }
}
