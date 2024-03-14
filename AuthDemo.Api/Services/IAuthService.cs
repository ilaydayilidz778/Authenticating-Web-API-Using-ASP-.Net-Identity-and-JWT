using AuthDemo.Api.Models;

namespace AuthDemo.Api.Services
{
    public interface IAuthService
    {
        string GenerateTokenString(LoginUser user);
        Task<bool> LoginAsync(LoginUser user);
        Task<bool> RegisterUserAsync(LoginUser user);
    }
}