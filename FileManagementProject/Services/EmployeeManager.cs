using AutoMapper;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Exceptions;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;

namespace FileManagementProject.Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public EmployeeManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<Employee> CreateOneEmployeeAsync(Employee employee)
        {

            _manager.Employee.CreateOneEmployeeAsync(employee);
            await _manager.SaveAsync();
            return employee;
        }

        public async Task DeleteOneEmployeeAsync(int id, bool trackChanges)
        {
            // check entity
            var entity = await GetOneEmployeeByIdAndCheckExists(id, trackChanges);
            _manager.Employee.DeleteOneEmployeeAsync(entity);
            await _manager.SaveAsync();
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync(bool trackChanges)
        {
            var employees = await _manager.Employee.GetAllEmployeesAsync(trackChanges);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);

        }

        public async Task<Employee> GetOneEmployeeByIdAsync(int id, bool trackChanges)
        {
            var entity = await GetOneEmployeeByIdAndCheckExists(id, trackChanges);
            return entity;
        }

        public Employee GetOneEmployeeWithDepartment(int id, bool trackChanges)
        {
            var employee = _manager.Employee.GetOneEmployeeWithDepartment(id, trackChanges);
            return employee;

        }

        public async Task UpdateOneEmployeeAsync(int id, EmployeeDtoForUpdate employeeDto, bool trackChanges)
        {
            //check entity
            var entity = await GetOneEmployeeByIdAndCheckExists(id, trackChanges);

            //Mapping
            //entity.EmployeeFirstName = employee.EmployeeFirstName;
            //entity.EmployeeLastName = employee.EmployeeLastName;
            //entity.DepartmentId = employee.DepartmentId;

            //AutoMapping
            entity = _mapper.Map<Employee>(employeeDto);

            _manager.Employee.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Employee> GetOneEmployeeByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.Employee.GetOneEmployeeByIdAsync(id, trackChanges);
            if (entity is null)
                throw new EmployeeNotFoundException(id);

            return entity;
        }

    }
}
