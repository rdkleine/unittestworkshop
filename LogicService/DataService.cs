using LogicService.Dto;
using AutoMapper;
namespace LogicService;

public interface IDataService
{
    public void UpsertEmployee(Employee employee);
    public void DeleteEmployee(int employeeId);
    public Employee? GetEmployee(int idEmployee);
    public List<Employee> GetEmployeeList();
}

public class DataService : IDataService
{
    private readonly IStoreService _storeService;
    private readonly IMapper _mapper;
    private readonly DatabaseContext _dbContext;
    public DataService(IStoreService storeService, DatabaseContext dbContext, IMapper mapper)
    {
        _storeService = storeService;
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void UpsertEmployee(Employee employee)
    {
        _dbContext.Employees.Add(_mapper.Map<Dto.Employee, Model.Employee>(employee));
        _dbContext.SaveChanges();
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