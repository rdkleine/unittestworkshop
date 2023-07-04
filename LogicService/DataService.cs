using LogicService.Dto;
using AutoMapper;
namespace LogicService;

public interface IDataService
{
    public void AddEmployee(Employee employee);
    public void UpdateEmployee(int employeeId, Employee employee);
    public void DeleteEmployee(int employeeId);
    public Employee? GetEmployee(int idEmployee);
    public List<Employee> GetEmployeeList();
    public List<Employee> GetEmployeeList(int employerId);
    public Employer? GetEmployer(int employerId);
}

public class DataService : IDataService
{
    private readonly IMapper _mapper;
    private readonly DatabaseContext _dbContext;
    public DataService(DatabaseContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void AddEmployee(Employee employeeDto)
    { }

    /// <summary>Update employee with idEmployee</summary>
    public void UpdateEmployee(int employeeId, Employee employeeDto)
    {
        var employeeRecord = _dbContext.Employees.Where(e => e.EmployeeId == employeeId).First();
        _mapper.Map<Dto.Employee, Model.Employee>(employeeDto, employeeRecord);
        var result = _dbContext.SaveChanges();
    }

    /// <summary>Get employee with idEmployee</summary>
    public Employee? GetEmployee(int idEmployee)
    {
        var employee = _dbContext.Employees.Where(e => e.EmployeeId == idEmployee).FirstOrDefault();
        return employee == null ? null : _mapper.Map<Model.Employee, Dto.Employee>(employee);
    }

    /// <summary>Get list of employees</summary>
    public List<Employee> GetEmployeeList()
    {
        var employees = _dbContext.Employees.ToList();
        return _mapper.Map<List<Model.Employee>, List<Dto.Employee>>(employees);
    }

    /// <summary>Soft delete employee</summary>
    public void DeleteEmployee(int idEmployee)
    {
        var employee = _dbContext.Employees.Where(e => e.EmployeeId == idEmployee).First();
        employee.Deleted = true;
        _dbContext.SaveChanges();
    }

    public Employer? GetEmployer(int employerId)
    {
        var employer = _dbContext.Employers.Where(e => e.EmployerId == employerId).FirstOrDefault();
        return employer == null ? null : _mapper.Map<Model.Employer, Employer>(employer);
    }

    public List<Employee> GetEmployeeList(int employerId)
    {
        var employees = _dbContext
            .Employers.Where(e => e.EmployerId == employerId).FirstOrDefault()?
            .EmployeeEmployers.Select(ee => ee.Employee)
            .ToList();
        return employees is null ? new List<Employee>() : _mapper.Map<List<Model.Employee>, List<Dto.Employee>>(employees);
    }
}