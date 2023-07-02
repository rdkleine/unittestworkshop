namespace LogicService.Tests;

public abstract class BaseDataBuilder<U> where U : class
{
    protected Random random = new Random();
    public delegate T Update<T>(T update);
    protected DatabaseContext dbContext;
    protected T Caller<T>(Update<T>? func, T entity)
        => func == null ? entity : func(entity);
    public BaseDataBuilder(DatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public U? Sub<T>(Action<T> action) where T : BaseDataBuilder<T>
    {
        var args = new object[] { dbContext };
        var sub = (T)Activator.CreateInstance(typeof(T), args)!;
        action(sub);
        return this as U;
    }

    public BaseDataBuilder<U> Build()
    {
        dbContext.SaveChanges();
        return this;
    }
}

public class EmployeeBuilder : BaseDataBuilder<EmployeeBuilder>
{
    public EmployeeBuilder(DatabaseContext dbContext) : base(dbContext)
    { }

    public Model.Employee CreateEmployee(Update<Model.Employee> update = null)
        => Caller(update, new Model.Employee
        {
            EmployeeId = 1,
            FirstName = "John",
            LastName = "Doe",
            EmailAddress = "john@doe.com"
        });

    public EmployeeBuilder AddEmployee(Model.Employee employee)
    {
        dbContext.Employees.Add(employee);
        return this;
    }

    public Model.Address CreateAddress(Update<Model.Address> update = null)
           => Caller(update, new Model.Address
           {
               AddressId = 1,
               City = "City",
               Country = "Country"
           });

    public EmployeeBuilder AddAddress(Model.Address address)
    {
        dbContext.Addresses.Add(address);
        return this;
    }

}