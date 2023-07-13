
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace LogicService.Tests;

public partial class EmployeeServiceTestsDelete : BaseBlazorTest
{
    public EmployeeServiceTestsDelete(ITestOutputHelper outputHelper) : base(outputHelper)
    { }

    [Fact]
    public void Delete_Invalid_Should()
    {
        // Arrange
        // Act
        // Assert
    }
}
