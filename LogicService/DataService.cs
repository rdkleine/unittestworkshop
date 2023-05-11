using LogicService.Dto;

namespace LogicService;

public interface IDataService
{
    public void AddEmployee(Employee employee);
    public Employee? GetEmployee(int idEmployee);
    public List<Employee> GetEmployeeList();
}

public class DataService : IDataService
{
    private readonly IStoreService _storeService;
    public DataService(IStoreService storeService)
    {
        _storeService = storeService;
    }

    public void AddEmployee(Employee employee)
    {
        var list = GetEmployeeList();
        list.Add(employee);
        _storeService.AddItems(list);
    }

    public Employee? GetEmployee(int idEmployee)
    {
        var list = GetEmployeeList();
        return list.Where(e => e.EmployeeId == idEmployee).FirstOrDefault();
    }

    public List<Employee> GetEmployeeList()
    {
        return _storeService.GetItems<Employee>() ?? new List<Employee>();
    }
}