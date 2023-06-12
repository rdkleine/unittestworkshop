using Microsoft.EntityFrameworkCore;

namespace LogicService;

public partial class DatabaseContext : DbContext
{
    public DbSet<Model.Employee> Employees { get; set; } = default!;
    public DbSet<Model.Address> Addresses { get; set; } = default!;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Model.Employee>()
            .Property(e => e.Deleted)
            .HasDefaultValue(false);
        modelBuilder
            .Entity<Model.Address>()
            .Property(e => e.Deleted)
            .HasDefaultValue(false);
        modelBuilder.Entity<Model.Address>()
            .HasOne(a => a.EmployeeFromHomeAddress)
            .WithOne(e => e.HomeAddress)
            .HasForeignKey<Model.Employee>(a => a.HomeAddressId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Model.Address>()
            .HasOne(a => a.EmployeeFromPostalAddress)
            .WithOne(e => e.PostalAddress)
            .HasForeignKey<Model.Employee>(a => a.PostalAddressId)
            .OnDelete(DeleteBehavior.Restrict);

        Seed(modelBuilder);
    }
}