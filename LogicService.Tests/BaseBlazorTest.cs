using Bunit;
using Bunit.TestDoubles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Text;
using Xunit.Abstractions;

namespace LogicService.Tests;

public class BaseBlazorTest : IDisposable
{
    protected TestContext? TestContext { get; private set; }
    protected TestAuthorizationContext AuthContext { get; private set; } = default!;
    private bool _disposed = false;

    protected BaseBlazorTest(ITestOutputHelper outputHelper)
    {
        TestContext = new TestContext();
        RegisterServices();
        Console.SetOut(new TestOutputWriter(outputHelper));
    }

    private void RegisterServices()
    {
        var services = TestContext!.Services;
        AuthContext = TestContext!.AddTestAuthorization();

        // Logging, as is.
        services.AddScoped<Microsoft.Extensions.Logging.ILogger, Logger<BaseBlazorTest>>();

        // Automapper hebben we nodig om te mappen tussen DTO's en Entities. Blijft as is.
        var asm = AppDomain.CurrentDomain.GetAssemblies();
        services.AddAutoMapper(asm.Where(a => a.FullName!.Contains("LogicService")).ToArray());

        // Voor de workshop gaan we de werkelijke implementatie van de Employeeservice gebruiken.  
        services.AddScoped<IEmployeeService, EmployeeService>();
        TestContext.JSInterop.Mode = JSRuntimeMode.Loose;

        // We gebruiken een in memory database zoals we in Camas ook doen. Hierdoor kunnen we de in code queries testen.
        services.AddDbContextFactory<DatabaseContext>(options =>
           {
               options.UseInMemoryDatabase($"UnitTestWS-{Guid.NewGuid()}")
               .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
           });
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                TestContext?.Dispose();
                TestContext = null;
            }

            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}

public class TestOutputWriter : TextWriter
{
    private ITestOutputHelper Output { get; set; }

    public TestOutputWriter(ITestOutputHelper output)
        => Output = output;

    public override Encoding Encoding
        => throw new NotImplementedException();

    public override void WriteLine(string message)
        => Output.WriteLine(message);
    public override void WriteLine(string format, params object[] args)
        => Output.WriteLine(format, args);
}
