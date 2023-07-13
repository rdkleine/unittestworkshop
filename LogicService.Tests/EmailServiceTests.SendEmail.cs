
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace LogicService.Tests;

public partial class EmailServiceTestsSendEmail : BaseBlazorTest
{
    public EmailServiceTestsSendEmail(ITestOutputHelper outputHelper) : base(outputHelper)
    { }

    [Theory]
    [InlineData(null, null, null, false)]
    [InlineData("geenemail", "Hi", "Got a great offer!", false)]
    [InlineData("bob@example.com", "Urgent!", "I am a Nigerian prince and need your help", true)]
    [InlineData("alan@exmple.com", null, null, false)]
    public void SendEmail_ValidateInput_ShouldReturn(string to, string subject, string body, bool resultExpected)
    {
        // Arrange
        // - Voeg email service toe aan de context
        TestContext!.Services.AddScoped<IEmailService, EmailService>();
        // - Haal de email service op
        var emailService = TestContext!.Services.GetService<IEmailService>() as IEmailService;

        // Act
        // - Roep de email service aan met de input parameters
        var result = emailService!.SendEmail(to, subject, body);

        // Assert
        Assert.Equal(resultExpected, result);
    }








    [Theory]
    [MemberData(nameof(GetTestData))]
    public void SendEmail_ValidateInputMem_ShouldReturn(string to, string subject, string body, bool resultExpected)
    {
        // Arrange
        // - Voeg email service toe aan de context
        TestContext!.Services.AddScoped<IEmailService, EmailService>();
        // - Haal de email service op
        var emailService = TestContext!.Services.GetService<IEmailService>() as IEmailService;

        // Act
        // - Roep de email service aan met de input parameters
        var result = emailService!.SendEmail(to, subject, body);

        // Assert
        Assert.Equal(resultExpected, result);
    }

    public static IEnumerable<object[]> GetTestData =>
    new List<object[]>
    {
        new object[]{null, null, null, false},
        new object[]{"geenemail", "Hi", "Got a great offer!", false},
        new object[]{"bob@example.com", "Urgent!", "I am a Nigerian prince and need your help", true},
        new object[]{"alan@exmple.com", null, null, false },
    };







    [Theory]
    [MemberData(nameof(GetTestData))]
    public void SendEmail_ValidateInputCls_ShouldReturn(string to, string subject, string body, bool resultExpected)
    {
        // Arrange
        // - Voeg email service toe aan de context
        TestContext!.Services.AddScoped<IEmailService, EmailService>();
        // - Haal de email service op
        var emailService = TestContext!.Services.GetService<IEmailService>() as IEmailService;

        // Act
        // - Roep de email service aan met de input parameters
        var result = emailService!.SendEmail(to, subject, body);

        // Assert
        Assert.Equal(resultExpected, result);
    }

    public class TestDataGenerator : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
    {
        new object[]{null, null, null, false},
        new object[]{"geenemail", "Hi", "Got a great offer!", false},
        new object[]{"bob@example.com", "Urgent!", "I am a Nigerian prince and need your help", true},
        new object[]{"alan@exmple.com", null, null, false },
    };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
