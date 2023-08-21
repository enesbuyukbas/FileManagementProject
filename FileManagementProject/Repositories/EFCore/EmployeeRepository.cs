using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.RequestFeatures;
using FileManagementProject.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace FileManagementProject.Repositories.EFCore
{
    public sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneEmployeeAsync(Employee employee) => Create(employee);

        public void DeleteOneEmployeeAsync(Employee employee) => Delete(employee);

        public async Task<PagedList<Employee>> GetAllEmployeesAsync(EmployeeParameters employeeParameters,
            bool trackChanges)
        {

            var query = FindAll(trackChanges)
            .OrderBy(e => e.EmployeeId);

            if(employeeParameters.requestDepartmentId != null)
            {
                query = (IOrderedQueryable<Employee>)query.FilterEmployee(employeeParameters.requestDepartmentId);
            }

            var employees = await query.ToListAsync();

            return PagedList<Employee>.ToPagedList(
                employees,
                employeeParameters.PageNumber,
                employeeParameters.PageSize
            );
        }
            

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
