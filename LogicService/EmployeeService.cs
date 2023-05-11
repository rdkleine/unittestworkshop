using LogicService.Dto;

namespace LogicService;
public interface IEmployeeService
{
    public List<Employee> GetEmployeeList();
    public Employee? GetEmployee(int employeeId);
    public void SaveEmployee(Employee employee);
}

public class EmployeeService : IEmployeeService
{
    private readonly IDataService _dataService;

    public EmployeeService(IDataService dataService)
    {
        _dataService = dataService;
    }

    public List<Employee> GetEmployeeList()
    {
        // Ophalen lijst van employees
        return _dataService.GetEmployeeList();
    }

    public Employee? GetEmployee(int employeeId)
    {
        // Ophalen employee
        return _dataService.GetEmployee(employeeId);
    }

    public void SaveEmployee(Employee employee)
    {
        // oplaan employee gegevens
        // opslaan employee adressen
        // Mail sturen als er iets is gewijzigd
        _dataService.AddEmployee(employee);
    }
}