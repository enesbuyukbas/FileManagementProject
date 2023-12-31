﻿using AutoMapper;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Exceptions;
using FileManagementProject.Entities.Models;
using FileManagementProject.Entities.RequestFeatures;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;

namespace FileManagementProject.Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IRedisService _redisService;
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public EmployeeManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper, IRedisService redisService)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _redisService = redisService;
        }


        public async Task<Employee> CreateOneEmployeeAsync(EmployeeDtoForCreate employeeDto)
        {

            var entity = _mapper.Map<Employee>(employeeDto);

            _manager.Employee.CreateOneEmployeeAsync(entity);
    
            await _manager.SaveAsync();
            return entity;
        }

        public async Task DeleteOneEmployeeAsync(int id, bool trackChanges)
        {
            // check entity
            var entity = await GetOneEmployeeByIdAndCheckExists(id, trackChanges);
            _manager.Employee.DeleteOneEmployeeAsync(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetAllEmployeesAsync(EmployeeParameters employeeParameters, bool trackChanges)
        {
            //if (!employeeParameters.ValidDepartmentId)
            //    throw new DepartmentIsNullBadRequestException(); //artık null değere görede işlem alıyoruz bu kod şuanlık işlevsiz durumda.

            var employeesWithMetaData = await _manager
                .Employee
                .GetAllEmployeesAsync(employeeParameters, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);
            return (employeesDto, employeesWithMetaData.MetaData);
        }

        public async Task<Employee> GetOneEmployeeByIdAsync(int id, bool trackChanges)
        {
            var cacheKey = $"Employee_{id}";
            var cachedEmployee = await _redisService.GetCachedDataAsync<Employee>(cacheKey);
            TimeSpan timeToLive = TimeSpan.FromSeconds(60);

            if (cachedEmployee != null)
            {
                return cachedEmployee;
            }

            var employee = await GetOneEmployeeByIdAndCheckExists(id, trackChanges);

            if (employee != null)
            {
                await _redisService.SetCachedDataAsync(cacheKey, employee, timeToLive);
            }

            return employee;
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
