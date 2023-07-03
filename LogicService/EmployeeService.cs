using System.Transactions;
using LogicService.Dto;

namespace LogicService;
public interface IEmployeeService
{
    //public List<Employee> SearchEmployees(..)
    public List<Employee> GetList();
    public Employee? Get(int employeeId);
    public void Upsert(Employee employee);
    public void Delete(int employeeId);
}

public class EmployeeService : IEmployeeService
{
    private readonly IDataService _dataService;
    //private readonly IEmailService _emailService;

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
        // Use scope for transaction
        // using var scope = new TransactionScope();
        
        // Add validation
        _dataService.UpdateEmployee(employee.EmployeeId, employee);

        // Send mail when data updated succesfully

        // scope.Complete();

        // Return result
    }

    public void Delete(int employeeId)
    {
        _dataService.DeleteEmployee(employeeId);
    }
}