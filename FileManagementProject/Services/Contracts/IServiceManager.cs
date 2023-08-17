﻿namespace FileManagementProject.Services.Contracts
{
    public interface IServiceManager
    {
        IEmployeeService EmployeeService { get; }
        IDepartmentService DepartmentService { get; }
        IAuthenticationService AuthenticationService { get; }
        IRedisService RedisService { get; }
    }
}
