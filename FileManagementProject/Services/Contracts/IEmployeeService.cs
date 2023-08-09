using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.RequestFeatures;

namespace FileManagementProject.Services.Contracts
{
    public interface IEmployeeService
    {
        Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetAllEmployeesAsync(EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetOneEmployeeByIdAsync (int id, bool trackChanges);
        Employee GetOneEmployeeWithDepartment (int id, bool trackChanges);
        Task<Employee> CreateOneEmployeeAsync (EmployeeDtoForCreate employeeDto);
        Task UpdateOneEmployeeAsync (int id, EmployeeDtoForUpdate employeeDto, bool trackChanges);
        Task DeleteOneEmployeeAsync (int id, bool trackChanges);
    }
}
