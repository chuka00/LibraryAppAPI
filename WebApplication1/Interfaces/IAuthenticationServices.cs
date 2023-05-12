using Microsoft.AspNetCore.Identity;
using WebApplication1.Dtos;

namespace WebApplication1.Interfaces
{
    public interface IAuthenticationServices
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<string> CreateToken();

    }
}
