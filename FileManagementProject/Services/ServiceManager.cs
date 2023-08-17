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
        private readonly Lazy<IRedisService> _redisService;

        public ServiceManager(IRepositoryManager repositoryManager,
            ILoggerService logger,
            IMapper mapper,
            IConfiguration configuration,
            UserManager<User> userManager,
            IRedisService redisService)    
        {
            _employeeService = new Lazy<IEmployeeService>(() => 
            new EmployeeManager(repositoryManager, logger, mapper, redisService));

            _departmentService = new Lazy<IDepartmentService>(() => 
            new DepartmentManager(repositoryManager, logger, mapper));

            _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationManager(logger, mapper, userManager, configuration));

            _redisService = new Lazy<IRedisService>();
        }
        public IEmployeeService EmployeeService => _employeeService.Value;

        public IDepartmentService DepartmentService => _departmentService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IRedisService RedisService => _redisService.Value;
    }

}
