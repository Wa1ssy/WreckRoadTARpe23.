using Microsoft.AspNetCore.Identity;
using WreckRoad.Core.Domain;
using WreckRoad.Core.Dto.AccountsDtos;
using WreckRoad.Core.ServiceInterface;

namespace WreckRoad.ApplicationServices.Services
{
    public class AccountsServices : IAccountsServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsServices
            (
                UserManager<ApplicationUser> userManager,
                SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> Register(ApplicationUserDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.USerName,
                Email = dto.Email,
                City = dto.City,
            };
            var result = await _userManager.CreateAsync( user, dto.Password );
            if ( result.Succeeded )
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            }
            return user;
        }

        public async Task<ApplicationUser> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync( userId );
            if ( user == null )
            {
                string errorMessage = $"User with id {userId} is not valid.";
            }
            var result = await _userManager.ConfirmEmailAsync(user, token );
            return user;
        }
        public async Task<ApplicationUser> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            return user;
        }
    }

}
