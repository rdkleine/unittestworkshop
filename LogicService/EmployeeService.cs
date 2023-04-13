using LogicService.Dto;

namespace LogicService;
public interface IEmployeeService
{
    public List<Employee> GetEmployees();
    public Employee GetEmployee(int employeeId);
    public void SaveEmployee(Employee employee);
}

public class EmployeeService : IEmployeeService
{
    //todo automapper
    public List<Employee> GetEmployees()
    {
        return new List<Employee>();
    }

    public Employee GetEmployee(int employeeId)
    {
        // Ophalen employee
        return new Employee();
    }

    public void SaveEmployee(Employee employee)
    {
        // oplaan employee gegevens
        // opslaan employee adressen
        // Mail sturen als er iets is gewijzigd
    }
}