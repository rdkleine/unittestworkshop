using LogicService;
using LogicService.Dto;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IExternalService, ExternalService>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer("Data Source=localhost,1435;Initial Catalog=UnitTestWs;User ID=sa;Password=#Perspectief!;TrustServerCertificate=true;");
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// app.Lifetime.ApplicationStarted.Register(() =>
// {
//     // Initial setup of the application
//     var employeeService = app.Services.GetService<IEmployeeService>();
//     // Add demo data to the memory cache 
//     employeeService!.SaveEmployee(new Employee()
//     {
//         EmployeeId = 1,
//         FirstName = "John",
//         LastName = "Doe",
//         EmailAddress = ""
//     });
//     employeeService!.SaveEmployee(new Employee()
//     {
//         EmployeeId = 2,
//         FirstName = "Jane",
//         LastName = "Doe",
//         EmailAddress = ""
//     });
// });

DatabaseMigrator.MigrateDatabase(app.Services);

app.Run();
