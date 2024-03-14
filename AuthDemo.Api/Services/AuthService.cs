using AuthDemo.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace AuthDemo.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<bool> RegisterUserAsync(LoginUser user)
        {
            var identityUser = new IdentityUser
            {
                UserName = user.Username,
                Email = user.Username
            };

            var result = await _userManager.CreateAsync(identityUser, user.Password);
            return result.Succeeded;
        }
        public async Task<bool> LoginAsync(LoginUser user)
        {
            var identityUser = await _userManager.FindByEmailAsync(user.Username);
            if(identityUser is null)
            {
                return false;
            }

            var result = await _userManager.CheckPasswordAsync(identityUser, user.Password);
            return result;
        }

        public string GenerateTokenString(LoginUser user)
        {
           
        }
    }
}
