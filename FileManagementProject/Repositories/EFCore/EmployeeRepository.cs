using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FileManagementProject.Repositories.EFCore
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneEmployeeAsync(Employee employee) => Create(employee);

        public void DeleteOneEmployeeAsync(Employee employee) => Delete(employee);

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync(bool trackChanges) =>
            await FindAll(trackChanges)
            .ToListAsync();


        public async Task<Employee> GetOneEmployeeByIdAsync(int id, bool trackChanges) =>
            await FindByCondition(b => b.EmployeeId.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public Employee GetOneEmployeeWithDepartment(int id, bool trackChanges)
        {
            var employee =  _context.Employees
                    .Include(e => e.Department) 
                    .Where(e => e.EmployeeId.Equals(id))
                    .SingleOrDefault();

            if (employee is null)
                return null;

            return employee;
        }

        public void UpdateOneEmployeeAsync(Employee employee) => Update(employee);

    }
}
