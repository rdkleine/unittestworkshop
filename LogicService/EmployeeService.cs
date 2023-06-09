using LogicService.Dto;

namespace LogicService;
public interface IEmployeeService
{
    public List<Employee> GetList();
    public Employee? Get(int employeeId);
    public void Upsert(Employee employee);
    public void Delete(int employeeId);
}

public class EmployeeService : IEmployeeService
{
    private readonly IDataService _dataService;

    public EmployeeService(IDataService dataService)
    {
        _dataService = dataService;
    }

    public List<Employee> GetList()
    {
        // Ophalen lijst van employees
        return _dataService.GetEmployeeList();
    }

    public Employee? Get(int employeeId)
    {
        // Ophalen employee
        return _dataService.GetEmployee(employeeId);
    }

    public void Upsert(Employee employee)
    {
        // oplaan employee gegevens
        // opslaan employee adressen
        // Mail sturen als er iets is gewijzigd
        _dataService.UpsertEmployee(employee);
    }

    public void Delete(int employeeId)
    {
        throw new NotImplementedException();
    }
}