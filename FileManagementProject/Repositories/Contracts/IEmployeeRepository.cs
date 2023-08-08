using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.RequestFeatures;

namespace FileManagementProject.Repositories.Contracts
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync(EmployeeParameters employeeParameters, bool trackChanges);
        Task<Employee> GetOneEmployeeByIdAsync(int id, bool trackChanges);
        Employee GetOneEmployeeWithDepartment(int id, bool trackChanges);
        void CreateOneEmployeeAsync(Employee employee);
        void UpdateOneEmployeeAsync(Employee employee);
        void DeleteOneEmployeeAsync(Employee employee);
    }
}
