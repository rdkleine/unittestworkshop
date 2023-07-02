
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace LogicService.Tests
{
    public partial class EmployeeServiceTestsGet : BaseBlazorTest
    {
        public EmployeeServiceTestsGet(ITestOutputHelper outputHelper) : base(outputHelper)
        { }

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
    }
}
