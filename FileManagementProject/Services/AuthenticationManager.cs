using AutoMapper;
using FileManagementProject.Entities.Dtos;
using FileManagementProject.Entities.Models;
using FileManagementProject.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace FileManagementProject.Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationManager(ILoggerService logger,
            IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            var result = await _userManager
                .CreateAsync(user, userForRegistrationDto.Password);

            if(result.Succeeded)
                await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
            return result;
        }
    }
}
