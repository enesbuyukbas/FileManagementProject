using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;

namespace FileManagementProject.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(bool trackChanges);
        Task<Employee> GetOneEmployeeByIdAsync (int id, bool trackChanges);
        Employee GetOneEmployeeWithDepartment (int id, bool trackChanges);
        Task<Employee> CreateOneEmployeeAsync (Employee employee);
        Task UpdateOneEmployeeAsync (int id, EmployeeDtoForUpdate employeeDto, bool trackChanges);
        Task DeleteOneEmployeeAsync (int id, bool trackChanges);
    }
}
