using Microsoft.EntityFrameworkCore;
namespace LogicService;

public class DatabaseContext : DbContext
{
    public DbSet<Model.Employee> Employees { get; set; }
    public DbSet<Model.Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=YourDatabaseName;Trusted_Connection=True;");
    }
}