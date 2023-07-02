// using Blazored.LocalStorage;
// using Blazored.SessionStorage;
using Bunit;
using Bunit.TestDoubles;
// using Microsoft.AspNetCore.Authentication;
// using Microsoft.AspNetCore.Hosting;
// using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Xunit.Abstractions;


namespace LogicService.Tests;

public class BaseBlazorTest : IDisposable
{
    protected TestContext? TestContext { get; private set; }
    protected TestAuthorizationContext AuthContext { get; private set; } = default!;
    private bool _disposed = false;
    private IConfiguration _configuration { get; set; }

    protected BaseBlazorTest(ITestOutputHelper outputHelper)
    {
        TestContext = new TestContext();
        RegisterServices();
        Console.SetOut(new TestOutputWriter(outputHelper));
        // InitInMemoryDatabase(TestContext!.Services.GetService<IDbContextFactory<Camas.Entities.Context.CamasDbContext>>()!);
    }

    private void RegisterServices()
    {
        var services = TestContext!.Services;
        AuthContext = TestContext!.AddTestAuthorization();

        services.AddScoped<Microsoft.Extensions.Logging.ILogger, Logger<BaseBlazorTest>>();
        var asm = AppDomain.CurrentDomain.GetAssemblies();
        services.AddAutoMapper(asm.Where(a => a.FullName!.Contains("LogicService")).ToArray());
        // services.AddScoped<EmailSchedulerService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        TestContext.JSInterop.Mode = JSRuntimeMode.Loose;

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
