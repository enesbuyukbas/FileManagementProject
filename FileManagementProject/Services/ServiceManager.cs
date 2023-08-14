using AutoMapper;
using FileManagementProject.Entities.Models;
using FileManagementProject.Repositories.Contracts;
using FileManagementProject.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace FileManagementProject.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IDepartmentService> _departmentService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager) 
        {
            _employeeService = new Lazy<IEmployeeService>(() => 
            new EmployeeManager(repositoryManager, logger, mapper));

            _departmentService = new Lazy<IDepartmentService>(() => 
            new DepartmentManager(repositoryManager, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration));
        }
        public IEmployeeService EmployeeService => _employeeService.Value;

        public IDepartmentService DepartmentService => _departmentService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }

}
