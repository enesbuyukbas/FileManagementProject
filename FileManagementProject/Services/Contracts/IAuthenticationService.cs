using FileManagementProject.Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace FileManagementProject.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistrationDto);
        Task<bool> ValidateUser(UserForAuthenticationDto userforAutDto);
        Task<string> CreateToken();
    }
}
