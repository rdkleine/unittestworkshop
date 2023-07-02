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

    public void UpdateEmployee(int employeeId, Employee employeeDto)
    {
        var employeeRecord = _dbContext.Employees.Where(e => e.EmployeeId == employeeId).First();
        _mapper.Map<Dto.Employee, Model.Employee>(employeeDto, employeeRecord);
        var result = _dbContext.SaveChanges();
    }

    public Employee? GetEmployee(int idEmployee)
    {
        var employee = _dbContext.Employees.Where(e => e.EmployeeId == idEmployee).FirstOrDefault();
        return employee == null ? null : _mapper.Map<Model.Employee, Dto.Employee>(employee);
    }

    public List<Employee> GetEmployeeList()
    {
        var employees = _dbContext.Employees.ToList();
        return _mapper.Map<List<Model.Employee>, List<Dto.Employee>>(employees);
    }

    public void DeleteEmployee(int idEmployee)
    {
        var employee = _dbContext.Employees.Where(e => e.EmployeeId == idEmployee).First();
        _dbContext.Employees.Remove(employee);
        _dbContext.SaveChanges();
    }
}